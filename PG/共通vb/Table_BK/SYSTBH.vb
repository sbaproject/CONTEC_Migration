Option Strict Off
Option Explicit On
Imports System
Imports System.Reflection


Module SYSTBH_DBM
    '==========================================================================
    '   SYSTBH.DBM   �V�X�e�����b�Z�[�W               UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_SYSTBH
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public MSGKB As String '���b�Z�[�W���        0
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(15), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=15)> Public MSGNM As String '���b�Z�[�W�A�C�e��
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public MSGSQ As String '���b�Z�[�W�A��        X(01)
    '       Dim BTNKB As Decimal '�{�^�����            000
    '       Dim BTNON As Decimal '�{�^�������l          000
    '       Dim ICNKB As Decimal '�A�C�R�����          00
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public MSGCM As String '���b�Z�[�W
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public COLSQ As String '�F�V�[�P���X          0
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String '�N���C�A���g�h�c      !@@@@@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String '��ѽ����(����)        9(06)
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String '��ѽ����(���t)        YYYY/MM/DD
    'End Structure
    'Public DB_SYSTBH As TYPE_DB_SYSTBH
    'Public DBN_SYSTBH As Short
    '20190611 del end

    ' Index1( MSGKB + MSGNM + MSGSQ )

    'Sub SYSTBH_GetFirst(ByVal paramMsgkb As String, ByVal paramMsgnm As String, ByVal paramMsgsq As String)

    '    Dim li_MsgRtn As Integer

    '    Try

    '        Dim tableCond As String = ""

    '        If DB_NullReplace(paramMsgnm, "") = "" Then
    '            tableCond = " where MSGKB = '" & paramMsgkb & "'"
    '        Else
    '            If paramMsgsq = "" Then
    '                tableCond = " where MSGKB = '" & paramMsgkb & "'" & " and MSGNM = '" & paramMsgnm & "'"
    '            Else
    '                tableCond = " where MSGKB = '" & paramMsgkb & "'" & " and MSGNM = '" & paramMsgnm & "'" & " and MSGSQ = '" & paramMsgsq & "'"
    '            End If
    '        End If

    '        DB_GetData("SYSTBH", tableCond, "")

    '        DB_SYSTBH = SYSTBH_GetNext(0)

    '        If DB_SYSTBH.MSGKB Is Nothing Then
    '            DBSTAT = 1
    '        Else
    '            DBSTAT = 0
    '        End If

    '    Catch ex As Exception
    '        li_MsgRtn = MsgBox("SYSTBH_GetFirst" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '    Finally

    '    End Try

    'End Sub

    'Function SYSTBH_GetNext(ByVal dataCount As Integer) As Object

    '    Dim t As Type

    '    t = GetType(TYPE_DB_SYSTBH)

    '    Dim members As MemberInfo() = t.GetMembers( _
    '        BindingFlags.Public Or BindingFlags.NonPublic Or _
    '        BindingFlags.Instance Or BindingFlags.Static Or _
    '        BindingFlags.DeclaredOnly)

    '    Dim v As ValueType = DB_SYSTBH
    '    Dim f As FieldInfo
    '    Dim m As MemberInfo

    '    If dsList.Tables("SYSTBH").Rows.Count - 1 < dataCount Then
    '        Return Nothing
    '    End If

    '    For Each m In members
    '        '�����o�̌^�ƁA���O��\������
    '        Console.WriteLine("{0} - {1}", m.MemberType, m.Name)

    '        f = DB_SYSTBH.GetType().GetField(m.Name)
    '        For i As Integer = 0 To dsList.Tables("SYSTBH").Columns.Count - 1
    '            If dsList.Tables("SYSTBH").Columns(i).Caption = m.Name Then
    '                If f.FieldType.Name = "String" Then
    '                    f.SetValue(v, DB_NullReplace(dsList.Tables("SYSTBH").Rows(dataCount).Item(m.Name), ""))
    '                Else
    '                    f.SetValue(v, DB_NullReplace(dsList.Tables("SYSTBH").Rows(dataCount).Item(m.Name), 0))
    '                End If

    '                DB_SYSTBH = DirectCast(v, TYPE_DB_SYSTBH)
    '                Exit For
    '            End If
    '        Next
    '    Next

    '    Return DB_SYSTBH

    'End Function

    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F  Function DSPMSGCM_SEARCH
    ''   �T�v�F  �V�X�e�����b�Z�[�W����
    ''   �����F  pin_strMSGKB    : ���b�Z�[�W���
    ''           pin_strMSGNM    : ���b�Z�[�W�A�C�e��
    ''           pin_strMSGSQ�@�@: ���b�Z�[�W�A��
    ''           pot_DB_SYSTBH   : ��������
    ''   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, ByVal pin_strMSGNM As String, ByVal pin_strMSGSQ As String, ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Short

    '    Dim li_MsgRtn As Integer

    '    Try
    '        Dim strSQL As String

    '        DSPMSGCM_SEARCH = 9

    '        strSQL = ""
    '        strSQL = strSQL & " Select * "
    '        strSQL = strSQL & "   from SYSTBH "
    '        strSQL = strSQL & "  Where MSGKB     = '" & CF_Ora_Sgl(pin_strMSGKB) & "' "
    '        strSQL = strSQL & "    and MSGNM     = '" & CF_Ora_Sgl(pin_strMSGNM) & "' "
    '        strSQL = strSQL & "    and MSGSQ     = '" & CF_Ora_Sgl(pin_strMSGSQ) & "' "

    '        'DB�A�N�Z�X
    '        '2019/03/14 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/03/14 CHG E N D

    '        '2019/03/14 CHG START
    '        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '            '2019/03/14 CHG E N D
    '            '�擾�f�[�^�Ȃ�
    '            DSPMSGCM_SEARCH = 1
    '            Exit Function
    '        End If

    '        With pot_DB_SYSTBH
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .MSGKB = DB_NullReplace(dt.Rows(0)("MSGKB"), "") '���b�Z�[�W���
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .MSGNM = DB_NullReplace(dt.Rows(0)("MSGNM"), "") '���b�Z�[�W�A�C�e��
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .MSGSQ = DB_NullReplace(dt.Rows(0)("MSGSQ"), "") '���b�Z�[�W�A��
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .BTNKB = DB_NullReplace(dt.Rows(0)("BTNKB"), 0) '�{�^�����
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .BTNON = DB_NullReplace(dt.Rows(0)("BTNON"), 0) '�{�^�������l
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .ICNKB = DB_NullReplace(dt.Rows(0)("ICNKB"), 0) '�A�C�R�����
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .MSGCM = DB_NullReplace(dt.Rows(0)("MSGCM"), "") '���b�Z�[�W
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .COLSQ = DB_NullReplace(dt.Rows(0)("COLSQ"), "") '�F�V�[�P���X
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '�ŏI��Ǝ҃R�[�h
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") '�N���C�A���g�h�c
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") '��ѽ����(����)
    '            'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") '��ѽ����(���t)
    '        End With

    '        DSPMSGCM_SEARCH = 0

    '    Catch ex As Exception
    '        li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '    End Try

    'End Function

    Sub SYSTBH_RClear()
        DB_SYSTBH = Nothing
	End Sub
End Module