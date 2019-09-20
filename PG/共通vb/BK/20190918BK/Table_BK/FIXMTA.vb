Option Strict Off
Option Explicit On
Module FIXMTA_DBM
    '==========================================================================
    '   FIXMTA.DBM   固定値マスタ                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_FIXMTA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '削除区分
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public CTLCD As String '管理コード
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public CTLNM As String '管理名称
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public FIXVAL As String '固定値
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(128), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=128)> Public REMARK As String '備考
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public RELFL As String '連携フラグ
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '最終作業者コード
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String 'クライアントＩＤ
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String 'タイムスタンプ（時間）
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String 'タイムスタンプ（日付）
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String 'タイムスタンプ（登録時間）
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String 'タイムスタンプ（登録日）
    'End Structure
    '   Public DB_FIXMTA As TYPE_DB_FIXMTA
    'Public DBN_FIXMTA As Short
    '20190611 del end


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_FIXMTA_Clear
    '   概要：  固定値マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_FIXMTA_Clear(ByRef pDB_FIXMTA As TYPE_DB_FIXMTA)
    '    pDB_FIXMTA = Nothing
    'End Sub

    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function DSPCTLCD_SEARCH
    ''   概要：  管理コード検索
    ''   引数：  pin_strCTLCD  : 検索対象管理コード
    ''           pot_DB_FIXMTA : 検索結果
    ''   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function DSPCTLCD_SEARCH(ByVal pin_strCTLCD As String, ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA) As Short

    '    Dim li_MsgRtn As Integer

    '    Try
    '        Dim strSQL As String
    '        'Dim intData As Short
    '        ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '        'Dim Usr_Ody As U_Ody

    '        'On Error GoTo ERR_DSPCTLCD_SEARCH

    '        DSPCTLCD_SEARCH = 9

    '        strSQL = ""
    '        strSQL = strSQL & " Select * "
    '        strSQL = strSQL & "   from FIXMTA "
    '        strSQL = strSQL & "  Where CTLCD = '" & pin_strCTLCD & "' "

    '        'DBアクセス
    '        '2019/03/14 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/03/14 CHG E N D

    '        '2019/03/14 CHG START
    '        'If CF_Ora_EOF(Usr_Ody) = True Then
    '        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '            '2019/03/14 CHG E N D
    '            '取得データなし
    '            DSPCTLCD_SEARCH = 1
    '            Exit Function
    '            'GoTo END_DSPCTLCD_SEARCH
    '        End If

    '        '2019/03/14 CHG START
    '        'If CF_Ora_EOF(Usr_Ody) = False Then
    '        '    With pot_DB_FIXMTA
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .CTLCD = CF_Ora_GetDyn(Usr_Ody, "CTLCD", "") '管理コード
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .CTLNM = CF_Ora_GetDyn(Usr_Ody, "CTLNM", "") '管理名称
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .FIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "") '固定値
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .REMARK = CF_Ora_GetDyn(Usr_Ody, "REMARK", "") '備考
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
    '        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
    '        '    End With
    '        'End If
    '        With pot_DB_FIXMTA
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '削除区分
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .CTLCD = DB_NullReplace(dt.Rows(0)("CTLCD"), "") '管理コード
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .CTLNM = DB_NullReplace(dt.Rows(0)("CTLNM"), "") '管理名称
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .FIXVAL = DB_NullReplace(dt.Rows(0)("FIXVAL"), "") '固定値
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .REMARK = DB_NullReplace(dt.Rows(0)("REMARK"), "") '備考
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
    '        End With
    '        '2019/03/14 CHG E N D

    '        DSPCTLCD_SEARCH = 0

    '        'END_DSPCTLCD_SEARCH:
    '        '            'クローズ
    '        '            Call CF_Ora_CloseDyn(Usr_Ody)

    '        '            Exit Function

    '        'ERR_DSPCTLCD_SEARCH:
    '        '            GoTo END_DSPCTLCD_SEARCH
    '    Catch ex As Exception
    '        li_MsgRtn = MsgBox("DSPCTLCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '    End Try

    'End Function
End Module