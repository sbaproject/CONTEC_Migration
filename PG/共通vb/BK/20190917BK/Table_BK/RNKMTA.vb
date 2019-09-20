Option Strict Off
Option Explicit On
Module RNKMTA_DBM
    '==========================================================================
    '   RNKMTA.DBM   ランク別仕切率マスタ　           UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_RNKMTA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public DATKB() As Char '伝票削除区分
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(4),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=4)> Public HINGRP() As Char '商品群
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public RNKCD() As Char 'ランク
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public URISETDT() As Char '販売単価設定日付
    '	Dim SIKRT As Decimal '仕切率
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'タイムスタンプ（時間）
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'タイムスタンプ（日付）
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char 'タイムスタンプ（時間）
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char 'タイムスタンプ（登録日）
    'End Structure
    'Public DB_RNKMTA As TYPE_DB_RNKMTA
    'Public DBN_RNKMTA As Short
    '20190611 del end


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_RNKMTA_Clear
    '   概要：  ランク別仕切率マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Sub DB_RNKMTA_Clear(ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA)

    '	Dim Clr_DB_RNKMTA As TYPE_DB_RNKMTA

    '	'UPGRADE_WARNING: オブジェクト pot_DB_RNKMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	pot_DB_RNKMTA = Clr_DB_RNKMTA

    'End Sub

    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Function DSPRNKM_SEARCH
    '    '   概要：  ランク別仕切率マスタ検索
    '    '   引数：　pin_strHINGRP   : 商品群
    '    '           pin_strRNKCD    : ランク
    '    '           pin_strURISETDT : 販売単価設定日付
    '    '           pot_DB_RNKMTA 　: 検索結果
    '    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '    '   備考：
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    Public Function DSPRNKM_SEARCH(ByVal pin_strHINGRP As String, ByVal pin_strRNKCD As String, ByVal pin_strURISETDT As String, ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA) As Short

    '		Dim strSQL As String
    '		Dim intData As Short
    '		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '		Dim Usr_Ody As U_Ody

    '		On Error GoTo ERR_DSPRNKM_SEARCH

    '		DSPRNKM_SEARCH = 9

    '		strSQL = ""
    '		strSQL = strSQL & " Select * "
    '		strSQL = strSQL & "   from RNKMTA "
    '		strSQL = strSQL & "  Where HINGRP = '" & pin_strHINGRP & "' "
    '		strSQL = strSQL & "  and RNKCD = '" & pin_strRNKCD & "' "
    '		strSQL = strSQL & "  and URISETDT = ( Select MAX(URISETDT) AS _MAX_URISETDT "
    '		strSQL = strSQL & "                     from RNKMTA "
    '		strSQL = strSQL & "                    Where HINGRP = '" & pin_strHINGRP & "' "
    '		strSQL = strSQL & "                      and RNKCD = '" & pin_strRNKCD & "' "
    '		strSQL = strSQL & "                      and URISETDT <= '" & pin_strURISETDT & "' )"

    '		'DBアクセス
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'取得データなし
    '			DSPRNKM_SEARCH = 1
    '			Exit Function
    '		End If

    '		If CF_Ora_EOF(Usr_Ody) = False Then
    '			With pot_DB_RNKMTA
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "") '商品群
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.RNKCD = CF_Ora_GetDyn(Usr_Ody, "RNKCD", "") 'ランク
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.URISETDT = CF_Ora_GetDyn(Usr_Ody, "URISETDT", "") '販売単価設定日付
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.SIKRT = CF_Ora_GetDyn(Usr_Ody, "SIKRT", 0) '仕切率
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（時間）
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
    '			End With
    '		End If

    '		'クローズ
    '		Call CF_Ora_CloseDyn(Usr_Ody)


    '		DSPRNKM_SEARCH = 0

    '		Exit Function

    'ERR_DSPRNKM_SEARCH: 


    '	End Function
End Module