Option Strict Off
Option Explicit On
Module ENDMTA_DBM
    '==========================================================================
    '   MEIMTA.DBM   エンドユーザマスタ                       UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_ENDMTA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '伝票削除区分          0
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(9), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=9)> Public ENDUSRCD As String 'エンドユーザコード
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(255), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=255)> Public ENDUSRNM As String 'エンドユーザ名
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FOPEID As String '初回登録担当者ID
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public FCLTID As String '初回登録クライアントID
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTFSTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTFSTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '更新担当者コード
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String '更新クライアントＩＤ
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UOPEID As String 'バッチ更新担当者コード
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public UCLTID As String 'バッチ更新クライアントID
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public UWRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UWRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(7), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=7)> Public PGID As String 'ﾌﾟﾛｸﾞﾗﾑID
    'End Structure
    'Public DB_ENDMTA As TYPE_DB_ENDMTA
    'Public DBN_ENDMTA As Short
    '20190611 del end


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_ENDMTA_Clear
    '   概要：  エンドユーザマスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_ENDMTA_Clear(ByRef pot_DB_ENDMTA As TYPE_DB_ENDMTA)
    '	Dim Clr_DB_ENDMTA As TYPE_DB_ENDMTA
    '	'UPGRADE_WARNING: オブジェクト pot_DB_ENDMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	pot_DB_ENDMTA = Clr_DB_ENDMTA
    '   End Sub

    '20190320 DEL START 仮
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_ENDMTA_SetData
    '   概要：  名称マスタ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Sub DB_ENDMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_ENDMTA As TYPE_DB_ENDMTA)

    '	'データ退避
    '	With pot_DB_ENDMTA
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.ENDUSRCD = CF_Ora_GetDyn(pin_Usr_Ody, "ENDUSRCD", "") 'エンドユーザコード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.ENDUSRNM = CF_Ora_GetDyn(pin_Usr_Ody, "ENDUSRNM", "") 'エンドユーザ名
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '初回登録担当者ID
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '初回登録クライアントID
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '更新担当者コード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '更新クライアントＩＤ
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") 'バッチ更新担当者コード
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") 'バッチ更新クライアントID
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
    '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") 'ﾌﾟﾛｸﾞﾗﾑID
    '	End With

    'End Sub
    '20190320 DEL END 仮


    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   '   名称：  Function ENDUSRNM_SEARCH3
    '   '   概要：  エンドユーザマスタより名称取得
    '   '             存在しない場合、名称マスタ参照
    '   '   引数：pin_strMEICDA    : コード
    '   '           pin_LoadingFlg     : 見積/受注情報読込時か否か判断する
    '   '           pot_strENDUSRNM  : 検索結果
    '   '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   '   備考：
    '   ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Public Function ENDUSRNM_SEARCH3(ByVal pin_strENDUSRCD As String, ByVal pin_LoadingFlg As Short, ByRef pot_strENDUSRNM As String) As Short


    '       'Dim intData As Short
    '       ''UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '       'Dim Usr_Ody_LC As U_Ody

    '       'On Error GoTo ERR_ENDUSRNM_SEARCH3
    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String

    '           ENDUSRNM_SEARCH3 = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select "
    '           strSQL = strSQL & "        Rtrim(ENDUSRNM) NAME "
    '           strSQL = strSQL & "   from ENDMTA "
    '           strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
    '           strSQL = strSQL & "   and  Trim(ENDUSRCD) = '" & Trim(pin_strENDUSRCD) & "' "

    '           'DBアクセス
    '           '2019/03/18 CHG START
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)
    '           '2019/03/18 CHG E N D

    '           '2019/03/18 CHG START
    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               '2019/03/18 CHG E N D
    '               If pin_LoadingFlg = 1 Then
    '                   '見積/受注情報読込時でエンドユーザマスタにない場合名称マスタから取得
    '                   strSQL = ""
    '                   strSQL = strSQL & " Select "
    '                   strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
    '                   strSQL = strSQL & "   from MEIMTA "
    '                   strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
    '                   strSQL = strSQL & "   and  KEYCD  = '114' "
    '                   strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strENDUSRCD) & "' "

    '                   'DBアクセス
    '                   '2019/03/18 CHG START
    '                   'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '                   dt = Nothing
    '                   dt = DB_GetTable(strSQL)
    '                   '2019/03/18 CHG E N D

    '                   '2019/03/18 CHG START
    '                   'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '                   If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '                       '2019/03/18 CHG E N D
    '                       '取得データなし
    '                       pot_strENDUSRNM = ""
    '                       'ENDUSRNM_SEARCH3 = 1
    '                       'GoTo END_ENDUSRNM_SEARCH3
    '                       Exit Function
    '                   End If
    '               Else
    '                   '見積/受注情報読込時でない場合
    '                   '取得データなし
    '                   pot_strENDUSRNM = ""
    '                   'ENDUSRNM_SEARCH3 = 1
    '                   'GoTo END_ENDUSRNM_SEARCH3
    '                   Exit Function
    '               End If
    '           End If

    '           '取得データ退避
    '           'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '           'pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")
    '           pot_strENDUSRNM = DB_NullReplace(dt.Rows(0)("NAME"), "")

    '           ENDUSRNM_SEARCH3 = 0

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("ENDUSRNM_SEARCH3" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try



    '       'END_ENDUSRNM_SEARCH3:
    '       '            'クローズ
    '       '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '       '            Exit Function

    '       'ERR_ENDUSRNM_SEARCH3:

    '   End Function
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function ENDUSRCD_SEARCH
    ''   概要：  見積見出分類トランよりエンドユーザコード取得
    ''   引数：　pDATNO    : 伝票番号
    ''             pMITNO     : 見積番号
    ''             pMITNOV   : 版数
    ''             pin_strENDUSRCD : エンドユーザコード
    ''   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function ENDUSRCD_SEARCH(ByVal pDATNO As String, ByVal pMITNO As String, ByVal pMITNOV As String, ByRef pin_strENDUSRCD As String) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String

    '           ENDUSRCD_SEARCH = 9

    '           If pDATNO = "" Then
    '               strSQL = ""
    '               strSQL = strSQL & "   Select "
    '               strSQL = strSQL & "   Rtrim(ENDUSRCD) AS ENDUSRCD"
    '               strSQL = strSQL & "   from MITTHB "
    '               strSQL = strSQL & "   ,MITTHA"
    '               strSQL = strSQL & "   Where MITTHA.DATNO = MITTHB.DATNO"
    '               strSQL = strSQL & "   and MITTHB.DATNO = (SELECT DATNO from MITTHA"
    '               strSQL = strSQL & "   Where MITTHA.DATKB = 1"
    '               strSQL = strSQL & "   and  MITTHA.MITNO  = '" & pMITNO & "' "
    '               strSQL = strSQL & "   and  MITTHA.MITNOV = '" & pMITNOV & "' )"
    '               strSQL = strSQL & "   and  MITTHB.MITNO  = '" & pMITNO & "' "
    '               strSQL = strSQL & "   and  MITTHB.MITNOV = '" & pMITNOV & "' "
    '           Else
    '               strSQL = ""
    '               strSQL = strSQL & " Select "
    '               strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
    '               strSQL = strSQL & " from MITTHB "
    '               strSQL = strSQL & " Where DATNO  = '" & pDATNO & "' "
    '               strSQL = strSQL & " and  MITNO  = '" & pMITNO & "' "
    '               strSQL = strSQL & " and  MITNOV = '" & pMITNOV & "' "
    '           End If

    '           'DBアクセス
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    '           Dim dt As DataTable = DB_GetTable(strSQL)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               pin_strENDUSRCD = ""
    '               ENDUSRCD_SEARCH = 1
    '               Exit Function
    '           Else
    '               pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
    '           End If

    '           ENDUSRCD_SEARCH = 0

    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("ENDUSRCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try


    '       'Dim intData As Short
    '       ''UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '       'Dim Usr_Ody_LC As U_Ody

    '       'On Error GoTo ERR_ENDUSRCD_SEARCH



    '       'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '       '	'取得データなし
    '       '	pin_strENDUSRCD = ""
    '       '	ENDUSRCD_SEARCH = 1
    '       '	GoTo END_ENDUSRCD_SEARCH
    '       'End If

    '       ''取得データ退避
    '       ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

    '       'END_ENDUSRCD_SEARCH: 
    '       '		'クローズ
    '       '		Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '       '		Exit Function

    '       'ERR_ENDUSRCD_SEARCH: 

    'End Function
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function ENDUSRCD_SEARCH2
    ''   概要：  エンドユーザ紐付けテーブルよりエンドユーザコード取得
    ''   引数：　pJDNNO    : 受注番号
    ''             pin_strENDUSRCD : エンドユーザコード
    ''   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function ENDUSRCD_SEARCH2(ByVal pJDNNO As String, ByRef pin_strENDUSRCD As String) As Short

    '       Dim li_MsgRtn As Integer

    '       Try
    '           Dim strSQL As String
    '           'Dim intData As Short
    '           ''UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '           'Dim Usr_Ody_LC As U_Ody

    '           'On Error GoTo ERR_ENDUSRCD_SEARCH2

    '           ENDUSRCD_SEARCH2 = 9

    '           strSQL = ""
    '           strSQL = strSQL & " Select "
    '           strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
    '           strSQL = strSQL & " from JDNTHE "
    '           strSQL = strSQL & " Where JDNNO  = '" & pJDNNO & "' "

    '           Dim dt As DataTable = DB_GetTable(strSQL)

    '           If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '               pin_strENDUSRCD = ""
    '               ENDUSRCD_SEARCH2 = 1
    '               Exit Function
    '           Else
    '               pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
    '           End If

    '           ''DBアクセス
    '           'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    '           'If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '           '    '取得データなし
    '           '    pin_strENDUSRCD = ""
    '           '    ENDUSRCD_SEARCH2 = 1
    '           '    GoTo END_ENDUSRCD_SEARCH2
    '           'End If

    '           ''取得データ退避
    '           ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '           'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

    '           ENDUSRCD_SEARCH2 = 0

    '           'END_ENDUSRCD_SEARCH2:
    '           '            'クローズ
    '           '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '           '            Exit Function

    '           'ERR_ENDUSRCD_SEARCH2:
    '       Catch ex As Exception
    '           li_MsgRtn = MsgBox("ENDUSRCD_SEARCH2" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '       End Try

    '   End Function
End Module