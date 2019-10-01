Option Strict Off
Option Explicit On
Module SSSEXC_BAS
	
	'Private Main_Inf                    As Cls_All
	
	'**************************************************************************************************
	'�v���V�W����   �F
	'�����T�v       �F�Ɩ��r�����䃂�W���[��
	'����
	'
	'�ߒl
	'
	'**************************************************************************************************
	
	Public Function SSSEXC_EXCTBZ_OPEN() As Object

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        If GET_EXCTBZ(SSS_CLTID.Value, SSS_PrgId) = 9 Then
			If INS_EXCTBZ(SSS_CLTID.Value, SSS_PrgId, VB6.Format(Now, "hhnnss"), gc_strMsgEXCTBZ_ERROR) = 9 Then Exit Function
		Else
			If UPD_EXCTBZ(SSS_CLTID.Value, SSS_PrgId, VB6.Format(Now, "hhnnss"), gc_strMsgEXCTBZ_ERROR) = 9 Then Exit Function
		End If

        '2019/04/17 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/17 CHG E N D

    End Function
	
	Public Function SSSEXC_EXCTBZ_CLOSE() As Object

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        If GET_EXCTBZ(SSS_CLTID.Value, SSS_PrgId) = 9 Then
		Else
			If DEL_EXCTBZ(SSS_CLTID.Value, SSS_PrgId, gc_strMsgEXCTBZ_ERROR) = 9 Then Exit Function
		End If

        '2019/04/17 CHG START
        'Call CF_Ora_CommitTraKns(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/17 CHG E N D

    End Function
	
	Function SSSEXC_EXCTBZ_CHECK() As String
		'�r���`�F�b�N�G���[�iLink_Shell�֐��͖߂�l "9" ���G���[�j
		'             "1"           : ����.
		'             "9" & �Ɩ���  : �r��.
		
		SSSEXC_EXCTBZ_CHECK = GET_GYMTBZ_CHECK(SSS_PrgId)
		
		
		''''Call DB_GetGrEq(DBN_GYMTBZ, 2, SSS_PrgId, BtrNormal)
		''''Do While (DBSTAT = 0) And _
		'''''         (Trim(DB_GYMTBZ.NGGYMCD) = Trim(SSS_PrgId)) And _
		'''''         (SSSEXC_EXCTBZ_CHECK = "1")
		''''
		''''    Call DB_GetEq(DBN_EXCTBZ, 2, DB_GYMTBZ.GYMCD, BtrNormal)
		''''    If DBSTAT = 0 Then
		''''        SSSEXC_EXCTBZ_CHECK = "9" & DB_GYMTBZ.GYMNM
		''''    End If
		''''    Call DB_GetNext(DBN_GYMTBZ, BtrNormal)
		''''
		''''Loop
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function GET_EXCTBZ
	'   �T�v�F  �r���e�[�u������
	'   �����F  pin_CLTID    : �N���C�A���g�h�c
	'       �F  pin_GYMCD    : �Ɩ��R�[�h
	'   �ߒl�F  0:����I�� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_EXCTBZ(ByVal pin_CLTID As String, ByVal pin_GYMCD As String) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo GET_EXCTBZ_ERROR
		
		GET_EXCTBZ = 9
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From EXCTBZ"
		strSql = strSql & vbCrLf & " Where CLTID    = " & "'" & pin_CLTID & "'"
		strSql = strSql & vbCrLf & "   And GYMCD    = " & "'" & pin_GYMCD & "'"

        'DB�A�N�Z�X
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	GET_EXCTBZ = 0

        '	GoTo GET_EXCTBZ_END
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            GET_EXCTBZ = 0

            GoTo GET_EXCTBZ_END

        End If
        '2019/04/23 CHG E N D

