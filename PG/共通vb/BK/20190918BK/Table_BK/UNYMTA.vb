Option Strict Off
Option Explicit On
Imports System
Imports System.Reflection


Module UNYMTA_DBM
    '==========================================================================
    '   UNYMTA.DBM   運用日テーブル                   UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_UNYMTA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UNYDT As String '運用日付              YYYY/MM/DD
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBA As String '運用区分１            !@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBB As String '運用区分２            !@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBC As String '運用区分３            !@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBD As String '運用区分４            !@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public UNYKBE As String '運用区分５            !@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public TERMNO As String '期                    00
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(4), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=4)> Public ACCYY As String '会計年度              YYYY
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '最終作業者コード      !@@@@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String 'クライアントＩＤ      !@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
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
    '        li_MsgRtn = MsgBox("UNYMTA_GetFirst" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
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
    '        'メンバの型と、名前を表示する
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
    ''   名称：  Sub DB_UNYMTA_Clear
    ''   概要：  運用日テーブル構造体クリア
    ''   引数：　なし
    ''   戻値：
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_UNYMTA_Clear(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA)

    '    '2019/04/26 CHG E N D
    '    'Dim Clr_DB_UNYMTA As TYPE_DB_UNYMTA

    '    ''UPGRADE_WARNING: オブジェクト pot_DB_UNYMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
    '               '取得データなし
    '               DSPUNYDT_SEARCH = 1
    '               Exit Function
    '           End If

    '           '2019/03/18 CHG START
    '           'DB_UNYMTA = UNYMTA_GetNext(0)
    '           pot_DB_UNYMTA = UNYMTA_GetNext(0)
    '           '2019/03/18 CHG E N D

    '           DSPUNYDT_SEARCH = 0

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("DSPUNYDT_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try

    '   End Function

    'Sub UNYMTA_RClear()
    '       DB_UNYMTA = Nothing
    '   End Sub

    '   '2019/03/20 ADD START
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   '   名称：  Function CHK_UNYDT
    '   '   概要：  運用日付チェック
    '   '   引数：
    '   '   戻値：　0:正常(運用日付が引数の日付と同一) -1:運用日マスタ無
    '   '　　　　　 1:運用日付が引数の日付より大きい 2:運用日付が引数の日付より小さい
    '   '   備考：連絡票№739
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Function CHK_UNYDT(ByRef CHK_DT As String) As Short

    '       '戻り値
    '       Dim rtnVal As Short = -1

    '       'SQL文
    '       Dim strSQL As String

    '       Dim ls_UNYDT As String
    '       Dim ls_CHK_DT As String

    '       Try
    '           ls_CHK_DT = Trim(CHK_DT)

    '           strSQL = ""
    '           strSQL &= " SELECT "
    '           strSQL &= "  UNYDT "
    '           strSQL &= " FROM UNYMTA "

    '           'DBアクセス 
    '           Dim dt As DataTable = DB_GetTable(strSQL)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               '取得データなし
    '               rtnVal = -1
    '           Else
    '               ls_UNYDT = DB_NullReplace(dt.Rows(0)("UNYDT"), "") '運用日付

    '               If ls_UNYDT = ls_CHK_DT Then
    '                   rtnVal = 0
    '               ElseIf ls_UNYDT > ls_CHK_DT Then
    '                   rtnVal = 1
    '               Else
    '                   rtnVal = 2
    '               End If
    '           End If

    '       Catch ex As Exception

    '           MsgBox("CHK_UNYDT" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")

    '           'Finally

    '       End Try

    '       Return rtnVal

    '   End Function
    '2019/03/20 ADD E N D

End Module