Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D

Module AUTHORITY_DBM
	'//*****************************************************************************************
	'//*
	'//*�����́�
	'//*    AUTHORI.bas
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    RISE
	'//*��������
	'//*    �V�X�e���֘A�E���ʃ��W���[���i�v���O�����̎��s�������擾�j
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20070110|Rise)          |���ʃv���O�����̎��s�����̎擾���W���[�����쐬
	'//*****************************************************************************************
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
		
		'�ϐ��錾
		Dim ls_sql As String
		'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/19 DEL START
        'Dim objRec As OraDynaset
        '2019/04/19 DEL E N D

		'�����l�͑S�����Ȃ�
		gs_UPDAUTH = "9" '�X�V����
		gs_PRTAUTH = "9" '�������
		gs_FILEAUTH = "9" '�t�@�C���o�͌���
		gs_SALTAUTH = "9" '�̔��P���ύX����
		gs_HDNTAUTH = "9" '�����P���ύX����
		gs_SAPMAUTH = "9" '�̔��v��N���v��C������
		
		'���[�UID�������������擾����
		ls_sql = "  SELECT "
		ls_sql = ls_sql & " K.UPDAUTH,"
		ls_sql = ls_sql & " K.PRTAUTH,"
		ls_sql = ls_sql & " K.FILEAUTH,"
		ls_sql = ls_sql & " K.SALTAUTH,"
		ls_sql = ls_sql & " K.HDNTAUTH,"
		ls_sql = ls_sql & " K.SAPMAUTH "
		ls_sql = ls_sql & " FROM KNGMTB K,TANMTA T "
		'ls_sql = ls_sql & " WHERE K.KNGGRCD = T.KNGGRCD "
		ls_sql = ls_sql & " WHERE K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END) "
		ls_sql = ls_sql & "   AND T.TANCD   = '" & gs_userid & "'"
		ls_sql = ls_sql & "   AND K.PGID    = '" & gs_pgid & "'"
		ls_sql = ls_sql & "   AND K.DATKB   = '1'"
		ls_sql = ls_sql & "   AND T.DATKB    = '1'"
		
		'UPGRADE_WARNING: Get_Authority �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

        '2019/04/19 ADD START
        Dim dt As DataTable = DB_GetTable(ls_sql)
        '2019/04/19 ADD E N D

        'UPGRADE_WARNING: Get_Authority �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

        '2019/04/19 ADD START
        '20190703 CHG START
       ' If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
       '     '�擾�f�[�^�Ȃ��̏ꍇ�͌����Ȃ��Ƃ݂Ȃ��B
       '     Get_Authority = 9
       ' Else
       '     For Each row As DataRow In dt.Rows
       '         gs_UPDAUTH = D0.Chk_Null(row("UPDAUTH"))     '�X�V����
       '         gs_PRTAUTH = D0.Chk_Null(row("PRTAUTH"))     '�������
       '         gs_FILEAUTH = D0.Chk_Null(row("FILEAUTH"))   '�t�@�C���o�͌���
       '         gs_SALTAUTH = D0.Chk_Null(row("SALTAUTH"))   '�̔��P���ύX����
       '         gs_HDNTAUTH = D0.Chk_Null(row("HDNTAUTH"))   '�����P���ύX����
       '         gs_SAPMAUTH = D0.Chk_Null(row("SAPMAUTH"))   '�̔��v��N���v��C������
       '     Next
       '     Get_Authority = 1
       ' End If
        
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            Get_Authority = CStr(9)
        Else
            gs_UPDAUTH = DB_NullReplace(dt.Rows(0).Item("UPDAUTH"), "")
            gs_PRTAUTH = DB_NullReplace(dt.Rows(0).Item("PRTAUTH"), "")
            gs_FILEAUTH = DB_NullReplace(dt.Rows(0).Item("FILEAUTH"), "")
            gs_SALTAUTH = DB_NullReplace(dt.Rows(0).Item("SALTAUTH"), "")
            gs_HDNTAUTH = DB_NullReplace(dt.Rows(0).Item("HDNTAUTH"), "")
            gs_SAPMAUTH = DB_NullReplace(dt.Rows(0).Item("SAPMAUTH"), "")

            Get_Authority = CStr(1)
        End If
        '20190703 CHG END
        '2019/04/19 ADD E N D

		If ec_CRW Is Nothing Then
		Else
			If gs_PRTAUTH = "1" Then
				'�������������ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowPrintBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ec_CRW.WindowShowPrintBtn = True '����{�^��
			Else
				'��������������ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowPrintBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ec_CRW.WindowShowPrintBtn = False '����{�^��
			End If
			If gs_FILEAUTH = "1" Then
				'�G�N�X�|�[�g����������ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowExportBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ec_CRW.WindowShowExportBtn = True '�G�N�X�|�[�g�{�^��
			Else
				'�G�N�X�|�[�g�����������ꍇ
				'UPGRADE_WARNING: �I�u�W�F�N�g ec_CRW.WindowShowExportBtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ec_CRW.WindowShowExportBtn = False '�G�N�X�|�[�g�{�^��
			End If
		End If
		
	End Function
End Module