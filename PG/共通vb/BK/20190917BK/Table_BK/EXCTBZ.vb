Option Strict Off
Option Explicit On

Imports System
Imports System.Reflection

Module EXCTBZ_DBM
    '==========================================================================
    '   EXCTBZ.DBM   排他テーブル                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_EXCTBZ
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String 'クライアントＩＤ      !@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public GYMCD As String '業務コード            0000000000
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public LCKTM As String '時刻                  9(06)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public SEQNO As String '連番                  0000000000
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public INTLCD As String '内部コード            0000000000
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public EXTCD As String '外部コード            0000000000
    'End Structure
    'Public DB_EXCTBZ As TYPE_DB_EXCTBZ
    'Public DBN_EXCTBZ As Short
    '20190611 del end

    ' Index1( CLTID + GYMCD )
    ' Index2( GYMCD )

    Sub EXCTBZ_RClear()
		Dim TmpStat As Object
		'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/03/26　仮
        '      TmpStat = Dll_RClear(DBN_EXCTBZ, G_LB)
        'Call ResetBuf(DBN_EXCTBZ)
        '2019/03/26　仮
    End Sub

    '2019/04/02 ADD START
    'Sub EXCTBZ_GetFirstRecByCLTIDAndGYMCD(ByVal pCLTID As String, ByVal pGYMCD As String)

    '    Dim li_MsgRtn As Integer

    '    Try
    '        Dim sqlWhereStr As String = ""

    '        sqlWhereStr = " WHERE CLTID = '" & pCLTID & "' AND GYMCD = '" & pGYMCD & "'"

    '        DB_GetData("EXCTBZ", sqlWhereStr, "")

    '        DB_EXCTBZ = EXCTBZ_GetNext(0)

    '        If DB_EXCTBZ.CLTID Is Nothing Then
    '            DBSTAT = 1
    '        Else
    '            DBSTAT = 0
    '        End If

    '    Catch ex As Exception
    '        li_MsgRtn = MsgBox("EXCTBZ_GetFirstRecByCLTIDAndGYMCD" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '    Finally

    '    End Try

    'End Sub
    ''2019/04/02 ADD E N D

    ''2019/04/02 ADD START
    'Function EXCTBZ_GetNext(ByVal dataCount As Integer) As Object

    '    Dim t As Type

    '    t = GetType(TYPE_DB_EXCTBZ)

    '    Dim members As MemberInfo() = t.GetMembers( _
    '        BindingFlags.Public Or BindingFlags.NonPublic Or _
    '        BindingFlags.Instance Or BindingFlags.Static Or _
    '        BindingFlags.DeclaredOnly)

    '    Dim v As ValueType = DB_EXCTBZ
    '    Dim f As FieldInfo
    '    Dim m As MemberInfo

    '    If dsList.Tables("EXCTBZ").Rows.Count - 1 < dataCount Then
    '        Return Nothing
    '    End If

    '    For Each m In members
    '        'メンバの型と、名前を表示する
    '        Console.WriteLine("{0} - {1}", m.MemberType, m.Name)

    '        f = DB_EXCTBZ.GetType().GetField(m.Name)
    '        For i As Integer = 0 To dsList.Tables("EXCTBZ").Columns.Count - 1
    '            If dsList.Tables("EXCTBZ").Columns(i).Caption = m.Name Then
    '                If f.FieldType.Name = "String" Then
    '                    f.SetValue(v, DB_NullReplace(dsList.Tables("EXCTBZ").Rows(dataCount).Item(m.Name), ""))
    '                Else
    '                    f.SetValue(v, DB_NullReplace(dsList.Tables("EXCTBZ").Rows(dataCount).Item(m.Name), 0))
    '                End If

    '                DB_EXCTBZ = DirectCast(v, TYPE_DB_EXCTBZ)
    '                Exit For
    '            End If
    '        Next
    '    Next

    '    Return DB_EXCTBZ

    'End Function
    '2019/04/02 ADD E N D

    '2019/04/02 ADD START
    'Function EXCTBZ_Insert(ByVal pDB_EXCTBZ As TYPE_DB_EXCTBZ) As Boolean

    '    Try
    '        Dim sqlStr As String = ""

    '        With pDB_EXCTBZ

    '            sqlStr &= " INSERT INTO EXCTBZ "
    '            sqlStr &= " (CLTID, GYMCD, LCKTM, SEQNO, INTLCD, EXTCD) "
    '            sqlStr &= " VALUES ('" & .CLTID & "', '" & .GYMCD & "', '" & .LCKTM & "', '" & .SEQNO & "', '" & .INTLCD & "', '" & .EXTCD & "') "
    '        End With

    '        DB_Execute(sqlStr)

    '    Catch ex As Exception
    '        MsgBox("EXCTBZ_Insert" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")

    '        Return False
    '    End Try

    '    Return True

    'End Function
    '2019/04/02 ADD E N D
End Module