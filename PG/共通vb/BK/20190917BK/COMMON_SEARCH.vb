Option Strict Off
Option Explicit On

Module COMMON_SEARECH


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPBMNCD_SEARCH
    '   �T�v�F  ����R�[�h����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ' === 20060828 === UPDATE S - ACE)Sejima
    'D    Public Function DSPBMNCD_SEARCH(ByVal pin_strBMNCD As String, _
    ''D                                    ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA) As Integer
    ' === 20060828 === UPDATE ��
    Public Function DSPBMNCD_SEARCH(ByVal pin_strBMNCD As String, ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA, Optional ByVal pin_strDate As String = "", Optional ByVal pin_datkb As String = "") As Short
        ' === 20060828 === UPDATE E

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPBMNCD_SEARCH

            DSPBMNCD_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from BMNMTA "
            strSQL = strSQL & "  Where BMNCD = '" & pin_strBMNCD & "' "
            ' === 20060828 === INSERT S - ACE)Sejima
            If Trim(pin_strDate) <> "" Then
                strSQL = strSQL & "  and STTTKDT <= '" & CF_Ora_Date(pin_strDate) & "' "
                strSQL = strSQL & "  and ENDTKDT >= '" & CF_Ora_Date(pin_strDate) & "' "
            End If
            ' === 20060828 === INSERT E
            '2019.04.17 add start
            If Trim(pin_datkb) <> "" Then
                strSQL = strSQL & "  and DATKB = '" & pin_datkb & "'"
            End If
            '2019.04.17 add end

            'DB�A�N�Z�X
            '2019/03/15 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim     dt As DataTable = DB_GetTable(strSQL)
            '2019/03/15 CHG E N D

            '2019/03/15 CHG START
            'If CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/15 CHG E N D
                '�擾�f�[�^�Ȃ�
                DSPBMNCD_SEARCH = 1
                Exit Function
            End If

            '2019/03/15 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_BMNMTA
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '����R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .STTTKDT = CF_Ora_GetDyn(Usr_Ody, "STTTKDT", "") '�K�p�J�n��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ENDTKDT = CF_Ora_GetDyn(Usr_Ody, "ENDTKDT", "") '�K�p�I����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '���喼��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNZP = CF_Ora_GetDyn(Usr_Ody, "BMNZP", "") '�X�֔ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNADA = CF_Ora_GetDyn(Usr_Ody, "BMNADA", "") '�Z���P
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNADB = CF_Ora_GetDyn(Usr_Ody, "BMNADB", "") '�Z���Q
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNADC = CF_Ora_GetDyn(Usr_Ody, "BMNADC", "") '�Z���R
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNTL = CF_Ora_GetDyn(Usr_Ody, "BMNTL", "") '�d�b�ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNFX = CF_Ora_GetDyn(Usr_Ody, "BMNFX", "") 'FAX�ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNURL = CF_Ora_GetDyn(Usr_Ody, "BMNURL", "") 'URL
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNCDUP = CF_Ora_GetDyn(Usr_Ody, "BMNCDUP", "") '��ʕ���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNLV = CF_Ora_GetDyn(Usr_Ody, "BMNLV", 0) '�K�w
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZMJGYCD = CF_Ora_GetDyn(Usr_Ody, "ZMJGYCD", "") '��v���Ə��R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZMCD = CF_Ora_GetDyn(Usr_Ody, "ZMCD", "") '��v�敪�R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "") '��v����R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '�c�Ə��R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '�n��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .HTANCD = CF_Ora_GetDyn(Usr_Ody, "HTANCD", "") '�����S���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .STANCD = CF_Ora_GetDyn(Usr_Ody, "STANCD", "") '���Y�S���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNPRNM = CF_Ora_GetDyn(Usr_Ody, "BMNPRNM", "") '�󎚗p����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            '    End With
            'End If
            With pot_DB_BMNMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNCD = DB_NullReplace(dt.Rows(0)("BMNCD"), "") '����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .STTTKDT = DB_NullReplace(dt.Rows(0)("STTTKDT"), "") '�K�p�J�n��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ENDTKDT = DB_NullReplace(dt.Rows(0)("ENDTKDT"), "") '�K�p�I����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNNM = DB_NullReplace(dt.Rows(0)("BMNNM"), "") '���喼��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNZP = DB_NullReplace(dt.Rows(0)("BMNZP"), "") '�X�֔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNADA = DB_NullReplace(dt.Rows(0)("BMNADA"), "") '�Z���P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNADB = DB_NullReplace(dt.Rows(0)("BMNADB"), "") '�Z���Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNADC = DB_NullReplace(dt.Rows(0)("BMNADC"), "") '�Z���R
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNTL = DB_NullReplace(dt.Rows(0)("BMNTL"), "") '�d�b�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNFX = DB_NullReplace(dt.Rows(0)("BMNFX"), "") 'FAX�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNURL = DB_NullReplace(dt.Rows(0)("BMNURL"), "") 'URL
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNCDUP = DB_NullReplace(dt.Rows(0)("BMNCDUP"), "") '��ʕ���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNLV = DB_NullReplace(dt.Rows(0)("BMNLV"), 0) '�K�w
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZMJGYCD = DB_NullReplace(dt.Rows(0)("ZMJGYCD"), "") '��v���Ə��R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZMCD = DB_NullReplace(dt.Rows(0)("ZMCD"), "") '��v�敪�R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "") '��v����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .EIGYOCD = DB_NullReplace(dt.Rows(0)("EIGYOCD"), "") '�c�Ə��R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TIKKB = DB_NullReplace(dt.Rows(0)("TIKKB"), "") '�n��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HTANCD = DB_NullReplace(dt.Rows(0)("HTANCD"), "") '�����S���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .STANCD = DB_NullReplace(dt.Rows(0)("STANCD"), "") '���Y�S���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNPRNM = DB_NullReplace(dt.Rows(0)("BMNPRNM"), "") '�󎚗p����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
            End With
            '2019/03/15 CHG E N D

            ''�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)

            DSPBMNCD_SEARCH = 0

            '            Exit Function

            'ERR_DSPBMNCD_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPBMNCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' === 20061215 === INSERT S - ACE)Nagasawa �c�Ə��R�[�h���c�ƕ�����擾
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPEIGYOCD_SEARCH
    '   �T�v�F  �c�Ə��R�[�h��蕔��}�X�^�̌���
    '   �����F�@pin_strEIGYOCD : �c�Ə��R�[�h
    '         �@pot_DB_BMNMTA  : �擾������
    '           pin_strDate    : ����i�ȗ����ꂽ�ꍇ�͉^�p���j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPEIGYOCD_SEARCH(ByVal pin_strEIGYOCD As String, ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA, Optional ByVal pin_strDate As String = "") As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strDate As String
            ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPEIGYOCD_SEARCH

            DSPEIGYOCD_SEARCH = 9

            '����̕ҏW
            strDate = ""
            If Trim(pin_strDate) = "" Then
                strDate = GV_UNYDate
            Else
                strDate = pin_strDate
            End If

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from BMNMTA "
            strSQL = strSQL & "  Where EIGYOCD = '" & CF_Ora_String(pin_strEIGYOCD, 1) & "' "
            If Trim(strDate) <> "" Then
                strSQL = strSQL & "  and STTTKDT <= '" & CF_Ora_Date(strDate) & "' "
                strSQL = strSQL & "  and ENDTKDT >= '" & CF_Ora_Date(strDate) & "' "
            End If


            '20190319 CHG START 
            ''DB�A�N�Z�X
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)

            'If CF_Ora_EOF(Usr_Ody) = True Then
            '    '�擾�f�[�^�Ȃ�
            '    DSPEIGYOCD_SEARCH = 1
            '    Exit Function
            'End If
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPEIGYOCD_SEARCH = 1
                Exit Function
            End If

            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_BMNMTA
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '����R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .STTTKDT = CF_Ora_GetDyn(Usr_Ody, "STTTKDT", "") '�K�p�J�n��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ENDTKDT = CF_Ora_GetDyn(Usr_Ody, "ENDTKDT", "") '�K�p�I����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '���喼��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNZP = CF_Ora_GetDyn(Usr_Ody, "BMNZP", "") '�X�֔ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNADA = CF_Ora_GetDyn(Usr_Ody, "BMNADA", "") '�Z���P
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNADB = CF_Ora_GetDyn(Usr_Ody, "BMNADB", "") '�Z���Q
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNADC = CF_Ora_GetDyn(Usr_Ody, "BMNADC", "") '�Z���R
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNTL = CF_Ora_GetDyn(Usr_Ody, "BMNTL", "") '�d�b�ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNFX = CF_Ora_GetDyn(Usr_Ody, "BMNFX", "") 'FAX�ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNURL = CF_Ora_GetDyn(Usr_Ody, "BMNURL", "") 'URL
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNCDUP = CF_Ora_GetDyn(Usr_Ody, "BMNCDUP", "") '��ʕ���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNLV = CF_Ora_GetDyn(Usr_Ody, "BMNLV", 0) '�K�w
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZMJGYCD = CF_Ora_GetDyn(Usr_Ody, "ZMJGYCD", "") '��v���Ə��R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZMCD = CF_Ora_GetDyn(Usr_Ody, "ZMCD", "") '��v�敪�R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "") '��v����R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '�c�Ə��R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '�n��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .HTANCD = CF_Ora_GetDyn(Usr_Ody, "HTANCD", "") '�����S���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .STANCD = CF_Ora_GetDyn(Usr_Ody, "STANCD", "") '���Y�S���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BMNPRNM = CF_Ora_GetDyn(Usr_Ody, "BMNPRNM", "") '�󎚗p����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            '    End With
            'End If

            ''�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)

            With pot_DB_BMNMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNCD = DB_NullReplace(dt.Rows(0)("BMNCD"), "") '����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .STTTKDT = DB_NullReplace(dt.Rows(0)("STTTKDT"), "") '�K�p�J�n��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ENDTKDT = DB_NullReplace(dt.Rows(0)("ENDTKDT"), "") '�K�p�I����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNNM = DB_NullReplace(dt.Rows(0)("BMNNM"), "") '���喼��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNZP = DB_NullReplace(dt.Rows(0)("BMNZP"), "") '�X�֔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNADA = DB_NullReplace(dt.Rows(0)("BMNADA"), "") '�Z���P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNADB = DB_NullReplace(dt.Rows(0)("BMNADB"), "") '�Z���Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNADC = DB_NullReplace(dt.Rows(0)("BMNADC"), "") '�Z���R
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNTL = DB_NullReplace(dt.Rows(0)("BMNTL"), "") '�d�b�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNFX = DB_NullReplace(dt.Rows(0)("BMNFX"), "") 'FAX�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNURL = DB_NullReplace(dt.Rows(0)("BMNURL"), "") 'URL
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNCDUP = DB_NullReplace(dt.Rows(0)("BMNCDUP"), "") '��ʕ���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNLV = DB_NullReplace(dt.Rows(0)("BMNLV"), 0) '�K�w
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZMJGYCD = DB_NullReplace(dt.Rows(0)("ZMJGYCD"), "") '��v���Ə��R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZMCD = DB_NullReplace(dt.Rows(0)("ZMCD"), "") '��v�敪�R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "") '��v����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .EIGYOCD = DB_NullReplace(dt.Rows(0)("EIGYOCD"), "") '�c�Ə��R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TIKKB = DB_NullReplace(dt.Rows(0)("TIKKB"), "") '�n��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HTANCD = DB_NullReplace(dt.Rows(0)("HTANCD"), "") '�����S���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .STANCD = DB_NullReplace(dt.Rows(0)("STANCD"), "") '���Y�S���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNPRNM = DB_NullReplace(dt.Rows(0)("BMNPRNM"), "") '�󎚗p����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
            End With
            '20190319 CHG START 

            DSPEIGYOCD_SEARCH = 0

            '            Exit Function

            'ERR_DSPEIGYOCD_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPEIGYOCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function
    ' === 20061215 === INSERT E -


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub DB_CLDMTA_Clear
    '   �T�v�F  �J�����_�}�X�^�\���̃N���A
    '   �����F�@�Ȃ�
    '   �ߒl�F
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_CLDMTA_Clear(ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA)

        Dim Clr_DB_CLDMTA As TYPE_DB_CLDMTA

        'UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_CLDMTA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pot_DB_CLDMTA = Clr_DB_CLDMTA

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCLDDT_SEARCH
    '   �T�v�F  �J�����_�}�X�^����
    '   �����F  pin_strCLDDT  : �����Ώۓ��t
    '           pot_DB_CLDMTA : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH(ByVal pin_strCLDDT As String, ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA) As Short

        Dim li_MsgRtn As Integer

        Try


            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPCLDDT_SEARCH

            DSPCLDDT_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from CLDMTA "
            strSQL = strSQL & "  Where CLDDT = '" & pin_strCLDDT & "' "

            'DB�A�N�Z�X
            '20190322 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '20190322 CHG END

            '20190322 CHG START
            ' CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '20190322 CHG 
                '�擾�f�[�^�Ȃ�
                DSPCLDDT_SEARCH = 1
                Exit Function
            End If

            '20190322 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_CLDMTA
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLDDT = CF_Ora_GetDyn(Usr_Ody, "CLDDT", "") '���t
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLDWKKB = CF_Ora_GetDyn(Usr_Ody, "CLDWKKB", "") '�j��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLDHLKB = CF_Ora_GetDyn(Usr_Ody, "CLDHLKB", "") '�j��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SLSMDD = CF_Ora_GetDyn(Usr_Ody, "SLSMDD", 0) '�c�ƒʎZ����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .PRDKDDD = CF_Ora_GetDyn(Usr_Ody, "PRDKDDD", 0) '���Y�ғ�����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DTBKDDD = CF_Ora_GetDyn(Usr_Ody, "DTBKDDD", 0) '�����ғ�����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLDSMDD = CF_Ora_GetDyn(Usr_Ody, "CLDSMDD", 0) '����ʎZ����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SLDKB = CF_Ora_GetDyn(Usr_Ody, "SLDKB", "") '�c�Ɠ��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BNKKDKB = CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") '��s�ғ��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .PRDKDKB = CF_Ora_GetDyn(Usr_Ody, "PRDKDKB", "") '���Y�ғ��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DTBKDKB = CF_Ora_GetDyn(Usr_Ody, "DTBKDKB", "") '�����ғ��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBA = CF_Ora_GetDyn(Usr_Ody, "ETCKBA", "") '���̑��敪�P
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBB = CF_Ora_GetDyn(Usr_Ody, "ETCKBB", "") '���̑��敪�Q
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBC = CF_Ora_GetDyn(Usr_Ody, "ETCKBC", "") '���̑��敪�R
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBD = CF_Ora_GetDyn(Usr_Ody, "ETCKBD", "") '���̑��敪�S
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBE = CF_Ora_GetDyn(Usr_Ody, "ETCKBE", "") '���̑��敪�T
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBF = CF_Ora_GetDyn(Usr_Ody, "ETCKBF", "") '���̑��敪�U
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBG = CF_Ora_GetDyn(Usr_Ody, "ETCKBG", "") '���̑��敪�V
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBH = CF_Ora_GetDyn(Usr_Ody, "ETCKBH", "") '���̑��敪�W
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBI = CF_Ora_GetDyn(Usr_Ody, "ETCKBI", "") '���̑��敪�X
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ETCKBJ = CF_Ora_GetDyn(Usr_Ody, "ETCKBJ", "") '���̑��敪�P�O
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            '    End With
            'End If

            ''�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)

            With pot_DB_CLDMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDDT = DB_NullReplace(dt.Rows(0)("CLDDT"), "") '���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDWKKB = DB_NullReplace(dt.Rows(0)("CLDWKKB"), "") '�j��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDHLKB = DB_NullReplace(dt.Rows(0)("CLDHLKB"), "") '�j��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SLSMDD = DB_NullReplace(dt.Rows(0)("SLSMDD"), 0) '�c�ƒʎZ����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PRDKDDD = DB_NullReplace(dt.Rows(0)("PRDKDDD"), 0) '���Y�ғ�����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DTBKDDD = DB_NullReplace(dt.Rows(0)("DTBKDDD"), 0) '�����ғ�����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDSMDD = DB_NullReplace(dt.Rows(0)("CLDSMDD"), 0) '����ʎZ����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SLDKB = DB_NullReplace(dt.Rows(0)("SLDKB"), "") '�c�Ɠ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BNKKDKB = DB_NullReplace(dt.Rows(0)("BNKKDKB"), "") '��s�ғ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PRDKDKB = DB_NullReplace(dt.Rows(0)("PRDKDKB"), "") '���Y�ғ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DTBKDKB = DB_NullReplace(dt.Rows(0)("DTBKDKB"), "") '�����ғ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBA = DB_NullReplace(dt.Rows(0)("ETCKBA"), "") '���̑��敪�P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBB = DB_NullReplace(dt.Rows(0)("ETCKBB"), "") '���̑��敪�Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBC = DB_NullReplace(dt.Rows(0)("ETCKBC"), "") '���̑��敪�R
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBD = DB_NullReplace(dt.Rows(0)("ETCKBD"), "") '���̑��敪�S
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBE = DB_NullReplace(dt.Rows(0)("ETCKBE"), "") '���̑��敪�T
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBF = DB_NullReplace(dt.Rows(0)("ETCKBF"), "") '���̑��敪�U
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBG = DB_NullReplace(dt.Rows(0)("ETCKBG"), "") '���̑��敪�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBH = DB_NullReplace(dt.Rows(0)("ETCKBH"), "") '���̑��敪�W
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBI = DB_NullReplace(dt.Rows(0)("ETCKBI"), "") '���̑��敪�X
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ETCKBJ = DB_NullReplace(dt.Rows(0)("ETCKBJ"), "") '���̑��敪�P�O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
            End With
            '20190322 CHG END

            DSPCLDDT_SEARCH = 0

            '            Exit Function

            'ERR_DSPCLDDT_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CHK_CLDDT
    '   �T�v�F  �x���`�F�b�N
    '   �����F  pin_strCLDDT  : �`�F�b�N�Ώۓ��t
    '           pin_strChkKbn : �`�F�b�N�敪(1:�c�Ɠ��`�F�b�N�@2:��s�ғ��`�F�b�N�@3:�����ғ��`�F�b�N�j
    '   �ߒl�F�@0:�ʏ�� 1:�x�� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CHK_CLDDT(ByVal pin_strCLDDT As String, ByVal pin_strChkKbn As String, ByRef pm_All As Cls_All) As Short

        Dim Mst_Inf As TYPE_DB_CLDMTA
        Dim intRet As Short

        '������
        Call DB_CLDMTA_Clear(Mst_Inf)
        CHK_CLDDT = 0

        '�J�����_�}�X�^����
        intRet = DSPCLDDT_SEARCH(pin_strCLDDT, Mst_Inf)
        Select Case intRet
            Case 0
                If Mst_Inf.DATKB = gc_strDATKB_USE Then
                    '���t�`�F�b�N
                    Select Case pin_strChkKbn
                        '�c�Ɠ��`�F�b�N
                        Case "1"
                            If Mst_Inf.SLDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If

                            '��s�ғ��`�F�b�N
                        Case "2"
                            If Mst_Inf.BNKKDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If

                            '�����ғ��`�F�b�N
                        Case "3"
                            If Mst_Inf.DTBKDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If

                        Case Else
                    End Select
                Else
                    CHK_CLDDT = 9
                End If

            Case 1
                CHK_CLDDT = 9

            Case Else
                CHK_CLDDT = 9
        End Select

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCLDDT_SEARCH_KDKB
    '   �T�v�F  �J�����_�}�X�^����(�ғ����̂ݎ擾)
    '   �����F  pin_strCLDDT  : �����Ώۓ��t
    '           pin_strKDKB   : �����ғ��敪("1":�c�Ɠ� "2":��s�ғ��� "3":�����ғ���)
    '           �@�@�@�@�@�@�@�@�@�@�@�@�@�@ "12":�c�Ɠ��E��s�ғ���)
    '           pin_strKEISAN : �v�Z�敪("1":���Z "2":���Z)
    '           pot_strCLDDT  : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH_KDKB(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPCLDDT_SEARCH_KDKB

        DSPCLDDT_SEARCH_KDKB = 9
        pot_strCLDDT = ""

        strSQL = ""
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        Else
            strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
        End If

        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB >= '" & gc_strDATKB_USE & "' "

        If pin_strKEISAN = "1" Then
            strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
        Else
            strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
        End If

        Select Case pin_strKDKB
            '�c�Ɠ�
            Case "1"
                strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "

                '��s�ғ���
            Case "2"
                strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "

                '�����ғ���
            Case "3"
                strSQL = strSQL & "    and DTBKDKB = '" & KDKB_WORK & "' "

                ' === 20070309 === INSERT S - ACE)Nagasawa
                '�c�Ɠ��E��s�ғ���
            Case "12"
                strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "
                strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "
                ' === 20070309 === INSERT E -

        End Select

        'DB�A�N�Z�X
        '2019/03/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/18 CHG E N D

        '2019/03/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/03/18 CHG E N D
            '�擾�f�[�^�Ȃ�
            DSPCLDDT_SEARCH_KDKB = 1
            Exit Function
        Else
            '2019/03/18 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pot_strCLDDT = DB_NullReplace(dt.Rows(0)("GETDATE"), "")
            '2019/03/18 CHG E N D
        End If


        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        DSPCLDDT_SEARCH_KDKB = 0

        Exit Function

ERR_DSPCLDDT_SEARCH_KDKB:


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPKDDT_SEARCH
    '   �T�v�F  �J�����_�}�X�^����(�c�ƒʎZ������茟��)
    '   �����F  pin_strCLDDT  : �����ΏےʎZ���t
    '           pin_strKDKB   : �����ғ��敪("1":�c�Ɠ� "2":��s�ғ��� "3":�����ғ��� "4":���Y�ғ���)
    '           pot_strCLDDT  : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPKDDT_SEARCH(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByRef pot_strCLDDT As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPKDDT_SEARCH

        DSPKDDT_SEARCH = 9
        pot_strCLDDT = ""

        strSQL = ""
        strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "

        Select Case pin_strKDKB
            '�c�Ɠ�
            Case "1", "2"
                strSQL = strSQL & "    and SLSMDD = " & CF_Ora_Number(pin_strCLDDT)

                '�����ғ���
            Case "3"
                strSQL = strSQL & "    and DTBKDDD = " & CF_Ora_Number(pin_strCLDDT)

                '���Y�ғ���
            Case "4"
                strSQL = strSQL & "    and PRDKDDD = " & CF_Ora_Number(pin_strCLDDT)
        End Select

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPKDDT_SEARCH = 1
            Exit Function
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
        End If


        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        DSPKDDT_SEARCH = 0

        Exit Function

