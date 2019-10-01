Option Strict Off
Option Explicit On
Module AUTHORITY_DBM
	Public gs_kengen As String
	Public gs_ari As String
	Public gs_userid As String
	Public gs_pgid As String
	Public gs_UPDAUTH As String
	Public gs_PRTAUTH As String
	Public gs_FILEAUTH As String
	Public gs_SALTAUTH As String
	Public gs_HDNTAUTH As String
	Public gs_SAPMAUTH As String
	
	'**************************************************************************************************
	'�v���V�W����   �FGet_Authority
	'�����T�v       �F�v���O�����̎��s�������擾����
	'                 CrystalReport�̃v���r���[��ʂ̈���{�^�������[�U�����ɂ���Đ��䂷��
	'����   �P�Fec_DATE(�S���҂̓K�p���𔻒f������t)
	'       �Q�Fec_CRW(CrystalReport�R���g���[����) �I�v�V����
	'�ߒl   1�F�����}�X�^�Ƀf�[�^�L��
	'       9�F�����}�X�^�Ƀf�[�^�Ȃ�
	'**************************************************************************************************
	Public Function Get_Authority(ByRef ec_DATE As String, Optional ByRef ec_CRW As Object = Nothing) As String
        '2019.04.22 del start ��
		'�ϐ��錾
        'Dim ls_sql As String
        ''UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
        'Dim Usr_Ody As U_Ody

        ''�����l�͑S�����Ȃ�
        'gs_UPDAUTH = "9" '�X�V����
        'gs_PRTAUTH = "9" '�������
        'gs_FILEAUTH = "9" '�t�@�C���o�͌���
        'gs_SALTAUTH = "9" '�̔��P���ύX����
        'gs_HDNTAUTH = "9" '�����P���ύX����
        'gs_SAPMAUTH = "9" '�̔��v��N���v��C������

        ''���[�UID�������������擾����
        'ls_sql = "  SELECT "
        'ls_sql = ls_sql & " K.UPDAUTH,"
        'ls_sql = ls_sql & " K.PRTAUTH,"
        'ls_sql = ls_sql & " K.FILEAUTH,"
        'ls_sql = ls_sql & " K.SALTAUTH,"
        'ls_sql = ls_sql & " K.HDNTAUTH,"
        'ls_sql = ls_sql & " K.SAPMAUTH "
        'ls_sql = ls_sql & " FROM KNGMTB K,TANMTA T "
        ''ls_sql = ls_sql & " WHERE K.KNGGRCD = T.KNGGRCD "
        'ls_sql = ls_sql & " WHERE K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END) "
        'ls_sql = ls_sql & "   AND T.TANCD   = '" & gs_userid & "'"
        'ls_sql = ls_sql & "   AND K.PGID    = '" & gs_pgid & "'"
        'ls_sql = ls_sql & "   AND K.DATKB   = '1'"
        'ls_sql = ls_sql & "   AND T.DATKB    = '1'"

        '      '2019.04.22 chg start
        '      'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
        '      Call DB_GetSQL2(DBN_KNGMTB, ls_sql)
        '      '2019.04.22 chg end

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	'�擾�f�[�^�Ȃ��̏ꍇ�͌����Ȃ��Ƃ݂Ȃ��B
        '	Get_Authority = CStr(9)
        'Else
        '	Do Until CF_Ora_EOF(Usr_Ody) = True
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "") '�X�V����
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "") '�������
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "") '�t�@�C���o�͌���
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "") '�̔��P���ύX����
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "") '�����P���ύX����
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "") '�̔��v��N���v��C������
        '              '�����R�[�h
        '              '2019.04.22 chg start
        '              'Call CF_Ora_MoveNext(Usr_Ody)
        '              Call DB_GetNext(DBN_KNGMTB, BtrNormal)
        '              '2019.04.22 chg end
        '	Loop 
        '	Get_Authority = CStr(1)
        'End If

        'If ec_CRW Is Nothing Then
        'Else
        '	If gs_PRTAUTH = "1" Then
        '		'�������������ꍇ
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowPrintBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		ec_CRW.WindowShowPrintBtn = True '����{�^��
        '	Else
        '		'��������������ꍇ
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowPrintBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		ec_CRW.WindowShowPrintBtn = False '����{�^��
        '	End If
        '	If gs_FILEAUTH = "1" Then
        '		'�G�N�X�|�[�g����������ꍇ
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowExportBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		ec_CRW.WindowShowExportBtn = True '�G�N�X�|�[�g�{�^��
        '	Else
        '		'�G�N�X�|�[�g�����������ꍇ
        '		'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowExportBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		ec_CRW.WindowShowExportBtn = False '�G�N�X�|�[�g�{�^��
        '	End If
        'End If
        '2019.04.22 del end
	End Function
End Module