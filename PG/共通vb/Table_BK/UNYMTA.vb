Option Strict Off
Option Explicit On
Imports System
Imports System.Reflection


Module UNYMTA_DBM
    '==========================================================================
    '   UNYMTA.DBM   �^�p���e�[�u��                   UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_UNYMTA
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UNYDT As String '�^�p���t              YYYY/MM/DD
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBA As String '�^�p�敪�P            !@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBB As String '�^�p�敪�Q            !@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBC As String '�^�p�敪�R            !@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBD As String '�^�p�敪�S            !@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBE As String '�^�p�敪�T            !@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public TERMNO As String '��                    00
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Public ACCYY As String '��v�N�x              YYYY
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String '�N���C�A���g�h�c      !@@@@@
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String '��ѽ����(����)        9(06)
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String '��ѽ����(���t)        YYYY/MM/DD
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String '��ѽ����(�o�^����)    9(06)
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String '��ѽ����(�o�^��)      YYYY/MM/DD
    'End Structure
    'Public DB_UNYMTA As TYPE_DB_UNYMTA
    'Public DBN_UNYMTA As Short
    '20190611 del end

    ' Index1( UNYDT )

    'Sub UNYMTA_GetFirst()

    '    Dim li_MsgRtn As Integer

    '    Try
    '        DB_GetData("UNYMTA", "", "")

    '        DB_UNYMTA = UNYMTA_GetNext(0)

    '        If DB_UNYMTA.UNYKBA Is Nothing Then
    '            DBSTAT = 1
    '        Else
    '            DBSTAT = 0
    '        End If

    '    Catch ex As Exception
    '        li_MsgRtn = MsgBox("UNYMTA_GetFirst" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '    Finally

    '    End Try

    'End Sub

    'Function UNYMTA_GetNext(ByVal dataCount As Integer) As Object

    '    Dim t As Type

    '    t = GetType(TYPE_DB_UNYMTA)

    '    Dim members As MemberInfo() = t.GetMembers( _
    '        BindingFlags.Public Or BindingFlags.NonPublic Or _
    '        BindingFlags.Instance Or BindingFlags.Static Or _
    '        BindingFlags.DeclaredOnly)

    '    Dim v As ValueType = DB_UNYMTA
    '    Dim f As FieldInfo
    '    Dim m As MemberInfo

    '    If dsList.Tables("UNYMTA").Rows.Count - 1 < dataCount Then
    '        Return Nothing
    '    End If

    '    For Each m In members
    '        '�����o�̌^�ƁA���O��\������
    '        Console.WriteLine("{0} - {1}", m.MemberType, m.Name)

    '        f = DB_UNYMTA.GetType().GetField(m.Name)
    '        For i As Integer = 0 To dsList.Tables("UNYMTA").Columns.Count - 1
    '            If dsList.Tables("UNYMTA").Columns(i).Caption = m.Name Then
    '                If f.FieldType.Name = "String" Then
    '                    f.SetValue(v, DB_NullReplace(dsList.Tables("UNYMTA").Rows(dataCount).Item(m.Name), ""))
    '                Else
    '                    f.SetValue(v, DB_NullReplace(dsList.Tables("UNYMTA").Rows(dataCount).Item(m.Name), 0))
    '                End If

    '                DB_UNYMTA = DirectCast(v, TYPE_DB_UNYMTA)
    '                Exit For
    '            End If
    '        Next
    '    Next

    '    Return DB_UNYMTA

    'End Function

    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   ���́F  Sub DB_UNYMTA_Clear
    ''   �T�v�F  �^�p���e�[�u���\���̃N���A
    ''   �����F�@�Ȃ�
    ''   �ߒl�F
    ''   ���l�F
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_UNYMTA_Clear(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA)

    '    '2019/04/26 CHG E N D
    '    'Dim Clr_DB_UNYMTA As TYPE_DB_UNYMTA

    '    ''UPGRADE_WARNING: �I�u�W�F�N�g pot_DB_UNYMTA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '    'pot_DB_UNYMTA = Clr_DB_UNYMTA
    '    pot_DB_UNYMTA = Nothing
    '    '2019/04/26 CHG START

    'End Sub

    '   Public Function DSPUNYDT_SEARCH(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA) As Short

    '       Dim li_MsgRtn As Integer

    '       Try

    '           DSPUNYDT_SEARCH = 9

    '           DB_GetData("UNYMTA", "", "")

    '           If dsList.Tables("UNYMTA").Rows.Count <= 0 Then
    '               '�擾�f�[�^�Ȃ�
    '               DSPUNYDT_SEARCH = 1
    '               Exit Function
    '           End If

    '           '2019/03/18 CHG START
    '           'DB_UNYMTA = UNYMTA_GetNext(0)
    '           pot_DB_UNYMTA = UNYMTA_GetNext(0)
    '           '2019/03/18 CHG E N D

    '           DSPUNYDT_SEARCH = 0

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("DSPUNYDT_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '       End Try

    '   End Function

    'Sub UNYMTA_RClear()
    '       DB_UNYMTA = Nothing
    '   End Sub

    '   '2019/03/20 ADD START
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   '   ���́F  Function CHK_UNYDT
    '   '   �T�v�F  �^�p���t�`�F�b�N
    '   '   �����F
    '   '   �ߒl�F�@0:����(�^�p���t�������̓��t�Ɠ���) -1:�^�p���}�X�^��
    '   '�@�@�@�@�@ 1:�^�p���t�������̓��t���傫�� 2:�^�p���t�������̓��t��菬����
    '   '   ���l�F�A���[��739
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Function CHK_UNYDT(ByRef CHK_DT As String) As Short

    '       '�߂�l
    '       Dim rtnVal As Short = -1

    '       'SQL��
    '       Dim strSQL As String

    '       Dim ls_UNYDT As String
    '       Dim ls_CHK_DT As String

    '       Try
    '           ls_CHK_DT = Trim(CHK_DT)

    '           strSQL = ""
    '           strSQL &= " SELECT "
    '           strSQL &= "  UNYDT "
    '           strSQL &= " FROM UNYMTA "

    '           'DB�A�N�Z�X 
    '           Dim dt As DataTable = DB_GetTable(strSQL)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               '�擾�f�[�^�Ȃ�
    '               rtnVal = -1
    '           Else
    '               ls_UNYDT = DB_NullReplace(dt.Rows(0)("UNYDT"), "") '�^�p���t

    '               If ls_UNYDT = ls_CHK_DT Then
    '                   rtnVal = 0
    '               ElseIf ls_UNYDT > ls_CHK_DT Then
    '                   rtnVal = 1
    '               Else
    '                   rtnVal = 2
    '               End If
    '           End If

    '       Catch ex As Exception

    '           MsgBox("CHK_UNYDT" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")

    '           'Finally

    '       End Try

    '       Return rtnVal

    '   End Function
    '2019/03/20 ADD E N D

End Module