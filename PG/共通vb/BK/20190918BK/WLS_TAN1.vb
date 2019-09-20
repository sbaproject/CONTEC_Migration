Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class WLSTAN1
    Inherits System.Windows.Forms.Form
    '********************************************************************************
    '*  �V�X�e�����@�@�@�F  �V�������V�X�e��
    '*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
    '*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
    '*  �v���O�������@�@�F�@�S���Ҍ���
    '*  �v���O�����h�c�@�F  WLSTAN
    '*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
    '*  �쐬���@�@�@�@�@�F  2006.05.12
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD�@�F�@�C�����
    '*     �C����
    '********************************************************************************

    '************************************************************************************
    '   �\����
    '************************************************************************************
    Private Structure TYPE_DB_TANMTA_W
        Dim WK_DB_TANMTA As TYPE_DB_TANMTA
        ' === 20060828 === UPDATE S - ACE)Sejima
        'D        BMNNM               As String               '���喼
        ' === 20060828 === UPDATE ��
        Dim TANBMNNM As String '���喼
        Dim OLDBMNNM As String '���喼
        ' === 20060828 === UPDATE E
    End Structure
    '************************************************************************************
    '   Private�萔
    '************************************************************************************

    ' === 20060730 === UPDATE S - ACE)Nagasawa
    '    Private Const WM_WLSKEY_ZOKUSEI = "0"       '�J�n�R�[�h���͑��� [0,X]
    Private Const WM_WLSKEY_ZOKUSEI As String = "X" '�J�n�R�[�h���͑��� [0,X]
    ' === 20060730 === UPDATE E -

    '************************************************************************************
    '   Private�ϐ�
    '************************************************************************************
    '�E�B���hհ�ް�ݒ�ϐ�
    '20190619 chg start
    'Private WM_WLS_MFIL As Short '�E�B���h�\��Ҳ�̧��
    Private WM_WLS_MFIL As Object '�E�B���h�\��Ҳ�̧��
    '20190619 chg end
    Private WM_WLS_CODELEN As Short '�J�n���ޓ��͕�����
    Private WM_WLS_NAMELEN As Short '�S���Җ����͕�����
    ' === 20060830 === INSERT S - ACE)Sejima
    Private WM_WLS_BMNLEN As Short '���庰�ޓ��͕�����
    ' === 20060830 === INSERT E

    '�E�B���h�����g�p�ϐ�
    Private WM_WLS_MAX As Short '�P��ʂ̕\������
    Private WM_WLS_CODE As String '�S���҃R�[�h�����p
    Private WM_WLS_TANNM As String '�S���Җ������p
    Private WM_WLS_TANNK_S As String '�S���Җ��J�i�����p(�J�n)
    Private WM_WLS_TANNK_E As String '�S���Җ��J�i�����p(�I��)
    ' === 20060830 === INSERT S - ACE)Sejima
    Private WM_WLS_BMNCD As String '���庰�ތ����p
    ' === 20060830 === INSERT E
    Private WM_WLS_Pagecnt As Short '�E�B���h�\���y�[�W�J�E���^
    Private WM_WLS_LastPage As Short '�E�B���h�ŏI�y�[�W
    Private WM_WLS_LastFL As Boolean '�E�B���h�ŏI�f�[�^���B�t���O
    Private WM_WLS_DSPArray() As String '�E�B���h�\���f�[�^
    Private WM_WLS_Dspflg As Short '�E�B���h�\���׸�(True or False)

    Private DblClickFl As Boolean

    'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    'Private Usr_Ody As U_Ody '�ް��ް����ð���
    Private DB_TANMTA_W As TYPE_DB_TANMTA_W
    Private Dyn_Open As Boolean '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_FORM_INIT
    '   �T�v�F  ��ʏ�����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
        '=== �\���J�n�R�[�h�����ݒ� ===
        WM_WLS_CODELEN = 6
        ' === 20060830 === UPDATE S - ACE)Sejima
        'D        WM_WLS_NAMELEN = 40
        ' === 20060830 === UPDATE ��
        WM_WLS_NAMELEN = 20
        WM_WLS_BMNLEN = 6
        ' === 20060830 === UPDATE E
        WM_WLS_MAX = 15 '��ʕ\������
        '�ϐ�������
        WLSTAN_RTNCODE = ""
        Call WLS_Clear()
        Dyn_Open = False
        ' === 20060828 === INSERT S - ACE)Sejima
        '����i�K�p���j�̍Đݒ�i�n����Ȃ������ꍇ�A�^�p���t�j
        If Trim(WLSTAN_TANTKDT) = "" Then
            WLSTAN_TANTKDT = GV_UNYDate
        End If
        ' === 20060828 === INSERT E

    End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_SetArray
    '   �T�v�F  ���X�g�ҏW
    '   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Short)

        ' === 20060830 === UPDATE S - ACE)Sejima
        'D        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_TANMTA_W.WK_DB_TANMTA.TANCD, WM_WLS_CODELEN) & Space(6) & _
        ''D                                    LeftWid$(DB_TANMTA_W.WK_DB_TANMTA.TANNM, WM_WLS_NAMELEN) & Space(2) & _
        ''D                                    DB_TANMTA_W.BMNNM
        ' === 20060830 === UPDATE ��
        Dim strBMNNM As String

        strBMNNM = DB_TANMTA_W.TANBMNNM

        WM_WLS_DSPArray(ArrayCnt) = LeftWid(DB_TANMTA_W.WK_DB_TANMTA.TANCD, WM_WLS_CODELEN) & Space(13) & LeftWid(DB_TANMTA_W.WK_DB_TANMTA.TANNM, WM_WLS_NAMELEN) & Space(9) & strBMNNM
        ' === 20060830 === UPDATE E

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

        ' === 20060828 === UPDATE S - ACE)Sejima ����K�p���Ή�
        'D        strSQL = ""
        'D        strSQL = strSQL & " Select TANCD "          '�S���҃R�[�h
        'D        strSQL = strSQL & "      , TANNM "          '�S���Җ�
        'D        strSQL = strSQL & "      , TANBMNCD "       '��������R�[�h
        'D        strSQL = strSQL & "      , BMNNM "          '�������喼
        'D        strSQL = strSQL & "   from TANMTA, BMNMTA "
        'D' === 20060814 === UPDATE S - ACE)Nagasawa
        'D'        strSQL = strSQL & "  Where TANMTA.DATKB     = '1' "
        'D        strSQL = strSQL & "  Where TANMTA.DATKB     = '" & gc_strDATKB_USE & "' "
        'D' === 20060814 === UPDATE E -
        'D        strSQL = strSQL & "    and TANBMNCD         = BMNCD (+) "
        'D' === 20060814 === UPDATE S - ACE)Nagasawa
        'D'        strSQL = strSQL & "    and BMNMTA.DATKB (+) = '1' "
        'D        strSQL = strSQL & "    and BMNMTA.DATKB (+) = '" & gc_strDATKB_USE & "' "
        'D' === 20060814 === UPDATE E -
        ' === 20060828 === UPDATE ��
        strSQL = ""
        strSQL = strSQL & " Select TANCD         AS TANCD" '�S���҃R�[�h
        strSQL = strSQL & "      , TANNM         AS TANNM" '�S���Җ�
        strSQL = strSQL & "      , TANBMNCD      AS TANBMNCD" '��������R�[�h
        strSQL = strSQL & "      , BMN1.BMNNM    AS TANBMNNM" '�������喼
        strSQL = strSQL & "      , OLDBMNCD      AS OLDBMNCD" '��������R�[�h
        strSQL = strSQL & "      , BMN2.BMNNM    AS OLDBMNNM" '�������喼
        strSQL = strSQL & "      , TANTKDT       AS TANTKDT" '�K�p��
        ' === 20061207 === UPDATE S - ACE)Nagasawa ����/�󒍂ł͉c�ƒS���҂̂ݓ���
        '        strSQL = strSQL & "   from TANMTA, BMNMTA BMN1, BMNMTA BMN2"
        strSQL = strSQL & "   from TANWTA TANMTA, BMNMTA BMN1, BMNMTA BMN2"
        ' === 20061207 === UPDATE E -
        strSQL = strSQL & "  Where TANMTA.DATKB     = '" & gc_strDATKB_USE & "' "


        '' 2007/04/03  chg start  kumeda
        ''        strSQL = strSQL & "    and TANBMNCD         = BMN1.BMNCD (+) "
        strSQL = strSQL & "    and BMN1.BMNCD (+) = (CASE WHEN TANMTA.TANTKDT <= '" & WLSTAN_TANTKDT & "' THEN TANMTA.TANBMNCD ELSE TANMTA.OLDBMNCD END )"
        '' 2007/04/03  chg end


        strSQL = strSQL & "    and BMN1.DATKB (+) = '" & gc_strDATKB_USE & "' "
        ' === 20070403 === INSERT S - ACE)Nagasawa ����̓K�p���̍l����ǉ�
        If Trim(WLSTAN_TANTKDT) <> "" Then
            strSQL = strSQL & "  and BMN1.STTTKDT (+) <= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
            strSQL = strSQL & "  and BMN1.ENDTKDT (+) >= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
        Else
            strSQL = strSQL & "  and BMN1.STTTKDT (+) <= '" & CF_Ora_Date(GV_UNYDate) & "' "
            strSQL = strSQL & "  and BMN1.ENDTKDT (+) >= '" & CF_Ora_Date(GV_UNYDate) & "' "
        End If
        ' === 20070403 === INSERT E -
        strSQL = strSQL & "    and OLDBMNCD         = BMN2.BMNCD (+) "
        strSQL = strSQL & "    and BMN2.DATKB (+) = '" & gc_strDATKB_USE & "' "
        ' === 20070403 === INSERT S - ACE)Nagasawa ����̓K�p���̍l����ǉ�
        '�R�����g�͂���
        If Trim(WLSTAN_TANTKDT) <> "" Then
            strSQL = strSQL & "  and BMN2.STTTKDT (+) <= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
            strSQL = strSQL & "  and BMN2.ENDTKDT (+) >= '" & CF_Ora_Date(WLSTAN_TANTKDT) & "' "
        Else
            strSQL = strSQL & "  and BMN2.STTTKDT (+) <= '" & CF_Ora_Date(GV_UNYDate) & "' "
            strSQL = strSQL & "  and BMN2.ENDTKDT (+) >= '" & CF_Ora_Date(GV_UNYDate) & "' "
        End If
        ' === 20070403 === INSERT E -
        ' === 20060828 === UPDATE E
        ' === 20061204 === INSERT S - ACE)Nagasawa ����/�󒍂ł͉c�ƒS���҂̂ݕ\��
        If Trim(WLSTAN_TANCLAKB) = gc_strTANCLKB_EIGYO Then
            strSQL = strSQL & "    and (CASE WHEN TANMTA.TANTKDT <= '" & WLSTAN_TANTKDT & "' THEN TANCLAKB ELSE TANCLBKB END ) = '" & gc_strTANCLKB_EIGYO & "' "
        End If
        ' === 20061204 === INSERT E -

        '�S���҃R�[�h����
        If Trim(WM_WLS_CODE) <> "" Then
            ' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
            '            strSQL = strSQL & "    and TANCD >=   '" & WM_WLS_CODE & "'"
            strSQL = strSQL & "    and TANCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
            ' === 20080929 === UPDATE E -
        End If

        '�S���Җ�����(�����܂�����)
        If Trim(WM_WLS_TANNM) <> "" Then
            ' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
            '            strSQL = strSQL & "    and TANNM LIKE '%" & WM_WLS_TANNM & "%'"
            strSQL = strSQL & "    and TANNM LIKE '%" & CF_Ora_String(WM_WLS_TANNM, CF_Ctr_AnsiLenB(WM_WLS_TANNM)) & "%'"
            ' === 20080929 === UPDATE E -
        End If

        '�S���Җ��J�i����
        If Trim(WM_WLS_TANNK_S) <> "" Then
            strSQL = strSQL & "    and TANNK >= '" & WM_WLS_TANNK_S & "' And TANNK < '" & WM_WLS_TANNK_E & "'"
        End If

        ' === 20060830 === INSERT S - ACE)Sejima
        '�������庰�ތ���
        If Trim(WM_WLS_BMNCD) <> "" Then
            ' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
            '            strSQL = strSQL & "    and TANBMNCD = '" & WM_WLS_BMNCD & "'"
            strSQL = strSQL & "    and TANBMNCD = '" & CF_Ora_String(WM_WLS_BMNCD, CF_Ctr_AnsiLenB(WM_WLS_BMNCD)) & "'"
            ' === 20080929 === UPDATE E -
        End If
        ' === 20060830 === INSERT E

        '�\�[�g����
        strSQL = strSQL & "   order by "
        If Trim(WM_WLS_TANNK_S) <> "" Then
            ''�S���Җ��J�i�̏ꍇ
            ' === 20061207 === INSERT S - ACE)Nagasawa ����/�󒍂ł͉c�ƒS���҂̂ݓ���
            strSQL = strSQL & "   DSPORD "
            ' === 20061207 === INSERT E -
            strSQL = strSQL & "  ,TANNK "
            strSQL = strSQL & "  ,TANCD "
        Else
            '�S���҃R�[�h����
            ' === 20061207 === INSERT S - ACE)Nagasawa ����/�󒍂ł͉c�ƒS���҂̂ݓ���
            strSQL = strSQL & "   DSPORD "
            ' === 20061207 === INSERT E -
            strSQL = strSQL & "  ,TANCD "
        End If

        If Dyn_Open = True Then
            '�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        '20190319 CHG START
        'DB�A�N�Z�X
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        'dsList.Tables("tableName").Clear()
        DB_GetTable(strSQL)
        '20190319 CHG END

        Dyn_Open = True
        ' === 20060728 === INSERT S - ACE)Furukawa
        LST.Items.Clear()
        ' === 20060728 === INSERT E

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

        '20190319 CHG START 
        'Do Until CF_Ora_EOF(Usr_Ody) = True

        '	'�擾���e�ޔ�
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TANMTA_W.WK_DB_TANMTA.TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "") '�S���҃R�[�h
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TANMTA_W.WK_DB_TANMTA.TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "") '�S���Җ�
        '	' === 20060828 === UPDATE S - ACE)Sejima
        '	'D        DB_TANMTA_W.BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "")                     '�������喼
        '	' === 20060828 === UPDATE ��
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TANMTA_W.WK_DB_TANMTA.TANTKDT = CF_Ora_GetDyn(Usr_Ody, "TANTKDT", "") '�K�p��
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TANMTA_W.WK_DB_TANMTA.TANBMNCD = CF_Ora_GetDyn(Usr_Ody, "TANBMNCD", "") '��������R�[�h
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TANMTA_W.WK_DB_TANMTA.OLDBMNCD = CF_Ora_GetDyn(Usr_Ody, "OLDBMNCD", "") '����������R�[�h
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TANMTA_W.TANBMNNM = CF_Ora_GetDyn(Usr_Ody, "TANBMNNM", "") '�������喼
        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_TANMTA_W.OLDBMNNM = CF_Ora_GetDyn(Usr_Ody, "OLDBMNNM", "") '���������喼
        '	' === 20060828 === UPDATE E

        '	'�\�����y�[�W
        '	If Cnt Mod WM_WLS_MAX = 0 Then
        '		WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        '		ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
        '		Cnt = 0
        '		'�ŏI�y�[�W�ޔ�
        '		WM_WLS_LastPage = WM_WLS_Pagecnt
        '	End If

        '	'�\���������W�J
        '	Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)

        '	Cnt = Cnt + 1

        '	Call CF_Ora_MoveNext(Usr_Ody)

        '	If Cnt >= WM_WLS_MAX Then
        '		Exit Do
        '	End If
        'Loop 

        ''�ŏI�f�[�^���B
        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	WM_WLS_LastFL = True
        'End If

        For i As Integer = 0 To dsList.Tables("tableName").Rows.Count - 1
            '�擾���e�ޔ�
            DB_TANMTA_W.WK_DB_TANMTA.TANCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TANCD"), "") '�S���҃R�[�h
            DB_TANMTA_W.WK_DB_TANMTA.TANNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TANNM"), "") '�S���Җ�
            DB_TANMTA_W.WK_DB_TANMTA.TANTKDT = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TANTKDT"), "") '�K�p��
            DB_TANMTA_W.WK_DB_TANMTA.TANBMNCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TANBMNCD"), "") '��������R�[�h
            DB_TANMTA_W.WK_DB_TANMTA.OLDBMNCD = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("OLDBMNCD"), "") '����������R�[�h
            DB_TANMTA_W.TANBMNNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("TANBMNNM"), "") '�������喼
            DB_TANMTA_W.OLDBMNNM = DB_NullReplace(dsList.Tables("tableName").Rows(i).Item("OLDBMNNM"), "") '���������喼
            ' === 20060828 === UPDATE E

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

            'If Cnt >= WM_WLS_MAX Then
            '    Exit For
            'End If
        Next

        WM_WLS_LastFL = True
        '20190319 CHG END 

        If Cnt > 0 Then
            '�y�[�W��\��
            WM_WLS_Pagecnt = 0
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
        WM_WLS_TANNM = ""
        WM_WLS_TANNK_S = ""
        WM_WLS_TANNK_E = ""
        ' === 20060830 === INSERT S - ACE)Sejima
        WM_WLS_BMNCD = ""
        ' === 20060830 === INSERT E

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
    'UPGRADE_WARNING: Form �C�x���g WLSTAN.Activate �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
    Private Sub WLSTAN_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        '20190529 DEL START
        ''WINDOW �ʒu�ݒ�
        'Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        'Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        'WM_WLS_Dspflg = False

        ''���ڏ�����
        'Call WLS_Kana_Init()
        'HD_CODE.Text = ""
        'HD_NAME.Text = ""
        '' === 20060830 === INSERT S - ACE)Sejima
        'HD_BMNCD.Text = ""
        '' === 20060830 === INSERT E
        'WLSKANA.SelectedIndex = 0
        'LST.Items.Clear()
        'WM_WLS_Dspflg = True

        'ReDim WM_WLS_DSPArray(0)

        ''������ԑS���\��
        'Call WLS_TextSQL()
        'Call WLS_DspNew()

        'DblClickFl = False

        'Me.Refresh()
        '' === 20060821 === UPDATE S - ACE)Nagasawa
        ''        HD_CODE.SetFocus
        '' === 20061228 === INSERT S - ACE)Nagasawa
        'On Error Resume Next
        '' === 20061228 === INSERT E -
        'LST.Focus()
        '' === 20060821 === UPDATE E -
        '20190529 DEL END

    End Sub

    Private Sub WLSTAN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Window�����ݒ�
        Call WLS_FORM_INIT()

        '20190529 ADD START
        'WINDOW �ʒu�ݒ�
        Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
        Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)

        WM_WLS_Dspflg = False

        '���ڏ�����
        Call WLS_Kana_Init()
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        ' === 20060830 === INSERT S - ACE)Sejima
        HD_BMNCD.Text = ""
        ' === 20060830 === INSERT E
        WLSKANA.SelectedIndex = 0
        LST.Items.Clear()
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

        '������ԑS���\��
        Call WLS_TextSQL()
        Call WLS_DspNew()

        DblClickFl = False

        Me.Refresh()
        ' === 20060821 === UPDATE S - ACE)Nagasawa
        '        HD_CODE.SetFocus
        ' === 20061228 === INSERT S - ACE)Nagasawa
        On Error Resume Next
        ' === 20061228 === INSERT E -
        LST.Focus()
        ' === 20060821 === UPDATE E -
        '20190529 ADD END

    End Sub

    '20190530 ADD START
    Private Sub WLSSOU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.btnF1.PerformClick()

                Case Keys.F2
                    Me.btnF2.PerformClick()

                Case Keys.F7
                    Me.btnF7.PerformClick()

                Case Keys.F8
                    Me.btnF8.PerformClick()

                Case Keys.F9
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try

    End Sub
    '20190530 ADD END

    ' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock���͑Ή�
    Private Sub HD_BMNCD_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_BMNCD.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    ' === 20070206 === UPDATE E -

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
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False
            'UPGRADE_WARNING: TextBox �v���p�e�B HD_CODE.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
            HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.Maxlength, WM_WLSKEY_ZOKUSEI)

            '�����p�ϐ��Z�b�g
            Call WLS_Clear()
            WM_WLS_CODE = HD_CODE.Text

            '�����������N���A
            WLSKANA.SelectedIndex = 0
            HD_NAME.Text = ""
            WM_WLS_Dspflg = True

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    ' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock���͑Ή�
    Private Sub HD_CODE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles HD_CODE.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)

        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
    ' === 20070206 === UPDATE E -

    Private Sub HD_NAME_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_NAME.Enter
        '---------- 20061019 ACE MENTE START ----------
        '   If LenWid(HD_NAME.Text) <= 0 Then
        '       HD_NAME.Text = Space$(HD_NAME.MaxLength)
        '   End If
        '---------- 20061019 ACE MENTE E N D ----------
        HD_NAME.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_NAME.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_NAME.SelectionLength = HD_NAME.Maxlength
    End Sub

    Private Sub HD_NAME_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_NAME.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False

            '�����p�ϐ��Z�b�g
            Call WLS_Clear()
            WM_WLS_TANNM = HD_NAME.Text

            '�����������N���A
            WLSKANA.SelectedIndex = 0
            HD_CODE.Text = ""
            WM_WLS_Dspflg = True

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub

    ' === 20060830 === INSERT S - ACE)Sejima
    Private Sub HD_BMNCD_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HD_BMNCD.Enter
        '---------- 20061019 ACE MENTE START ----------
        '   If LenWid(HD_BMNCD.Text) <= 0 Then
        '       HD_BMNCD.Text = Space$(HD_BMNCD.MaxLength)
        '   End If
        '---------- 20061019 ACE MENTE E N D ----------
        HD_BMNCD.SelectionStart = 0
        'UPGRADE_WARNING: TextBox �v���p�e�B HD_BMNCD.MaxLength �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        HD_BMNCD.SelectionLength = HD_BMNCD.Maxlength
    End Sub

    Private Sub HD_BMNCD_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles HD_BMNCD.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = False

            '�����p�ϐ��Z�b�g
            Call WLS_Clear()
            WM_WLS_BMNCD = HD_BMNCD.Text

            '�����������N���A
            WLSKANA.SelectedIndex = 0
            HD_CODE.Text = ""
            WM_WLS_Dspflg = True

            Call WLS_TextSQL()
            Call WLS_DspNew()
        End If
    End Sub
    ' === 20060830 === INSERT E

    Private Sub LST_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles LST.DoubleClick

        DblClickFl = True
        WLSTAN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)

    End Sub

    Private Sub LST_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles LST.MouseUp
        Dim Button As Short = eventArgs.Button \ &H100000
        Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
        Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
        Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)

        '20190530 CHG START
        'If DblClickFl Then Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
        If DblClickFl Then Call btnF12_Click(btnF12, New System.EventArgs())
        '20190530 CHG END

    End Sub

    Private Sub LST_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles LST.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        Select Case KeyCode
            'Enter�L�[����
            Case System.Windows.Forms.Keys.Return
                '20190530 CHG START
                'Call WLSOK_Click(WLSOK, New System.EventArgs())
                Call btnF1_Click(btnF1, New System.EventArgs())
                '20190530 CHG END

                'Escape�L�[����
            Case System.Windows.Forms.Keys.Escape
                '20190530 CHG START
                'Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())
                Call btnF12_Click(btnF12, New System.EventArgs())
                '20190530 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Left
                '20190530 CHG START
                'Call WLSMAE_Click(WLSMAE, New System.EventArgs())
                Call btnF7_Click(btnF7, New System.EventArgs())
                '20190530 CHG END

                '���L�[����
            Case System.Windows.Forms.Keys.Right
                '20190530 CHG START
                'Call WLSATO_Click(WLSATO, New System.EventArgs())
                Call btnF8_Click(btnF8, New System.EventArgs())
                '20190530 CHG END

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
            WM_WLS_TANNK_S = VB.Left(W_BUF, 1)
            'UPGRADE_WARNING: �I�u�W�F�N�g W_BUF �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            WM_WLS_TANNK_E = Chr(Asc(VB.Right(W_BUF, 1)) + 1)
        End If

        '�����������N���A
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL()
        Call WLS_DspNew()

    End Sub

    Private Sub WLSKANA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles WLSKANA.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then
            WM_WLS_Dspflg = True
            Call WLSKANA_SelectedIndexChanged(WLSKANA, New System.EventArgs())
        Else
            WM_WLS_Dspflg = False
        End If
    End Sub

    '20190530 CHG START
    'Private Sub WLSATO_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSATO.Click

    '    If LST.Items.Count <= 0 Then Exit Sub

    '    ' === 20060728 === DELETE S - ACE)Furukawa
    '    '    Call WLS_DspNew
    '    ' === 20060728 === DELETE E

    '    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
    '        ' === 20060728 === UPDATE S - ACE)Furukawa
    '        'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
    '        ' === 20060728 === UPDATE ��
    '        If Not WM_WLS_LastFL Then Call WLS_DspNew()
    '        ' === 20060728 === UPDATE E
    '    Else
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
    '        Call WLS_DspPage()
    '    End If
    'End Sub

    'Private Sub WLSATO_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSATO.Image = IM_ATO(1).Image
    'End Sub

    'Private Sub WLSATO_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSATO.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSATO.Image = IM_ATO(0).Image
    'End Sub

    Private Sub btnF8_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF8.Click

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
    '20190530 CHG END

    '20190530 ADD START
    Private Sub btnF2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF2.Click
        Dim li_MsgRtn As Integer

        Try
            If Me.HD_NAME.Focused Then
                Call HD_NAME_KeyDown(HD_NAME, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            ElseIf Me.HD_BMNCD.Focused Then
                Call HD_BMNCD_KeyDown(HD_BMNCD, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            Else
                Call HD_CODE_KeyDown(HD_CODE, New System.Windows.Forms.KeyEventArgs(Keys.Return))
            End If

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʌ����G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    Private Sub btnF9_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF9.Click
        Dim li_MsgRtn As Integer

        Try
            WLS_Clear()
            Me.HD_CODE.Text = ""
            Me.HD_NAME.Text = ""
            Me.HD_BMNCD.Text = ""
            LST.Items.Clear()
            Me.HD_CODE.Focus()

        Catch ex As Exception
            li_MsgRtn = MsgBox("��ʃN���A�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub
    '20190530 ADD END


    '20190530 CHG START
    'Private Sub WLSMAE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSMAE.Click
    '    If WM_WLS_Pagecnt > 0 Then
    '        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
    '        Call WLS_DspPage()
    '    End If
    'End Sub

    'Private Sub WLSMAE_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseDown
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSMAE.Image = IM_MAE(1).Image
    'End Sub

    'Private Sub WLSMAE_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles WLSMAE.MouseUp
    '    Dim Button As Short = eventArgs.Button \ &H100000
    '    Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
    '    Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
    '    Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
    '    WLSMAE.Image = IM_MAE(0).Image
    'End Sub

    Private Sub btnF7_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF7.Click
        If WM_WLS_Pagecnt > 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
            Call WLS_DspPage()
        End If
    End Sub
    '20190530 CHG END

    '20190530 CHG START
    'Private Sub WLSOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSOK.Click

    '    WLSTAN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
    '    Call WLSCANCEL_Click(WLSCANCEL, New System.EventArgs())

    'End Sub

    'Private Sub WLSCANCEL_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WLSCANCEL.Click

    '    If Dyn_Open = True Then
    '        '�N���[�Y
    '        'Call CF_Ora_CloseDyn(Usr_Ody)
    '        Dyn_Open = False
    '    End If

    '    Hide()
    'End Sub

    Private Sub btnF1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF1.Click

        WLSTAN_RTNCODE = LeftWid(VB6.GetItemString(LST, LST.SelectedIndex), WM_WLS_CODELEN)
        Call btnF12_Click(btnF12, New System.EventArgs())

    End Sub

    Private Sub btnF12_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnF12.Click

        If Dyn_Open = True Then
            '�N���[�Y
            'Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If

        Hide()
    End Sub
    '20190530 CHG END

End Class