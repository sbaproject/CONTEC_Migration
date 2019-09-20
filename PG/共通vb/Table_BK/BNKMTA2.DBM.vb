Option Strict Off
Option Explicit On
Module BNKMTA2_DBM
    '==========================================================================
    '   BNKMTA.DBM   銀行マスタ                       UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_BNKMTA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '伝票削除区分          0
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(7), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=7)> Public BNKCD As String '銀行コード            !@@@@@@@
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public BNKNM As String '銀行名称
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public STNNM As String '支店名称
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(30), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=30)> Public BNKNK As String '銀行名称カナ
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(30), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=30)> Public STNNK As String '支店名称カナ
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(3), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=3)> Public BNKKMKCD As String '銀行・総勘定科目ｺｰﾄﾞ  000
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(3), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=3)> Public BNKUTICD As String '銀行・科目内訳ｺｰﾄﾞ    000
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public RELFL As String '連携フラグ            0
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FOPEID As String '初回登録ﾕｰｻﾞｰID       !@@@@@@@@
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public FCLTID As String '初回登録ｸﾗｲｱﾝﾄID      !@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '最終作業者コード      !@@@@@@@@
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String 'クライアントＩＤ      !@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UOPEID As String 'ユーザID(ﾊﾞｯﾁ)        !@@@@@@@@
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public UCLTID As String 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)        !@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public UWRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UWRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(7), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=7)> Public PGID As String 'プログラムID          !@@@@@@@@
    'End Structure
    'Public DB_BNKMTA As TYPE_DB_BNKMTA
    '20190611 del end
    '   Public DBN_BNKMTA As Short
    '' Index1( BNKCD )
    ''銀行マスタ検索戻り値
    'Public WLSBNKMTA2_RTNCODE As String '銀行コード


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_BNKMTA_Clear
    '   概要：  銀行マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Sub DB_BNKMTA_Clear(ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA)

    '	Dim Clr_DB_BNKMTA As TYPE_DB_BNKMTA

    '	'UPGRADE_WARNING: オブジェクト pot_DB_BNKMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	pot_DB_BNKMTA = Clr_DB_BNKMTA

    'End Sub

    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   '   名称：  Function DSPBANK_SEARCH
    '   '   概要：  銀行マスタ検索
    '   '   引数：  pin_strBNKCD    : 銀行コード
    '   '           pot_DB_BNKMTA   : 検索結果
    '   '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   '   備考：
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Public Function DSPBANK_SEARCH(ByVal pin_strBNKCD As String, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String
    '           Dim intData As Short
    '           'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '           'Dim Usr_Ody_LC As U_Ody

    '           'On Error GoTo ERR_DSPBANK_SEARCH

    '           DSPBANK_SEARCH = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select * "
    '           strSQL = strSQL & "   from BNKMTA "
    '           strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
    '           strSQL = strSQL & "  and   BNKCD    = '" & CF_Ora_Sgl(pin_strBNKCD) & "' "
    '           strSQL = strSQL & "  Order by BNKCD "

    '           'DBアクセス
    '           '20190403 CHG START
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)
    '           '20190403 CHG END

    '           '20190403 CHG START
    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           '    '取得データなし
    '           '    DSPBANK_SEARCH = 1
    '           '    Exit Function
    '           'End If

    '           'If CF_Ora_EOF(Usr_Ody_LC) = False Then
    '           '    Call DB_BNKMTA_SetData(Usr_Ody_LC, pot_DB_BNKMTA)
    '           'End If

    '           ''クローズ
    '           'Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               DSPBANK_SEARCH = 1
    '               Exit Function
    '           End If

    '           Call Set_DB_BNKMTA(dt, pot_DB_BNKMTA, 0)
    '           '20190403 CHG END

    '           DSPBANK_SEARCH = 0

    '           'Exit Function

    '           'ERR_DSPBANK_SEARCH:
    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("DSPBANK_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try

    '   End Function

    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function DSPBANK_SEARCH_ALL
    ''   概要：  銀行マスタ検索
    ''   引数：  pin_strBNKCD    : 銀行コード
    ''           pot_DB_BNKMTA   : 検索結果
    ''   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function DSPBANK_SEARCH_ALL(ByVal pin_strBNKCD As String, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String
    '           Dim intData As Short
    '           'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '           'Dim Usr_Ody_LC As U_Ody

    '           'On Error GoTo ERR_DSPBANK_SEARCH_ALL

    '           DSPBANK_SEARCH_ALL = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select * "
    '           strSQL = strSQL & "   from BNKMTA "
    '           strSQL = strSQL & "  Where BNKCD    = '" & CF_Ora_Sgl(pin_strBNKCD) & "' "

    '           'DBアクセス
    '           '20190403 CHG START
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)
    '           '20190403 CHG END

    '           '20190403 CHG START
    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           '    '取得データなし
    '           '    DSPBANK_SEARCH_ALL = 1
    '           '    Exit Function
    '           'End If

    '           'If CF_Ora_EOF(Usr_Ody_LC) = False Then
    '           '    Call DB_BNKMTA_SetData(Usr_Ody_LC, pot_DB_BNKMTA)
    '           'End If

    '           ''クローズ
    '           'Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               DSPBANK_SEARCH_ALL = 1
    '               Exit Function
    '           End If

    '           Call Set_DB_BNKMTA(dt, pot_DB_BNKMTA, 0)
    '           '20190403 CHG END

    '           DSPBANK_SEARCH_ALL = 0

    '           'Exit Function

    '           'ERR_DSPBANK_SEARCH_ALL:

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("DSPBANK_SEARCH_ALL" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try

    'End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_BNKMTA_SetData
    '   概要：  銀行マスタ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '20190403 CHG START
    'Private Sub DB_BNKMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA)
    '	'データ退避
    '	With pot_DB_BNKMTA
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.BNKCD = CF_Ora_GetDyn(pin_Usr_Ody, "BNKCD", "") '銀行コード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.BNKNM = CF_Ora_GetDyn(pin_Usr_Ody, "BNKNM", "") '銀行名称
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.STNNM = CF_Ora_GetDyn(pin_Usr_Ody, "STNNM", "") '支店名称
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.BNKNK = CF_Ora_GetDyn(pin_Usr_Ody, "BNKNK", "") '銀行名称カナ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.STNNK = CF_Ora_GetDyn(pin_Usr_Ody, "STNNK", "") '支店名称カナ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.BNKKMKCD = CF_Ora_GetDyn(pin_Usr_Ody, "BNKKMKCD", "") '銀行・総勘定科目ｺｰﾄﾞ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.BNKUTICD = CF_Ora_GetDyn(pin_Usr_Ody, "BNKUTICD", "") '銀行・科目内訳ｺｰﾄﾞ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "") '連携フラグ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '初回登録ﾕｰｻﾞｰID
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '初回登録ｸﾗｲｱﾝﾄID
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '最終作業者コード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") 'クライアントＩＤ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") 'ユーザID(ﾊﾞｯﾁ)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") 'プログラムID
    '	End With
    '   End Sub

    Private Sub Set_DB_BNKMTA(ByRef pDT As DataTable, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA, ByVal DataCount As Integer)
        'データ退避
        With pot_DB_BNKMTA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(pDT.Rows(DataCount)("DATKB"), "") '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BNKCD = DB_NullReplace(pDT.Rows(DataCount)("BNKCD"), "") '銀行コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BNKNM = DB_NullReplace(pDT.Rows(DataCount)("BNKNM"), "") '銀行名称
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .STNNM = DB_NullReplace(pDT.Rows(DataCount)("STNNM"), "") '支店名称
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BNKNK = DB_NullReplace(pDT.Rows(DataCount)("BNKNK"), "") '銀行名称カナ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .STNNK = DB_NullReplace(pDT.Rows(DataCount)("STNNK"), "") '支店名称カナ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BNKKMKCD = DB_NullReplace(pDT.Rows(DataCount)("BNKKMKCD"), "") '銀行・総勘定科目ｺｰﾄﾞ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BNKUTICD = DB_NullReplace(pDT.Rows(DataCount)("BNKUTICD"), "") '銀行・科目内訳ｺｰﾄﾞ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELFL = DB_NullReplace(pDT.Rows(DataCount)("RELFL"), "") '連携フラグ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FOPEID = DB_NullReplace(pDT.Rows(DataCount)("FOPEID"), "") '初回登録ﾕｰｻﾞｰID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FCLTID = DB_NullReplace(pDT.Rows(DataCount)("FCLTID"), "") '初回登録ｸﾗｲｱﾝﾄID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(pDT.Rows(DataCount)("OPEID"), "") '最終作業者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(pDT.Rows(DataCount)("CLTID"), "") 'クライアントＩＤ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UOPEID = DB_NullReplace(pDT.Rows(DataCount)("UOPEID"), "") 'ユーザID(ﾊﾞｯﾁ)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UCLTID = DB_NullReplace(pDT.Rows(DataCount)("UCLTID"), "") 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTTM = DB_NullReplace(pDT.Rows(DataCount)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTDT = DB_NullReplace(pDT.Rows(DataCount)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .PGID = DB_NullReplace(pDT.Rows(DataCount)("PGID"), "") 'プログラムID
        End With
    End Sub
    '20190403 CHG END

End Module