ERR_DSPKDDT_SEARCH:


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function AE_CalcDate_Add
    '   �T�v�F  ���t�v�Z����
    '   �����F�@Pio_strDate     :�v�Z�Ώۓ�(�����W���A�܂���yyyy/mm/dd�̌`���j
    '           Pin_intAddDate  :���Z�Ώۓ����i�}�C�i�X�l�͌��Z�j
    '           Pin_strKind     :�c�Ɠ����("1":�c�Ɠ� "2":��s�ғ����@"3":�����ғ��� "4":���Y�ғ���)
    '                            �ȗ����͉c�Ɠ��ɂ��l������
    '   �ߒl�F  0 : ���� 9 : �ُ�
    '   ���l�F�@�o�ח\��������߂�ꍇ�̏C����A���[No.516�ōs����
    '   �@�@�@�@���̓��t�����߂鎞�ɓ��֐����g�p����ꍇ�́A�����C�����K�v�ƂȂ�
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function AE_CalcDate_Add(ByRef Pio_strDate As String, ByVal Pin_intAddDate As Short, Optional ByVal Pin_strKind As String = "0") As Short

        Dim strDate As String
        Dim strDate_W As String
        Dim Mst_Inf_NOW As TYPE_DB_CLDMTA
        Dim curCALCDATE As Decimal
        Dim curKDDATE As Decimal

        AE_CalcDate_Add = 9

        strDate = ""

        '���Z���l�`�F�b�N
        If IsNumeric(Pin_intAddDate) = False Then
            Exit Function
        End If

        '���t�������`�F�b�N
        If IsDate(Pio_strDate) = True Then
#Disable Warning BC40000 ' Type or member is obsolete
            strDate = VB6.Format(Pio_strDate, "yyyymmdd")
#Enable Warning BC40000 ' Type or member is obsolete
        End If

        '���t�l���ɕϊ�
#Disable Warning BC40000 ' Type or member is obsolete
        If IsDate(VB6.Format(Pio_strDate, "@@@@/@@/@@")) = True Then
#Enable Warning BC40000 ' Type or member is obsolete
            strDate = Pio_strDate
        End If

        If Trim(strDate) = "" Then
            Exit Function
        End If

        '�\���̃N���A
        Call DB_CLDMTA_Clear(Mst_Inf_NOW)

        curKDDATE = 0
        Select Case Pin_strKind
            '�c�Ɠ��ɂ��l������
            Case "0"
#Disable Warning BC40000 ' Type or member is obsolete
                strDate = VB6.Format(strDate, "@@@@/@@/@@")