GET_EXCTBZ_END:
        '�N���[�Y
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
GET_EXCTBZ_ERROR: 
		GoTo GET_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function UPD_EXCTBZ
	'   �T�v�F  �r���e�[�u���X�V
	'   �����F  pin_strCLTID : �N���C�A���g�h�c
	'       �F  pin_strGYMCD : �Ɩ��R�[�h
	'       �F  pin_strLCKTM : ����
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UPD_EXCTBZ(ByVal pin_strCLTID As String, ByVal pin_strGYMCD As String, ByVal pin_strLCKTM As String, ByVal pin_strErrNo As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo UPD_EXCTBZ_ERROR
		
		UPD_EXCTBZ = 9
		
		'�r���e�[�u���X�V
		strSql = ""
		strSql = strSql & vbCrLf & "Update EXCTBZ Set"
		strSql = strSql & vbCrLf & " LCKTM = " & "'" & pin_strLCKTM & "'" '����
		strSql = strSql & vbCrLf & " Where CLTID  = " & "'" & pin_strCLTID & "'"
		strSql = strSql & vbCrLf & "   And GYMCD  = " & "'" & pin_strGYMCD & "'"

        'SQL���s
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo UPD_EXCTBZ_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        UPD_EXCTBZ = 0
		
UPD_EXCTBZ_END: 
		Exit Function
		
UPD_EXCTBZ_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, pin_strErrNo, Main_Inf, "UPD_EXCTBZ")
		GoTo UPD_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function INS_EXCTBZ
	'   �T�v�F  �r���e�[�u���ǉ�
	'   �����F  pin_strCLTID : �N���C�A���g�h�c
	'       �F  pin_strGYMCD : �Ɩ��R�[�h
	'       �F  pin_strLCKTM : ����
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function INS_EXCTBZ(ByVal pin_strCLTID As String, ByVal pin_strGYMCD As String, ByVal pin_strLCKTM As String, ByVal pin_strErrNo As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo INS_EXCTBZ_ERROR
		
		INS_EXCTBZ = 9
		
		'�r���e�[�u���ǉ�
		strSql = ""
		strSql = strSql & vbCrLf & "Insert Into EXCTBZ"
		strSql = strSql & vbCrLf & "(CLTID"
		strSql = strSql & vbCrLf & ",GYMCD"
		strSql = strSql & vbCrLf & ",LCKTM"
		strSql = strSql & vbCrLf & ",SEQNO"
		strSql = strSql & vbCrLf & ",INTLCD"
		strSql = strSql & vbCrLf & ",EXTCD)"
		strSql = strSql & vbCrLf & " Values"
		strSql = strSql & vbCrLf & "(" & "'" & pin_strCLTID & "'" '�N���C�A���g�h�c
		strSql = strSql & vbCrLf & "," & "'" & pin_strGYMCD & "'" '�Ɩ��R�[�h
		strSql = strSql & vbCrLf & "," & "'" & pin_strLCKTM & "'" '����
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '�A��
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '�����R�[�h
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '�O���R�[�h
		strSql = strSql & vbCrLf & ")"

        'SQL���s
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo INS_EXCTBZ_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        INS_EXCTBZ = 0
		
INS_EXCTBZ_END: 
		Exit Function
		
INS_EXCTBZ_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, pin_strErrNo, Main_Inf, "INS_EXCTBZ")
		GoTo INS_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DEL_EXCTBZ
	'   �T�v�F  �r���e�[�u���폜
	'   �����F  pin_strCLTID : �N���C�A���g�h�c
	'       �F  pin_strGYMCD : �Ɩ��R�[�h
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DEL_EXCTBZ(ByVal pin_strCLTID As String, ByVal pin_strGYMCD As String, ByVal pin_strErrNo As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo DEL_EXCTBZ_ERROR
		
		DEL_EXCTBZ = 9
		
		strSql = ""
		strSql = strSql & vbCrLf & "Delete From EXCTBZ"
		strSql = strSql & vbCrLf & " Where CLTID  = " & "'" & pin_strCLTID & "'"
		strSql = strSql & vbCrLf & "   And GYMCD  = " & "'" & pin_strGYMCD & "'"

        'SQL���s
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo DEL_EXCTBZ_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D
        DEL_EXCTBZ = 0
		
DEL_EXCTBZ_END: 
		Exit Function
		
DEL_EXCTBZ_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, pin_strErrNo, Main_Inf, "DEL_EXCTBZ")
		GoTo DEL_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function GET_GYMTBZ_CHECK
	'   �T�v�F  �Ɩ�����e�[�u������
	'   �����F  pin_NGGYMCD : �Ɩ��R�[�h
	'   �ߒl�F  1:����I�� 9:�r���K�v
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_GYMTBZ_CHECK(ByVal pin_NGGYMCD As String) As String
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strGYMCD As String
		
		On Error GoTo GET_GYMTBZ_CHECK_ERROR
		
		GET_GYMTBZ_CHECK = "1"
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From GYMTBZ"
		strSql = strSql & vbCrLf & " Where NGGYMCD  = " & "'" & pin_NGGYMCD & "'"

        'DB�A�N�Z�X
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'Do While CF_Ora_EOF(Usr_Ody) = False

        '	'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	strGYMCD = CF_Ora_GetDyn(Usr_Ody, "GYMCD", "")
        '	If GET_EXCTBZ_2(strGYMCD) = 0 Then
        '		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		GET_GYMTBZ_CHECK = "9" & CF_Ora_GetDyn(Usr_Ody, "GYMNM", "")
        '		Exit Do
        '	End If

        '	'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody.Obj_Ody.MoveNext �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	Usr_Ody.Obj_Ody.MoveNext()
        'Loop

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                strGYMCD = DB_NullReplace(dt.Rows(i)("GYMCD"), "")
                If GET_EXCTBZ_2(strGYMCD) = 0 Then
                    GET_GYMTBZ_CHECK = "9" & DB_NullReplace(dt.Rows(i)("GYMNM"), "")
                    Exit For
                End If
            Next
        End If
        '2019/04/23 CHG E N D

