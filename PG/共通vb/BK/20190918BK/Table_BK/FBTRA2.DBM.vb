Option Strict Off
Option Explicit On
Module FBTRA2_DBM
    '==========================================================================
    '   FBTRA.DBM    ＦＢトラン                       UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_FBTRA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '伝票削除区分          0
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public FBRFNO As String '照会番号              0
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FBKJDT As String '勘定日                YYYY/MM/DD
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FBKSDT As String '起算日                YYYY/MM/DD
    '	Dim FBNYUKN As Decimal '金額                  #,###,###,##0
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public FBCLTCD As String '振込依頼人コード      !@@@@@@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(48), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=48)> Public FBCLTNM As String '振込依頼人名
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public FBDELKB As String '取消区分              0
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FBSSDT As String '作成日                YYYY/MM/DD
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FBKJJDT As String '勘定日（自）          YYYY/MM/DD
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FBKJIDT As String '勘定日（至）          YYYY/MM/DD
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(7), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=7)> Public FBBNKCD As String '銀行コード            !@@@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(15), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=15)> Public FBBNKNK As String '銀行名称カナ
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(15), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=15)> Public FBSTNNK As String '支店名称カナ
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public FBYKNKB As String '預金種別              0
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(7), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=7)> Public FBKOZNO As String '口座番号              0000000
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public FBKOZNM As String '口座名
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '最終作業者コード      !@@@@@@@@
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String 'クライアントＩＤ      !@@@@@
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
    'End Structure
    'Public DB_FBTRA As TYPE_DB_FBTRA
    'Public DBN_FBTRA As Short
    '20190611 del end

    ' Index1( FBRFNO )
    'ＦＢトラン検索戻り値
    'Public WLSFBTRA2_RTNCODE As String '照会番号

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_FBTRA_Clear
    '   概要：  ＦＢトランテーブル構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_FBTRA_Clear(ByRef pot_DB_FBTRA As TYPE_DB_FBTRA)

    '	Dim Clr_DB_FBTRA As TYPE_DB_FBTRA

    '	'UPGRADE_WARNING: オブジェクト pot_DB_FBTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	pot_DB_FBTRA = Clr_DB_FBTRA

    'End Sub

    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   '   名称：  Function DSPFBTRA_SEARCH
    '   '   概要：  ＦＢトラン検索
    '   '   引数：  pin_strFBRFNO   : 照会番号
    '   '           pot_DB_FBTRA    : 検索結果
    '   '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   '   備考：
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Public Function DSPFBTRA_SEARCH(ByVal pin_strFBRFNO As String, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String
    '           Dim intData As Short
    '           'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '           'Dim Usr_Ody_LC As U_Ody

    '           'On Error GoTo ERR_DSPFBTRA_SEARCH

    '           DSPFBTRA_SEARCH = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select * "
    '           strSQL = strSQL & "   from FBTRA "
    '           strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
    '           strSQL = strSQL & "  and   FBRFNO   = '" & CF_Ora_Sgl(pin_strFBRFNO) & "' "
    '           strSQL = strSQL & "  Order by BNKCD "

    '           'DBアクセス
    '           '20190403 CHG START
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)
    '           '20190403 CHG END

    '           '20190403 CHG START
    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           '    '取得データなし
    '           '    DSPFBTRA_SEARCH = 1
    '           '    Exit Function
    '           'End If

    '           'If CF_Ora_EOF(Usr_Ody_LC) = False Then
    '           '    Call DB_FBTRA_SetData(Usr_Ody_LC, pot_DB_FBTRA)
    '           'End If

    '           ''クローズ
    '           'Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               DSPFBTRA_SEARCH = 1
    '               Exit Function
    '           End If

    '           Call Set_DB_FBTRA(dt, pot_DB_FBTRA, 0)
    '           '20190403 CHG END

    '           DSPFBTRA_SEARCH = 0

    '           'Exit Function

    '           'ERR_DSPFBTRA_SEARCH:
    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("DSPFBTRA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try

    '   End Function

    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function DSPFBTRA_SEARCH_ALL
    ''   概要：  ＦＢトラン検索
    ''   引数：  pin_strFBRFNO   : 照会番号
    ''           pot_DB_FBTRA    : 検索結果
    ''   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function DSPFBTRA_SEARCH_ALL(ByVal pin_strFBRFNO As String, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String
    '           Dim intData As Short
    '           'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '           'Dim Usr_Ody_LC As U_Ody

    '           'On Error GoTo ERR_DSPFBTRA_SEARCH_ALL

    '           DSPFBTRA_SEARCH_ALL = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select * "
    '           strSQL = strSQL & "   from FBTRA "
    '           strSQL = strSQL & "  Where FBRFNO   = '" & CF_Ora_Sgl(pin_strFBRFNO) & "' "

    '           'DBアクセス
    '           '20190403 CHG START
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)
    '           '20190403 CHG END

    '           '20190403 CHG START
    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           '    '取得データなし
    '           '    DSPFBTRA_SEARCH_ALL = 1
    '           '    Exit Function
    '           'End If

    '           'If CF_Ora_EOF(Usr_Ody_LC) = False Then
    '           '    Call DB_FBTRA_SetData(Usr_Ody_LC, pot_DB_FBTRA)
    '           'End If

    '           ''クローズ
    '           'Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               DSPFBTRA_SEARCH_ALL = 1
    '               Exit Function
    '           End If

    '           Call Set_DB_FBTRA(dt, pot_DB_FBTRA, 0)
    '           '20190403 CHG END

    '           DSPFBTRA_SEARCH_ALL = 0

    '           'Exit Function

    '           'ERR_DSPFBTRA_SEARCH_ALL:

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("DSPFBTRA_SEARCH_ALL" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try

    'End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_FBTRA_SetData
    '   概要：  ＦＢトラン構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '20190403 CHG START
    'Private Sub DB_FBTRA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA)
    '	'データ退避
    '	With pot_DB_FBTRA
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBRFNO = CF_Ora_GetDyn(pin_Usr_Ody, "FBRFNO", "") '照会番号
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBKJDT = CF_Ora_GetDyn(pin_Usr_Ody, "FBKJDT", "") '勘定日
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBKSDT = CF_Ora_GetDyn(pin_Usr_Ody, "FBKSDT", "") '起算日
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBNYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "FBNYUKN", "") '金額
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBCLTCD = CF_Ora_GetDyn(pin_Usr_Ody, "FBCLTCD", "") '振込依頼人コード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBCLTNM = CF_Ora_GetDyn(pin_Usr_Ody, "FBCLTNM", "") '振込依頼人名
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBDELKB = CF_Ora_GetDyn(pin_Usr_Ody, "FBDELKB", "") '取消区分
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBSSDT = CF_Ora_GetDyn(pin_Usr_Ody, "FBSSDT", "") '作成日
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBKJJDT = CF_Ora_GetDyn(pin_Usr_Ody, "FBKJJDT", "") '勘定日（自）
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBKJIDT = CF_Ora_GetDyn(pin_Usr_Ody, "FBKJIDT", "") '勘定日（至）
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBBNKCD = CF_Ora_GetDyn(pin_Usr_Ody, "FBBNKCD", "") '銀行コード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBBNKNK = CF_Ora_GetDyn(pin_Usr_Ody, "FBBNKNK", "") '銀行名称カナ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBSTNNK = CF_Ora_GetDyn(pin_Usr_Ody, "FBSTNNK", "") '支店名称カナ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBYKNKB = CF_Ora_GetDyn(pin_Usr_Ody, "FBYKNKB", "") '預金種別
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBKOZNO = CF_Ora_GetDyn(pin_Usr_Ody, "FBKOZNO", "") '口座番号
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FBKOZNM = CF_Ora_GetDyn(pin_Usr_Ody, "FBKOZNM", "") '口座名
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '最終作業者コード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") 'クライアントＩＤ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
    '	End With
    '   End Sub

    Private Sub Set_DB_FBTRA(ByRef pDT As DataTable, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA, ByVal DataCount As Integer)
        'データ退避
        With pot_DB_FBTRA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(pDT.Rows(DataCount)("DATKB"), "") '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBRFNO = DB_NullReplace(pDT.Rows(DataCount)("FBRFNO"), "") '照会番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBKJDT = DB_NullReplace(pDT.Rows(DataCount)("FBKJDT"), "") '勘定日
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBKSDT = DB_NullReplace(pDT.Rows(DataCount)("FBKSDT"), "") '起算日
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBNYUKN = DB_NullReplace(pDT.Rows(DataCount)("FBNYUKN"), "") '金額
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBCLTCD = DB_NullReplace(pDT.Rows(DataCount)("FBCLTCD"), "") '振込依頼人コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBCLTNM = DB_NullReplace(pDT.Rows(DataCount)("FBCLTNM"), "") '振込依頼人名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBDELKB = DB_NullReplace(pDT.Rows(DataCount)("FBDELKB"), "") '取消区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBSSDT = DB_NullReplace(pDT.Rows(DataCount)("FBSSDT"), "") '作成日
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBKJJDT = DB_NullReplace(pDT.Rows(DataCount)("FBKJJDT"), "") '勘定日（自）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBKJIDT = DB_NullReplace(pDT.Rows(DataCount)("FBKJIDT"), "") '勘定日（至）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBBNKCD = DB_NullReplace(pDT.Rows(DataCount)("FBBNKCD"), "") '銀行コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBBNKNK = DB_NullReplace(pDT.Rows(DataCount)("FBBNKNK"), "") '銀行名称カナ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBSTNNK = DB_NullReplace(pDT.Rows(DataCount)("FBSTNNK"), "") '支店名称カナ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBYKNKB = DB_NullReplace(pDT.Rows(DataCount)("FBYKNKB"), "") '預金種別
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBKOZNO = DB_NullReplace(pDT.Rows(DataCount)("FBKOZNO"), "") '口座番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FBKOZNM = DB_NullReplace(pDT.Rows(DataCount)("FBKOZNM"), "") '口座名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(pDT.Rows(DataCount)("OPEID"), "") '最終作業者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(pDT.Rows(DataCount)("CLTID"), "") 'クライアントＩＤ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
        End With
    End Sub
    '20190403 CHG END
End Module