#Enable Warning BC40000 ' Type or member is obsolete
                strDate_W = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, Pin_intAddDate, CDate(strDate)))
                Pio_strDate = strDate_W
                AE_CalcDate_Add = 0

                '�c�Ɠ��A��s�ғ����l��
            Case "1", "2"
                '�J�����_�}�X�^����
                If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                    If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                        If IsNumeric(Mst_Inf_NOW.SLSMDD) = True Then
                            curKDDATE = CDec(Mst_Inf_NOW.SLSMDD)
                        Else
                            Exit Function
                        End If
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                '���t���Z
                curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

                '�����ғ����l��
            Case "3"
                '�J�����_�}�X�^����
                If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                    If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                        If IsNumeric(Mst_Inf_NOW.DTBKDDD) = True Then
                            curKDDATE = CDec(Mst_Inf_NOW.DTBKDDD)

                            '20081111 ADD START RISE)Tanimura  �A���[No.516
                            ' ���Z�Ώۓ������}�C�i�X�̏ꍇ
                            If Pin_intAddDate < 0 Then
                                ' �����ғ��敪 �� �x�� �̏ꍇ
                                If Mst_Inf_NOW.DTBKDKB = KDKB_Holiday Then
                                    ' �Œ�l�l����擾�����l + 1
                                    Pin_intAddDate = Pin_intAddDate + 1
                                End If
                            End If
                            '20081111 ADD END   RISE)Tanimura

                        Else
                            Exit Function
                        End If
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                '���Y�ғ����l��
            Case "4"
                '�J�����_�}�X�^����
                If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                    If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                        If IsNumeric(Mst_Inf_NOW.PRDKDDD) = True Then
                            curKDDATE = CDec(Mst_Inf_NOW.PRDKDDD)
                        Else
                            Exit Function
                        End If
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

        End Select

        '���t���Z
        curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

        If DSPKDDT_SEARCH(CStr(curCALCDATE), Pin_strKind, strDate_W) <> 0 Then
            Exit Function
        End If

        Pio_strDate = strDate_W

        AE_CalcDate_Add = 0

    End Function


    ' === 20070309 === INSERT S - ACE)Nagasawa �����̓��͉ې���̕ύX
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCLDDT_SEARCH_WK
    '   �T�v�F  �J�����_�}�X�^����(�j���v�Z)
    '   �����F  pin_strCLDDT   : �����Ώۓ��t
    '           pin_strCLDWKKB : �j���敪
    '           pin_strKEISAN  : �v�Z�敪("1":���Z "2":���Z)
    '           pot_strCLDDT   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F  �����Ώۓ��t���O�A�܂��͌�̗j���敪�Ŏw�肳�ꂽ�j���ɓ�������t������
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH_WK(ByVal pin_strCLDDT As String, ByVal pin_strCLDWKKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPCLDDT_SEARCH_WK

        DSPCLDDT_SEARCH_WK = 9
        pot_strCLDDT = ""

        strSQL = ""
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        Else
            strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
        End If

        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    And CLDWKKB = '" & CF_Ora_String(pin_strCLDWKKB, 1) & "' "

        If pin_strKEISAN = "1" Then
            strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
        Else
            strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
        End If

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPCLDDT_SEARCH_WK = 1
            Exit Function
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
        End If

        DSPCLDDT_SEARCH_WK = 0

ERR_DSPCLDDT_SEARCH_WK:

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

    End Function
    ' === 20070309 === INSERT E -

    ' �X���b�g��        : ����3�E��ʍ��ڃX���b�g
    ' ���j�b�g��        : MEINMC.F51
    ' �L�q��            : Standard Library
    ' �쐬���t          : 2006/07/13
    ' �g�p�v���O������  : MEIMT51
    '

    Function MEINMC_Check(ByVal MEICDA As Object, ByVal MEINMC As Object, ByVal EX_MEINMC As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short

        'UPGRADE_WARNING: �I�u�W�F�N�g MEINMC_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        MEINMC_Check = 0 '����I���B
        'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMC = " "
        End If
    End Function

    Function MEINMC_Derived(ByVal MEICDA As Object, ByVal MEINMC As Object, ByVal DE_INDEX As Object) As Object

        'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMC = " "
            'UPGRADE_WARNING: �I�u�W�F�N�g MEINMC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            MEINMC = DB_MEIMTA.MEINMC
        End If
        'MEINMC_Derived = MEINMC

    End Function

    Function EXCTBZ_Insert(ByVal pDB_EXCTBZ As TYPE_DB_EXCTBZ) As Boolean

        Try
            Dim sqlStr As String = ""

            With pDB_EXCTBZ

                sqlStr &= " INSERT INTO EXCTBZ "
                sqlStr &= " (CLTID, GYMCD, LCKTM, SEQNO, INTLCD, EXTCD) "
                sqlStr &= " VALUES ('" & .CLTID & "', '" & .GYMCD & "', '" & .LCKTM & "', '" & .SEQNO & "', '" & .INTLCD & "', '" & .EXTCD & "') "
            End With

            DB_Execute(sqlStr)

        Catch ex As Exception
            MsgBox("EXCTBZ_Insert" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")

            Return False
        End Try

        Return True

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPHINCD_SEARCH
    '   �T�v�F  ���i�R�[�h����
    '   �����F  pin_strHINCD  : �����Ώې��i�R�[�h
    '           pot_DB_HINMTA : ��������
    '           pin_strKJNDT  : �����P���K�p���
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
    '    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, _
    ''                                    ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, Optional ByRef pin_strKJNDT As String = "") As Short
        ' === 20060828 === UPDATE E -

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            DSPHINCD_SEARCH = 9

            ' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
            Select Case True
                '����̎w�肪�Ȃ��ꍇ
                Case Trim(pin_strKJNDT) = ""
                    pin_strKJNDT = GV_UNYDate

                    '���t�̌`���œn�����ꍇ
                Case IsDate(pin_strKJNDT)
#Disable Warning BC40000 ' Type or member is obsolete
                    pin_strKJNDT = VB6.Format(pin_strKJNDT, "yyyymmdd")
#Enable Warning BC40000 ' Type or member is obsolete

                Case Else
            End Select
            ' === 20060828 === UPDATE E -

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from HINMTA "
            strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "

            'DB�A�N�Z�X
            '20190318 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '20190318 CHG END

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPHINCD_SEARCH = 1
                Exit Function
            Else

                With pot_DB_HINMTA
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINMSTKB = DB_NullReplace(dt.Rows(0)("HINMSTKB"), "") '�}�X�^�敪�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCD = DB_NullReplace(dt.Rows(0)("HINCD"), "") '���i�R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINNMA = DB_NullReplace(dt.Rows(0)("HINNMA"), "") '�^��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINNMB = DB_NullReplace(dt.Rows(0)("HINNMB"), "") '���i���P
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINNMC = DB_NullReplace(dt.Rows(0)("HINNMC"), "") '���i���Q
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINNK = DB_NullReplace(dt.Rows(0)("HINNK"), "") '���i���J�i
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINNMD = DB_NullReplace(dt.Rows(0)("HINNMD"), "") '�V���[�Y���i���i���p�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINNME = DB_NullReplace(dt.Rows(0)("HINNME"), "") '�V���[�Y���i���i�S�p�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UNTCD = DB_NullReplace(dt.Rows(0)("UNTCD"), "") '�P�ʃR�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .UNTNM = DB_NullReplace(dt.Rows(0)("UNTNM"), "") '�P�ʖ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINKB = DB_NullReplace(dt.Rows(0)("HINKB"), "") '���i�敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINID = DB_NullReplace(dt.Rows(0)("HINID"), "") '���i���
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLAKB = DB_NullReplace(dt.Rows(0)("HINCLAKB"), "") '���ދ敪�P�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLBKB = DB_NullReplace(dt.Rows(0)("HINCLBKB"), "") '���ދ敪�Q�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLCKB = DB_NullReplace(dt.Rows(0)("HINCLCKB"), "") '���ދ敪�R�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLAID = DB_NullReplace(dt.Rows(0)("HINCLAID"), "") '���ރR�[�h�P�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLBID = DB_NullReplace(dt.Rows(0)("HINCLBID"), "") '���ރR�[�h�Q�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLCID = DB_NullReplace(dt.Rows(0)("HINCLCID"), "") '���ރR�[�h�R�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLANM = DB_NullReplace(dt.Rows(0)("HINCLANM"), "") '���ޖ��̂P�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLBNM = DB_NullReplace(dt.Rows(0)("HINCLBNM"), "") '���ޖ��̂Q�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCLCNM = DB_NullReplace(dt.Rows(0)("HINCLCNM"), "") '���ޖ��̂R�i���i�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .DSPKB = DB_NullReplace(dt.Rows(0)("DSPKB"), "") '�����\���敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZAIKB = DB_NullReplace(dt.Rows(0)("ZAIKB"), "") '�݌ɊǗ��敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINZEIKB = DB_NullReplace(dt.Rows(0)("HINZEIKB"), "") '���i����ŋ敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "") '����Ń����N
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0) '����ŗ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINJUNKB = DB_NullReplace(dt.Rows(0)("HINJUNKB"), "") '���ӕ\�o�͋敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MAKCD = DB_NullReplace(dt.Rows(0)("MAKCD"), "") '���[�J�[�R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCMA = DB_NullReplace(dt.Rows(0)("HINCMA"), "") '���i���l�`
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCMB = DB_NullReplace(dt.Rows(0)("HINCMB"), "") '���i���lB
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCMC = DB_NullReplace(dt.Rows(0)("HINCMC"), "") '���i���lC
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCMD = DB_NullReplace(dt.Rows(0)("HINCMD"), "") '���i���lD
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINCME = DB_NullReplace(dt.Rows(0)("HINCME"), "") '���i���l�d
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TEIKATK = DB_NullReplace(dt.Rows(0)("TEIKATK"), 0) '�艿
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZNKURITK = DB_NullReplace(dt.Rows(0)("ZNKURITK"), 0) '�Ŕ��̔��P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZKMURITK = DB_NullReplace(dt.Rows(0)("ZKMURITK"), 0) '�ō��̔��P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZNKSRETK = DB_NullReplace(dt.Rows(0)("ZNKSRETK"), 0) '�Ŕ��d���P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZKMSRETK = DB_NullReplace(dt.Rows(0)("ZKMSRETK"), 0) '�ō��d���P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .GNKTK = DB_NullReplace(dt.Rows(0)("GNKTK"), 0) '�����P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .PLANTK = DB_NullReplace(dt.Rows(0)("PLANTK"), 0) '�v��P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .OLDGNKTK = DB_NullReplace(dt.Rows(0)("OLDGNKTK"), 0) '�������P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .GNKTKDT = DB_NullReplace(dt.Rows(0)("GNKTKDT"), "") '�K�p��(�����P��)
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .OLDPLNTK = DB_NullReplace(dt.Rows(0)("OLDPLNTK"), 0) '���v��P��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .PLNTKDT = DB_NullReplace(dt.Rows(0)("PLNTKDT"), "") '�K�p���i�@�핪��)
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SODUNTSU = DB_NullReplace(dt.Rows(0)("SODUNTSU"), 0) '�����P�ʐ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TEKZAISU = DB_NullReplace(dt.Rows(0)("TEKZAISU"), 0) '�K���݌ɐ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ANZZAISU = DB_NullReplace(dt.Rows(0)("ANZZAISU"), 0) '���S�݌ɐ��i�̔��v��p�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HRTDD = DB_NullReplace(dt.Rows(0)("HRTDD"), "") '�������[�h�^�C��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ORTDD = DB_NullReplace(dt.Rows(0)("ORTDD"), "") '�o�׃��[�h�^�C��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .PRCDD = DB_NullReplace(dt.Rows(0)("PRCDD"), "") '���B���[�h�^�C��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MNFDD = DB_NullReplace(dt.Rows(0)("MNFDD"), "") '�������[�h�^�C��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINSIRCD = DB_NullReplace(dt.Rows(0)("HINSIRCD"), "") '���i�d����R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINSIRRN = DB_NullReplace(dt.Rows(0)("HINSIRRN"), "") '���i�d���於��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TNACM = DB_NullReplace(dt.Rows(0)("TNACM"), "") '�I�ԍ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINNMMKB = DB_NullReplace(dt.Rows(0)("HINNMMKB"), "") '�����ƭ�ٓ��͋敪(���i)
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .JANCD = DB_NullReplace(dt.Rows(0)("JANCD"), "") '�i�`�m�R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINFRNNM = DB_NullReplace(dt.Rows(0)("HINFRNNM"), "") '���i���C�O�\�L
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ZAIRNK = DB_NullReplace(dt.Rows(0)("ZAIRNK"), "") '�݌Ƀ����N
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .GNKCD = DB_NullReplace(dt.Rows(0)("GNKCD"), "") '�����Ǘ��R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MINSODSU = DB_NullReplace(dt.Rows(0)("MINSODSU"), 0) '�ŏ�������
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SODADDSU = DB_NullReplace(dt.Rows(0)("SODADDSU"), 0) '����������
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .JODHIKKB = DB_NullReplace(dt.Rows(0)("JODHIKKB"), "") '�󒍈����敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ORTSTPKB = DB_NullReplace(dt.Rows(0)("ORTSTPKB"), "") '�o�ג�~
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ORTSTPDT = DB_NullReplace(dt.Rows(0)("ORTSTPDT"), "") '�o�ג�~��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ORTKJDT = DB_NullReplace(dt.Rows(0)("ORTKJDT"), "") '�o�ג�~������
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ORTSTYDT = DB_NullReplace(dt.Rows(0)("ORTSTYDT"), "") '�o�׊J�n�\���
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .CTLGKB = DB_NullReplace(dt.Rows(0)("CTLGKB"), "") '�J�^���O�i�Ώ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MLOKB = DB_NullReplace(dt.Rows(0)("MLOKB"), "") '�ʔ̑Ώ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MLOHINID = DB_NullReplace(dt.Rows(0)("MLOHINID"), "") '�ʔ̐��i�h�c
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MLOIDORT = DB_NullReplace(dt.Rows(0)("MLOIDORT"), 0) '�ʔ̈ړ��䗦
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MLOLMTSU = DB_NullReplace(dt.Rows(0)("MLOLMTSU"), "") '�ʔ̈ړ����x��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .PRDENDKB = DB_NullReplace(dt.Rows(0)("PRDENDKB"), "") '���Y�I��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .PRDENDDT = DB_NullReplace(dt.Rows(0)("PRDENDDT"), "") '���Y�I�����t
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SLENDKB = DB_NullReplace(dt.Rows(0)("SLENDKB"), "") '�̔�����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SLENDDT = DB_NullReplace(dt.Rows(0)("SLENDDT"), "") '�̔��������t
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .JODSTPKB = DB_NullReplace(dt.Rows(0)("JODSTPKB"), "") '�󒍒�~
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .JODSTPDT = DB_NullReplace(dt.Rows(0)("JODSTPDT"), "") '�󒍒�~���t
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MNTENDKB = DB_NullReplace(dt.Rows(0)("MNTENDKB"), "") '�ێ�I��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MNTENDDT = DB_NullReplace(dt.Rows(0)("MNTENDDT"), "") '�ێ�I�����t
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ABODT = DB_NullReplace(dt.Rows(0)("ABODT"), "") '�p�~��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ORTKB = DB_NullReplace(dt.Rows(0)("ORTKB"), "") '�o�׋敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SERIKB = DB_NullReplace(dt.Rows(0)("SERIKB"), "") '�V���A���Ǘ��敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MAKNM = DB_NullReplace(dt.Rows(0)("MAKNM"), "") '���[�J�[��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .NXTMDL = DB_NullReplace(dt.Rows(0)("NXTMDL"), "") '��p�@��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .JODSTDT = DB_NullReplace(dt.Rows(0)("JODSTDT"), "") '�󒍊J�n��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .ORTSTDT = DB_NullReplace(dt.Rows(0)("ORTSTDT"), "") '�o�׊J�n��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .KOUZA = DB_NullReplace(dt.Rows(0)("KOUZA"), "") '����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .MDLCL = DB_NullReplace(dt.Rows(0)("MDLCL"), "") '�@�핪��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .OLDMDLCL = DB_NullReplace(dt.Rows(0)("OLDMDLCL"), "") '���@�핪��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINGRP = DB_NullReplace(dt.Rows(0)("HINGRP"), "") '���i�Q
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .SKHINGRP = DB_NullReplace(dt.Rows(0)("SKHINGRP"), "") '�d�ؗp���i�Q
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .OEMKB = DB_NullReplace(dt.Rows(0)("OEMKB"), "") '�n�d�l
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .OEMTOKRN = DB_NullReplace(dt.Rows(0)("OEMTOKRN"), "") '�n�d�l���Ӑ�
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .OPENKB = DB_NullReplace(dt.Rows(0)("OPENKB"), "") '�I�[�v�����i�敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .STRMATKB = DB_NullReplace(dt.Rows(0)("STRMATKB"), "") '�헪�����敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TITNM1 = DB_NullReplace(dt.Rows(0)("TITNM1"), "") '��ڂP
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TITNM2 = DB_NullReplace(dt.Rows(0)("TITNM2"), "") '��ڂQ
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .TITNM3 = DB_NullReplace(dt.Rows(0)("TITNM3"), "") '��ڂR
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .CATSPCNM = DB_NullReplace(dt.Rows(0)("CATSPCNM"), "") '�J�^���O�X�y�b�N
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .HINURLNM = DB_NullReplace(dt.Rows(0)("HINURLNM"), "") '���iURL
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .CHARANM = DB_NullReplace(dt.Rows(0)("CHARANM"), "") '����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .VSNNM = DB_NullReplace(dt.Rows(0)("VSNNM"), "") '�o�[�W����
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .EDIHINSY = DB_NullReplace(dt.Rows(0)("EDIHINSY"), "") 'EDI���i���
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .BTOKB = DB_NullReplace(dt.Rows(0)("BTOKB"), "") 'BTO�敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .KONPOP = DB_NullReplace(dt.Rows(0)("KONPOP"), 0) '����|�C���g
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .LOTSEQNO = DB_NullReplace(dt.Rows(0)("LOTSEQNO"), "") '���b�g�A��
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .KHNKB = DB_NullReplace(dt.Rows(0)("KHNKB"), "") '���{�敪
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j

                    ' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
                    If Trim(.GNKTKDT) <> "" Then
                        If .GNKTKDT > pin_strKJNDT Then
                            .GNKTK = .OLDGNKTK
                            .PLANTK = .OLDPLNTK
                        End If
                    End If
                    ' === 20060828 === UPDATE E -

                    ' === 20061107 === INSERT S - ACE)Nagasawa �@�핪�ޓK�p���Ή�
                    If Trim(.PLNTKDT) <> "" Then
                        If .PLNTKDT > pin_strKJNDT Then
                            .MDLCL = .OLDMDLCL
                        End If
                    End If
                    ' === 20061107 === INSERT E -

                End With

            End If

            DSPHINCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPHINCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPHINCD_SEARCH_B
    '   �T�v�F  ���i�R�[�h�����i���i���i�}�X�^�����킹�Č����j
    '   �����F  pin_strHINCD  : �����Ώې��i�R�[�h
    '           pot_DB_HINMTA : ��������
    '           pin_strKJNDT  : �����P���K�p���
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
    '    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, _
    ''                                      ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, Optional ByVal pin_strKJNDT As String = "") As Short
        ' === 20060828 === UPDATE E -
        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            DSPHINCD_SEARCH_B = 9

            ' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
            If Trim(pin_strKJNDT) = "" Then
                pin_strKJNDT = GV_UNYDate
            End If
            ' === 20060828 === UPDATE E -

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from HINMTA "
            strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "

            'DB�A�N�Z�X
            '2019/03/18 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/18 CHG E N D

            '2019/03/18 CHG START
            'If CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/18 CHG E N D

                '�擾�f�[�^�Ȃ�
                ''�N���[�Y
                'Call CF_Ora_CloseDyn(Usr_Ody)

                '���i���i�}�X�^
                strSQL = ""
                strSQL = strSQL & " Select * "
                strSQL = strSQL & "   from BHNMTA "
                strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "

                'DB�A�N�Z�X
                '2019/03/18 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                dt = Nothing
                dt = DB_GetTable(strSQL)
                '2019/03/18 CHG E N D

                '2019/03/18 CHG START
                'If CF_Ora_EOF(Usr_Ody) = True Then
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    '2019/03/18 CHG E N D
                    '�Y���f�[�^����
                    DSPHINCD_SEARCH_B = 1
                    'GoTo END_DSPHINCD_SEARCH_B
                    Exit Function
                End If
            End If

            With pot_DB_HINMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINMSTKB = DB_NullReplace(dt.Rows(0)("HINMSTKB"), "") '�}�X�^�敪�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCD = DB_NullReplace(dt.Rows(0)("HINCD"), "") '���i�R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNMA = DB_NullReplace(dt.Rows(0)("HINNMA"), "") '�^��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNMB = DB_NullReplace(dt.Rows(0)("HINNMB"), "") '���i���P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNMC = DB_NullReplace(dt.Rows(0)("HINNMC"), "") '���i���Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNK = DB_NullReplace(dt.Rows(0)("HINNK"), "") '���i���J�i
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNMD = DB_NullReplace(dt.Rows(0)("HINNMD"), "") '�V���[�Y���i���i���p�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNME = DB_NullReplace(dt.Rows(0)("HINNME"), "") '�V���[�Y���i���i�S�p�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UNTCD = DB_NullReplace(dt.Rows(0)("UNTCD"), "") '�P�ʃR�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UNTNM = DB_NullReplace(dt.Rows(0)("UNTNM"), "") '�P�ʖ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINKB = DB_NullReplace(dt.Rows(0)("HINKB"), "") '���i�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINID = DB_NullReplace(dt.Rows(0)("HINID"), "") '���i���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLAKB = DB_NullReplace(dt.Rows(0)("HINCLAKB"), "") '���ދ敪�P�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLBKB = DB_NullReplace(dt.Rows(0)("HINCLBKB"), "") '���ދ敪�Q�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLCKB = DB_NullReplace(dt.Rows(0)("HINCLCKB"), "") '���ދ敪�R�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLAID = DB_NullReplace(dt.Rows(0)("HINCLAID"), "") '���ރR�[�h�P�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLBID = DB_NullReplace(dt.Rows(0)("HINCLBID"), "") '���ރR�[�h�Q�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLCID = DB_NullReplace(dt.Rows(0)("HINCLCID"), "") '���ރR�[�h�R�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLANM = DB_NullReplace(dt.Rows(0)("HINCLANM"), "") '���ޖ��̂P�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLBNM = DB_NullReplace(dt.Rows(0)("HINCLBNM"), "") '���ޖ��̂Q�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCLCNM = DB_NullReplace(dt.Rows(0)("HINCLCNM"), "") '���ޖ��̂R�i���i�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DSPKB = DB_NullReplace(dt.Rows(0)("DSPKB"), "") '�����\���敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZAIKB = DB_NullReplace(dt.Rows(0)("ZAIKB"), "") '�݌ɊǗ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINZEIKB = DB_NullReplace(dt.Rows(0)("HINZEIKB"), "") '���i����ŋ敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "") '����Ń����N
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0) '����ŗ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINJUNKB = DB_NullReplace(dt.Rows(0)("HINJUNKB"), "") '���ӕ\�o�͋敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MAKCD = DB_NullReplace(dt.Rows(0)("MAKCD"), "") '���[�J�[�R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCMA = DB_NullReplace(dt.Rows(0)("HINCMA"), "") '���i���l�`
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCMB = DB_NullReplace(dt.Rows(0)("HINCMB"), "") '���i���lB
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCMC = DB_NullReplace(dt.Rows(0)("HINCMC"), "") '���i���lC
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCMD = DB_NullReplace(dt.Rows(0)("HINCMD"), "") '���i���lD
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINCME = DB_NullReplace(dt.Rows(0)("HINCME"), "") '���i���l�d
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TEIKATK = DB_NullReplace(dt.Rows(0)("TEIKATK"), 0) '�艿
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZNKURITK = DB_NullReplace(dt.Rows(0)("ZNKURITK"), 0) '�Ŕ��̔��P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZKMURITK = DB_NullReplace(dt.Rows(0)("ZKMURITK"), 0) '�ō��̔��P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZNKSRETK = DB_NullReplace(dt.Rows(0)("ZNKSRETK"), 0) '�Ŕ��d���P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZKMSRETK = DB_NullReplace(dt.Rows(0)("ZKMSRETK"), 0) '�ō��d���P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .GNKTK = DB_NullReplace(dt.Rows(0)("GNKTK"), 0) '�����P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PLANTK = DB_NullReplace(dt.Rows(0)("PLANTK"), 0) '�v��P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OLDGNKTK = DB_NullReplace(dt.Rows(0)("OLDGNKTK"), 0) '�������P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .GNKTKDT = DB_NullReplace(dt.Rows(0)("GNKTKDT"), "") '�K�p��(�����P��)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OLDPLNTK = DB_NullReplace(dt.Rows(0)("OLDPLNTK"), 0) '���v��P��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PLNTKDT = DB_NullReplace(dt.Rows(0)("PLNTKDT"), "") '�K�p���i�v��P��)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SODUNTSU = DB_NullReplace(dt.Rows(0)("SODUNTSU"), 0) '�����P�ʐ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TEKZAISU = DB_NullReplace(dt.Rows(0)("TEKZAISU"), 0) '�K���݌ɐ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ANZZAISU = DB_NullReplace(dt.Rows(0)("ANZZAISU"), 0) '���S�݌ɐ��i�̔��v��p�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HRTDD = DB_NullReplace(dt.Rows(0)("HRTDD"), "") '�������[�h�^�C��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ORTDD = DB_NullReplace(dt.Rows(0)("ORTDD"), "") '�o�׃��[�h�^�C��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PRCDD = DB_NullReplace(dt.Rows(0)("PRCDD"), "") '���B���[�h�^�C��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MNFDD = DB_NullReplace(dt.Rows(0)("MNFDD"), "") '�������[�h�^�C��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINSIRCD = DB_NullReplace(dt.Rows(0)("HINSIRCD"), "") '���i�d����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINSIRRN = DB_NullReplace(dt.Rows(0)("HINSIRRN"), "") '���i�d���於��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TNACM = DB_NullReplace(dt.Rows(0)("TNACM"), "") '�I�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINNMMKB = DB_NullReplace(dt.Rows(0)("HINNMMKB"), "") '�����ƭ�ٓ��͋敪(���i)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JANCD = DB_NullReplace(dt.Rows(0)("JANCD"), "") '�i�`�m�R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINFRNNM = DB_NullReplace(dt.Rows(0)("HINFRNNM"), "") '���i���C�O�\�L
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZAIRNK = DB_NullReplace(dt.Rows(0)("ZAIRNK"), "") '�݌Ƀ����N
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .GNKCD = DB_NullReplace(dt.Rows(0)("GNKCD"), "") '�����Ǘ��R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MINSODSU = DB_NullReplace(dt.Rows(0)("MINSODSU"), 0) '�ŏ�������
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SODADDSU = DB_NullReplace(dt.Rows(0)("SODADDSU"), 0) '����������
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JODHIKKB = DB_NullReplace(dt.Rows(0)("JODHIKKB"), "") '�󒍈����敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ORTSTPKB = DB_NullReplace(dt.Rows(0)("ORTSTPKB"), "") '�o�ג�~
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ORTSTPDT = DB_NullReplace(dt.Rows(0)("ORTSTPDT"), "") '�o�ג�~��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ORTKJDT = DB_NullReplace(dt.Rows(0)("ORTKJDT"), "") '�o�ג�~������
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ORTSTYDT = DB_NullReplace(dt.Rows(0)("ORTSTYDT"), "") '�o�׊J�n�\���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CTLGKB = DB_NullReplace(dt.Rows(0)("CTLGKB"), "") '�J�^���O�i�Ώ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MLOKB = DB_NullReplace(dt.Rows(0)("MLOKB"), "") '�ʔ̑Ώ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MLOHINID = DB_NullReplace(dt.Rows(0)("MLOHINID"), "") '�ʔ̐��i�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MLOIDORT = DB_NullReplace(dt.Rows(0)("MLOIDORT"), 0) '�ʔ̈ړ��䗦
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MLOLMTSU = DB_NullReplace(dt.Rows(0)("MLOLMTSU"), "") '�ʔ̈ړ����x��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PRDENDKB = DB_NullReplace(dt.Rows(0)("PRDENDKB"), "") '���Y�I��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PRDENDDT = DB_NullReplace(dt.Rows(0)("PRDENDDT"), "") '���Y�I�����t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SLENDKB = DB_NullReplace(dt.Rows(0)("SLENDKB"), "") '�̔�����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SLENDDT = DB_NullReplace(dt.Rows(0)("SLENDDT"), "") '�̔��������t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JODSTPKB = DB_NullReplace(dt.Rows(0)("JODSTPKB"), "") '�󒍒�~
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JODSTPDT = DB_NullReplace(dt.Rows(0)("JODSTPDT"), "") '�󒍒�~���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MNTENDKB = DB_NullReplace(dt.Rows(0)("MNTENDKB"), "") '�ێ�I��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MNTENDDT = DB_NullReplace(dt.Rows(0)("MNTENDDT"), "") '�ێ�I�����t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ABODT = DB_NullReplace(dt.Rows(0)("ABODT"), "") '�p�~��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ORTKB = DB_NullReplace(dt.Rows(0)("ORTKB"), "") '�o�׋敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SERIKB = DB_NullReplace(dt.Rows(0)("SERIKB"), "") '�V���A���Ǘ��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MAKNM = DB_NullReplace(dt.Rows(0)("MAKNM"), "") '���[�J�[��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NXTMDL = DB_NullReplace(dt.Rows(0)("NXTMDL"), "") '��p�@��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JODSTDT = DB_NullReplace(dt.Rows(0)("JODSTDT"), "") '�󒍊J�n��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ORTSTDT = DB_NullReplace(dt.Rows(0)("ORTSTDT"), "") '�o�׊J�n��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KOUZA = DB_NullReplace(dt.Rows(0)("KOUZA"), "") '����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MDLCL = DB_NullReplace(dt.Rows(0)("MDLCL"), "") '�@�핪��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OLDMDLCL = DB_NullReplace(dt.Rows(0)("OLDMDLCL"), "") '���@�핪��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINGRP = DB_NullReplace(dt.Rows(0)("HINGRP"), "") '���i�Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SKHINGRP = DB_NullReplace(dt.Rows(0)("SKHINGRP"), "") '�d�ؗp���i�Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OEMKB = DB_NullReplace(dt.Rows(0)("OEMKB"), "") '�n�d�l
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OEMTOKRN = DB_NullReplace(dt.Rows(0)("OEMTOKRN"), "") '�n�d�l���Ӑ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPENKB = DB_NullReplace(dt.Rows(0)("OPENKB"), "") '�I�[�v�����i�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .STRMATKB = DB_NullReplace(dt.Rows(0)("STRMATKB"), "") '�헪�����敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TITNM1 = DB_NullReplace(dt.Rows(0)("TITNM1"), "") '��ڂP
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TITNM2 = DB_NullReplace(dt.Rows(0)("TITNM2"), "") '��ڂQ
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TITNM3 = DB_NullReplace(dt.Rows(0)("TITNM3"), "") '��ڂR
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CATSPCNM = DB_NullReplace(dt.Rows(0)("CATSPCNM"), "") '�J�^���O�X�y�b�N
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINURLNM = DB_NullReplace(dt.Rows(0)("HINURLNM"), "") '���iURL
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CHARANM = DB_NullReplace(dt.Rows(0)("CHARANM"), "") '����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .VSNNM = DB_NullReplace(dt.Rows(0)("VSNNM"), "") '�o�[�W����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .EDIHINSY = DB_NullReplace(dt.Rows(0)("EDIHINSY"), "") 'EDI���i���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BTOKB = DB_NullReplace(dt.Rows(0)("BTOKB"), "") 'BTO�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KONPOP = DB_NullReplace(dt.Rows(0)("KONPOP"), 0) '����|�C���g
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .LOTSEQNO = DB_NullReplace(dt.Rows(0)("LOTSEQNO"), "") '���b�g�A��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KHNKB = DB_NullReplace(dt.Rows(0)("KHNKB"), "") '���{�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
                ' === 20060828 === UPDATE S - ACE)Nagasawa �����P���K�p���Ή�
                If Trim(.GNKTKDT) <> "" Then
                    If .GNKTKDT > pin_strKJNDT Then
                        .GNKTK = .OLDGNKTK
                        ' === 20080104 === INSERT S - ACE)Nagasawa
                        .PLANTK = .OLDPLNTK
                        ' === 20080104 === INSERT E -
                    End If
                End If
                ' === 20060828 === UPDATE E -

                ' === 20080104 === INSERT S - ACE)Nagasawa
                If Trim(.PLNTKDT) <> "" Then
                    If .PLNTKDT > pin_strKJNDT Then
                        .MDLCL = .OLDMDLCL
                    End If
                End If
                ' === 20080104 === INSERT E -

            End With

            DSPHINCD_SEARCH_B = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPHINCD_SEARCH_B" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    Public Function KNGMTA_SEARCH(ByVal pin_strKNGGRCD As String, ByRef pot_DB_KNGMTA As TYPE_DB_KNGMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody As U_Ody
            'Dim strTGRPCD As String

            'On Error GoTo ERR_KNGMTA_SEARCH

            KNGMTA_SEARCH = 9

            'Call DB_KNGMTA_Clear(pot_DB_KNGMTA)

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from KNGMTA "
            strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "    and KNGGRCD = '" & CF_Ora_Sgl(pin_strKNGGRCD) & "' "

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                KNGMTA_SEARCH = 1
                Exit Function
            End If

            ''DB�A�N�Z�X
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

            'If CF_Ora_EOF(Usr_Ody) = True Then
            '    '�擾�f�[�^�Ȃ�
            '    KNGMTA_SEARCH = 1
            '    GoTo END_KNGMTA_SEARCH
            'End If

            With pot_DB_KNGMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KNGGRCD = DB_NullReplace(dt.Rows(0)("KNGGRCD"), "") '�����O���[�v
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SALTKKB = DB_NullReplace(dt.Rows(0)("SALTKKB"), "") '�̔��P���ύX
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HDNTKKB = DB_NullReplace(dt.Rows(0)("HDNTKKB"), "") '�����P���ύX
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SAPMODKB = DB_NullReplace(dt.Rows(0)("SAPMODKB"), "") '�̔��v��N���v��C��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SAPCSVKB = DB_NullReplace(dt.Rows(0)("SAPCSVKB"), "") '�̔��v��CSV�o��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TRIUPDKB = DB_NullReplace(dt.Rows(0)("TRIUPDKB"), "") '�����}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSUPDKB = DB_NullReplace(dt.Rows(0)("NHSUPDKB"), "") '�[����}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINUPDKB = DB_NullReplace(dt.Rows(0)("HINUPDKB"), "") '���i�}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SIKUPDKB = DB_NullReplace(dt.Rows(0)("SIKUPDKB"), "") '�d�؊֘A�}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TUPUPDKB = DB_NullReplace(dt.Rows(0)("TUPUPDKB"), "") '�C�O�̔��P���}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SUPUPDKB = DB_NullReplace(dt.Rows(0)("SUPUPDKB"), "") '�d���P���}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SBNUPDKB = DB_NullReplace(dt.Rows(0)("SBNUPDKB"), "") '���ԃ}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BMNUPDKB = DB_NullReplace(dt.Rows(0)("BMNUPDKB"), "") '����}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TANUPDKB = DB_NullReplace(dt.Rows(0)("TANUPDKB"), "") '�S���҃}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KNGUPDKB = DB_NullReplace(dt.Rows(0)("KNGUPDKB"), "") '�����}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BNKUPDKB = DB_NullReplace(dt.Rows(0)("BNKUPDKB"), "") '��s�}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SOUUPDKB = DB_NullReplace(dt.Rows(0)("SOUUPDKB"), "") '�q�Ƀ}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MEIUPDKB = DB_NullReplace(dt.Rows(0)("MEIUPDKB"), "") '���̃}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .FIXUPDKB = DB_NullReplace(dt.Rows(0)("FIXUPDKB"), "") '�Œ�l�}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TUKUPDKB = DB_NullReplace(dt.Rows(0)("TUKUPDKB"), "") '���[�g�}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UNTUPDKB = DB_NullReplace(dt.Rows(0)("UNTUPDKB"), "") '�P�ʃ}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLDUPDKB = DB_NullReplace(dt.Rows(0)("CLDUPDKB"), "") '�J�����_�[�}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TAXUPDKB = DB_NullReplace(dt.Rows(0)("TAXUPDKB"), "") '����ŗ��}�X�^�X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TZNUPDKB = DB_NullReplace(dt.Rows(0)("TZNUPDKB"), "") '���Ӑ�c���X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SZNUPDKB = DB_NullReplace(dt.Rows(0)("SZNUPDKB"), "") '�d����c���X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNUPDKB = DB_NullReplace(dt.Rows(0)("JDNUPDKB"), "") '�󒍍X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HDNUPDKB = DB_NullReplace(dt.Rows(0)("HDNUPDKB"), "") '�����X�V
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .YOBKBA = DB_NullReplace(dt.Rows(0)("YOBKBA"), "") '�\���敪A
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .YOBKBB = DB_NullReplace(dt.Rows(0)("YOBKBB"), "") '�\���敪B
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .YOBKBC = DB_NullReplace(dt.Rows(0)("YOBKBC"), "") '�\���敪C
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .YOBKBD = DB_NullReplace(dt.Rows(0)("YOBKBD"), "") '�\���敪D
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .YOBKBE = DB_NullReplace(dt.Rows(0)("YOBKBE"), "") '�\���敪E
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
            End With


            KNGMTA_SEARCH = 0

            'END_KNGMTA_SEARCH:
            '        '�N���[�Y
            '        Call CF_Ora_CloseDyn(Usr_Ody)

            '        Exit Function

            'ERR_KNGMTA_SEARCH:
            '        GoTo END_KNGMTA_SEARCH
        Catch ex As Exception
            li_MsgRtn = MsgBox("KNGMTA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function







    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEIM_SEARCH
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pin_strMEICDA : �R�[�h�P
    '           pot_DB_MEIMTA : ��������
    '           pin_strMEICDB : �R�[�h�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEICDB As Object = Nothing) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_DSPMEIM_SEARCH

        DSPMEIM_SEARCH = 9

        strSQL = ""
        '20190618 DEL START
        'strSQL = strSQL & " Select * "
        'strSQL = strSQL & "   from MEIMTA "
        '20190618 DEL START

        strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If IsNothing(pin_strMEICDB) = False Then
            'UPGRADE_WARNING: �I�u�W�F�N�g pin_strMEICDB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
        End If

        Call GetRowsCommon("MEIMTA", strSQL)
        pot_DB_MEIMTA = DB_MEIMTA

        If DB_MEIMTA.DATKB Is Nothing Then
            DSPMEIM_SEARCH = 1
            Exit Function
        End If
        ''DB�A�N�Z�X
        ''2019/03/14 CHG START
        ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        'Dim dt As DataTable = DB_GetTable(strSQL)
        ''2019/03/14 CHG E N D

        ''2019/03/14 CHG START
        ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
        'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
        '    '2019/03/14 CHG E N D
        '    '�擾�f�[�^�Ȃ�
        '    DSPMEIM_SEARCH = 1
        '    GoTo END_DSPMEIM_SEARCH
        'End If

        '�擾�f�[�^�ޔ�
        ' === 20060920 === UPDATE S - ACE)Sejima
        'D        With pot_DB_MEIMTA
        'D            .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
        'D            .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
        'D            .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
        'D            .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
        'D            .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
        'D            .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
        'D            .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
        'D            .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
        'D            .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
        'D            .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
        'D            .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
        'D            .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
        'D            .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
        'D            .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
        'D            .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
        'D            .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
        'D            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
        'D            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
        'D            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
        'D            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
        'D            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
        'D            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
        'D        End With
        ' === 20060920 === UPDATE ��
        '2019/03/14 CHG START
        'Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
        ''Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
        'Call SetDataCommon("MEIMTA", dt)
        '2019/03/14 CHG E N D
        ' === 20060920 === UPDATE E

        DSPMEIM_SEARCH = 0

END_DSPMEIM_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_DSPMEIM_SEARCH:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEINMA_SEARCH_A1
    '   �T�v�F  ���̃}�X�^����(���̂P�̂����܂������j
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pin_strMEINMA : ���̂P
    '           pot_DB_MEIMTA : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMA_SEARCH_A1(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA, Optional ByRef pin_strMEICDA As Object = Nothing) As Short

        Dim strSQL As String
        Dim strSQLCount As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody
        Dim intIdx As Short

        On Error GoTo ERR_DSPMEINMA_SEARCH_A1

        DSPMEINMA_SEARCH_A1 = 9

        strSQL = ""
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
        'ADD START FKS)INABA 2009/07/17 ****************************************************************************
        '�A���[��FC09071701
        'UPGRADE_WARNING: �I�u�W�F�N�g pin_strMEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(pin_strMEICDA) = True Or Trim(pin_strMEICDA) = "" Then
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g pin_strMEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        End If
        strSQL = strSQL & "   ORDER BY MEICDA "
        'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************

        '�����擾
        strSQLCount = ""
        strSQLCount = strSQLCount & " Select Count(*) as DataCount "
        strSQLCount = strSQLCount & strSQL

        'DB�A�N�Z�X
        '20190325 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)

        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)

        ''�N���[�Y
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)

        'If intData = 0 Then
        '	'�擾�f�[�^�Ȃ�
        '	DSPMEINMA_SEARCH_A1 = 1
        '	Exit Function
        '      End If

        Dim dt As DataTable = DB_GetTable(strSQLCount)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            DSPMEINMA_SEARCH_A1 = 1
            Exit Function
        End If
        intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
        dt = Nothing
        '20190325 CHG END

        strSQL = " Select * " & strSQL
        'DB�A�N�Z�X
        '20190325 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '	'�擾�f�[�^�Ȃ�
        '	DSPMEINMA_SEARCH_A1 = 1
        '	GoTo END_DSPMEINMA_SEARCH_A1
        'End If
        dt = DB_GetTable(strSQL)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            DSPMEINMA_SEARCH_A1 = 1
            Exit Function
        End If
        '20190325 CHG END


        '�擾�f�[�^�ޔ�
        ReDim pot_DB_MEIMTA(intData)
        intIdx = 1

        '20190325 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        '	' === 20060920 === UPDATE S - ACE)Sejima
        '	'D            With pot_DB_MEIMTA(intIdx)
        '	'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
        '	'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
        '	'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
        '	'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
        '	'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
        '	'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
        '	'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
        '	'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
        '	'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
        '	'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
        '	'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
        '	'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
        '	'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
        '	'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
        '	'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
        '	'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
        '	'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
        '	'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
        '	'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
        '	'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
        '	'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
        '	'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
        '	'D            End With
        '          ' === 20060920 === UPDATE ��
        '          Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intIdx))
        '          ' === 20060920 === UPDATE E
        '	intIdx = intIdx + 1
        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '      Loop
        For i As Integer = 0 To dt.Rows.Count - 1
            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA(intIdx), i)
            intIdx = intIdx + 1
        Next
        '20190325 CHG END

        DSPMEINMA_SEARCH_A1 = 0

END_DSPMEINMA_SEARCH_A1:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_DSPMEINMA_SEARCH_A1:

    End Function


    Sub Set_DB_MEIMTA(ByRef pDT As DataTable, ByRef pDB_MEIMTA As TYPE_DB_MEIMTA, ByVal DataCount As Integer)

        With pDB_MEIMTA
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .DATKB = DB_NullReplace(pDT.Rows(DataCount)("DATKB"), "") '�`�[�폜�敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .KEYCD = DB_NullReplace(pDT.Rows(DataCount)("KEYCD"), "") '�L�[
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEIKMKNM = DB_NullReplace(pDT.Rows(DataCount)("MEIKMKNM"), "") '���ږ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEICDA = DB_NullReplace(pDT.Rows(DataCount)("MEICDA"), "") '�R�[�h�P
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEICDB = DB_NullReplace(pDT.Rows(DataCount)("MEICDB"), "") '�R�[�h�Q
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEINMA = DB_NullReplace(pDT.Rows(DataCount)("MEINMA"), "") '���̂P
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEINMB = DB_NullReplace(pDT.Rows(DataCount)("MEINMB"), "") '���̂Q
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEINMC = DB_NullReplace(pDT.Rows(DataCount)("MEINMC"), "") '���̂R
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEISUA = DB_NullReplace(pDT.Rows(DataCount)("MEISUA"), 0) '���l���ڂP
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEISUB = DB_NullReplace(pDT.Rows(DataCount)("MEISUB"), 0) '���l���ڂQ
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEISUC = DB_NullReplace(pDT.Rows(DataCount)("MEISUC"), 0) '���l���ڂR
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEIKBA = DB_NullReplace(pDT.Rows(DataCount)("MEIKBA"), "") '�敪�P
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEIKBB = DB_NullReplace(pDT.Rows(DataCount)("MEIKBB"), "") '�敪�Q
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .MEIKBC = DB_NullReplace(pDT.Rows(DataCount)("MEIKBC"), "") '�敪�R
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .DSPORD = DB_NullReplace(pDT.Rows(DataCount)("DSPORD"), "") '�\������
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .RELFL = DB_NullReplace(pDT.Rows(DataCount)("RELFL"), "") '�A�g�t���O
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .FOPEID = DB_NullReplace(pDT.Rows(DataCount)("FOPEID"), "") '����o�^�S����ID
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .FCLTID = DB_NullReplace(pDT.Rows(DataCount)("FCLTID"), "") '����o�^�N���C�A���gID
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTTM"), "") '��ѽ����(����o�^����)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTDT"), "") '��ѽ����(����o�^���t)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .OPEID = DB_NullReplace(pDT.Rows(DataCount)("OPEID"), "") '�X�V�S���҃R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CLTID = DB_NullReplace(pDT.Rows(DataCount)("CLTID"), "") '�X�V�N���C�A���g�h�c
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTTM"), "") '��ѽ����(�X�V����)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTDT"), "") '��ѽ����(�X�V���t)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .UOPEID = DB_NullReplace(pDT.Rows(DataCount)("UOPEID"), "") '�o�b�`�X�V�S���҃R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .UCLTID = DB_NullReplace(pDT.Rows(DataCount)("UCLTID"), "") '�o�b�`�X�V�N���C�A���gID
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .UWRTTM = DB_NullReplace(pDT.Rows(DataCount)("UWRTTM"), "") '��ѽ����(�o�b�`�X�V����)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .UWRTDT = DB_NullReplace(pDT.Rows(DataCount)("UWRTDT"), "") '��ѽ����(�o�b�`�X�V���t)
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .PGID = DB_NullReplace(pDT.Rows(DataCount)("PGID"), "") '��۸���ID
            ' === 20061227 === UPDATE E -
        End With

    End Sub


    'ADD START FKS)INABA 2009/07/17 ****************************************************************************
    '�A���[��FC09071701
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEINMA_SEARCH_A2
    '   �T�v�F  ���̃}�X�^����(���̂P�ł̂����܂�����(���݃`�F�b�N�̂�)�j
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pin_strMEINMA : ���̂P
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMA_SEARCH_A2(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSQLCount As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody
            Dim intIdx As Short

            'On Error GoTo ERR_DSPMEINMA_SEARCH_A2

            DSPMEINMA_SEARCH_A2 = 9

            strSQL = ""
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
            strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
            strSQL = strSQL & "   ORDER BY MEICDA "

            '�����擾
            strSQLCount = ""
            strSQLCount = strSQLCount & " Select Count(*) as DataCount "
            strSQLCount = strSQLCount & strSQL

            'DB�A�N�Z�X
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)

            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)

            ''�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If intData = 0 Then
            '	'�擾�f�[�^�Ȃ�
            '	DSPMEINMA_SEARCH_A2 = 1
            '	Exit Function
            '      End If

            Dim dt As DataTable = DB_GetTable(strSQLCount)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEINMA_SEARCH_A2 = 1
                Exit Function
            End If
            intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
            dt = Nothing
            If intData = 0 Then
                '�擾�f�[�^�Ȃ�
                DSPMEINMA_SEARCH_A2 = 1
                Exit Function
            End If
            '20190325 CHG END

            DSPMEINMA_SEARCH_A2 = 0

            '20190325 DEL START
            'END_DSPMEINMA_SEARCH_A2: 
            '		'�N���[�Y
            '		Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '		Exit Function

            'ERR_DSPMEINMA_SEARCH_A2: 
            '20190325 DEL END
        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function
    'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEINMB_SEARCH
    '   �T�v�F  ���̃}�X�^����(���̂Q�̌����j
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pin_strMEINMB : ���̂Q
    '           pot_DB_MEIMTA : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMB_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEINMB As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSQLCount As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody
            Dim intIdx As Short

            'On Error GoTo ERR_DSPMEINMB_SEARCH

            DSPMEINMB_SEARCH = 9

            strSQL = ""
            strSQL = " Select * " & strSQL
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
            strSQL = strSQL & "   and  MEINMB =    '" & CF_Ora_String(pin_strMEINMB, 20) & "' "

            'DB�A�N�Z�X
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '    '�擾�f�[�^�Ȃ�
            '    DSPMEINMB_SEARCH = 1
            '    GoTo END_DSPMEINMB_SEARCH
            'End If

            ''�擾�f�[�^�ޔ�
            'If CF_Ora_EOF(Usr_Ody_LC) = False Then
            '    ' === 20060920 === UPDATE S - ACE)Sejima �����Ή�
            '    'D            With pot_DB_MEIMTA
            '    'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '�`�[�폜�敪
            '    'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               '�L�[
            '    'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '���ږ�
            '    'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             '�R�[�h�P
            '    'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             '�R�[�h�Q
            '    'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '���̂P
            '    'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '���̂Q
            '    'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '���̂R
            '    'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '���l���ڂP
            '    'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '���l���ڂQ
            '    'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '���l���ڂR
            '    'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '�敪�P
            '    'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '�敪�Q
            '    'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '�敪�R
            '    'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '�\������
            '    'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '�A�g�t���O
            '    'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '�ŏI��Ǝ҃R�[�h
            '    'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               '�N���C�A���g�h�c
            '    'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               '�^�C���X�^���v�i���ԁj
            '    'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               '�^�C���X�^���v�i���t�j
            '    'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         '�^�C���X�^���v�i�o�^���ԁj
            '    'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         '�^�C���X�^���v�i�o�^���j
            '    'D            End With
            '    ' === 20060920 === UPDATE ��
            '    Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
            '    ' === 20060920 === UPDATE E
            'End If

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEINMB_SEARCH = 1
                Exit Function
            End If

            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
            '20190325 CHG END

            DSPMEINMB_SEARCH = 0
            '20190325 DEL START
            'END_DSPMEINMB_SEARCH:
            '            '�N���[�Y
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEINMB_SEARCH:
            '20190325 DEL END

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' === 20060920 === INSERT S - ACE)Sejima �����Ή�
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEIKBA_SEARCH
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pin_strMEIKBA : �敪�P
    '           pot_DB_MEIMTA : ��������
    '           pin_strMEICDB : �R�[�h�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIKBA_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEIKBA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPMEIKBA_SEARCH

            DSPMEIKBA_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
            strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "

            'DB�A�N�Z�X
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '	'�擾�f�[�^�Ȃ�
            '	DSPMEIKBA_SEARCH = 1
            '	GoTo END_DSPMEIKBA_SEARCH
            'End If

            ''�擾�f�[�^�ޔ�
            'Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEIKBA_SEARCH = 1
                Exit Function
            End If

            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
            '20190325 CHG END

            DSPMEIKBA_SEARCH = 0

            'END_DSPMEIKBA_SEARCH:
            '            '�N���[�Y
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEIKBA_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function
    ' === 20060920 === INSERT E

    ' === 20060822 === INSERT S - ACE)Sejima
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Get_KNNOUGYO
    '   �T�v�F  ����[���|�[���Ǝҁi�[�����o�^�p�j�擾
    '   �����F  pm_All           : ��ʏ��
    '           pot_intMaxLinNo  : �擾�s��
    '   �ߒl�F  0 : ����@1 : �Y���f�[�^�Ȃ��@9 : �ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Get_KNNOUGYO(ByVal pin_strBINCD As String, ByRef pot_strKNNOUGYO As String) As Short

        Dim strKNNOUGYO As String
        Dim intRet As Short
        Dim Mst_Inf As TYPE_DB_MEIMTA
        Dim Ret_Value As Short

        On Error GoTo CF_Get_KNNOUGYO_Err

        '��������u�ُ�v
        Ret_Value = 9
        '��������u�Ȃ��v
        strKNNOUGYO = gc_strKNNOUGYO_NO

        If Trim(pin_strBINCD) <> "" Then

            '�֖��R�[�h�̓��͂�����ꍇ�A���R�[�h���L�[�Ƃ��Ė��̃}�X�^������
            '20190618 CHG START
            'Call DB_MEIMTA_Clear(Mst_Inf)
            Call InitDataCommon("MEIMTA")
            '20190618 CHG END

            intRet = DSPMEIM_SEARCH(gc_strKEYCD_BINCD, pin_strBINCD, Mst_Inf)

            If intRet = 0 Then
                If Trim(Mst_Inf.MEINMB) <> "" Then
                    '�f�[�^���擾�ł��A�����̂Q�ɒl�������Ă���
                    '�@�˂��̒l��Ԃ��i���[���Ǝҁj
                    strKNNOUGYO = Trim(Mst_Inf.MEINMB)

                End If
            End If

        End If

        '�u����v
        Ret_Value = 0

CF_Get_KNNOUGYO_End:
        '�擾�����R�[�h��Ԃ�
        pot_strKNNOUGYO = strKNNOUGYO

        CF_Get_KNNOUGYO = Ret_Value
        Exit Function

CF_Get_KNNOUGYO_Err:
        GoTo CF_Get_KNNOUGYO_End

    End Function
    ' === 20060822 === INSERT E

    ' === 20060921 === INSERT S - ACE)Sejima
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_Get_CRM_RsnCnKb
    '   �T�v�F  �󒍁i��ݾفj���R�擾�iCRM�p�j
    '   �����F�@pin_strKEYCD   : �L�[
    '           pin_strMEICDA  : �R�[�h�P
    '           pot_strRsnCnKb : ���R���ށi���̂R�j
    '           pot_strRsnCnNm : ���R���́i���̂Q�j
    '   �ߒl�F�@0:����  9:�ُ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Get_CRM_RsnCnKb(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strRsnCnKb As String, ByRef pot_strRsnCnNm As String) As Short

        Dim Ret_Value As Short
        Dim Mst_Inf As TYPE_DB_MEIMTA

        On Error GoTo CF_Get_CRM_RsnCnKb_End

        CF_Get_CRM_RsnCnKb = 9

        '��������G���[����
        Ret_Value = 9

        '�߂��ϐ���������
        pot_strRsnCnKb = ""
        pot_strRsnCnNm = ""

        If DSPMEIM_SEARCH(pin_strKEYCD, pin_strMEICDA, Mst_Inf) = 0 Then
            '�_���폜�`�F�b�N
            If Mst_Inf.DATKB = "9" Then
            Else
                '�擾�l���i�[
                pot_strRsnCnKb = Trim(Mst_Inf.MEINMC)
                pot_strRsnCnNm = Trim(Mst_Inf.MEINMB)
            End If
        End If

        'CRM�ҏW�p�ɉ��H
        pot_strRsnCnKb = CF_ZeroLenFormat(pot_strRsnCnKb, 6, True)
        pot_strRsnCnNm = CF_Ctr_AnsiLeftB(pot_strRsnCnNm & Space(40), 40)

        '���툵��
        Ret_Value = 0

CF_Get_CRM_RsnCnKb_End:
        '�߂�l��Ԃ�
        CF_Get_CRM_RsnCnKb = Ret_Value

    End Function
    ' === 20060921 === INSERT E

    ' === 20061110 === INSERT S - ACE)Nagasawa �Z�b�g�A�b�v�d�ύX�Ή�
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEIM_SEARCH_ALL
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pot_DB_MEIMTA : �������ʁi�z��j
    '   �ߒl�F�@0:����I�� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIM_SEARCH_ALL(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSQL_Where As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPMEIM_SEARCH_ALL

            DSPMEIM_SEARCH_ALL = 9

            '�߂�l�̃N���A
            Erase pot_DB_MEIMTA

            strSQL = ""
            strSQL = strSQL & " Select Count(*) As CNTDATA"

            strSQL_Where = ""
            strSQL_Where = strSQL_Where & "   from MEIMTA "
            strSQL_Where = strSQL_Where & "  Where KEYCD  = '" & pin_strKEYCD & "' "

            strSQL = strSQL & strSQL_Where

            'DB�A�N�Z�X
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            ''�����擾
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))

            ''�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody_LC)

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEIM_SEARCH_ALL = 1
                Exit Function
            End If
            intData = DB_NullReplace(dt.Rows(0)("CNTDATA"), 0)
            dt = Nothing
            If intData = 0 Then
                '�擾�f�[�^�Ȃ�
                DSPMEIM_SEARCH_ALL = 1
                Exit Function
            End If
            '20190325 CHG END

            '����
            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & strSQL_Where

            ReDim pot_DB_MEIMTA(intData)

            'DB�A�N�Z�X
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            ''�擾�f�[�^�ޔ�
            'intData = 1
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

            '	Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))

            '	Call CF_Ora_MoveNext(Usr_Ody_LC)
            '	intData = intData + 1
            'Loop 

            dt = DB_GetTable(strSQL)
            intData = 1
            For i As Integer = 0 To dt.Rows.Count - 1
                Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA(intData), i)
                intData = intData + 1
            Next
            '20190325 CHG END

            DSPMEIM_SEARCH_ALL = 0

            'END_DSPMEIM_SEARCH_ALL:
            '            '�N���[�Y
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEIM_SEARCH_ALL:

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function
    ' === 20061110 === INSERT E -

    ' === 20070213 === INSERT S - ACE)Nagasawa �V�X�e���󒍂ŋ@��󒍂���͉Ƃ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEIKB_SEARCH
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pot_DB_MEIMTA : ��������
    '           pin_strMEIKBA : �敪�P�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
    '           pin_strMEIKBB : �敪�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
    '           pin_strMEIKBC : �敪�R�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F  �敪�ł̌���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIKB_SEARCH(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEIKBA As String = "", Optional ByVal pin_strMEIKBB As String = "", Optional ByVal pin_strMEIKBC As String = "") As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPMEIKB_SEARCH

            DSPMEIKB_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "

            '�敪�P
            If Trim(pin_strMEIKBA) <> "" Then
                strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "
            End If

            '�敪�Q
            If Trim(pin_strMEIKBB) <> "" Then
                strSQL = strSQL & "   and  MEIKBB = '" & pin_strMEIKBB & "' "
            End If

            '�敪�R
            If Trim(pin_strMEIKBC) <> "" Then
                strSQL = strSQL & "   and  MEIKBC = '" & pin_strMEIKBC & "' "
            End If

            '���я�
            strSQL = strSQL & "  Order By KEYCD, MEICDA "

            'DB�A�N�Z�X
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '    '�擾�f�[�^�Ȃ�
            '    DSPMEIKB_SEARCH = 1
            '    GoTo END_DSPMEIKB_SEARCH
            'End If

            ''�擾�f�[�^�ޔ�
            'Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEIKB_SEARCH = 1
                Exit Function
            End If

            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
            '20190325 CHG END

            DSPMEIKB_SEARCH = 0

            'END_DSPMEIKB_SEARCH:
            '            '�N���[�Y
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEIKB_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function
    ' === 20070213 === INSERT E -

    ' === 20130719 === INSERT S - FWEST)Koroyasau �G���h���[�U�Ή�
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function ENDUSRNM_SEARCH
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD     : �L�[�P
    '           pin_strMEICDA    : �R�[�h
    '           pot_strENDUSRNM  : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRNM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strENDUSRNM As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_ENDUSRNM_SEARCH

        ENDUSRNM_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select "
        strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strMEICDA) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '�擾�f�[�^�Ȃ�
            ENDUSRNM_SEARCH = 1
            GoTo END_ENDUSRNM_SEARCH
        End If

        '�擾�f�[�^�ޔ�
        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")

        ENDUSRNM_SEARCH = 0

END_ENDUSRNM_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_ENDUSRNM_SEARCH:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function ENDUSRNM_SEARCH2
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pin_strMEINM  : ����
    '           pot_DB_MEIMTA : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRNM_SEARCH2(ByVal pin_strKEYCD As String, ByVal pin_strMEINM As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_ENDUSRNM_SEARCH2

        ENDUSRNM_SEARCH2 = 9

        strSQL = ""
        strSQL = strSQL & " Select "
        strSQL = strSQL & "        Rtrim(MEINMA) "
        strSQL = strSQL & "        , Rtrim(MEINMB) "
        strSQL = strSQL & "        , Rtrim(MEINMC) "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC)  = '" & Trim(pin_strMEINM) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
            '�擾�f�[�^�Ȃ�
            ENDUSRNM_SEARCH2 = 1
            GoTo END_ENDUSRNM_SEARCH2
        End If

        ENDUSRNM_SEARCH2 = 0

END_ENDUSRNM_SEARCH2:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_ENDUSRNM_SEARCH2:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function RPTTKA_CHK_SEARCH
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strMEINM  : ����
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function RPTTKA_CHK_SEARCH(ByVal pin_strMEINM As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_RPTTKA_CHK_SEARCH

        RPTTKA_CHK_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select MEINMA "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "   and  KEYCD  = '" & gc_strKEYCD_YUKOKGN & "' "
        strSQL = strSQL & "   and  MEINMA  = '" & Trim(pin_strMEINM) & "' "
        strSQL = strSQL & "   and  MEIKBA  = '" & gc_strRPTTKA_ON & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
            '�擾�f�[�^�Ȃ�
            RPTTKA_CHK_SEARCH = 1
            GoTo END_RPTTKA_CHK_SEARCH
        End If

        RPTTKA_CHK_SEARCH = 0

END_RPTTKA_CHK_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_RPTTKA_CHK_SEARCH:

    End Function
    ' === 20130719 === INSERT E -






    Function MEINMA_Check(ByVal MEICDA As Object, ByVal MEINMA As Object, ByVal EX_MEINMA As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short

        'UPGRADE_WARNING: �I�u�W�F�N�g MEINMA_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        MEINMA_Check = 0 '����I���B
        'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMA = " "
        End If
    End Function

    Function MEINMA_Derived(ByVal MEICDA As Object, ByVal MEINMA As Object, ByVal DE_INDEX As Object) As Object

        'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMA = " "
            'UPGRADE_WARNING: �I�u�W�F�N�g MEINMA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            MEINMA = DB_MEIMTA.MEINMA
        End If
        'MEINMA_Derived = MEINMA

    End Function



    Function MEINMB_Check(ByVal MEICDA As Object, ByVal MEINMB As Object, ByVal EX_MEINMB As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short

        'UPGRADE_WARNING: �I�u�W�F�N�g MEINMB_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        MEINMB_Check = 0 '����I���B
        'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMB = " "
        End If
    End Function

    Function MEINMB_Derived(ByVal MEICDA As Object, ByVal MEINMB As Object, ByVal DE_INDEX As Object) As Object

        'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMB = " "
            'UPGRADE_WARNING: �I�u�W�F�N�g MEINMB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            MEINMB = DB_MEIMTA.MEINMB
        End If
        'MEINMB_Derived = MEINMB

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function MF_Chk_UWRTDTTM
    '   �T�v�F  �X�V���ԃ`�F�b�N����
    '   �����F  pin_strWRTDT    : �X�V���t
    '           pin_strWRTTM    : �X�V����
    '           pin_strUWRTDT   : �o�b�`�X�V���t
    '           pin_strUWRTTM   : �o�b�`�X�V����
    '   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_Chk_UWRTDTTM(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String) As Boolean


        On Error GoTo MF_Chk_UWRTDTTM_err

        MF_Chk_UWRTDTTM = False


        '�X�V���ԃ`�F�b�N
        If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_inf.WRTDT) & Trim(M_MOTO_inf.WRTTM) & Trim(M_MOTO_inf.UWRTDT) & Trim(M_MOTO_inf.UWRTTM) Then
            GoTo MF_Chk_UWRTDTTM_End
        End If

        MF_Chk_UWRTDTTM = True

MF_Chk_UWRTDTTM_End:
        Exit Function

MF_Chk_UWRTDTTM_err:
        GoTo MF_Chk_UWRTDTTM_End

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function MF_Chk_UWRTDTTM_T
    '   �T�v�F  �X�V���ԃ`�F�b�N����
    '   �����F  pin_strWRTDT    : �X�V���t
    '           pin_strWRTTM    : �X�V����
    '           pin_strUWRTDT   : �o�b�`�X�V���t
    '           pin_strUWRTTM   : �o�b�`�X�V����
    '           pin_intIDX      : �����ׂ̏ꍇ�@�@�@�@���׍s�i0�`�j
    '   �@�@�@�@�@�@�@�@�@�@�@�@�@���Ӑ�l�o�^�̏ꍇ�@0�c���Ӑ� 1�c�d����
    '   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
    '   ���l�F  �����׋y�сA���Ӑ�l�o�^�p
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_Chk_UWRTDTTM_T(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean


        On Error GoTo MF_Chk_UWRTDTTM_T_err

        MF_Chk_UWRTDTTM_T = False

        '''    MsgBox "A " & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM)
        '''    MsgBox "B " & Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & _
        'Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM)

        'CHG START FKS)ASANO 2008/03/18
        If InStr(Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then

            '�X�V���ԃ`�F�b�N
            If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM) Then
                GoTo MF_Chk_UWRTDTTM_T_End
            End If
        End If

        'CHG END FKS)ASANO 2008/03/18

        MF_Chk_UWRTDTTM_T = True

MF_Chk_UWRTDTTM_T_End:
        Exit Function

MF_Chk_UWRTDTTM_T_err:
        GoTo MF_Chk_UWRTDTTM_T_End

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function MF_CmnMsgLibrary
    '   �T�v�F  ���b�Z�[�W�\������
    '   �����F  pin_strMsgCode  : ���b�Z�[�W�R�[�h
    '   �ߒl�F  �I���{�^��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_DspMsg(ByVal pin_strMsgCode As String) As Short

        Dim intRet As Short

        On Error Resume Next

        MF_DspMsg = False

        '���b�Z�[�W�\��
        intRet = DSP_MsgBox(SSS_ERROR, pin_strMsgCode, 0)

        MF_DspMsg = intRet

MF_DspMsg_End:
        Exit Function

MF_DspMsg_err:
        GoTo MF_DspMsg_End

    End Function

    '2007/12/24 add-str M.SUEZAWA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function MF_UpDown_UWRTDTTM
    '   �T�v�F  ���ׁ@�폜�E�}������
    '   �����F  pin_intIDX      : �Ώۍs
    '           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
    '   �ߒl�F�@True�F����OK�@False�F����NG
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean

        On Error GoTo MF_UpDown_UWRTDTTM_err

        MF_UpDown_UWRTDTTM = False

        '�X�V���ԁ@�z��ړ�
        M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT
        M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM
        M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT
        M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM

        M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
        M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
        M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
        M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""

        MF_UpDown_UWRTDTTM = True

MF_UpDown_UWRTDTTM_End:
        Exit Function

MF_UpDown_UWRTDTTM_err:
        GoTo MF_UpDown_UWRTDTTM_End

    End Function
    '2007/12/24 add-end M.SUEZAWA

    '2007/12/24 add-str M.SUEZAWA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function MF_SaveRestore_UWRTDTTM
    '   �T�v�F  ���ׁ@�ޔ��E��������
    '   �����F  pin_intIDX      : �Ώۍs
    '           pin_intKBN      : 0�c�ޔ��@1�c����
    '   �ߒl�F�@True�F����OK�@False�F����NG
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean

        On Error GoTo MF_SaveRestore_UWRTDTTM_err

        MF_SaveRestore_UWRTDTTM = False

        If pin_intKBN = 0 Then
            '�ޔ��E��������
            M_MOTO_inf.WRTDT = M_MOTO_A_inf(pin_intIDX).WRTDT
            M_MOTO_inf.WRTTM = M_MOTO_A_inf(pin_intIDX).WRTTM
            M_MOTO_inf.UWRTDT = M_MOTO_A_inf(pin_intIDX).UWRTDT
            M_MOTO_inf.UWRTTM = M_MOTO_A_inf(pin_intIDX).UWRTTM
        Else
            '��������
            M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_inf.WRTDT
            M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_inf.WRTTM
            M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_inf.UWRTDT
            M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_inf.UWRTTM
        End If

        MF_SaveRestore_UWRTDTTM = True

MF_SaveRestore_UWRTDTTM_End:
        Exit Function

MF_SaveRestore_UWRTDTTM_err:
        GoTo MF_SaveRestore_UWRTDTTM_End

    End Function
    '2007/12/24 add-end M.SUEZAWA

    '2007/12/24 add-str M.SUEZAWA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function MF_Clear_UWRTDTTM
    '   �T�v�F  ���ׁ@�Ώۍs�N���A����
    '   �����F  pin_intIDX      : �Ώۍs
    '   �ߒl�F�@True�F����OK�@False�F����NG
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean

        On Error GoTo MF_Clear_UWRTDTTM_err

        MF_Clear_UWRTDTTM = False
        '�X�V���ԁ@�z��N���A
        M_MOTO_A_inf(pin_intIDX).WRTDT = ""
        M_MOTO_A_inf(pin_intIDX).WRTTM = ""
        M_MOTO_A_inf(pin_intIDX).UWRTDT = ""
        M_MOTO_A_inf(pin_intIDX).UWRTTM = ""

        MF_Clear_UWRTDTTM = True

MF_Clear_UWRTDTTM_End:
        Exit Function

MF_Clear_UWRTDTTM_err:
        GoTo MF_Clear_UWRTDTTM_End

    End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPNHSCD_SEARCH
    '   �T�v�F  �[����R�[�h����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPNHSCD_SEARCH(ByVal pin_strNHSCD As String, ByRef pot_DB_NHSMTA As TYPE_DB_NHSMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPNHSCD_SEARCH

        DSPNHSCD_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from NHSMTA "
        strSQL = strSQL & "  Where NHSCD = '" & pin_strNHSCD & "' "


        'DB�A�N�Z�X
        '2019/03/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/18 CHG E N D

        '2019/03/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/03/18 CHG E N D
            '�擾�f�[�^�Ȃ�
            DSPNHSCD_SEARCH = 1
            GoTo END_DSPNHSCD_SEARCH
        End If

        '2019/03/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    With pot_DB_NHSMTA
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "") '�}�X�^�敪�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '�[����R�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "") '�[���於�̂P
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "") '�[���於�̂Q
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSRN", "") '�[���旪��
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSNK = CF_Ora_GetDyn(Usr_Ody, "NHSNK", "") '�[���於�̃J�i
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSRNNK = CF_Ora_GetDyn(Usr_Ody, "NHSRNNK", "") '�[���旪�̃J�i
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSZP = CF_Ora_GetDyn(Usr_Ody, "NHSZP", "") '�[����X�֔ԍ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "") '�[����Z���P
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "") '�[����Z���Q
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "") '�[����Z���R
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSTL = CF_Ora_GetDyn(Usr_Ody, "NHSTL", "") '�[����d�b�ԍ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSFX = CF_Ora_GetDyn(Usr_Ody, "NHSFX", "") '�[����e�`�w�ԍ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSBOSNM = CF_Ora_GetDyn(Usr_Ody, "NHSBOSNM", "") '�[�����\�Җ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCTANM = CF_Ora_GetDyn(Usr_Ody, "NHSCTANM", "") '�[�����S���Җ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSMLAD = CF_Ora_GetDyn(Usr_Ody, "NHSMLAD", "") '�[���惁�[���A�h���X
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLAKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLAKB", "") '���ދ敪�P�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLBKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLBKB", "") '���ދ敪�Q�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLCKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLCKB", "") '���ދ敪�R�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLAID = CF_Ora_GetDyn(Usr_Ody, "NHSCLAID", "") '���ރR�[�h�P�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLBID = CF_Ora_GetDyn(Usr_Ody, "NHSCLBID", "") '���ރR�[�h�Q�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLCID = CF_Ora_GetDyn(Usr_Ody, "NHSCLCID", "") '���ރR�[�h�R�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLANM = CF_Ora_GetDyn(Usr_Ody, "NHSCLANM", "") '���ޖ��̂P�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLBNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLBNM", "") '���ޖ��̂Q�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSCLCNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLCNM", "") '���ޖ��̂R�i�[����j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "") '���̃}�j���A�����͋敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .OLDNHSCD = CF_Ora_GetDyn(Usr_Ody, "OLDNHSCD", "") '���[����R�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .NGRPCD = CF_Ora_GetDyn(Usr_Ody, "NGRPCD", "") '�O���[�v��ЃR�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .OLNGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLNGRPCD", "") '���O���[�v��ЃR�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "") '�Ǝ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "") '�n��
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "") '�֋敪
        '        ' === 20061224 === INSERT S - ACE)Nagasawa �X�֔ԍ�/�d�b�ԍ�/FAX�ԍ��̒ǉ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '�C�O����敪
        '        ' === 20061224 === INSERT E -
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
        '    End With
        'End If
        With pot_DB_NHSMTA
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�폜�敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSMSTKB = DB_NullReplace(dt.Rows(0)("NHSMSTKB"), "") '�}�X�^�敪�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCD = DB_NullReplace(dt.Rows(0)("NHSCD"), "") '�[����R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSNMA = DB_NullReplace(dt.Rows(0)("NHSNMA"), "") '�[���於�̂P
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSNMB = DB_NullReplace(dt.Rows(0)("NHSNMB"), "") '�[���於�̂Q
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSRN = DB_NullReplace(dt.Rows(0)("NHSRN"), "") '�[���旪��
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSNK = DB_NullReplace(dt.Rows(0)("NHSNK"), "") '�[���於�̃J�i
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSRNNK = DB_NullReplace(dt.Rows(0)("NHSRNNK"), "") '�[���旪�̃J�i
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSZP = DB_NullReplace(dt.Rows(0)("NHSZP"), "") '�[����X�֔ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSADA = DB_NullReplace(dt.Rows(0)("NHSADA"), "") '�[����Z���P
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSADB = DB_NullReplace(dt.Rows(0)("NHSADB"), "") '�[����Z���Q
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSADC = DB_NullReplace(dt.Rows(0)("NHSADC"), "") '�[����Z���R
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSTL = DB_NullReplace(dt.Rows(0)("NHSTL"), "") '�[����d�b�ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSFX = DB_NullReplace(dt.Rows(0)("NHSFX"), "") '�[����e�`�w�ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSBOSNM = DB_NullReplace(dt.Rows(0)("NHSBOSNM"), "") '�[�����\�Җ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCTANM = DB_NullReplace(dt.Rows(0)("NHSCTANM"), "") '�[�����S���Җ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSMLAD = DB_NullReplace(dt.Rows(0)("NHSMLAD"), "") '�[���惁�[���A�h���X
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLAKB = DB_NullReplace(dt.Rows(0)("NHSCLAKB"), "") '���ދ敪�P�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLBKB = DB_NullReplace(dt.Rows(0)("NHSCLBKB"), "") '���ދ敪�Q�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLCKB = DB_NullReplace(dt.Rows(0)("NHSCLCKB"), "") '���ދ敪�R�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLAID = DB_NullReplace(dt.Rows(0)("NHSCLAID"), "") '���ރR�[�h�P�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLBID = DB_NullReplace(dt.Rows(0)("NHSCLBID"), "") '���ރR�[�h�Q�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLCID = DB_NullReplace(dt.Rows(0)("NHSCLCID"), "") '���ރR�[�h�R�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLANM = DB_NullReplace(dt.Rows(0)("NHSCLANM"), "") '���ޖ��̂P�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLBNM = DB_NullReplace(dt.Rows(0)("NHSCLBNM"), "") '���ޖ��̂Q�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSCLCNM = DB_NullReplace(dt.Rows(0)("NHSCLCNM"), "") '���ޖ��̂R�i�[����j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NHSNMMKB = DB_NullReplace(dt.Rows(0)("NHSNMMKB"), "") '���̃}�j���A�����͋敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .OLDNHSCD = DB_NullReplace(dt.Rows(0)("OLDNHSCD"), "") '���[����R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .NGRPCD = DB_NullReplace(dt.Rows(0)("NGRPCD"), "") '�O���[�v��ЃR�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .OLNGRPCD = DB_NullReplace(dt.Rows(0)("OLNGRPCD"), "") '���O���[�v��ЃR�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .GYOSHU = DB_NullReplace(dt.Rows(0)("GYOSHU"), "") '�Ǝ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CHIIKI = DB_NullReplace(dt.Rows(0)("CHIIKI"), "") '�n��
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .BINCD = DB_NullReplace(dt.Rows(0)("BINCD"), "") '�֋敪
            ' === 20061224 === INSERT S - ACE)Nagasawa �X�֔ԍ�/�d�b�ԍ�/FAX�ԍ��̒ǉ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .FRNKB = DB_NullReplace(dt.Rows(0)("FRNKB"), "") '�C�O����敪
            ' === 20061224 === INSERT E -
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
        End With
        '2019/03/18 CHG E N D

        DSPNHSCD_SEARCH = 0

END_DSPNHSCD_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPNHSCD_SEARCH:
        GoTo END_DSPNHSCD_SEARCH

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPNHSNMA_SEARCH
    '   �T�v�F  �[���於�̂P����
    '   �����F�@pin_strNHSNMA :�@�[���於�̂P
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPNHSNMA_SEARCH(ByVal pin_strNHSNMA As String, ByRef pot_DB_NHSMTA As TYPE_DB_NHSMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPNHSNMA_SEARCH

        DSPNHSNMA_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from NHSMTA "
        strSQL = strSQL & "  Where TRIM(NHSNMA) = '" & Trim(pin_strNHSNMA) & "' "


        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPNHSNMA_SEARCH = 1
            GoTo END_DSPNHSNMA_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_NHSMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "") '�}�X�^�敪�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '�[����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "") '�[���於�̂P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "") '�[���於�̂Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSRN", "") '�[���旪��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSNK = CF_Ora_GetDyn(Usr_Ody, "NHSNK", "") '�[���於�̃J�i
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSRNNK = CF_Ora_GetDyn(Usr_Ody, "NHSRNNK", "") '�[���旪�̃J�i
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSZP = CF_Ora_GetDyn(Usr_Ody, "NHSZP", "") '�[����X�֔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "") '�[����Z���P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "") '�[����Z���Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "") '�[����Z���R
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSTL = CF_Ora_GetDyn(Usr_Ody, "NHSTL", "") '�[����d�b�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSFX = CF_Ora_GetDyn(Usr_Ody, "NHSFX", "") '�[����e�`�w�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSBOSNM = CF_Ora_GetDyn(Usr_Ody, "NHSBOSNM", "") '�[�����\�Җ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCTANM = CF_Ora_GetDyn(Usr_Ody, "NHSCTANM", "") '�[�����S���Җ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSMLAD = CF_Ora_GetDyn(Usr_Ody, "NHSMLAD", "") '�[���惁�[���A�h���X
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLAKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLAKB", "") '���ދ敪�P�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLBKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLBKB", "") '���ދ敪�Q�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLCKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLCKB", "") '���ދ敪�R�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLAID = CF_Ora_GetDyn(Usr_Ody, "NHSCLAID", "") '���ރR�[�h�P�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLBID = CF_Ora_GetDyn(Usr_Ody, "NHSCLBID", "") '���ރR�[�h�Q�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLCID = CF_Ora_GetDyn(Usr_Ody, "NHSCLCID", "") '���ރR�[�h�R�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLANM = CF_Ora_GetDyn(Usr_Ody, "NHSCLANM", "") '���ޖ��̂P�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLBNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLBNM", "") '���ޖ��̂Q�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCLCNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLCNM", "") '���ޖ��̂R�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "") '���̃}�j���A�����͋敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OLDNHSCD = CF_Ora_GetDyn(Usr_Ody, "OLDNHSCD", "") '���[����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NGRPCD = CF_Ora_GetDyn(Usr_Ody, "NGRPCD", "") '�O���[�v��ЃR�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OLNGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLNGRPCD", "") '���O���[�v��ЃR�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "") '�Ǝ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "") '�n��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "") '�֋敪
                ' === 20061224 === INSERT S - ACE)Nagasawa �X�֔ԍ�/�d�b�ԍ�/FAX�ԍ��̒ǉ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '�C�O����敪
                ' === 20061224 === INSERT E -
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            End With
        End If

        DSPNHSNMA_SEARCH = 0

END_DSPNHSNMA_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPNHSNMA_SEARCH:
        GoTo END_DSPNHSNMA_SEARCH

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPSOUCD_SEARCH
    '   �T�v�F  �q�ɃR�[�h����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPSOUCD_SEARCH(ByVal pin_strSOUCD As String, ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPSOUCD_SEARCH

        DSPSOUCD_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SOUMTA "
        strSQL = strSQL & "  Where SOUCD = '" & pin_strSOUCD & "' "


        'DB�A�N�Z�X
        '2019/03/14 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/14 CHG E N D

        '2019/03/14 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/03/14 CHG E N D
            '�擾�f�[�^�Ȃ�
            DSPSOUCD_SEARCH = 1
            Exit Function
        End If

        '2019/03/14 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    With pot_DB_SOUMTA
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB"), "") '�`�[�폜�敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD"), "") '�q�ɃR�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM"), "") '�q�ɖ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUZP = CF_Ora_GetDyn(Usr_Ody, "SOUZP"), "") '�q�ɗX�֔ԍ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUADA = CF_Ora_GetDyn(Usr_Ody, "SOUADA"), "") '�q�ɏZ���P
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUADB = CF_Ora_GetDyn(Usr_Ody, "SOUADB"), "") '�q�ɏZ���Q
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUADC = CF_Ora_GetDyn(Usr_Ody, "SOUADC"), "") '�q�ɏZ���R
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUTL = CF_Ora_GetDyn(Usr_Ody, "SOUTL"), "") '�q�ɓd�b�ԍ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUFX = CF_Ora_GetDyn(Usr_Ody, "SOUFX"), "") '�q�ɂe�`�w�ԍ�
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUBSCD = CF_Ora_GetDyn(Usr_Ody, "SOUBSCD"), "") '�ꏊ�R�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUKB = CF_Ora_GetDyn(Usr_Ody, "SOUKB"), "") '�q�Ɏ��
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SRSCNKB = CF_Ora_GetDyn(Usr_Ody, "SRSCNKB"), "") '�V���A���X�L�����v�ۋ敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB"), "") '���Y���敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD"), "") '�����R�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB"), "") '�q�ɋ敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .HIKKB = CF_Ora_GetDyn(Usr_Ody, "HIKKB"), "") '�����Ώۋ敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .SALPALKB = CF_Ora_GetDyn(Usr_Ody, "SALPALKB"), "") '�̔��v��Ώۋ敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL"), "") '�A�g�t���O
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID"), "") '�ŏI��Ǝ҃R�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID"), "") '�N���C�A���g�h�c
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM"), "") '�^�C���X�^���v�i���ԁj
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT"), "") '�^�C���X�^���v�i���t�j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
        '    End With
        'End If
        With pot_DB_SOUMTA
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUCD = DB_NullReplace(dt.Rows(0)("SOUCD"), "") '�q�ɃR�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUNM = DB_NullReplace(dt.Rows(0)("SOUNM"), "") '�q�ɖ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUZP = DB_NullReplace(dt.Rows(0)("SOUZP"), "") '�q�ɗX�֔ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUADA = DB_NullReplace(dt.Rows(0)("SOUADA"), "") '�q�ɏZ���P
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUADB = DB_NullReplace(dt.Rows(0)("SOUADB"), "") '�q�ɏZ���Q
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUADC = DB_NullReplace(dt.Rows(0)("SOUADC"), "") '�q�ɏZ���R
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUTL = DB_NullReplace(dt.Rows(0)("SOUTL"), "") '�q�ɓd�b�ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUFX = DB_NullReplace(dt.Rows(0)("SOUFX"), "") '�q�ɂe�`�w�ԍ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUBSCD = DB_NullReplace(dt.Rows(0)("SOUBSCD"), "") '�ꏊ�R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUKB = DB_NullReplace(dt.Rows(0)("SOUKB"), "") '�q�Ɏ��
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SRSCNKB = DB_NullReplace(dt.Rows(0)("SRSCNKB"), "") '�V���A���X�L�����v�ۋ敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SISNKB = DB_NullReplace(dt.Rows(0)("SISNKB"), "") '���Y���敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUTRICD = DB_NullReplace(dt.Rows(0)("SOUTRICD"), "") '�����R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SOUKOKB = DB_NullReplace(dt.Rows(0)("SOUKOKB"), "") '�q�ɋ敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .HIKKB = DB_NullReplace(dt.Rows(0)("HIKKB"), "") '�����Ώۋ敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .SALPALKB = DB_NullReplace(dt.Rows(0)("SALPALKB"), "") '�̔��v��Ώۋ敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
        End With
        '2019/03/14 CHG E N D

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        DSPSOUCD_SEARCH = 0

        Exit Function

ERR_DSPSOUCD_SEARCH:

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function SYSTBA_SEARCH
    '   �T�v�F  ���[�U�[���Ǘ��e�[�u������
    '   �����F  pot_DB_SYSTBA   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function SYSTBA_SEARCH(ByRef pot_DB_SYSTBA As TYPE_DB_SYSTBA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            SYSTBA_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from SYSTBA "

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                SYSTBA_SEARCH = 1
                Exit Function
            End If

            With pot_DB_SYSTBA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRID = DB_NullReplace(dt.Rows(0)("USRID"), "") '���[�U�[ID
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRNMA = DB_NullReplace(dt.Rows(0)("USRNMA"), "") '���[�U�[��1(����)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRNMB = DB_NullReplace(dt.Rows(0)("USRNMB"), "") '���[�U�[��2(����)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRRN = DB_NullReplace(dt.Rows(0)("USRRN"), "") '���[�U�[����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRNK = DB_NullReplace(dt.Rows(0)("USRNK"), "") '���[�U�[����(�J�i)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRZP = DB_NullReplace(dt.Rows(0)("USRZP"), "") '���[�U�[�X�֔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRADA = DB_NullReplace(dt.Rows(0)("USRADA"), "") '���[�U�[�Z��1
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRADB = DB_NullReplace(dt.Rows(0)("USRADB"), "") '���[�U�[�Z��2
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRADC = DB_NullReplace(dt.Rows(0)("USRADC"), "") '���[�U�[�Z��3
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRTL = DB_NullReplace(dt.Rows(0)("USRTL"), "") '���[�U�[�d�b�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRFX = DB_NullReplace(dt.Rows(0)("USRFX"), "") '���[�U�[FAX�ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRBOSNM = DB_NullReplace(dt.Rows(0)("USRBOSNM"), "") '���[�U�[��\�Җ���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .USRTANNM = DB_NullReplace(dt.Rows(0)("USRTANNM"), "") '���[�U�[�S���Җ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SMAMM = DB_NullReplace(dt.Rows(0)("SMAMM"), "") '���Z��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SMADD = DB_NullReplace(dt.Rows(0)("SMADD"), "") '���Z��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SMAMONDD = DB_NullReplace(dt.Rows(0)("SMAMONDD"), "") '�������Z��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SMEDD = DB_NullReplace(dt.Rows(0)("SMEDD"), "") '���ߓ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KESCC = DB_NullReplace(dt.Rows(0)("KESCC"), "") '����x����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KESDD = DB_NullReplace(dt.Rows(0)("KESDD"), "") '����x����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "") '�`�[�Ǘ�NO.
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RECNO = DB_NullReplace(dt.Rows(0)("RECNO"), "") '���R�[�h�Ǘ�NO.
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .STTDATNO = DB_NullReplace(dt.Rows(0)("STTDATNO"), "") '�J�n�`�[�Ǘ�NO.
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ENDDATNO = DB_NullReplace(dt.Rows(0)("ENDDATNO"), "") '�I���`�[�Ǘ�NO.
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .STTRECNO = DB_NullReplace(dt.Rows(0)("STTRECNO"), "") '�J�n���R�[�h�Ǘ�NO.
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ENDRECNO = DB_NullReplace(dt.Rows(0)("ENDRECNO"), "") '�I�����R�[�h�Ǘ�NO.
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .GYMSTTDT = DB_NullReplace(dt.Rows(0)("GYMSTTDT"), "") '�Ɩ��J�n���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKSSAKB = DB_NullReplace(dt.Rows(0)("TOKSSAKB"), "") '���Ӑ搿���������敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKSMAKB = DB_NullReplace(dt.Rows(0)("TOKSMAKB"), "") '���Ӑ�o���������敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SIRSSAKB = DB_NullReplace(dt.Rows(0)("SIRSSAKB"), "") '�d����x���������敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SIRSMAKB = DB_NullReplace(dt.Rows(0)("SIRSMAKB"), "") '�d����o���������敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SMAUPDDT = DB_NullReplace(dt.Rows(0)("SMAUPDDT"), "") '�O��o�������s��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UKSMEDT = DB_NullReplace(dt.Rows(0)("UKSMEDT"), "") '�����������i����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SKSMEDT = DB_NullReplace(dt.Rows(0)("SKSMEDT"), "") '�����������i�d���j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MINSPCCP = DB_NullReplace(dt.Rows(0)("MINSPCCP"), "") '�Œ�󂫗e��(�l)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MONUPDSC = DB_NullReplace(dt.Rows(0)("MONUPDSC"), "") '�g�����ۑ�����(��)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .YERUPDSC = DB_NullReplace(dt.Rows(0)("YERUPDSC"), "") '�T�}���ۑ�����(��)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MONUPDDT = DB_NullReplace(dt.Rows(0)("MONUPDDT"), "") '�O�񌎎��X�V���s��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .YERUPDDT = DB_NullReplace(dt.Rows(0)("YERUPDDT"), "") '�O��N���X�V���s��
                '�a��̗p�敪
                'For intCnt = 0 To 1
                '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .NEGKB(intCnt) = DB_NullReplace(dt.Rows(0)("NEGKB") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGKB00 = DB_NullReplace(dt.Rows(0)("NEGKB00"), "")
                .NEGKB01 = DB_NullReplace(dt.Rows(0)("NEGKB01"), "")

                '���N(����)
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .NEGDT(intCnt) = DB_NullReplace(dt.Rows(0)("NEGDT") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGDT00 = DB_NullReplace(dt.Rows(0)("NEGDT00"), "")
                .NEGDT01 = DB_NullReplace(dt.Rows(0)("NEGDT01"), "")
                .NEGDT02 = DB_NullReplace(dt.Rows(0)("NEGDT02"), "")
                .NEGDT03 = DB_NullReplace(dt.Rows(0)("NEGDT03"), "")
                .NEGDT04 = DB_NullReplace(dt.Rows(0)("NEGDT04"), "")

                '����(�N)
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .NEGYY(intCnt) = DB_NullReplace(dt.Rows(0)("NEGYY") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGYY00 = DB_NullReplace(dt.Rows(0)("NEGYY00"), "")
                .NEGYY01 = DB_NullReplace(dt.Rows(0)("NEGYY01"), "")
                .NEGYY02 = DB_NullReplace(dt.Rows(0)("NEGYY02"), "")
                .NEGYY03 = DB_NullReplace(dt.Rows(0)("NEGYY03"), "")
                .NEGYY04 = DB_NullReplace(dt.Rows(0)("NEGYY04"), "")

                '����
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '    .NEGNM(intCnt) = DB_NullReplace(dt.Rows(0)("NEGNM") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGNM00 = DB_NullReplace(dt.Rows(0)("NEGNM00"), "")
                .NEGNM01 = DB_NullReplace(dt.Rows(0)("NEGNM01"), "")
                .NEGNM02 = DB_NullReplace(dt.Rows(0)("NEGNM02"), "")
                .NEGNM03 = DB_NullReplace(dt.Rows(0)("NEGNM03"), "")
                .NEGNM04 = DB_NullReplace(dt.Rows(0)("NEGNM04"), "")

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .VERNO = DB_NullReplace(dt.Rows(0)("VERNO"), "") 'VERNO
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .LEVNO = DB_NullReplace(dt.Rows(0)("LEVNO"), "") 'LEBEL NO
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZAIHYKKB = DB_NullReplace(dt.Rows(0)("ZAIHYKKB"), "") '�݌ɕ]�����@
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .GNKHYKKB = DB_NullReplace(dt.Rows(0)("GNKHYKKB"), "") '�����]�����@-�e���p
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HYKSTTDT = DB_NullReplace(dt.Rows(0)("HYKSTTDT"), "") '�]���v�Z�J�n���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '��ѽ����(����)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '��ѽ����(���t)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '��ѽ����(�o�^����)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '��ѽ����(�o�^���t)
            End With

            SYSTBA_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPZEIRT_SEARCH
    '   �T�v�F  ����ŗ�����
    '   �����F  pin_strZEIDT    : ���
    '           pin_strZEIRNKKB : ����Ń����N
    '           pot_DB_SYSTBB   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPZEIRT_SEARCH(ByVal pin_strZEIDT As String, ByVal pin_strZEIRNKKB As String, ByRef pot_DB_SYSTBB As TYPE_DB_SYSTBB) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_DSPZEIRT_SEARCH

        DSPZEIRT_SEARCH = 9

        ' === 20131203 === INSERT S - RS)Ishida ����Ŗ@�����Ή�
        '�p�����[�^�̎擾���t���A"/"����������B
        pin_strZEIDT = Replace(pin_strZEIDT, "/", "")
        ' === 20131203 === INSERT E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SYSTBB "
        strSQL = strSQL & "  Where ZEIDT    <= '" & pin_strZEIDT & "' "
        strSQL = strSQL & "    and ZEIRNKKB  = '" & pin_strZEIRNKKB & "' "
        strSQL = strSQL & "  Order by ZEIDT DESC "

        'DB�A�N�Z�X
        '2019/04/09 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/09 CHG E N D

        '2019/04/09 CHG START     
        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/09 CHG E N D
            '�擾�f�[�^�Ȃ�
            DSPZEIRT_SEARCH = 1
            Exit Function
        End If

        '2019/04/09 CHG START
        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '    With pot_DB_SYSTBB
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ZEIDT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIDT", "") '�`�[�폜�敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRNKKB", "") '�`�[�폜�敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .ZEIRT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRT", 0) '�`�[�폜�敪
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "") '�ŏI��Ǝ҃R�[�h
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "") '�N���C�A���g�h�c
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "") '�^�C���X�^���v�i���ԁj
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "") '�^�C���X�^���v�i���t�j
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
        '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
        '    End With
        'End If
        With pot_DB_SYSTBB
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .ZEIDT = DB_NullReplace(dt.Rows(0)("ZEIDT"), "") '�`�[�폜�敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "") '�`�[�폜�敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0) '�`�[�폜�敪
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
        End With
        '2019/04/09 CHG E N D

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)


        DSPZEIRT_SEARCH = 0

        Exit Function

ERR_DSPZEIRT_SEARCH:


    End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMSGCM_SEARCH
    '   �T�v�F  �V�X�e�����b�Z�[�W����
    '   �����F  pin_strMSGKB    : ���b�Z�[�W���
    '           pin_strMSGNM    : ���b�Z�[�W�A�C�e��
    '           pin_strMSGSQ�@�@: ���b�Z�[�W�A��
    '           pot_DB_SYSTBH   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, ByVal pin_strMSGNM As String, ByVal pin_strMSGSQ As String, ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            DSPMSGCM_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from SYSTBH "
            strSQL = strSQL & "  Where MSGKB     = '" & CF_Ora_Sgl(pin_strMSGKB) & "' "
            strSQL = strSQL & "    and MSGNM     = '" & CF_Ora_Sgl(pin_strMSGNM) & "' "
            strSQL = strSQL & "    and MSGSQ     = '" & CF_Ora_Sgl(pin_strMSGSQ) & "' "

            'DB�A�N�Z�X
            '2019/03/14 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/14 CHG E N D

            '2019/03/14 CHG START
            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/14 CHG E N D
                '�擾�f�[�^�Ȃ�
                DSPMSGCM_SEARCH = 1
                Exit Function
            End If

            With pot_DB_SYSTBH
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MSGKB = DB_NullReplace(dt.Rows(0)("MSGKB"), "") '���b�Z�[�W���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MSGNM = DB_NullReplace(dt.Rows(0)("MSGNM"), "") '���b�Z�[�W�A�C�e��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MSGSQ = DB_NullReplace(dt.Rows(0)("MSGSQ"), "") '���b�Z�[�W�A��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BTNKB = DB_NullReplace(dt.Rows(0)("BTNKB"), 0) '�{�^�����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BTNON = DB_NullReplace(dt.Rows(0)("BTNON"), 0) '�{�^�������l
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ICNKB = DB_NullReplace(dt.Rows(0)("ICNKB"), 0) '�A�C�R�����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MSGCM = DB_NullReplace(dt.Rows(0)("MSGCM"), "") '���b�Z�[�W
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .COLSQ = DB_NullReplace(dt.Rows(0)("COLSQ"), "") '�F�V�[�P���X
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '��ѽ����(����)
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '��ѽ����(���t)
            End With

            DSPMSGCM_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    Public Function DSPTANCD_SEARCH(ByVal pin_strTANCD As String, ByRef pot_DB_TANMTA As TYPE_DB_TANMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            DSPTANCD_SEARCH = 9

            Dim tableCond As String = ""

            If DB_NullReplace(pin_strTANCD, "") = "" Then
                tableCond = ""
            Else
                tableCond = "where TANCD = '" & pin_strTANCD & "'"
            End If

            '20190618 CHG START
            'DB_GetData("TANMTA", tableCond, "")

            'If dsList.Tables("TANMTA").Rows.Count <= 0 Then
            '    '�擾�f�[�^�Ȃ�
            '    DSPTANCD_SEARCH = 1
            '    Exit Function
            'End If

            ''2019/03/15 CHG START
            ''DB_TANMTA = TANMTA_GetNext(0)
            'pot_DB_TANMTA = TANMTA_GetNext(0)
            ''2019/03/15 CHG E N D

            GetRowsCommon("TANMTA", tableCond)
            pot_DB_TANMTA = DB_TANMTA

            If pot_DB_TANMTA.DATKB Is Nothing Then
                DSPTANCD_SEARCH = 9
                Exit Function
            End If
            '20190618 CHG END

            DSPTANCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTANCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPTOKCD_SEARCH
    '   �T�v�F  ���Ӑ�R�[�h����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKCD_SEARCH(ByVal pin_strTOKCD As String, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            DSPTOKCD_SEARCH = 9

            Dim tableCond As String = ""

            If DB_NullReplace(pin_strTOKCD, "") = "" Then
                tableCond = ""
            Else
                tableCond = "where TOKCD = '" & pin_strTOKCD & "'"
            End If

            DB_GetData("TOKMTA", tableCond, "")

            If dsList.Tables("TOKMTA").Rows.Count <= 0 Then
                '�擾�f�[�^�Ȃ�
                DSPTOKCD_SEARCH = 1
                Exit Function
            End If

            '20190619 CHG START
            '2019/03/15 CHG START
            'DB_TOKMTA = TOKMTA_GetNext(0)
            'pot_DB_TOKMTA = TOKMTA_GetNext(0)
            '2019/03/15 CHG E N D

            GetRowsCommon("TOKMTA", tableCond)
            pot_DB_TOKMTA = DB_TOKMTA
            '20190619 CHG END


            DSPTOKCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTOKCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPTOKRN_SEARCH
    '   �T�v�F  ���Ӑ旪�̌���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKRN_SEARCH(ByVal pin_strTOKRN As String, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            DSPTOKRN_SEARCH = 9

            Dim tableCond As String = ""

            If DB_NullReplace(pin_strTOKRN, "") = "" Then
                tableCond = ""
            Else
                tableCond = "where TOKRN = '" & pin_strTOKRN & "'"
            End If

            DB_GetData("TOKMTA", tableCond, "")

            If dsList.Tables("TOKMTA").Rows.Count <= 0 Then
                '�擾�f�[�^�Ȃ�
                DSPTOKRN_SEARCH = 1
                Exit Function
            End If

            '20190619 CHG START
            'DB_TOKMTA = TOKMTA_GetNext(0)
            GetRowsCommon("TOKMTA", tableCond)
            '20190619 CHG END

            DSPTOKRN_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTOKRN_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPLMTKN_SEARCH
    '   �T�v�F  �^�M���x�z����
    '   �����F�@pin_strTOKCD  : ���Ӑ�R�[�h
    '           pin_strTGRPCD : ���Ӑ�O���[�v�R�[�h
    '           pot_curLMTKN  : �^�M���x�z
    '   �ߒl�F�@0:����I�� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPLMTKN_SEARCH(ByVal pin_strTOKCD As String, ByVal pin_strTGRPCD As String, ByRef pot_curLMTKN As Decimal) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody As U_Ody
            Dim strTOKCD_Where As String

            'On Error GoTo ERR_DSPLMTKN_SEARCH

            DSPLMTKN_SEARCH = 9
            pot_curLMTKN = 0

            If Trim(pin_strTGRPCD) = "" Then
                strTOKCD_Where = pin_strTOKCD
            Else
                strTOKCD_Where = pin_strTGRPCD
            End If

            strSQL = ""
            strSQL = strSQL & " Select LMTKN "
            strSQL = strSQL & "   from TOKMTA "
            strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(strTOKCD_Where) & "' "


            '2019/03/14 CHG START MIYAMOTO
            ''DB�A�N�Z�X
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

            'If CF_Ora_EOF(Usr_Ody) = False Then
            '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '	pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "") '�^�M���x�z
            '	DSPLMTKN_SEARCH = 0

            '	GoTo END_DSPLMTKN_SEARCH
            'End If
            DB_GetTable(strSQL)

            If dsList.Tables("tableName").Rows.Count > 0 Then
                pot_curLMTKN = dsList.Tables("tableName").Rows(0).Item("LMTKN")
                DSPLMTKN_SEARCH = 0
            End If
            '2019/03/14 CHG END MIYAMOTO


            '�擾�f�[�^�����݂��Ȃ������ꍇ�ŁA�������e�ȊO�̏ꍇ
            If strTOKCD_Where <> pin_strTOKCD Then
                '2019/03/14 DEL START MIYAMOTO
                ''�N���[�Y
                'Call CF_Ora_CloseDyn(Usr_Ody)
                '2019/03/14 DEL END MIYAMOTO

                strSQL = ""
                strSQL = strSQL & " Select LMTKN "
                strSQL = strSQL & "   from TOKMTA "
                strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
                strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(pin_strTOKCD) & "' "


                '2019/03/14 CHG START MIYAMOTO
                ''DB�A�N�Z�X
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

                'If CF_Ora_EOF(Usr_Ody) = False Then
                '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '	pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "") '�^�M���x�z
                '         End If
                DB_GetTable(strSQL)

                If dsList.Tables("tableName").Rows.Count > 0 Then
                    pot_curLMTKN = dsList.Tables("tableName").Rows(0).Item("LMTKN")
                    DSPLMTKN_SEARCH = 0
                End If
                '2019/03/14 CHG END MIYAMOTO

            End If

            DSPLMTKN_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTOKRN_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

        'END_DSPLMTKN_SEARCH: 
        '		'�N���[�Y
        '		Call CF_Ora_CloseDyn(Usr_Ody)

        '		Exit Function

        'ERR_DSPLMTKN_SEARCH: 

    End Function


    Public Function DSPUNYDT_SEARCH(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA) As Short

        Dim li_MsgRtn As Integer

        Try

            DSPUNYDT_SEARCH = 9

            DB_GetData("UNYMTA", "", "")

            If dsList.Tables("UNYMTA").Rows.Count <= 0 Then
                '�擾�f�[�^�Ȃ�
                DSPUNYDT_SEARCH = 1
                Exit Function
            End If

            '2019/03/18 CHG START
            'DB_UNYMTA = UNYMTA_GetNext(0)
            'pot_DB_UNYMTA = UNYMTA_GetNext(0)
            GetRowsCommon("UNYMTA", "")
            pot_DB_UNYMTA = DB_UNYMTA
            '20190619 CHG END
            '2019/03/18 CHG E N D

            DSPUNYDT_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPUNYDT_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    Sub UNYMTA_RClear()
        DB_UNYMTA = Nothing
    End Sub

    '2019/03/20 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CHK_UNYDT
    '   �T�v�F  �^�p���t�`�F�b�N
    '   �����F
    '   �ߒl�F�@0:����(�^�p���t�������̓��t�Ɠ���) -1:�^�p���}�X�^��
    '�@�@�@�@�@ 1:�^�p���t�������̓��t���傫�� 2:�^�p���t�������̓��t��菬����
    '   ���l�F�A���[��739
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Function CHK_UNYDT(ByRef CHK_DT As String) As Short

        '�߂�l
        Dim rtnVal As Short = -1

        'SQL��
        Dim strSQL As String

        Dim ls_UNYDT As String
        Dim ls_CHK_DT As String

        Try
            ls_CHK_DT = Trim(CHK_DT)

            strSQL = ""
            strSQL &= " SELECT "
            strSQL &= "  UNYDT "
            strSQL &= " FROM UNYMTA "

            'DB�A�N�Z�X 
            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '�擾�f�[�^�Ȃ�
                rtnVal = -1
            Else
                ls_UNYDT = DB_NullReplace(dt.Rows(0)("UNYDT"), "") '�^�p���t

                If ls_UNYDT = ls_CHK_DT Then
                    rtnVal = 0
                ElseIf ls_UNYDT > ls_CHK_DT Then
                    rtnVal = 1
                Else
                    rtnVal = 2
                End If
            End If

        Catch ex As Exception

            MsgBox("CHK_UNYDT" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")

            'Finally

        End Try

        Return rtnVal

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPBANK_SEARCH
    '   �T�v�F  ��s�}�X�^����
    '   �����F  pin_strBNKCD    : ��s�R�[�h
    '           pot_DB_BNKMTA   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPBANK_SEARCH(ByVal pin_strBNKCD As String, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPBANK_SEARCH

            DSPBANK_SEARCH = 9

            strSQL = ""
            '20190619 DEL START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from BNKMTA "
            '20190619 DEL END
            strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "  and   BNKCD    = '" & CF_Ora_Sgl(pin_strBNKCD) & "' "
            strSQL = strSQL & "  Order by BNKCD "


            '20190619 CHG START
            'DB�A�N�Z�X
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '�擾�f�[�^�Ȃ�
            ''    DSPBANK_SEARCH = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_BNKMTA_SetData(Usr_Ody_LC, pot_DB_BNKMTA)
            ''End If

            '''�N���[�Y
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPBANK_SEARCH = 1
            '    Exit Function
            'End If

            'Call Set_DB_BNKMTA(dt, pot_DB_BNKMTA, 0)
            ''20190403 CHG END

            GetRowsCommon("BNKMTA", strSQL)
            pot_DB_BNKMTA = DB_BNKMTA
            '20190619 CHG END


            DSPBANK_SEARCH = 0

            'Exit Function

            'ERR_DSPBANK_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPBANK_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPBANK_SEARCH_ALL
    '   �T�v�F  ��s�}�X�^����
    '   �����F  pin_strBNKCD    : ��s�R�[�h
    '           pot_DB_BNKMTA   : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPBANK_SEARCH_ALL(ByVal pin_strBNKCD As String, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPBANK_SEARCH_ALL

            DSPBANK_SEARCH_ALL = 9

            strSQL = ""
            '20190619 DEL START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from BNKMTA "
            '20190619 DEL END
            strSQL = strSQL & "  Where BNKCD    = '" & CF_Ora_Sgl(pin_strBNKCD) & "' "

            '20190619 CHG START
            'DB�A�N�Z�X
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '�擾�f�[�^�Ȃ�
            ''    DSPBANK_SEARCH_ALL = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_BNKMTA_SetData(Usr_Ody_LC, pot_DB_BNKMTA)
            ''End If

            '''�N���[�Y
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPBANK_SEARCH_ALL = 1
            '    Exit Function
            'End If

            'Call Set_DB_BNKMTA(dt, pot_DB_BNKMTA, 0)
            ''20190403 CHG END
            GetRowsCommon("BNKMTA", strSQL)
            pot_DB_BNKMTA = DB_BNKMTA
            '20190619 CHG END

            DSPBANK_SEARCH_ALL = 0

            'Exit Function

            'ERR_DSPBANK_SEARCH_ALL:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPBANK_SEARCH_ALL" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function ENDUSRNM_SEARCH3
    '   �T�v�F  �G���h���[�U�}�X�^��薼�̎擾
    '             ���݂��Ȃ��ꍇ�A���̃}�X�^�Q��
    '   �����Fpin_strMEICDA    : �R�[�h
    '           pin_LoadingFlg     : ����/�󒍏��Ǎ������ۂ����f����
    '           pot_strENDUSRNM  : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRNM_SEARCH3(ByVal pin_strENDUSRCD As String, ByVal pin_LoadingFlg As Short, ByRef pot_strENDUSRNM As String) As Short


        'Dim intData As Short
        ''UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        'Dim Usr_Ody_LC As U_Ody

        'On Error GoTo ERR_ENDUSRNM_SEARCH3
        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            ENDUSRNM_SEARCH3 = 9

            strSQL = ""
            strSQL = strSQL & " Select "
            strSQL = strSQL & "        Rtrim(ENDUSRNM) NAME "
            strSQL = strSQL & "   from ENDMTA "
            strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "   and  Trim(ENDUSRCD) = '" & Trim(pin_strENDUSRCD) & "' "

            'DB�A�N�Z�X
            '2019/03/18 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/18 CHG E N D

            '2019/03/18 CHG START
            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/18 CHG E N D
                If pin_LoadingFlg = 1 Then
                    '����/�󒍏��Ǎ����ŃG���h���[�U�}�X�^�ɂȂ��ꍇ���̃}�X�^����擾
                    strSQL = ""
                    strSQL = strSQL & " Select "
                    strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
                    strSQL = strSQL & "   from MEIMTA "
                    strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
                    strSQL = strSQL & "   and  KEYCD  = '114' "
                    strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strENDUSRCD) & "' "

                    'DB�A�N�Z�X
                    '2019/03/18 CHG START
                    'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
                    dt = Nothing
                    dt = DB_GetTable(strSQL)
                    '2019/03/18 CHG E N D

                    '2019/03/18 CHG START
                    'If CF_Ora_EOF(Usr_Ody_LC) = True Then
                    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                        '2019/03/18 CHG E N D
                        '�擾�f�[�^�Ȃ�
                        pot_strENDUSRNM = ""
                        'ENDUSRNM_SEARCH3 = 1
                        'GoTo END_ENDUSRNM_SEARCH3
                        Exit Function
                    End If
                Else
                    '����/�󒍏��Ǎ����łȂ��ꍇ
                    '�擾�f�[�^�Ȃ�
                    pot_strENDUSRNM = ""
                    'ENDUSRNM_SEARCH3 = 1
                    'GoTo END_ENDUSRNM_SEARCH3
                    Exit Function
                End If
            End If

            '�擾�f�[�^�ޔ�
            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")
            pot_strENDUSRNM = DB_NullReplace(dt.Rows(0)("NAME"), "")

            ENDUSRNM_SEARCH3 = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("ENDUSRNM_SEARCH3" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try



        'END_ENDUSRNM_SEARCH3:
        '            '�N���[�Y
        '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

        '            Exit Function

        'ERR_ENDUSRNM_SEARCH3:

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function ENDUSRCD_SEARCH
    '   �T�v�F  ���ό��o���ރg�������G���h���[�U�R�[�h�擾
    '   �����F�@pDATNO    : �`�[�ԍ�
    '             pMITNO     : ���ϔԍ�
    '             pMITNOV   : �Ő�
    '             pin_strENDUSRCD : �G���h���[�U�R�[�h
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRCD_SEARCH(ByVal pDATNO As String, ByVal pMITNO As String, ByVal pMITNOV As String, ByRef pin_strENDUSRCD As String) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            ENDUSRCD_SEARCH = 9

            If pDATNO = "" Then
                strSQL = ""
                strSQL = strSQL & "   Select "
                strSQL = strSQL & "   Rtrim(ENDUSRCD) AS ENDUSRCD"
                strSQL = strSQL & "   from MITTHB "
                strSQL = strSQL & "   ,MITTHA"
                strSQL = strSQL & "   Where MITTHA.DATNO = MITTHB.DATNO"
                strSQL = strSQL & "   and MITTHB.DATNO = (SELECT DATNO from MITTHA"
                strSQL = strSQL & "   Where MITTHA.DATKB = 1"
                strSQL = strSQL & "   and  MITTHA.MITNO  = '" & pMITNO & "' "
                strSQL = strSQL & "   and  MITTHA.MITNOV = '" & pMITNOV & "' )"
                strSQL = strSQL & "   and  MITTHB.MITNO  = '" & pMITNO & "' "
                strSQL = strSQL & "   and  MITTHB.MITNOV = '" & pMITNOV & "' "
            Else
                strSQL = ""
                strSQL = strSQL & " Select "
                strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
                strSQL = strSQL & " from MITTHB "
                strSQL = strSQL & " Where DATNO  = '" & pDATNO & "' "
                strSQL = strSQL & " and  MITNO  = '" & pMITNO & "' "
                strSQL = strSQL & " and  MITNOV = '" & pMITNOV & "' "
            End If

            'DB�A�N�Z�X
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                pin_strENDUSRCD = ""
                ENDUSRCD_SEARCH = 1
                Exit Function
            Else
                pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
            End If

            ENDUSRCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("ENDUSRCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try


        'Dim intData As Short
        ''UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        'Dim Usr_Ody_LC As U_Ody

        'On Error GoTo ERR_ENDUSRCD_SEARCH



        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '	'�擾�f�[�^�Ȃ�
        '	pin_strENDUSRCD = ""
        '	ENDUSRCD_SEARCH = 1
        '	GoTo END_ENDUSRCD_SEARCH
        'End If

        ''�擾�f�[�^�ޔ�
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

        'END_ENDUSRCD_SEARCH: 
        '		'�N���[�Y
        '		Call CF_Ora_CloseDyn(Usr_Ody_LC)

        '		Exit Function

        'ERR_ENDUSRCD_SEARCH: 

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function ENDUSRCD_SEARCH2
    '   �T�v�F  �G���h���[�U�R�t���e�[�u�����G���h���[�U�R�[�h�擾
    '   �����F�@pJDNNO    : �󒍔ԍ�
    '             pin_strENDUSRCD : �G���h���[�U�R�[�h
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRCD_SEARCH2(ByVal pJDNNO As String, ByRef pin_strENDUSRCD As String) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_ENDUSRCD_SEARCH2

            ENDUSRCD_SEARCH2 = 9

            strSQL = ""
            strSQL = strSQL & " Select "
            strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
            strSQL = strSQL & " from JDNTHE "
            strSQL = strSQL & " Where JDNNO  = '" & pJDNNO & "' "

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                pin_strENDUSRCD = ""
                ENDUSRCD_SEARCH2 = 1
                Exit Function
            Else
                pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
            End If

            ''DB�A�N�Z�X
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '    '�擾�f�[�^�Ȃ�
            '    pin_strENDUSRCD = ""
            '    ENDUSRCD_SEARCH2 = 1
            '    GoTo END_ENDUSRCD_SEARCH2
            'End If

            ''�擾�f�[�^�ޔ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

            ENDUSRCD_SEARCH2 = 0

            'END_ENDUSRCD_SEARCH2:
            '            '�N���[�Y
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_ENDUSRCD_SEARCH2:
        Catch ex As Exception
            li_MsgRtn = MsgBox("ENDUSRCD_SEARCH2" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPFBTRA_SEARCH
    '   �T�v�F  �e�a�g��������
    '   �����F  pin_strFBRFNO   : �Ɖ�ԍ�
    '           pot_DB_FBTRA    : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPFBTRA_SEARCH(ByVal pin_strFBRFNO As String, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPFBTRA_SEARCH

            DSPFBTRA_SEARCH = 9

            strSQL = ""
            '20190619 CHG START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from FBTRA "
            '20190619 CHG END
            strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "  and   FBRFNO   = '" & CF_Ora_Sgl(pin_strFBRFNO) & "' "
            strSQL = strSQL & "  Order by BNKCD "

            '20190619 CHG START
            'DB�A�N�Z�X
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '�擾�f�[�^�Ȃ�
            ''    DSPFBTRA_SEARCH = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_FBTRA_SetData(Usr_Ody_LC, pot_DB_FBTRA)
            ''End If

            '''�N���[�Y
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPFBTRA_SEARCH = 1
            '    Exit Function
            'End If

            'Call Set_DB_FBTRA(dt, pot_DB_FBTRA, 0)
            ''20190403 CHG END
            GetRowsCommon("FBTRA", strSQL)
            pot_DB_FBTRA = DB_FBTRA
            '20190619 CHG END


            DSPFBTRA_SEARCH = 0

            'Exit Function

            'ERR_DSPFBTRA_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPFBTRA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPFBTRA_SEARCH_ALL
    '   �T�v�F  �e�a�g��������
    '   �����F  pin_strFBRFNO   : �Ɖ�ԍ�
    '           pot_DB_FBTRA    : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPFBTRA_SEARCH_ALL(ByVal pin_strFBRFNO As String, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPFBTRA_SEARCH_ALL

            DSPFBTRA_SEARCH_ALL = 9

            strSQL = ""
            '20190619 DEL START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from FBTRA "
            '20190619 DEL END
            strSQL = strSQL & "  Where FBRFNO   = '" & CF_Ora_Sgl(pin_strFBRFNO) & "' "

            '20190619 CHG START
            'DB�A�N�Z�X
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '�擾�f�[�^�Ȃ�
            ''    DSPFBTRA_SEARCH_ALL = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_FBTRA_SetData(Usr_Ody_LC, pot_DB_FBTRA)
            ''End If

            '''�N���[�Y
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPFBTRA_SEARCH_ALL = 1
            '    Exit Function
            'End If

            'Call Set_DB_FBTRA(dt, pot_DB_FBTRA, 0)
            ''20190403 CHG END

            GetRowsCommon("FBTRA", strSQL)
            pot_DB_FBTRA = DB_FBTRA
            '20190619 CHG END

            DSPFBTRA_SEARCH_ALL = 0

            'Exit Function

            'ERR_DSPFBTRA_SEARCH_ALL:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPFBTRA_SEARCH_ALL" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPCTLCD_SEARCH
    '   �T�v�F  �Ǘ��R�[�h����
    '   �����F  pin_strCTLCD  : �����ΏۊǗ��R�[�h
    '           pot_DB_FIXMTA : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCTLCD_SEARCH(ByVal pin_strCTLCD As String, ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPCTLCD_SEARCH

            DSPCTLCD_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from FIXMTA "
            strSQL = strSQL & "  Where CTLCD = '" & pin_strCTLCD & "' "

            'DB�A�N�Z�X
            '2019/03/14 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/14 CHG E N D

            '2019/03/14 CHG START
            'If CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/14 CHG E N D
                '�擾�f�[�^�Ȃ�
                DSPCTLCD_SEARCH = 1
                Exit Function
                'GoTo END_DSPCTLCD_SEARCH
            End If

            '2019/03/14 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_FIXMTA
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CTLCD = CF_Ora_GetDyn(Usr_Ody, "CTLCD", "") '�Ǘ��R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CTLNM = CF_Ora_GetDyn(Usr_Ody, "CTLNM", "") '�Ǘ�����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .FIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "") '�Œ�l
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .REMARK = CF_Ora_GetDyn(Usr_Ody, "REMARK", "") '���l
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            '    End With
            'End If
            With pot_DB_FIXMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CTLCD = DB_NullReplace(dt.Rows(0)("CTLCD"), "") '�Ǘ��R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CTLNM = DB_NullReplace(dt.Rows(0)("CTLNM"), "") '�Ǘ�����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .FIXVAL = DB_NullReplace(dt.Rows(0)("FIXVAL"), "") '�Œ�l
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .REMARK = DB_NullReplace(dt.Rows(0)("REMARK"), "") '���l
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
            End With
            '2019/03/14 CHG E N D

            DSPCTLCD_SEARCH = 0

            'END_DSPCTLCD_SEARCH:
            '            '�N���[�Y
            '            Call CF_Ora_CloseDyn(Usr_Ody)

            '            Exit Function

            'ERR_DSPCTLCD_SEARCH:
            '            GoTo END_DSPCTLCD_SEARCH
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPCTLCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPJDNTHA_SEARCH
    '   �T�v�F  �󒍌��o���g��������
    '   �����F�@pin_strJDNNO          :�󒍔ԍ�
    '           pot_DB_JDNTHA�@�@�@�@ :�󒍌��o���g�����f�[�^
    '           pin_strDATKB �@�@�@�@ :�`�[�폜�敪�iOptional�A�n����Ȃ��ꍇ"1"�j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPJDNTHA_SEARCH(ByVal pin_strJDNNO As String, ByRef pot_DB_JDNTHA As TYPE_DB_JDNTHA, Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPJDNTHA_SEARCH

            DSPJDNTHA_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from JDNTHA "
            strSQL = strSQL & "  Where JDNNO = '" & pin_strJDNNO & "' "
            strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

            'DB�A�N�Z�X
            '20190319 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

            'If CF_Ora_EOF(Usr_Ody) = True Then
            '    '�擾�f�[�^�Ȃ�
            '    DSPJDNTHA_SEARCH = 1
            '    Exit Function
            'End If
            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '�擾�f�[�^�Ȃ�
                DSPJDNTHA_SEARCH = 1
                Exit Function
            End If
            '20190319 CHG END

            '20190319 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_JDNTHA
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "") '�`�[�Ǘ���
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "") '�`�[�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "") '�󒍔ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JHDNO = CF_Ora_GetDyn(Usr_Ody, "JHDNO", "") '�󔭒���
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JDNDT = CF_Ora_GetDyn(Usr_Ody, "JDNDT", "") '�󒍓`�[���t
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DENDT = CF_Ora_GetDyn(Usr_Ody, "DENDT", "") '�󒍓��t
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "") '�[��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '���Ӑ�R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '���Ӑ旪��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '�[����R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "") '�[���於�̂P
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "") '�[���於�̂Q
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "") '�S���҃R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "") '�S���Җ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "") '����R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "") '���喼
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '������R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '�q�ɃR�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '�q�ɖ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "") '����敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "") '����敪��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SMADT = CF_Ora_GetDyn(Usr_Ody, "SMADT", "") '�o�������t
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JDNENDKB = CF_Ora_GetDyn(Usr_Ody, "JDNENDKB", "") '�󒍊����敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SBAUODKN = CF_Ora_GetDyn(Usr_Ody, "SBAUODKN", 0) '�󒍋��z�i�{�̍��v�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SBAUZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZEKN", 0) '�󒍋��z�i����Ŋz�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SBAUZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZKKN", 0) '�󒍋��z�i�`�[�v�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DENCM = CF_Ora_GetDyn(Usr_Ody, "DENCM", "") '���l
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "") '���敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "") '���������t�i����j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "TOKSMECC", "") '���T�C�N���i����j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "") '���ߗj��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "") '����T�C�N��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "") '������t
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "") '����j��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .LSTID = CF_Ora_GetDyn(Usr_Ody, "LSTID", "") '�`�[���
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "TKNRPSKB", "") '���z�[����������
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "TKNZRNKB", "") '���z�[�������敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "") '����ŋ敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "TOKZCLKB", "") '����ŎZ�o�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "TOKRPSKB", "") '����Œ[����������
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "TOKZRNKB", "") '����Œ[�������敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "") '�����ƭ�ٓ��͋敪�i���Ӑ�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "") '�����ƭ�ٓ��͋敪�i�[����j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "") '�}�X�^�敪�i���Ӑ�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "") '�}�X�^�敪�i�[����j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TANMSTKB = CF_Ora_GetDyn(Usr_Ody, "TANMSTKB", "") '�}�X�^�敪�i�S���ҁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "") '���ϔԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") '�Ő�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "") '�Č��h�c
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLMDL = CF_Ora_GetDyn(Usr_Ody, "CLMDL", "") '���ތ^��
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .URIKJN = CF_Ora_GetDyn(Usr_Ody, "URIKJN", "") '����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "") '�֖��R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "") '�����P
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "") '�����Q
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BKTHKKB = CF_Ora_GetDyn(Usr_Ody, "BKTHKKB", "") '�����s�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .MAEUKKB = CF_Ora_GetDyn(Usr_Ody, "MAEUKKB", "") '�O��敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SEIKB = CF_Ora_GetDyn(Usr_Ody, "SEIKB", "") '�����敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "") '�󒍎���敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "") '�[����Z���P
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "") '�[����Z���Q
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "") '�[����Z���R
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JDNINKB = CF_Ora_GetDyn(Usr_Ody, "JDNINKB", "") '�󒍎捞���
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DFKJDNNO = CF_Ora_GetDyn(Usr_Ody, "DFKJDNNO", "") '�_�C�t�N�󒍔ԍ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "TOKJDNNO", "") '�q�撍��No.
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .HDKEIKN = CF_Ora_GetDyn(Usr_Ody, "HDKEIKN", 0) '�n�[�h�_����z
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .HDSIKKN = CF_Ora_GetDyn(Usr_Ody, "HDSIKKN", 0) '�n�[�h�d�؋��z
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SFKEIKN = CF_Ora_GetDyn(Usr_Ody, "SFKEIKN", 0) '�\�t�g�_����z
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SFSIKKN = CF_Ora_GetDyn(Usr_Ody, "SFSIKKN", 0) '�\�t�g�d�؋��z
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CMPKTCD = CF_Ora_GetDyn(Usr_Ody, "CMPKTCD", "") '�R���s���[�^�^���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CMPKTNM = CF_Ora_GetDyn(Usr_Ody, "CMPKTNM", "") '�R���s���[�^�^����
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .PRDTBMCD = CF_Ora_GetDyn(Usr_Ody, "PRDTBMCD", "") '���Y�S������R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "") '�ʉ݋敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SBAFRCKN = CF_Ora_GetDyn(Usr_Ody, "SBAFRCKN", 0) '�O�ݎ󒍋��z�i�`�[�v�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JODRSNKB = CF_Ora_GetDyn(Usr_Ody, "JODRSNKB", "") '�󒍗��R�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JODCNKB = CF_Ora_GetDyn(Usr_Ody, "JODCNKB", "") '�󒍃L�����Z�����R�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JSKTANCD = CF_Ora_GetDyn(Usr_Ody, "JSKTANCD", "") '�n����ђS���҃R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JSKTANNM = CF_Ora_GetDyn(Usr_Ody, "JSKTANNM", "") '�n����ђS���Җ�
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JSKBMNCD = CF_Ora_GetDyn(Usr_Ody, "JSKBMNCD", "") '�n����ѕ���R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JSKBMNNM = CF_Ora_GetDyn(Usr_Ody, "JSKBMNNM", "") '�n����ѕ��喼
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '�C�O����敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "") '�d���n
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JDNPRKB = CF_Ora_GetDyn(Usr_Ody, "JDNPRKB", "") '���s�敪
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .DENCMIN = CF_Ora_GetDyn(Usr_Ody, "DENCMIN", "") '�Г����l
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            '        'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .JDNENDNM = CF_Ora_GetDyn(Usr_Ody, "JDNENDNM", "") '�󒍊����敪��
            '    End With
            'End If

            ''�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)

            With pot_DB_JDNTHA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "") '�`�[�Ǘ���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�`�[�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DENKB = DB_NullReplace(dt.Rows(0)("DENKB"), "") '�`�[�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNNO = DB_NullReplace(dt.Rows(0)("JDNNO"), "") '�󒍔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JHDNO = DB_NullReplace(dt.Rows(0)("JHDNO"), "") '�󔭒���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNDT = DB_NullReplace(dt.Rows(0)("JDNDT"), "") '�󒍓`�[���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DENDT = DB_NullReplace(dt.Rows(0)("DENDT"), "") '�󒍓��t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DEFNOKDT = DB_NullReplace(dt.Rows(0)("DEFNOKDT"), "") '�[��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKCD = DB_NullReplace(dt.Rows(0)("TOKCD"), "") '���Ӑ�R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKRN = DB_NullReplace(dt.Rows(0)("TOKRN"), "") '���Ӑ旪��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSCD = DB_NullReplace(dt.Rows(0)("NHSCD"), "") '�[����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSNMA = DB_NullReplace(dt.Rows(0)("NHSNMA"), "") '�[���於�̂P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSNMB = DB_NullReplace(dt.Rows(0)("NHSNMB"), "") '�[���於�̂Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TANCD = DB_NullReplace(dt.Rows(0)("TANCD"), "") '�S���҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TANNM = DB_NullReplace(dt.Rows(0)("TANNM"), "") '�S���Җ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BUMCD = DB_NullReplace(dt.Rows(0)("BUMCD"), "") '����R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BUMNM = DB_NullReplace(dt.Rows(0)("BUMNM"), "") '���喼
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKSEICD = DB_NullReplace(dt.Rows(0)("TOKSEICD"), "") '������R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SOUCD = DB_NullReplace(dt.Rows(0)("SOUCD"), "") '�q�ɃR�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SOUNM = DB_NullReplace(dt.Rows(0)("SOUNM"), "") '�q�ɖ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZKTKB = DB_NullReplace(dt.Rows(0)("ZKTKB"), "") '����敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .ZKTNM = DB_NullReplace(dt.Rows(0)("ZKTNM"), "") '����敪��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SMADT = DB_NullReplace(dt.Rows(0)("SMADT"), "") '�o�������t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNENDKB = DB_NullReplace(dt.Rows(0)("JDNENDKB"), "") '�󒍊����敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SBAUODKN = DB_NullReplace(dt.Rows(0)("SBAUODKN"), 0) '�󒍋��z�i�{�̍��v�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SBAUZEKN = DB_NullReplace(dt.Rows(0)("SBAUZEKN"), 0) '�󒍋��z�i����Ŋz�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SBAUZKKN = DB_NullReplace(dt.Rows(0)("SBAUZKKN"), 0) '�󒍋��z�i�`�[�v�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DENCM = DB_NullReplace(dt.Rows(0)("DENCM"), "") '���l
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKSMEKB = DB_NullReplace(dt.Rows(0)("TOKSMEKB"), "") '���敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKSMEDD = DB_NullReplace(dt.Rows(0)("TOKSMEDD"), "") '���������t�i����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKSMECC = DB_NullReplace(dt.Rows(0)("TOKSMECC"), "") '���T�C�N���i����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKSDWKB = DB_NullReplace(dt.Rows(0)("TOKSDWKB"), "") '���ߗj��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKKESCC = DB_NullReplace(dt.Rows(0)("TOKKESCC"), "") '����T�C�N��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKKESDD = DB_NullReplace(dt.Rows(0)("TOKKESDD"), "") '������t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKKDWKB = DB_NullReplace(dt.Rows(0)("TOKKDWKB"), "") '����j��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .LSTID = DB_NullReplace(dt.Rows(0)("LSTID"), "") '�`�[���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TKNRPSKB = DB_NullReplace(dt.Rows(0)("TKNRPSKB"), "") '���z�[����������
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TKNZRNKB = DB_NullReplace(dt.Rows(0)("TKNZRNKB"), "") '���z�[�������敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKZEIKB = DB_NullReplace(dt.Rows(0)("TOKZEIKB"), "") '����ŋ敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKZCLKB = DB_NullReplace(dt.Rows(0)("TOKZCLKB"), "") '����ŎZ�o�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKRPSKB = DB_NullReplace(dt.Rows(0)("TOKRPSKB"), "") '����Œ[����������
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKZRNKB = DB_NullReplace(dt.Rows(0)("TOKZRNKB"), "") '����Œ[�������敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKNMMKB = DB_NullReplace(dt.Rows(0)("TOKNMMKB"), "") '�����ƭ�ٓ��͋敪�i���Ӑ�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSNMMKB = DB_NullReplace(dt.Rows(0)("NHSNMMKB"), "") '�����ƭ�ٓ��͋敪�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKMSTKB = DB_NullReplace(dt.Rows(0)("TOKMSTKB"), "") '�}�X�^�敪�i���Ӑ�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSMSTKB = DB_NullReplace(dt.Rows(0)("NHSMSTKB"), "") '�}�X�^�敪�i�[����j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TANMSTKB = DB_NullReplace(dt.Rows(0)("TANMSTKB"), "") '�}�X�^�敪�i�S���ҁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MITNO = DB_NullReplace(dt.Rows(0)("MITNO"), "") '���ϔԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MITNOV = DB_NullReplace(dt.Rows(0)("MITNOV"), "") '�Ő�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .AKNID = DB_NullReplace(dt.Rows(0)("AKNID"), "") '�Č��h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLMDL = DB_NullReplace(dt.Rows(0)("CLMDL"), "") '���ތ^��
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .URIKJN = DB_NullReplace(dt.Rows(0)("URIKJN"), "") '����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BINCD = DB_NullReplace(dt.Rows(0)("BINCD"), "") '�֖��R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KENNMA = DB_NullReplace(dt.Rows(0)("KENNMA"), "") '�����P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .KENNMB = DB_NullReplace(dt.Rows(0)("KENNMB"), "") '�����Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .BKTHKKB = DB_NullReplace(dt.Rows(0)("BKTHKKB"), "") '�����s�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .MAEUKKB = DB_NullReplace(dt.Rows(0)("MAEUKKB"), "") '�O��敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SEIKB = DB_NullReplace(dt.Rows(0)("SEIKB"), "") '�����敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "") '�󒍎���敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSADA = DB_NullReplace(dt.Rows(0)("NHSADA"), "") '�[����Z���P
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSADB = DB_NullReplace(dt.Rows(0)("NHSADB"), "") '�[����Z���Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .NHSADC = DB_NullReplace(dt.Rows(0)("NHSADC"), "") '�[����Z���R
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNINKB = DB_NullReplace(dt.Rows(0)("JDNINKB"), "") '�󒍎捞���
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DFKJDNNO = DB_NullReplace(dt.Rows(0)("DFKJDNNO"), "") '�_�C�t�N�󒍔ԍ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TOKJDNNO = DB_NullReplace(dt.Rows(0)("TOKJDNNO"), "") '�q�撍��No.
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HDKEIKN = DB_NullReplace(dt.Rows(0)("HDKEIKN"), 0) '�n�[�h�_����z
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HDSIKKN = DB_NullReplace(dt.Rows(0)("HDSIKKN"), 0) '�n�[�h�d�؋��z
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SFKEIKN = DB_NullReplace(dt.Rows(0)("SFKEIKN"), 0) '�\�t�g�_����z
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SFSIKKN = DB_NullReplace(dt.Rows(0)("SFSIKKN"), 0) '�\�t�g�d�؋��z
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CMPKTCD = DB_NullReplace(dt.Rows(0)("CMPKTCD"), "") '�R���s���[�^�^���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CMPKTNM = DB_NullReplace(dt.Rows(0)("CMPKTNM"), "") '�R���s���[�^�^����
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .PRDTBMCD = DB_NullReplace(dt.Rows(0)("PRDTBMCD"), "") '���Y�S������R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .TUKKB = DB_NullReplace(dt.Rows(0)("TUKKB"), "") '�ʉ݋敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SBAFRCKN = DB_NullReplace(dt.Rows(0)("SBAFRCKN"), 0) '�O�ݎ󒍋��z�i�`�[�v�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JODRSNKB = DB_NullReplace(dt.Rows(0)("JODRSNKB"), "") '�󒍗��R�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JODCNKB = DB_NullReplace(dt.Rows(0)("JODCNKB"), "") '�󒍃L�����Z�����R�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JSKTANCD = DB_NullReplace(dt.Rows(0)("JSKTANCD"), "") '�n����ђS���҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JSKTANNM = DB_NullReplace(dt.Rows(0)("JSKTANNM"), "") '�n����ђS���Җ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JSKBMNCD = DB_NullReplace(dt.Rows(0)("JSKBMNCD"), "") '�n����ѕ���R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JSKBMNNM = DB_NullReplace(dt.Rows(0)("JSKBMNNM"), "") '�n����ѕ��喼
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .FRNKB = DB_NullReplace(dt.Rows(0)("FRNKB"), "") '�C�O����敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SIMUKE = DB_NullReplace(dt.Rows(0)("SIMUKE"), "") '�d���n
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNPRKB = DB_NullReplace(dt.Rows(0)("JDNPRKB"), "") '���s�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DENCMIN = DB_NullReplace(dt.Rows(0)("DENCMIN"), "") '�Г����l
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .JDNENDNM = DB_NullReplace(dt.Rows(0)("JDNENDNM"), "") '�󒍊����敪��
            End With
            '20190319 CHG END

            DSPJDNTHA_SEARCH = 0

            '            Exit Function

            'ERR_DSPJDNTHA_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPJDNTHA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPRNKM_SEARCH
    '   �T�v�F  �����N�ʎd�ؗ��}�X�^����
    '   �����F�@pin_strHINGRP   : ���i�Q
    '           pin_strRNKCD    : �����N
    '           pin_strURISETDT : �̔��P���ݒ���t
    '           pot_DB_RNKMTA �@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPRNKM_SEARCH(ByVal pin_strHINGRP As String, ByVal pin_strRNKCD As String, ByVal pin_strURISETDT As String, ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPRNKM_SEARCH

        DSPRNKM_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from RNKMTA "
        strSQL = strSQL & "  Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "  and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "  and URISETDT = ( Select MAX(URISETDT) AS _MAX_URISETDT "
        strSQL = strSQL & "                     from RNKMTA "
        strSQL = strSQL & "                    Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "                      and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "                      and URISETDT <= '" & pin_strURISETDT & "' )"

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPRNKM_SEARCH = 1
            Exit Function
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_RNKMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�`�[�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "") '���i�Q
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RNKCD = CF_Ora_GetDyn(Usr_Ody, "RNKCD", "") '�����N
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .URISETDT = CF_Ora_GetDyn(Usr_Ody, "URISETDT", "") '�̔��P���ݒ���t
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .SIKRT = CF_Ora_GetDyn(Usr_Ody, "SIKRT", 0) '�d�ؗ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            End With
        End If

        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)


        DSPRNKM_SEARCH = 0

        Exit Function

ERR_DSPRNKM_SEARCH:


    End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPYSN_SEARCH
    '   �T�v�F  �^�M���x�t�@�C������
    '   �����F  pin_strTOKCD�@�@ : ���Ӑ�R�[�h
    '           pin_strTGRPCD�@�@: �O���[�v��ЃR�[�h
    '   �@�@�@�@pin_strYSNUPDT �@: �o�^��
    '   �@�@�@�@pot_DB_YSNTRA  �@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPYSN_SEARCH(ByVal pin_strTOKCD As String, ByVal pin_strTGRPCD As String, ByVal pin_strYSNUPDT As String, ByRef pot_DB_YSNTRA As TYPE_DB_YSNTRA) As Short

        Dim strSQL As String
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody
        Dim strTGRPCD As String

        On Error GoTo ERR_DSPYSN_SEARCH

        DSPYSN_SEARCH = 9

        '20190619 DEL START
        'Call DB_YSNTRA_Clear(pot_DB_YSNTRA)
        '20190619 DEL END

        If Trim(pin_strTGRPCD) = "" Then
            strTGRPCD = pin_strTOKCD
        Else
            strTGRPCD = pin_strTGRPCD
        End If

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from YSNTRA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TGRPCD  = '" & CF_Ora_Sgl(strTGRPCD) & "' "
        strSQL = strSQL & "    and YSNUPDT = '" & CF_Ora_Sgl(pin_strYSNUPDT) & "' "


        '20190827 CHG START
        'DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        Dim dt As DataTable = Nothing
        dt = DB_GetTable(strSQL)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt.Rows.Count = 0 Then
            '�擾�f�[�^�Ȃ�
            DSPYSN_SEARCH = 1
            GoTo END_DSPYSN_SEARCH
        End If

        'If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_YSNTRA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '�폜�敪

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "") '�O���[�v��ЃR�[�h
                .TGRPCD = DB_NullReplace(dt.Rows(0)("TGRPCD"), "") '�O���[�v��ЃR�[�h

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.YSNUPDT = CF_Ora_GetDyn(Usr_Ody, "YSNUPDT", "") '�o�^��
                .YSNUPDT = DB_NullReplace(dt.Rows(0)("YSNUPDT"), "") '�o�^��

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0) '���|�c���z
                .URKZANKN = DB_NullReplace(dt.Rows(0)("URKZANKN"), 0) '���|�c���z

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.YSNJDNKN = CF_Ora_GetDyn(Usr_Ody, "YSNJDNKN", 0) '�󒍎c���z
                .YSNJDNKN = DB_NullReplace(dt.Rows(0)("YSNJDNKN"), 0) '�󒍎c���z

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.YSNTEGKN = CF_Ora_GetDyn(Usr_Ody, "YSNTEGKN", 0) '���c���z
                .YSNTEGKN = DB_NullReplace(dt.Rows(0)("YSNTEGKN"), 0) '���c���z

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '�^�C���X�^���v�i���ԁj

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '�^�C���X�^���v�i���t�j

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") '�^�C���X�^���v�i�o�^���ԁj

                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") '�^�C���X�^���v�i�o�^���j

            End With
        'End If

        '20190827 CHG END

        DSPYSN_SEARCH = 0

END_DSPYSN_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPYSN_SEARCH:
        GoTo END_DSPYSN_SEARCH

    End Function

    '20190628 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPUNTCD_SEARCH
    '   �T�v�F  �P�ʃ}�X�^����
    '   �����F  pin_strUNTCD�@�@ : �P�ʃR�[�h
    '   �@�@�@�@pot_DB_UNTMTA  �@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPUNTCD_SEARCH(ByVal pin_strUNTCD As String, ByRef pot_DB_UNTMTA As TYPE_DB_UNTMTA) As Short

        Dim strSQL As String
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPUNTCD_SEARCH

        DSPUNTCD_SEARCH = 9

        '20190628 CHG START
        'Call DB_UNTMTA_Clear(pot_DB_UNTMTA)
        Call InitDataCommon("UNTMTA")
        '20190628 CHG END

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from UNTMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and UNTCD   = '" & CF_Ora_Sgl(pin_strUNTCD) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPUNTCD_SEARCH = 1
            GoTo END_DSPUNTCD_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_UNTMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "") '�P�ʃR�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "") '�P�ʖ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            End With
        End If

        DSPUNTCD_SEARCH = 0

END_DSPUNTCD_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPUNTCD_SEARCH:
        GoTo END_DSPUNTCD_SEARCH

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPUNTNM_SEARCH
    '   �T�v�F  �P�ʃ}�X�^�����i�P�ʖ����j
    '   �����F  pin_strUNTNM�@�@ : �P�ʖ�
    '   �@�@�@�@pot_DB_UNTMTA  �@: ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPUNTNM_SEARCH(ByVal pin_strUNTNM As String, ByRef pot_DB_UNTMTA As TYPE_DB_UNTMTA) As Short

        Dim strSQL As String
        'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPUNTNM_SEARCH

        DSPUNTNM_SEARCH = 9

        '20190628 CHG START
        'Call DB_UNTMTA_Clear(pot_DB_UNTMTA)
        Call InitDataCommon("UNTMTA")
        '20190628 CHG END

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from UNTMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and UNTNM   = '" & CF_Ora_String(pin_strUNTNM, 4) & "' "

        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '�擾�f�[�^�Ȃ�
            DSPUNTNM_SEARCH = 1
            GoTo END_DSPUNTNM_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_UNTMTA
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '�폜�敪
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "") '�P�ʃR�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "") '�P�ʖ�
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '�A�g�t���O
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '�ŏI��Ǝ҃R�[�h
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") '�N���C�A���g�h�c
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '�^�C���X�^���v�i���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '�^�C���X�^���v�i���t�j
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") '�^�C���X�^���v�i�o�^���ԁj
                'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") '�^�C���X�^���v�i�o�^���j
            End With
        End If

        DSPUNTNM_SEARCH = 0

END_DSPUNTNM_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPUNTNM_SEARCH:
        GoTo END_DSPUNTNM_SEARCH

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPANID_SEARCH
    '   �T�v�F  �Č���񌟍�
    '   �����F  pin_strANID   : �Č�ID
    '           pot_DB_ANKNVIEW : ��������
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPANID_SEARCH(ByVal pin_strANID As String, ByRef pot_DB_ANKNVIEW As TYPE_DB_ANKNVIEW) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPANID_SEARCH

            '20190809 DEL START
            'DSPANID_SEARCH = 9

            'strSQL = ""
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from cszIncidentHanbai@HSODBC "
            'strSQL = strSQL & "  Where ""iIncidentid""   = " & CF_Get_CCurString(pin_strANID) & " "

            'Dim dt As DataTable = DB_GetTable(strSQL)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPANID_SEARCH = 1
            '    Exit Function
            'End If

            '''DB�A�N�Z�X
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''	'�擾�f�[�^�Ȃ�
            ''	DSPANID_SEARCH = 1
            ''	GoTo END_DSPANID_SEARCH
            ''End If

            ''�擾�f�[�^�ޔ�
            'With pot_DB_ANKNVIEW
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .ANKNID = DB_NullReplace(dt.Rows(0)("iIncidentid"), "") '�Č�ID
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .KKYKID = DB_NullReplace(dt.Rows(0)("iOwnerId"), "") '�ڋqID
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TOKRN = DB_NullReplace(dt.Rows(0)("CompanyName"), "") '��Њ�����
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .SYAINNM_L = DB_NullReplace(dt.Rows(0)("CustomerNameSei"), "") '�Ј�������
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .SYAINNM_F = DB_NullReplace(dt.Rows(0)("CustomerNameMei"), "") '�Ј�������
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .CATEGORY = DB_NullReplace(dt.Rows(0)("iIncidentCategory"), "") '�J�e�S��
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TKAFL = DB_NullReplace(dt.Rows(0)("iIncidentTypeId"), "") '���e����
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .KENNM = DB_NullReplace(dt.Rows(0)("vchDesc1"), "") '���e
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .STS = DB_NullReplace(dt.Rows(0)("iStatusId"), "") '�X�e�[�^�X
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .CODE1 = DB_NullReplace(dt.Rows(0)("iCode1"), "") '�����R�[�h�P
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .CODE2 = DB_NullReplace(dt.Rows(0)("iCode2"), "") '�����R�[�h�Q
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TANID = DB_NullReplace(dt.Rows(0)("chAssignedTo"), "") '�S����ID
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TANNM = DB_NullReplace(dt.Rows(0)("chAssignedName"), "") '�S���Җ�
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .KAKID = DB_NullReplace(dt.Rows(0)("vchUser1Id"), "") '�󒍋K��/�m�xID
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .KAKNM = DB_NullReplace(dt.Rows(0)("vchUser1"), "") '�󒍋K��/�m�x��
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .SBAUZKKN = DB_NullReplace(dt.Rows(0)("vchUser2"), "") '�󒍗\����z
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .JDNYTDT = DB_NullReplace(dt.Rows(0)("vchUser3"), "") '�󒍗\���
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .DEFNOKDT = DB_NullReplace(dt.Rows(0)("vchUser4"), "") '�\��[��
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .NHSNMA = DB_NullReplace(dt.Rows(0)("vchUser5"), "") '�[����
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .HINNMA = DB_NullReplace(dt.Rows(0)("vchUser6"), "") '��\�^��
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .ANSU = DB_NullReplace(dt.Rows(0)("vchUser7"), "") '����
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .MITNO = DB_NullReplace(dt.Rows(0)("vchUser8"), "") '����No
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .JDNNO = DB_NullReplace(dt.Rows(0)("vchUser9"), "") '��No
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .ANID_OYA = DB_NullReplace(dt.Rows(0)("vchUser10"), "") '�e�Č�ID
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .OPEID = DB_NullReplace(dt.Rows(0)("chInsertBy"), "") '�쐬��ID
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .WRTFSTTM = DB_NullReplace(dt.Rows(0)("dtInsertDate"), "") '�쐬����
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .UPDOPEID = DB_NullReplace(dt.Rows(0)("chUpdateBy"), "") '�X�V��ID
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .WRTTM = DB_NullReplace(dt.Rows(0)("dtUpdateDate"), "") '�X�V����
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .RECSTS = DB_NullReplace(dt.Rows(0)("tiRecordStatus"), "") '���R�[�h�X�e�[�^�X
            'End With
            '20190809 DEL END

            DSPANID_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPANID_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

        'END_DSPANID_SEARCH:
        '        '�N���[�Y
        '        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        '        Exit Function

        'ERR_DSPANID_SEARCH:
        '        GoTo END_DSPANID_SEARCH

    End Function
    '20190628 ADD START

    '20190701 ADD START

    ' === 20060920 === INSERT E

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function DSPMEIC_SEARCH
    '   �T�v�F  ���̃}�X�^����
    '   �����F  pin_strKEYCD  : �L�[�P
    '           pin_strMEICDA : �R�[�h�P
    '           pot_DB_MEIMTC : ��������
    '           pin_strMEICDB : �R�[�h�Q�i�ȗ����ꂽ�ꍇ�A���������Ɋ܂߂Ȃ��j
    '   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIC_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByVal pin_strTKDT As String, ByRef pot_DB_MEIMTC As TYPE_DB_MEIMTC, Optional ByVal pin_strMEICDB As Object = Nothing) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_DSPMEIC_SEARCH

        DSPMEIC_SEARCH = 9

        strSQL = ""
        '20190701 DEL START
        'strSQL = strSQL & " Select * "
        'strSQL = strSQL & "   from MEIMTC "
        '20190701 DEL END
        strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
        If IsNothing(pin_strMEICDB) = False Then
            'UPGRADE_WARNING: �I�u�W�F�N�g pin_strMEICDB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
        End If
        strSQL = strSQL & "   and  STTTKDT <= '" & pin_strTKDT & "' "
        strSQL = strSQL & "   and  ENDTKDT >= '" & pin_strTKDT & "' "

        'DB�A�N�Z�X
        ' 'change 20190405 START saiki
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        '      If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '	'�擾�f�[�^�Ȃ�
        '	DSPMEIC_SEARCH = 1
        '	GoTo END_DSPMEIC_SEARCH
        'End If

        ''�擾�f�[�^�ޔ�
        'Call DB_MEIMTC_SetData(Usr_Ody_LC, pot_DB_MEIMTC)


        'Dim dt As DataTable = DB_GetTable(strSQL)

        'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
        '    '�擾�f�[�^�Ȃ�
        '    DSPMEIC_SEARCH = 1
        '    GoTo END_DSPMEIC_SEARCH
        'End If

        'Call DB_MEIMTC_SetData(dt, pot_DB_MEIMTC, 0)
        'change 20190405 END saiki

        '20190701 ADD START
        GetRowsCommon("MEIMTC", strSQL)

        pot_DB_MEIMTC = DB_MEIMTC

        If pot_DB_MEIMTC.DATKB Is Nothing Then
            '�擾�f�[�^�Ȃ�
            DSPMEIC_SEARCH = 1
            GoTo END_DSPMEIC_SEARCH
        End If
        '20190701 ADD END


        DSPMEIC_SEARCH = 0

END_DSPMEIC_SEARCH:
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_DSPMEIC_SEARCH:

    End Function
    '20190701 ADD END


    '20190703 ADD START
    Function DELTRN() As Short
        'Dim PlStat As Long
        'Dim I%
        '    '
        '    ' PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���
        '    If G_PlCnd.nJobMode <> 2 Then Exit Function  'Delete�ȊO
        '    FR_SSSMAIN.Enabled = False
        '
        '    For I = 0 To MAX_CNDARR - 1
        '        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
        '        G_PlCnd.nCndNum(I) = I + 1
        '    Next I
        '
        '    G_PlCnd.sOpeID = SSS_OPEID
        '    G_PlCnd.sCltID = SSS_CLTID
        '
        '    G_PlInfo.FCnt = 2
        '    G_PlInfo.Fno(0) = DBN_JDNTRA
        '    G_PlInfo.RCnt(0) = 1
        '    G_PlInfo.ArrayFlg(0) = 1
        '    G_PlInfo.Fno(1) = DBN_JDNTHA
        '    G_PlInfo.RCnt(1) = 1
        '    G_PlInfo.ArrayFlg(1) = 0
        '
        '    DB_JDNTHA.JDNNO = RD_SSSMAIN_JDNNO(-1)
        '
        '    PlStat = DB_PlStart
        '    PlStat = DB_PlCndSet
        '    PlStat = DB_PlSet(DBN_JDNTHA, 0)
        '    PlStat = DB_PlSet(DBN_JDNTRA, 0)
        '
        '    Call DB_BeginTransaction(BTR_Exclude)
        '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_JDNTRA")
        '    If PlStat <> 0 And PlStat <> 1485 Then
        '        MsgBox "PL/SQL Error�F" & PlStat
        '        DELTRN = False
        '        DB_AbortTransaction
        '    Else
        '        DELTRN = True
        '        Call DB_EndTransaction
        '    End If
        '
        '    PlStat = DB_PlFree
        '
        '    FR_SSSMAIN.Enabled = True
    End Function

    Function WRTTRN() As Short
        'Dim I As Integer
        'Dim PlStat As Long
        '    '
        '    FR_SSSMAIN.Enabled = False
        '
        '    ' PL/SQL �Ή����Ұ� G_PlCnd.nJobMode �� SSSMAIN.ET1 �Őݒ肳���
        '
        '    For I = 0 To MAX_CNDARR - 1
        '        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
        '        G_PlCnd.nCndNum(I) = I + 1
        '    Next I
        '
        '    G_PlCnd.sOpeID = SSS_OPEID
        '    G_PlCnd.sCltID = SSS_CLTID
        '
        '    G_PlInfo.FCnt = 2
        '    G_PlInfo.Fno(0) = DBN_JDNTRA
        '    G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
        '    G_PlInfo.ArrayFlg(0) = 1
        '    G_PlInfo.Fno(1) = DBN_JDNTHA
        '    G_PlInfo.RCnt(1) = 1
        '    G_PlInfo.ArrayFlg(1) = 0
        '
        '    '
        '    Call JDNTHA_RClear
        '    Call JDNTHA_FromSCR(-1)
        '    DB_JDNTHA.DATKB = "1"
        '    DB_JDNTHA.DENKB = "1"
        '    DB_JDNTHA.JDNKB = "1"   '1999/10/19 Insert
        '    DB_JDNTHA.SMADT = SSS_SMADT
        '    '
        '    PlStat = DB_PlStart
        '    PlStat = DB_PlCndSet
        '    PlStat = DB_PlSet(DBN_JDNTHA, 0)
        '    I = 0
        '    Do While I < PP_SSSMAIN.LastDe
        '        Call JDNTRA_RClear
        '        Call Mfil_FromSCR(I)
        '        DB_JDNTRA.DATKB = "1"
        '        DB_JDNTRA.DENKB = "1"
        '        DB_JDNTRA.JDNKB = "1"   '1999/10/19 Insert
        '        DB_JDNTRA.SMADT = SSS_SMADT
        '        PlStat = DB_PlSet(DBN_JDNTRA, I)
        '        I = I + 1
        '    Loop
        '
        '    Call DB_BeginTransaction(BTR_Exclude)
        '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_JDNTRA")
        '    If PlStat <> 0 And PlStat <> 1485 Then
        '        MsgBox "PL/SQL Error�F" & PlStat
        '        WRTTRN = False
        '        DB_AbortTransaction
        '    Else
        '        WRTTRN = True
        '        Call DB_EndTransaction
        ''1998/05/12  �P�s�ǉ�
        '        Call DP_SSSMAIN_JDNNO(-1, G_PlCnd2.sCndStr(1))
        '    End If
        '
        '    PlStat = DB_PlFree
        '
        '    FR_SSSMAIN.Enabled = True
    End Function
    '20190703 ADD END

End Module