GET_GYMTBZ_CHECK_END:
        '�N���[�Y
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
GET_GYMTBZ_CHECK_ERROR: 
		GoTo GET_GYMTBZ_CHECK_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function GET_EXCTBZ_2
	'   �T�v�F  �r���e�[�u������
	'   �����F  pin_GYMCD    : �Ɩ��R�[�h
	'   �ߒl�F  0:����I�� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_EXCTBZ_2(ByVal pin_GYMCD As String) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo GET_EXCTBZ_2_ERROR
		
		GET_EXCTBZ_2 = 9
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From EXCTBZ"
		strSql = strSql & vbCrLf & " Where GYMCD    = " & "'" & pin_GYMCD & "'"

        'DB�A�N�Z�X
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	GET_EXCTBZ_2 = 0

        '	GoTo GET_EXCTBZ_2_END
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            GET_EXCTBZ_2 = 0

            GoTo GET_EXCTBZ_2_END

        End If
        '2019/04/23 CHG E N D

GET_EXCTBZ_2_END:
        '�N���[�Y
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
GET_EXCTBZ_2_ERROR: 
		GoTo GET_EXCTBZ_2_END
		
	End Function
	
	' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SSSWIN_EXCTBZ_CHECK2
	'   �T�v�F�@�r���`�F�b�N����
	'   �����F  pin_strGYMCD�F�Ɩ��R�[�h
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������i�r���`�F�b�N�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_EXCTBZ_CHECK2(ByRef pin_strGYMCD As Object) As Short
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo SSSWIN_EXCTBZ_CHECK2_ERROR
		
		SSSWIN_EXCTBZ_CHECK2 = 9
		
		strSql = ""
		strSql = strSql & " SELECT * "
		strSql = strSql & "  FROM "
		strSql = strSql & "        EXCTBZ " '�r���e�[�u��
		strSql = strSql & "  WHERE "
		'UPGRADE_WARNING: �I�u�W�F�N�g pin_strGYMCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "        GYMCD   = '" & Trim(pin_strGYMCD) & "'" '�Ɩ��R�[�h
        '2019/04/23 CHG START
        '     Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        '     If CF_Ora_EOF(Usr_Ody) = False Then
        ''UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) = SSS_CLTID.Value And Trim(CF_Ora_GetDyn(Usr_Ody, "INTLCD", "")) = SSS_PrgId Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            If Trim(DB_NullReplace(dt.Rows(0)("CLTID"), "")) = SSS_CLTID.Value And Trim(DB_NullReplace(dt.Rows(0)("INTLCD"), "")) = SSS_PrgId Then
                '2019/04/23 CHG E N D

                SSSWIN_EXCTBZ_CHECK2 = 0
            Else
                '�������ʂ����݂����ꍇ
                SSSWIN_EXCTBZ_CHECK2 = 1
                '�����I��
                Exit Function
            End If
        Else
            '�������ʂ�0���̏ꍇ
            '�r������i�r���e�[�u���֏������݁j
            bolRet = SSSWIN_Execute_EXCTBZ(pin_strGYMCD)
			If bolRet = False Then
				Exit Function
			End If
			SSSWIN_EXCTBZ_CHECK2 = 0
		End If
		
SSSWIN_EXCTBZ_CHECK2_END:
        '�N���[�Y
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
SSSWIN_EXCTBZ_CHECK2_ERROR: 
		GoTo SSSWIN_EXCTBZ_CHECK2_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SSSWIN_Execute_EXCTBZ
	'   �T�v�F  �r�����䏈��
	'   �����F  pin_strGYMCD�F�Ɩ��R�[�h
	'   �ߒl�F�@True : ���� False : �ُ�
	'   ���l�F  �r����������s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_Execute_EXCTBZ(ByRef pin_strGYMCD As Object) As Boolean
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo SSSWIN_Execute_EXCTBZ_ERROR
		
		SSSWIN_Execute_EXCTBZ = False

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        strSql = ""
		strSql = strSql & " INSERT INTO "
		strSql = strSql & "        EXCTBZ " '�r���e�[�u��
		strSql = strSql & "      ( CLTID " '�N���C�A���gID
		strSql = strSql & "      , GYMCD " '�󒍔ԍ�
		strSql = strSql & "      , LCKTM " '�^�C���X�^���v
		strSql = strSql & "      , INTLCD " '�v���O����ID
		strSql = strSql & "      ) "
		strSql = strSql & " VALUES "
		strSql = strSql & "      ( '" & SSS_CLTID.Value & "' " '�N���C�A���gID
		'UPGRADE_WARNING: �I�u�W�F�N�g pin_strGYMCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSql = strSql & "      , '" & Trim(pin_strGYMCD) & "' " '�Ɩ��R�[�h
		strSql = strSql & "      , '" & VB6.Format(Now, "hhnnss") & "' " '�^�C���X�^���v
		strSql = strSql & "      , '" & SSS_PrgId & "'" '�v���O����ID
        strSql = strSql & "      ) "

        '2019/04/17 CHG START
        'Call CF_Ora_Execute(gv_Odb_USR1, strSql)

        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Execute(strSql)

        Call DB_Commit()
        '2019/04/17 CHG E N D

        SSSWIN_Execute_EXCTBZ = True
		
SSSWIN_Execute_EXCTBZ_END:
        '�N���[�Y
        '2019/04/17 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/17 DEL E N D

        Exit Function
		
SSSWIN_Execute_EXCTBZ_ERROR: 
		GoTo SSSWIN_Execute_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SSSWIN_Unlock_EXCTBZ
	'   �T�v�F�@�r�������������
	'   �����F
	'   �ߒl�F�@True : ����  False : �ُ�
	'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_Unlock_EXCTBZ() As Boolean
		
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo SSSWIN_Unlock_EXCTBZ_ERROR
		
		SSSWIN_Unlock_EXCTBZ = False

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        strSql = ""
		strSql = strSql & " DELETE FROM "
		strSql = strSql & "        EXCTBZ " '�r���e�[�u��
		strSql = strSql & "  WHERE "
		strSql = strSql & "        CLTID    = '" & SSS_CLTID.Value & "' " '�N���C�A���gID
        strSql = strSql & "    AND INTLCD   = '" & SSS_PrgId & "' " '�v���O����ID
        '2019/04/17 CHG START
        'Call CF_Ora_Execute(gv_Odb_USR1, strSql)

        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Execute(strSql)

        Call DB_Commit()
        '2019/04/17 CHG E N D

        SSSWIN_Unlock_EXCTBZ = True
		
SSSWIN_Unlock_EXCTBZ_END:
        '�N���[�Y
        '2019/04/17 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/17 DEL E N D
        Exit Function
		
SSSWIN_Unlock_EXCTBZ_ERROR: 
		GoTo SSSWIN_Unlock_EXCTBZ_END
		
	End Function
	' === 20130708 === INSERT E -
End Module