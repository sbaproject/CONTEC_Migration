Option Strict Off
Option Explicit On
Imports System
Imports System.Reflection


Module SYSTBH_DBM
    '==========================================================================
    '   SYSTBH.DBM   システムメッセージ               UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_SYSTBH
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public MSGKB As String 'メッセージ種別        0
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(15), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=15)> Public MSGNM As String 'メッセージアイテム
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public MSGSQ As String 'メッセージ連番        X(01)
    '       Dim BTNKB As Decimal 'ボタン種別            000
    '       Dim BTNON As Decimal 'ボタン初期値          000
    '       Dim ICNKB As Decimal 'アイコン種別          00
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public MSGCM As String 'メッセージ
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public COLSQ As String '色シーケンス          0
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '最終作業者コード      !@@@@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String 'クライアントＩＤ      !@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
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
    '        li_MsgRtn = MsgBox("SYSTBH_GetFirst" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
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
    '        'メンバの型と、名前を表示する
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
    ''   名称：  Function DSPMSGCM_SEARCH
    ''   概要：  システムメッセージ検索
    ''   引数：  pin_strMSGKB    : メッセージ種別
    ''           pin_strMSGNM    : メッセージアイテム
    ''           pin_strMSGSQ　　: メッセージ連番
    ''           pot_DB_SYSTBH   : 検索結果
    ''   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    ''   備考：
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

    '        'DBアクセス
    '        '2019/03/14 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/03/14 CHG E N D

    '        '2019/03/14 CHG START
    '        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '            '2019/03/14 CHG E N D
    '            '取得データなし
    '            DSPMSGCM_SEARCH = 1
    '            Exit Function
    '        End If

    '        With pot_DB_SYSTBH
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .MSGKB = DB_NullReplace(dt.Rows(0)("MSGKB"), "") 'メッセージ種別
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .MSGNM = DB_NullReplace(dt.Rows(0)("MSGNM"), "") 'メッセージアイテム
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .MSGSQ = DB_NullReplace(dt.Rows(0)("MSGSQ"), "") 'メッセージ連番
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .BTNKB = DB_NullReplace(dt.Rows(0)("BTNKB"), 0) 'ボタン種別
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .BTNON = DB_NullReplace(dt.Rows(0)("BTNON"), 0) 'ボタン初期値
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .ICNKB = DB_NullReplace(dt.Rows(0)("ICNKB"), 0) 'アイコン種別
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .MSGCM = DB_NullReplace(dt.Rows(0)("MSGCM"), "") 'メッセージ
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .COLSQ = DB_NullReplace(dt.Rows(0)("COLSQ"), "") '色シーケンス
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '        End With

    '        DSPMSGCM_SEARCH = 0

    '    Catch ex As Exception
    '        li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '    End Try

    'End Function

    Sub SYSTBH_RClear()
        DB_SYSTBH = Nothing
	End Sub
End Module