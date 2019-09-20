Option Strict Off
Option Explicit On
Module YSNTRA_DBM
    '==========================================================================
    '   YSNTRA.DBM   与信限度ファイル                UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_YSNTRA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public DATKB() As Char '伝票削除区分
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public TGRPCD() As Char 'グループ会社コード
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public YSNUPDT() As Char '登録日
    '	Dim URKZANKN As Decimal '売掛残金額
    '	Dim YSNJDNKN As Decimal '受注残金額
    '	Dim YSNTEGKN As Decimal '受手残金額
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'タイムスタンプ（時間）
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'タイムスタンプ（日付）
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char 'タイムスタンプ（登録時間）
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char 'タイムスタンプ（登録日）
    'End Structure
    '20190611 del end

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_YSNTRA_Clear
    '   概要：  与信限度ファイル構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   Sub DB_YSNTRA_Clear(ByRef pot_DB_YSNTRA As TYPE_DB_YSNTRA)

    '	Dim Clr_DB_YSNTRA As TYPE_DB_YSNTRA

    '	'UPGRADE_WARNING: オブジェクト pot_DB_YSNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	pot_DB_YSNTRA = Clr_DB_YSNTRA

    'End Sub

    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Function DSPYSN_SEARCH
    '    '   概要：  与信限度ファイル検索
    '    '   引数：  pin_strTOKCD　　 : 得意先コード
    '    '           pin_strTGRPCD　　: グループ会社コード
    '    '   　　　　pin_strYSNUPDT 　: 登録日
    '    '   　　　　pot_DB_YSNTRA  　: 検索結果
    '    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '    '   備考：
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    Public Function DSPYSN_SEARCH(ByVal pin_strTOKCD As String, ByVal pin_strTGRPCD As String, ByVal pin_strYSNUPDT As String, ByRef pot_DB_YSNTRA As TYPE_DB_YSNTRA) As Short

    '		Dim strSQL As String
    '		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '		Dim Usr_Ody As U_Ody
    '		Dim strTGRPCD As String

    '		On Error GoTo ERR_DSPYSN_SEARCH

    '		DSPYSN_SEARCH = 9

    '		Call DB_YSNTRA_Clear(pot_DB_YSNTRA)

    '		If Trim(pin_strTGRPCD) = "" Then
    '			strTGRPCD = pin_strTOKCD
    '		Else
    '			strTGRPCD = pin_strTGRPCD
    '		End If

    '		strSQL = ""
    '		strSQL = strSQL & " Select * "
    '		strSQL = strSQL & "   from YSNTRA "
    '		strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
    '		strSQL = strSQL & "    and TGRPCD  = '" & CF_Ora_Sgl(strTGRPCD) & "' "
    '		strSQL = strSQL & "    and YSNUPDT = '" & CF_Ora_Sgl(pin_strYSNUPDT) & "' "

    '		'DBアクセス
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'取得データなし
    '			DSPYSN_SEARCH = 1
    '			GoTo END_DSPYSN_SEARCH
    '		End If

    '		If CF_Ora_EOF(Usr_Ody) = False Then
    '			With pot_DB_YSNTRA
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "") 'グループ会社コード
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.YSNUPDT = CF_Ora_GetDyn(Usr_Ody, "YSNUPDT", "") '登録日
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0) '売掛残金額
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.YSNJDNKN = CF_Ora_GetDyn(Usr_Ody, "YSNJDNKN", 0) '受注残金額
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.YSNTEGKN = CF_Ora_GetDyn(Usr_Ody, "YSNTEGKN", 0) '受手残金額
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
    '				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
    '			End With
    '		End If

    '		DSPYSN_SEARCH = 0

    'END_DSPYSN_SEARCH: 
    '		'クローズ
    '		Call CF_Ora_CloseDyn(Usr_Ody)

    '		Exit Function

    'ERR_DSPYSN_SEARCH: 
    '		GoTo END_DSPYSN_SEARCH

    '	End Function
End Module