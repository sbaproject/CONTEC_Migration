Option Strict Off
Option Explicit On
Module CLDMTA_DBM
    '==========================================================================
    '   CLDMTA.DBM   カレンダマスタ                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    'Public Const DATE_KBN_SLDKB As Short = 1 '営業日区分
    'Public Const DATE_KBN_BNKKDKB As Short = 2 '銀行稼動区分
    'Public Const DATE_KBN_DTBKDKB As Short = 3 '物流稼動区分
    'Public Const DATE_KBN_ETCKBA As Short = 4 'その他区分１
    'Public Const DATE_KBN_ETCKBB As Short = 5 'その他区分２
    'Public Const DATE_KBN_ETCKBC As Short = 6 'その他区分３
    'Public Const DATE_KBN_ETCKBD As Short = 7 'その他区分４
    'Public Const DATE_KBN_ETCKBE As Short = 8 'その他区分５
    'Public Const DATE_KBN_ETCKBF As Short = 9 'その他区分６
    'Public Const DATE_KBN_ETCKBG As Short = 10 'その他区分７
    'Public Const DATE_KBN_ETCKBH As Short = 11 'その他区分８
    'Public Const DATE_KBN_ETCKBI As Short = 12 'その他区分９
    '   Public Const DATE_KBN_ETCKBJ As Short = 13 'その他区分１０

    '20190610 del start

    '   Structure TYPE_DB_CLDMTA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DATKB As String '伝票削除区分
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public CLDDT As String '日付
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public CLDWKKB As String '曜日
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public CLDHLKB As String '祝日
    '	Dim SLSMDD As Decimal '営業通算日数
    '	Dim PRDKDDD As Decimal '生産稼働日数
    '	Dim DTBKDDD As Decimal '物流稼働日数
    '	Dim CLDSMDD As Decimal '暦日通算日数
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SLDKB As String '営業日区分
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public BNKKDKB As String '銀行稼動区分
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public PRDKDKB As String '生産稼動区分
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public DTBKDKB As String '物流稼動区分
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBA As String 'その他区分１
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBB As String 'その他区分２
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBC As String 'その他区分３
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBD As String 'その他区分４
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBE As String 'その他区分５
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBF As String 'その他区分６
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBG As String 'その他区分７
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBH As String 'その他区分８
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBI As String 'その他区分９
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public ETCKBJ As String 'その他区分１０
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
    'Public DB_CLDMTA As TYPE_DB_CLDMTA
    'Public DBN_TCLDMTA As Short
    '20190610 del end


    'カレンダマスタ検索画面パラメータ
    '営業日区分,銀行稼動区分,物流稼動区分,その他区分１,その他区分２
    'その他区分３,その他区分４,その他区分５,その他区分６,その他区分７
    'その他区分８,その他区分９,その他区分１０
    '   Public WLSDATE_KBN As Short

    ''カレンダ検索戻り値
    'Public WLSDATE_RTNCODE As String '日付（yyyy/mm/dd）

    '' === 20070309 === UPDATE S - ACE)Nagasawa
    ''Private Const KDKB_Holiday As String = "9"
    ''Private Const KDKB_WORK    As String = "1"
    'Public Const KDKB_Holiday As String = "9"
    'Public Const KDKB_WORK As String = "1"
    '   ' === 20070309 === UPDATE E -


    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Sub DB_CLDMTA_Clear
    '	'   概要：  カレンダマスタ構造体クリア
    '	'   引数：　なし
    '	'   戻値：
    '	'   備考：
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Sub DB_CLDMTA_Clear(ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA)

    '		Dim Clr_DB_CLDMTA As TYPE_DB_CLDMTA

    '		'UPGRADE_WARNING: オブジェクト pot_DB_CLDMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		pot_DB_CLDMTA = Clr_DB_CLDMTA

    '	End Sub

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function DSPCLDDT_SEARCH
    '	'   概要：  カレンダマスタ検索
    '	'   引数：  pin_strCLDDT  : 検索対象日付
    '	'           pot_DB_CLDMTA : 検索結果
    '	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '	'   備考：
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPCLDDT_SEARCH(ByVal pin_strCLDDT As String, ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA) As Short

    '        Dim li_MsgRtn As Integer

    '        Try


    '            Dim strSQL As String
    '            'Dim intData As Short
    '            ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '            'Dim Usr_Ody As U_Ody

    '            'On Error GoTo ERR_DSPCLDDT_SEARCH

    '            DSPCLDDT_SEARCH = 9

    '            strSQL = ""
    '            strSQL = strSQL & " Select * "
    '            strSQL = strSQL & "   from CLDMTA "
    '            strSQL = strSQL & "  Where CLDDT = '" & pin_strCLDDT & "' "

    '            'DBアクセス
    '            '20190322 CHG START
    '            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    '            Dim dt As DataTable = DB_GetTable(strSQL)
    '            '20190322 CHG END

    '            '20190322 CHG START
    '            ' CF_Ora_EOF(Usr_Ody) = True Then
    '            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '                '20190322 CHG 
    '                '取得データなし
    '                DSPCLDDT_SEARCH = 1
    '                Exit Function
    '            End If

    '            '20190322 CHG START
    '            'If CF_Ora_EOF(Usr_Ody) = False Then
    '            '    With pot_DB_CLDMTA
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .CLDDT = CF_Ora_GetDyn(Usr_Ody, "CLDDT", "") '日付
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .CLDWKKB = CF_Ora_GetDyn(Usr_Ody, "CLDWKKB", "") '曜日
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .CLDHLKB = CF_Ora_GetDyn(Usr_Ody, "CLDHLKB", "") '祝日
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .SLSMDD = CF_Ora_GetDyn(Usr_Ody, "SLSMDD", 0) '営業通算日数
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .PRDKDDD = CF_Ora_GetDyn(Usr_Ody, "PRDKDDD", 0) '生産稼働日数
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .DTBKDDD = CF_Ora_GetDyn(Usr_Ody, "DTBKDDD", 0) '物流稼働日数
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .CLDSMDD = CF_Ora_GetDyn(Usr_Ody, "CLDSMDD", 0) '暦日通算日数
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .SLDKB = CF_Ora_GetDyn(Usr_Ody, "SLDKB", "") '営業日区分
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .BNKKDKB = CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") '銀行稼動区分
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .PRDKDKB = CF_Ora_GetDyn(Usr_Ody, "PRDKDKB", "") '生産稼動区分
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .DTBKDKB = CF_Ora_GetDyn(Usr_Ody, "DTBKDKB", "") '物流稼動区分
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBA = CF_Ora_GetDyn(Usr_Ody, "ETCKBA", "") 'その他区分１
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBB = CF_Ora_GetDyn(Usr_Ody, "ETCKBB", "") 'その他区分２
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBC = CF_Ora_GetDyn(Usr_Ody, "ETCKBC", "") 'その他区分３
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBD = CF_Ora_GetDyn(Usr_Ody, "ETCKBD", "") 'その他区分４
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBE = CF_Ora_GetDyn(Usr_Ody, "ETCKBE", "") 'その他区分５
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBF = CF_Ora_GetDyn(Usr_Ody, "ETCKBF", "") 'その他区分６
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBG = CF_Ora_GetDyn(Usr_Ody, "ETCKBG", "") 'その他区分７
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBH = CF_Ora_GetDyn(Usr_Ody, "ETCKBH", "") 'その他区分８
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBI = CF_Ora_GetDyn(Usr_Ody, "ETCKBI", "") 'その他区分９
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .ETCKBJ = CF_Ora_GetDyn(Usr_Ody, "ETCKBJ", "") 'その他区分１０
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
    '            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
    '            '    End With
    '            'End If

    '            ''クローズ
    '            'Call CF_Ora_CloseDyn(Usr_Ody)

    '            With pot_DB_CLDMTA
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .CLDDT = DB_NullReplace(dt.Rows(0)("CLDDT"), "") '日付
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .CLDWKKB = DB_NullReplace(dt.Rows(0)("CLDWKKB"), "") '曜日
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .CLDHLKB = DB_NullReplace(dt.Rows(0)("CLDHLKB"), "") '祝日
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .SLSMDD = DB_NullReplace(dt.Rows(0)("SLSMDD"), 0) '営業通算日数
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .PRDKDDD = DB_NullReplace(dt.Rows(0)("PRDKDDD"), 0) '生産稼働日数
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .DTBKDDD = DB_NullReplace(dt.Rows(0)("DTBKDDD"), 0) '物流稼働日数
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .CLDSMDD = DB_NullReplace(dt.Rows(0)("CLDSMDD"), 0) '暦日通算日数
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .SLDKB = DB_NullReplace(dt.Rows(0)("SLDKB"), "") '営業日区分
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .BNKKDKB = DB_NullReplace(dt.Rows(0)("BNKKDKB"), "") '銀行稼動区分
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .PRDKDKB = DB_NullReplace(dt.Rows(0)("PRDKDKB"), "") '生産稼動区分
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .DTBKDKB = DB_NullReplace(dt.Rows(0)("DTBKDKB"), "") '物流稼動区分
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBA = DB_NullReplace(dt.Rows(0)("ETCKBA"), "") 'その他区分１
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBB = DB_NullReplace(dt.Rows(0)("ETCKBB"), "") 'その他区分２
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBC = DB_NullReplace(dt.Rows(0)("ETCKBC"), "") 'その他区分３
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBD = DB_NullReplace(dt.Rows(0)("ETCKBD"), "") 'その他区分４
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBE = DB_NullReplace(dt.Rows(0)("ETCKBE"), "") 'その他区分５
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBF = DB_NullReplace(dt.Rows(0)("ETCKBF"), "") 'その他区分６
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBG = DB_NullReplace(dt.Rows(0)("ETCKBG"), "") 'その他区分７
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBH = DB_NullReplace(dt.Rows(0)("ETCKBH"), "") 'その他区分８
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBI = DB_NullReplace(dt.Rows(0)("ETCKBI"), "") 'その他区分９
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ETCKBJ = DB_NullReplace(dt.Rows(0)("ETCKBJ"), "") 'その他区分１０
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
    '            End With
    '            '20190322 CHG END

    '            DSPCLDDT_SEARCH = 0

    '            '            Exit Function

    '            'ERR_DSPCLDDT_SEARCH:
    '        Catch ex As Exception
    '            li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '        End Try

    '    End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function CHK_CLDDT
    '	'   概要：  休日チェック
    '	'   引数：  pin_strCLDDT  : チェック対象日付
    '	'           pin_strChkKbn : チェック区分(1:営業日チェック　2:銀行稼動チェック　3:物流稼動チェック）
    '	'   戻値：　0:通常日 1:休日 9:異常終了
    '	'   備考：
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function CHK_CLDDT(ByVal pin_strCLDDT As String, ByVal pin_strChkKbn As String, ByRef pm_All As Cls_All) As Short

    '		Dim Mst_Inf As TYPE_DB_CLDMTA
    '		Dim intRet As Short

    '		'初期化
    '		Call DB_CLDMTA_Clear(Mst_Inf)
    '		CHK_CLDDT = 0

    '		'カレンダマスタ検索
    '		intRet = DSPCLDDT_SEARCH(pin_strCLDDT, Mst_Inf)
    '		Select Case intRet
    '			Case 0
    '				If Mst_Inf.DATKB = gc_strDATKB_USE Then
    '					'日付チェック
    '					Select Case pin_strChkKbn
    '						'営業日チェック
    '						Case "1"
    '							If Mst_Inf.SLDKB = KDKB_Holiday Then
    '								CHK_CLDDT = 1
    '							End If

    '							'銀行稼働チェック
    '						Case "2"
    '							If Mst_Inf.BNKKDKB = KDKB_Holiday Then
    '								CHK_CLDDT = 1
    '							End If

    '							'物流稼動チェック
    '						Case "3"
    '							If Mst_Inf.DTBKDKB = KDKB_Holiday Then
    '								CHK_CLDDT = 1
    '							End If

    '						Case Else
    '					End Select
    '				Else
    '					CHK_CLDDT = 9
    '				End If

    '			Case 1
    '				CHK_CLDDT = 9

    '			Case Else
    '				CHK_CLDDT = 9
    '		End Select

    '	End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function DSPCLDDT_SEARCH_KDKB
    '	'   概要：  カレンダマスタ検索(稼働日のみ取得)
    '	'   引数：  pin_strCLDDT  : 検索対象日付
    '	'           pin_strKDKB   : 検索稼動区分("1":営業日 "2":銀行稼働日 "3":物流稼働日)
    '	'           　　　　　　　　　　　　　　 "12":営業日・銀行稼働日)
    '	'           pin_strKEISAN : 計算区分("1":加算 "2":減算)
    '	'           pot_strCLDDT  : 検索結果
    '	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '	'   備考：
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPCLDDT_SEARCH_KDKB(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

    '		Dim strSQL As String
    '		Dim intData As Short
    '		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '		Dim Usr_Ody As U_Ody

    '		On Error GoTo ERR_DSPCLDDT_SEARCH_KDKB

    '		DSPCLDDT_SEARCH_KDKB = 9
    '		pot_strCLDDT = ""

    '		strSQL = ""
    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
    '		Else
    '			strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
    '		End If

    '		strSQL = strSQL & "   from CLDMTA "
    '		strSQL = strSQL & "  Where DATKB >= '" & gc_strDATKB_USE & "' "

    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
    '		Else
    '			strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
    '		End If

    '		Select Case pin_strKDKB
    '			'営業日
    '			Case "1"
    '				strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "

    '				'銀行稼働日
    '			Case "2"
    '				strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "

    '				'物流稼動日
    '			Case "3"
    '				strSQL = strSQL & "    and DTBKDKB = '" & KDKB_WORK & "' "

    '				' === 20070309 === INSERT S - ACE)Nagasawa
    '				'営業日・銀行稼働日
    '			Case "12"
    '				strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "
    '				strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "
    '				' === 20070309 === INSERT E -

    '		End Select

    '        'DBアクセス
    '        '2019/03/18 CHG START
    '        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/03/18 CHG E N D

    '        '2019/03/18 CHG START
    '        'If CF_Ora_EOF(Usr_Ody) = True Then
    '        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '            '2019/03/18 CHG E N D
    '            '取得データなし
    '            DSPCLDDT_SEARCH_KDKB = 1
    '            Exit Function
    '        Else
    '            '2019/03/18 CHG START
    '            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            'pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
    '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            pot_strCLDDT = DB_NullReplace(dt.Rows(0)("GETDATE"), "")
    '            '2019/03/18 CHG E N D
    '        End If


    '        'クローズ
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        DSPCLDDT_SEARCH_KDKB = 0

    '        Exit Function

    'ERR_DSPCLDDT_SEARCH_KDKB:


    '    End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function DSPKDDT_SEARCH
    '	'   概要：  カレンダマスタ検索(営業通算日等より検索)
    '	'   引数：  pin_strCLDDT  : 検索対象通算日付
    '	'           pin_strKDKB   : 検索稼動区分("1":営業日 "2":銀行稼働日 "3":物流稼働日 "4":生産稼働日)
    '	'           pot_strCLDDT  : 検索結果
    '	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '	'   備考：
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPKDDT_SEARCH(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByRef pot_strCLDDT As String) As Short

    '		Dim strSQL As String
    '		Dim intData As Short
    '		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '		Dim Usr_Ody As U_Ody

    '		On Error GoTo ERR_DSPKDDT_SEARCH

    '		DSPKDDT_SEARCH = 9
    '		pot_strCLDDT = ""

    '		strSQL = ""
    '		strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
    '		strSQL = strSQL & "   from CLDMTA "
    '		strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "

    '		Select Case pin_strKDKB
    '			'営業日
    '			Case "1", "2"
    '				strSQL = strSQL & "    and SLSMDD = " & CF_Ora_Number(pin_strCLDDT)

    '				'物流稼働日
    '			Case "3"
    '				strSQL = strSQL & "    and DTBKDDD = " & CF_Ora_Number(pin_strCLDDT)

    '				'生産稼働日
    '			Case "4"
    '				strSQL = strSQL & "    and PRDKDDD = " & CF_Ora_Number(pin_strCLDDT)
    '		End Select

    '		'DBアクセス
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'取得データなし
    '			DSPKDDT_SEARCH = 1
    '			Exit Function
    '		Else
    '			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
    '		End If


    '		'クローズ
    '		Call CF_Ora_CloseDyn(Usr_Ody)

    '		DSPKDDT_SEARCH = 0

    '		Exit Function

    'ERR_DSPKDDT_SEARCH: 


    '	End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function AE_CalcDate_Add
    '	'   概要：  日付計算処理
    '	'   引数：　Pio_strDate     :計算対象日(数字８桁、またはyyyy/mm/ddの形式）
    '	'           Pin_intAddDate  :加算対象日数（マイナス値は減算）
    '	'           Pin_strKind     :営業日種別("1":営業日 "2":銀行稼働日　"3":物流稼働日 "4":生産稼働日)
    '	'                            省略時は営業日による考慮無し
    '	'   戻値：  0 : 正常 9 : 異常
    '	'   備考：　出荷予定日を求める場合の修正を連絡票No.516で行った
    '	'   　　　　他の日付を求める時に当関数を使用する場合は、同じ修正が必要となる
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function AE_CalcDate_Add(ByRef Pio_strDate As String, ByVal Pin_intAddDate As Short, Optional ByVal Pin_strKind As String = "0") As Short

    '		Dim strDate As String
    '		Dim strDate_W As String
    '		Dim Mst_Inf_NOW As TYPE_DB_CLDMTA
    '		Dim curCALCDATE As Decimal
    '		Dim curKDDATE As Decimal

    '		AE_CalcDate_Add = 9

    '		strDate = ""

    '		'加算数値チェック
    '		If IsNumeric(Pin_intAddDate) = False Then
    '			Exit Function
    '		End If

    '		'日付整合性チェック
    '		If IsDate(Pio_strDate) = True Then
    '#Disable Warning BC40000 ' Type or member is obsolete
    '			strDate = VB6.Format(Pio_strDate, "yyyymmdd")
    '#Enable Warning BC40000 ' Type or member is obsolete
    '		End If

    '		'日付様式に変換
    '#Disable Warning BC40000 ' Type or member is obsolete
    '		If IsDate(VB6.Format(Pio_strDate, "@@@@/@@/@@")) = True Then
    '#Enable Warning BC40000 ' Type or member is obsolete
    '			strDate = Pio_strDate
    '		End If

    '		If Trim(strDate) = "" Then
    '			Exit Function
    '		End If

    '		'構造体クリア
    '		Call DB_CLDMTA_Clear(Mst_Inf_NOW)

    '		curKDDATE = 0
    '		Select Case Pin_strKind
    '			'営業日による考慮無し
    '			Case "0"
    '#Disable Warning BC40000 ' Type or member is obsolete
    '				strDate = VB6.Format(strDate, "@@@@/@@/@@")
    '#Enable Warning BC40000 ' Type or member is obsolete
    '				strDate_W = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, Pin_intAddDate, CDate(strDate)))
    '				Pio_strDate = strDate_W
    '				AE_CalcDate_Add = 0

    '				'営業日、銀行稼働日考慮
    '			Case "1", "2"
    '				'カレンダマスタ検索
    '				If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
    '					If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
    '						If IsNumeric(Mst_Inf_NOW.SLSMDD) = True Then
    '							curKDDATE = CDec(Mst_Inf_NOW.SLSMDD)
    '						Else
    '							Exit Function
    '						End If
    '					Else
    '						Exit Function
    '					End If
    '				Else
    '					Exit Function
    '				End If

    '				'日付加算
    '				curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

    '				'物流稼働日考慮
    '			Case "3"
    '				'カレンダマスタ検索
    '				If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
    '					If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
    '						If IsNumeric(Mst_Inf_NOW.DTBKDDD) = True Then
    '							curKDDATE = CDec(Mst_Inf_NOW.DTBKDDD)

    '							'20081111 ADD START RISE)Tanimura  連絡票No.516
    '							' 加算対象日数がマイナスの場合
    '							If Pin_intAddDate < 0 Then
    '								' 物流稼働区分 が 休日 の場合
    '								If Mst_Inf_NOW.DTBKDKB = KDKB_Holiday Then
    '									' 固定値Ｍから取得した値 + 1
    '									Pin_intAddDate = Pin_intAddDate + 1
    '								End If
    '							End If
    '							'20081111 ADD END   RISE)Tanimura

    '						Else
    '							Exit Function
    '						End If
    '					Else
    '						Exit Function
    '					End If
    '				Else
    '					Exit Function
    '				End If

    '				'生産稼働日考慮
    '			Case "4"
    '				'カレンダマスタ検索
    '				If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
    '					If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
    '						If IsNumeric(Mst_Inf_NOW.PRDKDDD) = True Then
    '							curKDDATE = CDec(Mst_Inf_NOW.PRDKDDD)
    '						Else
    '							Exit Function
    '						End If
    '					Else
    '						Exit Function
    '					End If
    '				Else
    '					Exit Function
    '				End If

    '		End Select

    '		'日付加算
    '		curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

    '		If DSPKDDT_SEARCH(CStr(curCALCDATE), Pin_strKind, strDate_W) <> 0 Then
    '			Exit Function
    '		End If

    '		Pio_strDate = strDate_W

    '		AE_CalcDate_Add = 0

    '	End Function


    '	' === 20070309 === INSERT S - ACE)Nagasawa 売上後の入力可否制御の変更
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function DSPCLDDT_SEARCH_WK
    '	'   概要：  カレンダマスタ検索(曜日計算)
    '	'   引数：  pin_strCLDDT   : 検索対象日付
    '	'           pin_strCLDWKKB : 曜日区分
    '	'           pin_strKEISAN  : 計算区分("1":加算 "2":減算)
    '	'           pot_strCLDDT   : 検索結果
    '	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '	'   備考：  検索対象日付より前、または後の曜日区分で指定された曜日に当たる日付を検索
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function DSPCLDDT_SEARCH_WK(ByVal pin_strCLDDT As String, ByVal pin_strCLDWKKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

    '		Dim strSQL As String
    '		Dim intData As Short
    '		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '		Dim Usr_Ody As U_Ody

    '		On Error GoTo ERR_DSPCLDDT_SEARCH_WK

    '		DSPCLDDT_SEARCH_WK = 9
    '		pot_strCLDDT = ""

    '		strSQL = ""
    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
    '		Else
    '			strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
    '		End If

    '		strSQL = strSQL & "   from CLDMTA "
    '		strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
    '		strSQL = strSQL & "    And CLDWKKB = '" & CF_Ora_String(pin_strCLDWKKB, 1) & "' "

    '		If pin_strKEISAN = "1" Then
    '			strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
    '		Else
    '			strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
    '		End If

    '		'DBアクセス
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'取得データなし
    '			DSPCLDDT_SEARCH_WK = 1
    '			Exit Function
    '		Else
    '			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
    '		End If

    '		DSPCLDDT_SEARCH_WK = 0

    'ERR_DSPCLDDT_SEARCH_WK: 

    '		'クローズ
    '		Call CF_Ora_CloseDyn(Usr_Ody)

    '	End Function
    '	' === 20070309 === INSERT E -
End Module