Option Strict Off
Option Explicit On

Module COMMON_SEARECH


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPBMNCD_SEARCH
    '   概要：  部門コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ' === 20060828 === UPDATE S - ACE)Sejima
    'D    Public Function DSPBMNCD_SEARCH(ByVal pin_strBMNCD As String, _
    ''D                                    ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA) As Integer
    ' === 20060828 === UPDATE ↓
    Public Function DSPBMNCD_SEARCH(ByVal pin_strBMNCD As String, ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA, Optional ByVal pin_strDate As String = "", Optional ByVal pin_datkb As String = "") As Short
        ' === 20060828 === UPDATE E

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPBMNCD_SEARCH

            DSPBMNCD_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from BMNMTA "
            strSQL = strSQL & "  Where BMNCD = '" & pin_strBMNCD & "' "
            ' === 20060828 === INSERT S - ACE)Sejima
            If Trim(pin_strDate) <> "" Then
                strSQL = strSQL & "  and STTTKDT <= '" & CF_Ora_Date(pin_strDate) & "' "
                strSQL = strSQL & "  and ENDTKDT >= '" & CF_Ora_Date(pin_strDate) & "' "
            End If
            ' === 20060828 === INSERT E
            '2019.04.17 add start
            If Trim(pin_datkb) <> "" Then
                strSQL = strSQL & "  and DATKB = '" & pin_datkb & "'"
            End If
            '2019.04.17 add end

            'DBアクセス
            '2019/03/15 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim     dt As DataTable = DB_GetTable(strSQL)
            '2019/03/15 CHG E N D

            '2019/03/15 CHG START
            'If CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/15 CHG E N D
                '取得データなし
                DSPBMNCD_SEARCH = 1
                Exit Function
            End If

            '2019/03/15 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_BMNMTA
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .STTTKDT = CF_Ora_GetDyn(Usr_Ody, "STTTKDT", "") '適用開始日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ENDTKDT = CF_Ora_GetDyn(Usr_Ody, "ENDTKDT", "") '適用終了日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '部門名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNZP = CF_Ora_GetDyn(Usr_Ody, "BMNZP", "") '郵便番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNADA = CF_Ora_GetDyn(Usr_Ody, "BMNADA", "") '住所１
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNADB = CF_Ora_GetDyn(Usr_Ody, "BMNADB", "") '住所２
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNADC = CF_Ora_GetDyn(Usr_Ody, "BMNADC", "") '住所３
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNTL = CF_Ora_GetDyn(Usr_Ody, "BMNTL", "") '電話番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNFX = CF_Ora_GetDyn(Usr_Ody, "BMNFX", "") 'FAX番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNURL = CF_Ora_GetDyn(Usr_Ody, "BMNURL", "") 'URL
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNCDUP = CF_Ora_GetDyn(Usr_Ody, "BMNCDUP", "") '上位部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNLV = CF_Ora_GetDyn(Usr_Ody, "BMNLV", 0) '階層
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZMJGYCD = CF_Ora_GetDyn(Usr_Ody, "ZMJGYCD", "") '会計事業所コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZMCD = CF_Ora_GetDyn(Usr_Ody, "ZMCD", "") '会計区分コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "") '会計部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '営業所コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '地区区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .HTANCD = CF_Ora_GetDyn(Usr_Ody, "HTANCD", "") '発注担当コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .STANCD = CF_Ora_GetDyn(Usr_Ody, "STANCD", "") '生産担当コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNPRNM = CF_Ora_GetDyn(Usr_Ody, "BMNPRNM", "") '印字用名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            '    End With
            'End If
            With pot_DB_BMNMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNCD = DB_NullReplace(dt.Rows(0)("BMNCD"), "") '部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STTTKDT = DB_NullReplace(dt.Rows(0)("STTTKDT"), "") '適用開始日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ENDTKDT = DB_NullReplace(dt.Rows(0)("ENDTKDT"), "") '適用終了日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNNM = DB_NullReplace(dt.Rows(0)("BMNNM"), "") '部門名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNZP = DB_NullReplace(dt.Rows(0)("BMNZP"), "") '郵便番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNADA = DB_NullReplace(dt.Rows(0)("BMNADA"), "") '住所１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNADB = DB_NullReplace(dt.Rows(0)("BMNADB"), "") '住所２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNADC = DB_NullReplace(dt.Rows(0)("BMNADC"), "") '住所３
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNTL = DB_NullReplace(dt.Rows(0)("BMNTL"), "") '電話番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNFX = DB_NullReplace(dt.Rows(0)("BMNFX"), "") 'FAX番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNURL = DB_NullReplace(dt.Rows(0)("BMNURL"), "") 'URL
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNCDUP = DB_NullReplace(dt.Rows(0)("BMNCDUP"), "") '上位部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNLV = DB_NullReplace(dt.Rows(0)("BMNLV"), 0) '階層
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZMJGYCD = DB_NullReplace(dt.Rows(0)("ZMJGYCD"), "") '会計事業所コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZMCD = DB_NullReplace(dt.Rows(0)("ZMCD"), "") '会計区分コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "") '会計部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .EIGYOCD = DB_NullReplace(dt.Rows(0)("EIGYOCD"), "") '営業所コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TIKKB = DB_NullReplace(dt.Rows(0)("TIKKB"), "") '地区区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HTANCD = DB_NullReplace(dt.Rows(0)("HTANCD"), "") '発注担当コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STANCD = DB_NullReplace(dt.Rows(0)("STANCD"), "") '生産担当コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNPRNM = DB_NullReplace(dt.Rows(0)("BMNPRNM"), "") '印字用名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
            End With
            '2019/03/15 CHG E N D

            ''クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody)

            DSPBMNCD_SEARCH = 0

            '            Exit Function

            'ERR_DSPBMNCD_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPBMNCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' === 20061215 === INSERT S - ACE)Nagasawa 営業所コードより営業部門を取得
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPEIGYOCD_SEARCH
    '   概要：  営業所コードより部門マスタの検索
    '   引数：　pin_strEIGYOCD : 営業所コード
    '         　pot_DB_BMNMTA  : 取得部門情報
    '           pin_strDate    : 基準日（省略された場合は運用日）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPEIGYOCD_SEARCH(ByVal pin_strEIGYOCD As String, ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA, Optional ByVal pin_strDate As String = "") As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strDate As String
            ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPEIGYOCD_SEARCH

            DSPEIGYOCD_SEARCH = 9

            '基準日の編集
            strDate = ""
            If Trim(pin_strDate) = "" Then
                strDate = GV_UNYDate
            Else
                strDate = pin_strDate
            End If

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from BMNMTA "
            strSQL = strSQL & "  Where EIGYOCD = '" & CF_Ora_String(pin_strEIGYOCD, 1) & "' "
            If Trim(strDate) <> "" Then
                strSQL = strSQL & "  and STTTKDT <= '" & CF_Ora_Date(strDate) & "' "
                strSQL = strSQL & "  and ENDTKDT >= '" & CF_Ora_Date(strDate) & "' "
            End If


            '20190319 CHG START 
            ''DBアクセス
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)

            'If CF_Ora_EOF(Usr_Ody) = True Then
            '    '取得データなし
            '    DSPEIGYOCD_SEARCH = 1
            '    Exit Function
            'End If
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPEIGYOCD_SEARCH = 1
                Exit Function
            End If

            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_BMNMTA
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "") '部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .STTTKDT = CF_Ora_GetDyn(Usr_Ody, "STTTKDT", "") '適用開始日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ENDTKDT = CF_Ora_GetDyn(Usr_Ody, "ENDTKDT", "") '適用終了日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "") '部門名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNZP = CF_Ora_GetDyn(Usr_Ody, "BMNZP", "") '郵便番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNADA = CF_Ora_GetDyn(Usr_Ody, "BMNADA", "") '住所１
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNADB = CF_Ora_GetDyn(Usr_Ody, "BMNADB", "") '住所２
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNADC = CF_Ora_GetDyn(Usr_Ody, "BMNADC", "") '住所３
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNTL = CF_Ora_GetDyn(Usr_Ody, "BMNTL", "") '電話番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNFX = CF_Ora_GetDyn(Usr_Ody, "BMNFX", "") 'FAX番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNURL = CF_Ora_GetDyn(Usr_Ody, "BMNURL", "") 'URL
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNCDUP = CF_Ora_GetDyn(Usr_Ody, "BMNCDUP", "") '上位部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNLV = CF_Ora_GetDyn(Usr_Ody, "BMNLV", 0) '階層
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZMJGYCD = CF_Ora_GetDyn(Usr_Ody, "ZMJGYCD", "") '会計事業所コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZMCD = CF_Ora_GetDyn(Usr_Ody, "ZMCD", "") '会計区分コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "") '会計部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "") '営業所コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "") '地区区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .HTANCD = CF_Ora_GetDyn(Usr_Ody, "HTANCD", "") '発注担当コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .STANCD = CF_Ora_GetDyn(Usr_Ody, "STANCD", "") '生産担当コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BMNPRNM = CF_Ora_GetDyn(Usr_Ody, "BMNPRNM", "") '印字用名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            '    End With
            'End If

            ''クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody)

            With pot_DB_BMNMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNCD = DB_NullReplace(dt.Rows(0)("BMNCD"), "") '部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STTTKDT = DB_NullReplace(dt.Rows(0)("STTTKDT"), "") '適用開始日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ENDTKDT = DB_NullReplace(dt.Rows(0)("ENDTKDT"), "") '適用終了日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNNM = DB_NullReplace(dt.Rows(0)("BMNNM"), "") '部門名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNZP = DB_NullReplace(dt.Rows(0)("BMNZP"), "") '郵便番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNADA = DB_NullReplace(dt.Rows(0)("BMNADA"), "") '住所１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNADB = DB_NullReplace(dt.Rows(0)("BMNADB"), "") '住所２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNADC = DB_NullReplace(dt.Rows(0)("BMNADC"), "") '住所３
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNTL = DB_NullReplace(dt.Rows(0)("BMNTL"), "") '電話番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNFX = DB_NullReplace(dt.Rows(0)("BMNFX"), "") 'FAX番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNURL = DB_NullReplace(dt.Rows(0)("BMNURL"), "") 'URL
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNCDUP = DB_NullReplace(dt.Rows(0)("BMNCDUP"), "") '上位部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNLV = DB_NullReplace(dt.Rows(0)("BMNLV"), 0) '階層
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZMJGYCD = DB_NullReplace(dt.Rows(0)("ZMJGYCD"), "") '会計事業所コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZMCD = DB_NullReplace(dt.Rows(0)("ZMCD"), "") '会計区分コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "") '会計部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .EIGYOCD = DB_NullReplace(dt.Rows(0)("EIGYOCD"), "") '営業所コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TIKKB = DB_NullReplace(dt.Rows(0)("TIKKB"), "") '地区区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HTANCD = DB_NullReplace(dt.Rows(0)("HTANCD"), "") '発注担当コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STANCD = DB_NullReplace(dt.Rows(0)("STANCD"), "") '生産担当コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNPRNM = DB_NullReplace(dt.Rows(0)("BMNPRNM"), "") '印字用名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
            End With
            '20190319 CHG START 

            DSPEIGYOCD_SEARCH = 0

            '            Exit Function

            'ERR_DSPEIGYOCD_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPEIGYOCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function
    ' === 20061215 === INSERT E -


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_CLDMTA_Clear
    '   概要：  カレンダマスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_CLDMTA_Clear(ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA)

        Dim Clr_DB_CLDMTA As TYPE_DB_CLDMTA

        'UPGRADE_WARNING: オブジェクト pot_DB_CLDMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pot_DB_CLDMTA = Clr_DB_CLDMTA

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPCLDDT_SEARCH
    '   概要：  カレンダマスタ検索
    '   引数：  pin_strCLDDT  : 検索対象日付
    '           pot_DB_CLDMTA : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH(ByVal pin_strCLDDT As String, ByRef pot_DB_CLDMTA As TYPE_DB_CLDMTA) As Short

        Dim li_MsgRtn As Integer

        Try


            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPCLDDT_SEARCH

            DSPCLDDT_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from CLDMTA "
            strSQL = strSQL & "  Where CLDDT = '" & pin_strCLDDT & "' "

            'DBアクセス
            '20190322 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '20190322 CHG END

            '20190322 CHG START
            ' CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '20190322 CHG 
                '取得データなし
                DSPCLDDT_SEARCH = 1
                Exit Function
            End If

            '20190322 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_CLDMTA
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLDDT = CF_Ora_GetDyn(Usr_Ody, "CLDDT", "") '日付
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLDWKKB = CF_Ora_GetDyn(Usr_Ody, "CLDWKKB", "") '曜日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLDHLKB = CF_Ora_GetDyn(Usr_Ody, "CLDHLKB", "") '祝日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SLSMDD = CF_Ora_GetDyn(Usr_Ody, "SLSMDD", 0) '営業通算日数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .PRDKDDD = CF_Ora_GetDyn(Usr_Ody, "PRDKDDD", 0) '生産稼働日数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DTBKDDD = CF_Ora_GetDyn(Usr_Ody, "DTBKDDD", 0) '物流稼働日数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLDSMDD = CF_Ora_GetDyn(Usr_Ody, "CLDSMDD", 0) '暦日通算日数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SLDKB = CF_Ora_GetDyn(Usr_Ody, "SLDKB", "") '営業日区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BNKKDKB = CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") '銀行稼動区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .PRDKDKB = CF_Ora_GetDyn(Usr_Ody, "PRDKDKB", "") '生産稼動区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DTBKDKB = CF_Ora_GetDyn(Usr_Ody, "DTBKDKB", "") '物流稼動区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBA = CF_Ora_GetDyn(Usr_Ody, "ETCKBA", "") 'その他区分１
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBB = CF_Ora_GetDyn(Usr_Ody, "ETCKBB", "") 'その他区分２
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBC = CF_Ora_GetDyn(Usr_Ody, "ETCKBC", "") 'その他区分３
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBD = CF_Ora_GetDyn(Usr_Ody, "ETCKBD", "") 'その他区分４
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBE = CF_Ora_GetDyn(Usr_Ody, "ETCKBE", "") 'その他区分５
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBF = CF_Ora_GetDyn(Usr_Ody, "ETCKBF", "") 'その他区分６
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBG = CF_Ora_GetDyn(Usr_Ody, "ETCKBG", "") 'その他区分７
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBH = CF_Ora_GetDyn(Usr_Ody, "ETCKBH", "") 'その他区分８
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBI = CF_Ora_GetDyn(Usr_Ody, "ETCKBI", "") 'その他区分９
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ETCKBJ = CF_Ora_GetDyn(Usr_Ody, "ETCKBJ", "") 'その他区分１０
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            '    End With
            'End If

            ''クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody)

            With pot_DB_CLDMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDDT = DB_NullReplace(dt.Rows(0)("CLDDT"), "") '日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDWKKB = DB_NullReplace(dt.Rows(0)("CLDWKKB"), "") '曜日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDHLKB = DB_NullReplace(dt.Rows(0)("CLDHLKB"), "") '祝日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SLSMDD = DB_NullReplace(dt.Rows(0)("SLSMDD"), 0) '営業通算日数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PRDKDDD = DB_NullReplace(dt.Rows(0)("PRDKDDD"), 0) '生産稼働日数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DTBKDDD = DB_NullReplace(dt.Rows(0)("DTBKDDD"), 0) '物流稼働日数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDSMDD = DB_NullReplace(dt.Rows(0)("CLDSMDD"), 0) '暦日通算日数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SLDKB = DB_NullReplace(dt.Rows(0)("SLDKB"), "") '営業日区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BNKKDKB = DB_NullReplace(dt.Rows(0)("BNKKDKB"), "") '銀行稼動区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PRDKDKB = DB_NullReplace(dt.Rows(0)("PRDKDKB"), "") '生産稼動区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DTBKDKB = DB_NullReplace(dt.Rows(0)("DTBKDKB"), "") '物流稼動区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBA = DB_NullReplace(dt.Rows(0)("ETCKBA"), "") 'その他区分１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBB = DB_NullReplace(dt.Rows(0)("ETCKBB"), "") 'その他区分２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBC = DB_NullReplace(dt.Rows(0)("ETCKBC"), "") 'その他区分３
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBD = DB_NullReplace(dt.Rows(0)("ETCKBD"), "") 'その他区分４
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBE = DB_NullReplace(dt.Rows(0)("ETCKBE"), "") 'その他区分５
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBF = DB_NullReplace(dt.Rows(0)("ETCKBF"), "") 'その他区分６
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBG = DB_NullReplace(dt.Rows(0)("ETCKBG"), "") 'その他区分７
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBH = DB_NullReplace(dt.Rows(0)("ETCKBH"), "") 'その他区分８
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBI = DB_NullReplace(dt.Rows(0)("ETCKBI"), "") 'その他区分９
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ETCKBJ = DB_NullReplace(dt.Rows(0)("ETCKBJ"), "") 'その他区分１０
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
            End With
            '20190322 CHG END

            DSPCLDDT_SEARCH = 0

            '            Exit Function

            'ERR_DSPCLDDT_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CHK_CLDDT
    '   概要：  休日チェック
    '   引数：  pin_strCLDDT  : チェック対象日付
    '           pin_strChkKbn : チェック区分(1:営業日チェック　2:銀行稼動チェック　3:物流稼動チェック）
    '   戻値：　0:通常日 1:休日 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CHK_CLDDT(ByVal pin_strCLDDT As String, ByVal pin_strChkKbn As String, ByRef pm_All As Cls_All) As Short

        Dim Mst_Inf As TYPE_DB_CLDMTA
        Dim intRet As Short

        '初期化
        Call DB_CLDMTA_Clear(Mst_Inf)
        CHK_CLDDT = 0

        'カレンダマスタ検索
        intRet = DSPCLDDT_SEARCH(pin_strCLDDT, Mst_Inf)
        Select Case intRet
            Case 0
                If Mst_Inf.DATKB = gc_strDATKB_USE Then
                    '日付チェック
                    Select Case pin_strChkKbn
                        '営業日チェック
                        Case "1"
                            If Mst_Inf.SLDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If

                            '銀行稼働チェック
                        Case "2"
                            If Mst_Inf.BNKKDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If

                            '物流稼動チェック
                        Case "3"
                            If Mst_Inf.DTBKDKB = KDKB_Holiday Then
                                CHK_CLDDT = 1
                            End If

                        Case Else
                    End Select
                Else
                    CHK_CLDDT = 9
                End If

            Case 1
                CHK_CLDDT = 9

            Case Else
                CHK_CLDDT = 9
        End Select

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPCLDDT_SEARCH_KDKB
    '   概要：  カレンダマスタ検索(稼働日のみ取得)
    '   引数：  pin_strCLDDT  : 検索対象日付
    '           pin_strKDKB   : 検索稼動区分("1":営業日 "2":銀行稼働日 "3":物流稼働日)
    '           　　　　　　　　　　　　　　 "12":営業日・銀行稼働日)
    '           pin_strKEISAN : 計算区分("1":加算 "2":減算)
    '           pot_strCLDDT  : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH_KDKB(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPCLDDT_SEARCH_KDKB

        DSPCLDDT_SEARCH_KDKB = 9
        pot_strCLDDT = ""

        strSQL = ""
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        Else
            strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
        End If

        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB >= '" & gc_strDATKB_USE & "' "

        If pin_strKEISAN = "1" Then
            strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
        Else
            strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
        End If

        Select Case pin_strKDKB
            '営業日
            Case "1"
                strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "

                '銀行稼働日
            Case "2"
                strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "

                '物流稼動日
            Case "3"
                strSQL = strSQL & "    and DTBKDKB = '" & KDKB_WORK & "' "

                ' === 20070309 === INSERT S - ACE)Nagasawa
                '営業日・銀行稼働日
            Case "12"
                strSQL = strSQL & "    and SLDKB = '" & KDKB_WORK & "' "
                strSQL = strSQL & "    and BNKKDKB = '" & KDKB_WORK & "' "
                ' === 20070309 === INSERT E -

        End Select

        'DBアクセス
        '2019/03/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/18 CHG E N D

        '2019/03/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/03/18 CHG E N D
            '取得データなし
            DSPCLDDT_SEARCH_KDKB = 1
            Exit Function
        Else
            '2019/03/18 CHG START
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_strCLDDT = DB_NullReplace(dt.Rows(0)("GETDATE"), "")
            '2019/03/18 CHG E N D
        End If


        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        DSPCLDDT_SEARCH_KDKB = 0

        Exit Function

ERR_DSPCLDDT_SEARCH_KDKB:


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPKDDT_SEARCH
    '   概要：  カレンダマスタ検索(営業通算日等より検索)
    '   引数：  pin_strCLDDT  : 検索対象通算日付
    '           pin_strKDKB   : 検索稼動区分("1":営業日 "2":銀行稼働日 "3":物流稼働日 "4":生産稼働日)
    '           pot_strCLDDT  : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPKDDT_SEARCH(ByVal pin_strCLDDT As String, ByVal pin_strKDKB As String, ByRef pot_strCLDDT As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPKDDT_SEARCH

        DSPKDDT_SEARCH = 9
        pot_strCLDDT = ""

        strSQL = ""
        strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB = '" & gc_strDATKB_USE & "' "

        Select Case pin_strKDKB
            '営業日
            Case "1", "2"
                strSQL = strSQL & "    and SLSMDD = " & CF_Ora_Number(pin_strCLDDT)

                '物流稼働日
            Case "3"
                strSQL = strSQL & "    and DTBKDDD = " & CF_Ora_Number(pin_strCLDDT)

                '生産稼働日
            Case "4"
                strSQL = strSQL & "    and PRDKDDD = " & CF_Ora_Number(pin_strCLDDT)
        End Select

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPKDDT_SEARCH = 1
            Exit Function
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
        End If


        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        DSPKDDT_SEARCH = 0

        Exit Function

ERR_DSPKDDT_SEARCH:


    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_CalcDate_Add
    '   概要：  日付計算処理
    '   引数：　Pio_strDate     :計算対象日(数字８桁、またはyyyy/mm/ddの形式）
    '           Pin_intAddDate  :加算対象日数（マイナス値は減算）
    '           Pin_strKind     :営業日種別("1":営業日 "2":銀行稼働日　"3":物流稼働日 "4":生産稼働日)
    '                            省略時は営業日による考慮無し
    '   戻値：  0 : 正常 9 : 異常
    '   備考：　出荷予定日を求める場合の修正を連絡票No.516で行った
    '   　　　　他の日付を求める時に当関数を使用する場合は、同じ修正が必要となる
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function AE_CalcDate_Add(ByRef Pio_strDate As String, ByVal Pin_intAddDate As Short, Optional ByVal Pin_strKind As String = "0") As Short

        Dim strDate As String
        Dim strDate_W As String
        Dim Mst_Inf_NOW As TYPE_DB_CLDMTA
        Dim curCALCDATE As Decimal
        Dim curKDDATE As Decimal

        AE_CalcDate_Add = 9

        strDate = ""

        '加算数値チェック
        If IsNumeric(Pin_intAddDate) = False Then
            Exit Function
        End If

        '日付整合性チェック
        If IsDate(Pio_strDate) = True Then
#Disable Warning BC40000 ' Type or member is obsolete
            strDate = VB6.Format(Pio_strDate, "yyyymmdd")
#Enable Warning BC40000 ' Type or member is obsolete
        End If

        '日付様式に変換
#Disable Warning BC40000 ' Type or member is obsolete
        If IsDate(VB6.Format(Pio_strDate, "@@@@/@@/@@")) = True Then
#Enable Warning BC40000 ' Type or member is obsolete
            strDate = Pio_strDate
        End If

        If Trim(strDate) = "" Then
            Exit Function
        End If

        '構造体クリア
        Call DB_CLDMTA_Clear(Mst_Inf_NOW)

        curKDDATE = 0
        Select Case Pin_strKind
            '営業日による考慮無し
            Case "0"
#Disable Warning BC40000 ' Type or member is obsolete
                strDate = VB6.Format(strDate, "@@@@/@@/@@")
#Enable Warning BC40000 ' Type or member is obsolete
                strDate_W = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, Pin_intAddDate, CDate(strDate)))
                Pio_strDate = strDate_W
                AE_CalcDate_Add = 0

                '営業日、銀行稼働日考慮
            Case "1", "2"
                'カレンダマスタ検索
                If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                    If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                        If IsNumeric(Mst_Inf_NOW.SLSMDD) = True Then
                            curKDDATE = CDec(Mst_Inf_NOW.SLSMDD)
                        Else
                            Exit Function
                        End If
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                '日付加算
                curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

                '物流稼働日考慮
            Case "3"
                'カレンダマスタ検索
                If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                    If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                        If IsNumeric(Mst_Inf_NOW.DTBKDDD) = True Then
                            curKDDATE = CDec(Mst_Inf_NOW.DTBKDDD)

                            '20081111 ADD START RISE)Tanimura  連絡票No.516
                            ' 加算対象日数がマイナスの場合
                            If Pin_intAddDate < 0 Then
                                ' 物流稼働区分 が 休日 の場合
                                If Mst_Inf_NOW.DTBKDKB = KDKB_Holiday Then
                                    ' 固定値Ｍから取得した値 + 1
                                    Pin_intAddDate = Pin_intAddDate + 1
                                End If
                            End If
                            '20081111 ADD END   RISE)Tanimura

                        Else
                            Exit Function
                        End If
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

                '生産稼働日考慮
            Case "4"
                'カレンダマスタ検索
                If DSPCLDDT_SEARCH(strDate, Mst_Inf_NOW) = 0 Then
                    If Mst_Inf_NOW.DATKB = gc_strDATKB_USE Then
                        If IsNumeric(Mst_Inf_NOW.PRDKDDD) = True Then
                            curKDDATE = CDec(Mst_Inf_NOW.PRDKDDD)
                        Else
                            Exit Function
                        End If
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If

        End Select

        '日付加算
        curCALCDATE = curKDDATE + CDec(Pin_intAddDate)

        If DSPKDDT_SEARCH(CStr(curCALCDATE), Pin_strKind, strDate_W) <> 0 Then
            Exit Function
        End If

        Pio_strDate = strDate_W

        AE_CalcDate_Add = 0

    End Function


    ' === 20070309 === INSERT S - ACE)Nagasawa 売上後の入力可否制御の変更
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPCLDDT_SEARCH_WK
    '   概要：  カレンダマスタ検索(曜日計算)
    '   引数：  pin_strCLDDT   : 検索対象日付
    '           pin_strCLDWKKB : 曜日区分
    '           pin_strKEISAN  : 計算区分("1":加算 "2":減算)
    '           pot_strCLDDT   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：  検索対象日付より前、または後の曜日区分で指定された曜日に当たる日付を検索
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCLDDT_SEARCH_WK(ByVal pin_strCLDDT As String, ByVal pin_strCLDWKKB As String, ByVal pin_strKEISAN As String, ByRef pot_strCLDDT As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPCLDDT_SEARCH_WK

        DSPCLDDT_SEARCH_WK = 9
        pot_strCLDDT = ""

        strSQL = ""
        If pin_strKEISAN = "1" Then
            strSQL = strSQL & " Select MIN(CLDDT) AS GETDATE"
        Else
            strSQL = strSQL & " Select MAX(CLDDT) AS GETDATE"
        End If

        strSQL = strSQL & "   from CLDMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    And CLDWKKB = '" & CF_Ora_String(pin_strCLDWKKB, 1) & "' "

        If pin_strKEISAN = "1" Then
            strSQL = strSQL & "    and CLDDT >= '" & pin_strCLDDT & "' "
        Else
            strSQL = strSQL & "    and CLDDT <= '" & pin_strCLDDT & "' "
        End If

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPCLDDT_SEARCH_WK = 1
            Exit Function
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pot_strCLDDT = CF_Ora_GetDyn(Usr_Ody, "GETDATE", "")
        End If

        DSPCLDDT_SEARCH_WK = 0

ERR_DSPCLDDT_SEARCH_WK:

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

    End Function
    ' === 20070309 === INSERT E -

    ' スロット名        : 名称3・画面項目スロット
    ' ユニット名        : MEINMC.F51
    ' 記述者            : Standard Library
    ' 作成日付          : 2006/07/13
    ' 使用プログラム名  : MEIMT51
    '

    Function MEINMC_Check(ByVal MEICDA As Object, ByVal MEINMC As Object, ByVal EX_MEINMC As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short

        'UPGRADE_WARNING: オブジェクト MEINMC_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        MEINMC_Check = 0 '正常終了。
        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMC = " "
        End If
    End Function

    Function MEINMC_Derived(ByVal MEICDA As Object, ByVal MEINMC As Object, ByVal DE_INDEX As Object) As Object

        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMC = " "
            'UPGRADE_WARNING: オブジェクト MEINMC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            MEINMC = DB_MEIMTA.MEINMC
        End If
        'MEINMC_Derived = MEINMC

    End Function

    Function EXCTBZ_Insert(ByVal pDB_EXCTBZ As TYPE_DB_EXCTBZ) As Boolean

        Try
            Dim sqlStr As String = ""

            With pDB_EXCTBZ

                sqlStr &= " INSERT INTO EXCTBZ "
                sqlStr &= " (CLTID, GYMCD, LCKTM, SEQNO, INTLCD, EXTCD) "
                sqlStr &= " VALUES ('" & .CLTID & "', '" & .GYMCD & "', '" & .LCKTM & "', '" & .SEQNO & "', '" & .INTLCD & "', '" & .EXTCD & "') "
            End With

            DB_Execute(sqlStr)

        Catch ex As Exception
            MsgBox("EXCTBZ_Insert" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")

            Return False
        End Try

        Return True

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPHINCD_SEARCH
    '   概要：  製品コード検索
    '   引数：  pin_strHINCD  : 検索対象製品コード
    '           pot_DB_HINMTA : 検索結果
    '           pin_strKJNDT  : 原価単価適用基準日
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
    '    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, _
    ''                                    ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, Optional ByRef pin_strKJNDT As String = "") As Short
        ' === 20060828 === UPDATE E -

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            DSPHINCD_SEARCH = 9

            ' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
            Select Case True
                '基準日の指定がない場合
                Case Trim(pin_strKJNDT) = ""
                    pin_strKJNDT = GV_UNYDate

                    '日付の形式で渡される場合
                Case IsDate(pin_strKJNDT)
#Disable Warning BC40000 ' Type or member is obsolete
                    pin_strKJNDT = VB6.Format(pin_strKJNDT, "yyyymmdd")
#Enable Warning BC40000 ' Type or member is obsolete

                Case Else
            End Select
            ' === 20060828 === UPDATE E -

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from HINMTA "
            strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "

            'DBアクセス
            '20190318 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '20190318 CHG END

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPHINCD_SEARCH = 1
                Exit Function
            Else

                With pot_DB_HINMTA
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINMSTKB = DB_NullReplace(dt.Rows(0)("HINMSTKB"), "") 'マスタ区分（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCD = DB_NullReplace(dt.Rows(0)("HINCD"), "") '製品コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINNMA = DB_NullReplace(dt.Rows(0)("HINNMA"), "") '型式
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINNMB = DB_NullReplace(dt.Rows(0)("HINNMB"), "") '商品名１
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINNMC = DB_NullReplace(dt.Rows(0)("HINNMC"), "") '商品名２
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINNK = DB_NullReplace(dt.Rows(0)("HINNK"), "") '商品名カナ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINNMD = DB_NullReplace(dt.Rows(0)("HINNMD"), "") 'シリーズ商品名（半角）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINNME = DB_NullReplace(dt.Rows(0)("HINNME"), "") 'シリーズ商品名（全角）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UNTCD = DB_NullReplace(dt.Rows(0)("UNTCD"), "") '単位コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .UNTNM = DB_NullReplace(dt.Rows(0)("UNTNM"), "") '単位名
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINKB = DB_NullReplace(dt.Rows(0)("HINKB"), "") '商品区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINID = DB_NullReplace(dt.Rows(0)("HINID"), "") '商品種別
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLAKB = DB_NullReplace(dt.Rows(0)("HINCLAKB"), "") '分類区分１（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLBKB = DB_NullReplace(dt.Rows(0)("HINCLBKB"), "") '分類区分２（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLCKB = DB_NullReplace(dt.Rows(0)("HINCLCKB"), "") '分類区分３（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLAID = DB_NullReplace(dt.Rows(0)("HINCLAID"), "") '分類コード１（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLBID = DB_NullReplace(dt.Rows(0)("HINCLBID"), "") '分類コード２（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLCID = DB_NullReplace(dt.Rows(0)("HINCLCID"), "") '分類コード３（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLANM = DB_NullReplace(dt.Rows(0)("HINCLANM"), "") '分類名称１（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLBNM = DB_NullReplace(dt.Rows(0)("HINCLBNM"), "") '分類名称２（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCLCNM = DB_NullReplace(dt.Rows(0)("HINCLCNM"), "") '分類名称３（商品）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .DSPKB = DB_NullReplace(dt.Rows(0)("DSPKB"), "") '検索表示区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZAIKB = DB_NullReplace(dt.Rows(0)("ZAIKB"), "") '在庫管理区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINZEIKB = DB_NullReplace(dt.Rows(0)("HINZEIKB"), "") '商品消費税区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "") '消費税ランク
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0) '消費税率
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINJUNKB = DB_NullReplace(dt.Rows(0)("HINJUNKB"), "") '順意表出力区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MAKCD = DB_NullReplace(dt.Rows(0)("MAKCD"), "") 'メーカーコード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCMA = DB_NullReplace(dt.Rows(0)("HINCMA"), "") '商品備考Ａ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCMB = DB_NullReplace(dt.Rows(0)("HINCMB"), "") '商品備考B
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCMC = DB_NullReplace(dt.Rows(0)("HINCMC"), "") '商品備考C
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCMD = DB_NullReplace(dt.Rows(0)("HINCMD"), "") '商品備考D
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINCME = DB_NullReplace(dt.Rows(0)("HINCME"), "") '商品備考Ｅ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TEIKATK = DB_NullReplace(dt.Rows(0)("TEIKATK"), 0) '定価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZNKURITK = DB_NullReplace(dt.Rows(0)("ZNKURITK"), 0) '税抜販売単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZKMURITK = DB_NullReplace(dt.Rows(0)("ZKMURITK"), 0) '税込販売単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZNKSRETK = DB_NullReplace(dt.Rows(0)("ZNKSRETK"), 0) '税抜仕入単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZKMSRETK = DB_NullReplace(dt.Rows(0)("ZKMSRETK"), 0) '税込仕入単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .GNKTK = DB_NullReplace(dt.Rows(0)("GNKTK"), 0) '原価単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .PLANTK = DB_NullReplace(dt.Rows(0)("PLANTK"), 0) '計画単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .OLDGNKTK = DB_NullReplace(dt.Rows(0)("OLDGNKTK"), 0) '旧原価単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .GNKTKDT = DB_NullReplace(dt.Rows(0)("GNKTKDT"), "") '適用日(原価単価)
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .OLDPLNTK = DB_NullReplace(dt.Rows(0)("OLDPLNTK"), 0) '旧計画単価
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .PLNTKDT = DB_NullReplace(dt.Rows(0)("PLNTKDT"), "") '適用日（機種分類)
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SODUNTSU = DB_NullReplace(dt.Rows(0)("SODUNTSU"), 0) '発注単位数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TEKZAISU = DB_NullReplace(dt.Rows(0)("TEKZAISU"), 0) '適正在庫数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ANZZAISU = DB_NullReplace(dt.Rows(0)("ANZZAISU"), 0) '安全在庫数（販売計画用）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HRTDD = DB_NullReplace(dt.Rows(0)("HRTDD"), "") '発注リードタイム
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ORTDD = DB_NullReplace(dt.Rows(0)("ORTDD"), "") '出荷リードタイム
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .PRCDD = DB_NullReplace(dt.Rows(0)("PRCDD"), "") '調達リードタイム
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MNFDD = DB_NullReplace(dt.Rows(0)("MNFDD"), "") '製造リードタイム
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINSIRCD = DB_NullReplace(dt.Rows(0)("HINSIRCD"), "") '商品仕入先コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINSIRRN = DB_NullReplace(dt.Rows(0)("HINSIRRN"), "") '商品仕入先名称
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TNACM = DB_NullReplace(dt.Rows(0)("TNACM"), "") '棚番号
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINNMMKB = DB_NullReplace(dt.Rows(0)("HINNMMKB"), "") '名称ﾏﾆｭｱﾙ入力区分(商品)
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .JANCD = DB_NullReplace(dt.Rows(0)("JANCD"), "") 'ＪＡＮコード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINFRNNM = DB_NullReplace(dt.Rows(0)("HINFRNNM"), "") '商品名海外表記
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ZAIRNK = DB_NullReplace(dt.Rows(0)("ZAIRNK"), "") '在庫ランク
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .GNKCD = DB_NullReplace(dt.Rows(0)("GNKCD"), "") '原価管理コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MINSODSU = DB_NullReplace(dt.Rows(0)("MINSODSU"), 0) '最小発注数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SODADDSU = DB_NullReplace(dt.Rows(0)("SODADDSU"), 0) '発注増加数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .JODHIKKB = DB_NullReplace(dt.Rows(0)("JODHIKKB"), "") '受注引当区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ORTSTPKB = DB_NullReplace(dt.Rows(0)("ORTSTPKB"), "") '出荷停止
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ORTSTPDT = DB_NullReplace(dt.Rows(0)("ORTSTPDT"), "") '出荷停止日
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ORTKJDT = DB_NullReplace(dt.Rows(0)("ORTKJDT"), "") '出荷停止解除日
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ORTSTYDT = DB_NullReplace(dt.Rows(0)("ORTSTYDT"), "") '出荷開始予定日
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .CTLGKB = DB_NullReplace(dt.Rows(0)("CTLGKB"), "") 'カタログ品対象
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MLOKB = DB_NullReplace(dt.Rows(0)("MLOKB"), "") '通販対象
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MLOHINID = DB_NullReplace(dt.Rows(0)("MLOHINID"), "") '通販製品ＩＤ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MLOIDORT = DB_NullReplace(dt.Rows(0)("MLOIDORT"), 0) '通販移動比率
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MLOLMTSU = DB_NullReplace(dt.Rows(0)("MLOLMTSU"), "") '通販移動限度数
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .PRDENDKB = DB_NullReplace(dt.Rows(0)("PRDENDKB"), "") '生産終了
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .PRDENDDT = DB_NullReplace(dt.Rows(0)("PRDENDDT"), "") '生産終了日付
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SLENDKB = DB_NullReplace(dt.Rows(0)("SLENDKB"), "") '販売完了
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SLENDDT = DB_NullReplace(dt.Rows(0)("SLENDDT"), "") '販売完了日付
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .JODSTPKB = DB_NullReplace(dt.Rows(0)("JODSTPKB"), "") '受注停止
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .JODSTPDT = DB_NullReplace(dt.Rows(0)("JODSTPDT"), "") '受注停止日付
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MNTENDKB = DB_NullReplace(dt.Rows(0)("MNTENDKB"), "") '保守終了
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MNTENDDT = DB_NullReplace(dt.Rows(0)("MNTENDDT"), "") '保守終了日付
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ABODT = DB_NullReplace(dt.Rows(0)("ABODT"), "") '廃止日
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ORTKB = DB_NullReplace(dt.Rows(0)("ORTKB"), "") '出荷区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SERIKB = DB_NullReplace(dt.Rows(0)("SERIKB"), "") 'シリアル管理区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MAKNM = DB_NullReplace(dt.Rows(0)("MAKNM"), "") 'メーカー名
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .NXTMDL = DB_NullReplace(dt.Rows(0)("NXTMDL"), "") '後継機種
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .JODSTDT = DB_NullReplace(dt.Rows(0)("JODSTDT"), "") '受注開始日
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .ORTSTDT = DB_NullReplace(dt.Rows(0)("ORTSTDT"), "") '出荷開始日
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .KOUZA = DB_NullReplace(dt.Rows(0)("KOUZA"), "") '口座
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .MDLCL = DB_NullReplace(dt.Rows(0)("MDLCL"), "") '機種分類
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .OLDMDLCL = DB_NullReplace(dt.Rows(0)("OLDMDLCL"), "") '旧機種分類
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINGRP = DB_NullReplace(dt.Rows(0)("HINGRP"), "") '商品群
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .SKHINGRP = DB_NullReplace(dt.Rows(0)("SKHINGRP"), "") '仕切用商品群
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .OEMKB = DB_NullReplace(dt.Rows(0)("OEMKB"), "") 'ＯＥＭ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .OEMTOKRN = DB_NullReplace(dt.Rows(0)("OEMTOKRN"), "") 'ＯＥＭ得意先
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .OPENKB = DB_NullReplace(dt.Rows(0)("OPENKB"), "") 'オープン価格区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .STRMATKB = DB_NullReplace(dt.Rows(0)("STRMATKB"), "") '戦略物資区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TITNM1 = DB_NullReplace(dt.Rows(0)("TITNM1"), "") '題目１
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TITNM2 = DB_NullReplace(dt.Rows(0)("TITNM2"), "") '題目２
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .TITNM3 = DB_NullReplace(dt.Rows(0)("TITNM3"), "") '題目３
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .CATSPCNM = DB_NullReplace(dt.Rows(0)("CATSPCNM"), "") 'カタログスペック
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .HINURLNM = DB_NullReplace(dt.Rows(0)("HINURLNM"), "") '商品URL
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .CHARANM = DB_NullReplace(dt.Rows(0)("CHARANM"), "") '特徴
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .VSNNM = DB_NullReplace(dt.Rows(0)("VSNNM"), "") 'バージョン
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .EDIHINSY = DB_NullReplace(dt.Rows(0)("EDIHINSY"), "") 'EDI商品種別
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .BTOKB = DB_NullReplace(dt.Rows(0)("BTOKB"), "") 'BTO区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .KONPOP = DB_NullReplace(dt.Rows(0)("KONPOP"), 0) '梱包ポイント
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .LOTSEQNO = DB_NullReplace(dt.Rows(0)("LOTSEQNO"), "") 'ロット連番
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .KHNKB = DB_NullReplace(dt.Rows(0)("KHNKB"), "") '仮本区分
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）

                    ' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
                    If Trim(.GNKTKDT) <> "" Then
                        If .GNKTKDT > pin_strKJNDT Then
                            .GNKTK = .OLDGNKTK
                            .PLANTK = .OLDPLNTK
                        End If
                    End If
                    ' === 20060828 === UPDATE E -

                    ' === 20061107 === INSERT S - ACE)Nagasawa 機種分類適用日対応
                    If Trim(.PLNTKDT) <> "" Then
                        If .PLNTKDT > pin_strKJNDT Then
                            .MDLCL = .OLDMDLCL
                        End If
                    End If
                    ' === 20061107 === INSERT E -

                End With

            End If

            DSPHINCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPHINCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPHINCD_SEARCH_B
    '   概要：  製品コード検索（部品商品マスタも合わせて検索）
    '   引数：  pin_strHINCD  : 検索対象製品コード
    '           pot_DB_HINMTA : 検索結果
    '           pin_strKJNDT  : 原価単価適用基準日
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
    '    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, _
    ''                                      ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, Optional ByVal pin_strKJNDT As String = "") As Short
        ' === 20060828 === UPDATE E -
        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            DSPHINCD_SEARCH_B = 9

            ' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
            If Trim(pin_strKJNDT) = "" Then
                pin_strKJNDT = GV_UNYDate
            End If
            ' === 20060828 === UPDATE E -

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from HINMTA "
            strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "

            'DBアクセス
            '2019/03/18 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/18 CHG E N D

            '2019/03/18 CHG START
            'If CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/18 CHG E N D

                '取得データなし
                ''クローズ
                'Call CF_Ora_CloseDyn(Usr_Ody)

                '部品商品マスタ
                strSQL = ""
                strSQL = strSQL & " Select * "
                strSQL = strSQL & "   from BHNMTA "
                strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "

                'DBアクセス
                '2019/03/18 CHG START
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                dt = Nothing
                dt = DB_GetTable(strSQL)
                '2019/03/18 CHG E N D

                '2019/03/18 CHG START
                'If CF_Ora_EOF(Usr_Ody) = True Then
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    '2019/03/18 CHG E N D
                    '該当データ無し
                    DSPHINCD_SEARCH_B = 1
                    'GoTo END_DSPHINCD_SEARCH_B
                    Exit Function
                End If
            End If

            With pot_DB_HINMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINMSTKB = DB_NullReplace(dt.Rows(0)("HINMSTKB"), "") 'マスタ区分（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCD = DB_NullReplace(dt.Rows(0)("HINCD"), "") '製品コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMA = DB_NullReplace(dt.Rows(0)("HINNMA"), "") '型式
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMB = DB_NullReplace(dt.Rows(0)("HINNMB"), "") '商品名１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMC = DB_NullReplace(dt.Rows(0)("HINNMC"), "") '商品名２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNK = DB_NullReplace(dt.Rows(0)("HINNK"), "") '商品名カナ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMD = DB_NullReplace(dt.Rows(0)("HINNMD"), "") 'シリーズ商品名（半角）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNME = DB_NullReplace(dt.Rows(0)("HINNME"), "") 'シリーズ商品名（全角）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UNTCD = DB_NullReplace(dt.Rows(0)("UNTCD"), "") '単位コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UNTNM = DB_NullReplace(dt.Rows(0)("UNTNM"), "") '単位名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINKB = DB_NullReplace(dt.Rows(0)("HINKB"), "") '商品区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINID = DB_NullReplace(dt.Rows(0)("HINID"), "") '商品種別
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLAKB = DB_NullReplace(dt.Rows(0)("HINCLAKB"), "") '分類区分１（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLBKB = DB_NullReplace(dt.Rows(0)("HINCLBKB"), "") '分類区分２（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLCKB = DB_NullReplace(dt.Rows(0)("HINCLCKB"), "") '分類区分３（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLAID = DB_NullReplace(dt.Rows(0)("HINCLAID"), "") '分類コード１（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLBID = DB_NullReplace(dt.Rows(0)("HINCLBID"), "") '分類コード２（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLCID = DB_NullReplace(dt.Rows(0)("HINCLCID"), "") '分類コード３（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLANM = DB_NullReplace(dt.Rows(0)("HINCLANM"), "") '分類名称１（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLBNM = DB_NullReplace(dt.Rows(0)("HINCLBNM"), "") '分類名称２（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCLCNM = DB_NullReplace(dt.Rows(0)("HINCLCNM"), "") '分類名称３（商品）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DSPKB = DB_NullReplace(dt.Rows(0)("DSPKB"), "") '検索表示区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZAIKB = DB_NullReplace(dt.Rows(0)("ZAIKB"), "") '在庫管理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINZEIKB = DB_NullReplace(dt.Rows(0)("HINZEIKB"), "") '商品消費税区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "") '消費税ランク
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0) '消費税率
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINJUNKB = DB_NullReplace(dt.Rows(0)("HINJUNKB"), "") '順意表出力区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MAKCD = DB_NullReplace(dt.Rows(0)("MAKCD"), "") 'メーカーコード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCMA = DB_NullReplace(dt.Rows(0)("HINCMA"), "") '商品備考Ａ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCMB = DB_NullReplace(dt.Rows(0)("HINCMB"), "") '商品備考B
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCMC = DB_NullReplace(dt.Rows(0)("HINCMC"), "") '商品備考C
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCMD = DB_NullReplace(dt.Rows(0)("HINCMD"), "") '商品備考D
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINCME = DB_NullReplace(dt.Rows(0)("HINCME"), "") '商品備考Ｅ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TEIKATK = DB_NullReplace(dt.Rows(0)("TEIKATK"), 0) '定価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZNKURITK = DB_NullReplace(dt.Rows(0)("ZNKURITK"), 0) '税抜販売単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZKMURITK = DB_NullReplace(dt.Rows(0)("ZKMURITK"), 0) '税込販売単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZNKSRETK = DB_NullReplace(dt.Rows(0)("ZNKSRETK"), 0) '税抜仕入単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZKMSRETK = DB_NullReplace(dt.Rows(0)("ZKMSRETK"), 0) '税込仕入単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GNKTK = DB_NullReplace(dt.Rows(0)("GNKTK"), 0) '原価単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PLANTK = DB_NullReplace(dt.Rows(0)("PLANTK"), 0) '計画単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OLDGNKTK = DB_NullReplace(dt.Rows(0)("OLDGNKTK"), 0) '旧原価単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GNKTKDT = DB_NullReplace(dt.Rows(0)("GNKTKDT"), "") '適用日(原価単価)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OLDPLNTK = DB_NullReplace(dt.Rows(0)("OLDPLNTK"), 0) '旧計画単価
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PLNTKDT = DB_NullReplace(dt.Rows(0)("PLNTKDT"), "") '適用日（計画単価)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SODUNTSU = DB_NullReplace(dt.Rows(0)("SODUNTSU"), 0) '発注単位数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TEKZAISU = DB_NullReplace(dt.Rows(0)("TEKZAISU"), 0) '適正在庫数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ANZZAISU = DB_NullReplace(dt.Rows(0)("ANZZAISU"), 0) '安全在庫数（販売計画用）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HRTDD = DB_NullReplace(dt.Rows(0)("HRTDD"), "") '発注リードタイム
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ORTDD = DB_NullReplace(dt.Rows(0)("ORTDD"), "") '出荷リードタイム
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PRCDD = DB_NullReplace(dt.Rows(0)("PRCDD"), "") '調達リードタイム
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MNFDD = DB_NullReplace(dt.Rows(0)("MNFDD"), "") '製造リードタイム
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINSIRCD = DB_NullReplace(dt.Rows(0)("HINSIRCD"), "") '商品仕入先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINSIRRN = DB_NullReplace(dt.Rows(0)("HINSIRRN"), "") '商品仕入先名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TNACM = DB_NullReplace(dt.Rows(0)("TNACM"), "") '棚番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINNMMKB = DB_NullReplace(dt.Rows(0)("HINNMMKB"), "") '名称ﾏﾆｭｱﾙ入力区分(商品)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JANCD = DB_NullReplace(dt.Rows(0)("JANCD"), "") 'ＪＡＮコード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINFRNNM = DB_NullReplace(dt.Rows(0)("HINFRNNM"), "") '商品名海外表記
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZAIRNK = DB_NullReplace(dt.Rows(0)("ZAIRNK"), "") '在庫ランク
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GNKCD = DB_NullReplace(dt.Rows(0)("GNKCD"), "") '原価管理コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MINSODSU = DB_NullReplace(dt.Rows(0)("MINSODSU"), 0) '最小発注数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SODADDSU = DB_NullReplace(dt.Rows(0)("SODADDSU"), 0) '発注増加数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JODHIKKB = DB_NullReplace(dt.Rows(0)("JODHIKKB"), "") '受注引当区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ORTSTPKB = DB_NullReplace(dt.Rows(0)("ORTSTPKB"), "") '出荷停止
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ORTSTPDT = DB_NullReplace(dt.Rows(0)("ORTSTPDT"), "") '出荷停止日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ORTKJDT = DB_NullReplace(dt.Rows(0)("ORTKJDT"), "") '出荷停止解除日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ORTSTYDT = DB_NullReplace(dt.Rows(0)("ORTSTYDT"), "") '出荷開始予定日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CTLGKB = DB_NullReplace(dt.Rows(0)("CTLGKB"), "") 'カタログ品対象
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MLOKB = DB_NullReplace(dt.Rows(0)("MLOKB"), "") '通販対象
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MLOHINID = DB_NullReplace(dt.Rows(0)("MLOHINID"), "") '通販製品ＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MLOIDORT = DB_NullReplace(dt.Rows(0)("MLOIDORT"), 0) '通販移動比率
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MLOLMTSU = DB_NullReplace(dt.Rows(0)("MLOLMTSU"), "") '通販移動限度数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PRDENDKB = DB_NullReplace(dt.Rows(0)("PRDENDKB"), "") '生産終了
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PRDENDDT = DB_NullReplace(dt.Rows(0)("PRDENDDT"), "") '生産終了日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SLENDKB = DB_NullReplace(dt.Rows(0)("SLENDKB"), "") '販売完了
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SLENDDT = DB_NullReplace(dt.Rows(0)("SLENDDT"), "") '販売完了日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JODSTPKB = DB_NullReplace(dt.Rows(0)("JODSTPKB"), "") '受注停止
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JODSTPDT = DB_NullReplace(dt.Rows(0)("JODSTPDT"), "") '受注停止日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MNTENDKB = DB_NullReplace(dt.Rows(0)("MNTENDKB"), "") '保守終了
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MNTENDDT = DB_NullReplace(dt.Rows(0)("MNTENDDT"), "") '保守終了日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ABODT = DB_NullReplace(dt.Rows(0)("ABODT"), "") '廃止日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ORTKB = DB_NullReplace(dt.Rows(0)("ORTKB"), "") '出荷区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SERIKB = DB_NullReplace(dt.Rows(0)("SERIKB"), "") 'シリアル管理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MAKNM = DB_NullReplace(dt.Rows(0)("MAKNM"), "") 'メーカー名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NXTMDL = DB_NullReplace(dt.Rows(0)("NXTMDL"), "") '後継機種
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JODSTDT = DB_NullReplace(dt.Rows(0)("JODSTDT"), "") '受注開始日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ORTSTDT = DB_NullReplace(dt.Rows(0)("ORTSTDT"), "") '出荷開始日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KOUZA = DB_NullReplace(dt.Rows(0)("KOUZA"), "") '口座
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MDLCL = DB_NullReplace(dt.Rows(0)("MDLCL"), "") '機種分類
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OLDMDLCL = DB_NullReplace(dt.Rows(0)("OLDMDLCL"), "") '旧機種分類
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINGRP = DB_NullReplace(dt.Rows(0)("HINGRP"), "") '商品群
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SKHINGRP = DB_NullReplace(dt.Rows(0)("SKHINGRP"), "") '仕切用商品群
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OEMKB = DB_NullReplace(dt.Rows(0)("OEMKB"), "") 'ＯＥＭ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OEMTOKRN = DB_NullReplace(dt.Rows(0)("OEMTOKRN"), "") 'ＯＥＭ得意先
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPENKB = DB_NullReplace(dt.Rows(0)("OPENKB"), "") 'オープン価格区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STRMATKB = DB_NullReplace(dt.Rows(0)("STRMATKB"), "") '戦略物資区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TITNM1 = DB_NullReplace(dt.Rows(0)("TITNM1"), "") '題目１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TITNM2 = DB_NullReplace(dt.Rows(0)("TITNM2"), "") '題目２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TITNM3 = DB_NullReplace(dt.Rows(0)("TITNM3"), "") '題目３
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CATSPCNM = DB_NullReplace(dt.Rows(0)("CATSPCNM"), "") 'カタログスペック
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINURLNM = DB_NullReplace(dt.Rows(0)("HINURLNM"), "") '商品URL
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CHARANM = DB_NullReplace(dt.Rows(0)("CHARANM"), "") '特徴
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .VSNNM = DB_NullReplace(dt.Rows(0)("VSNNM"), "") 'バージョン
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .EDIHINSY = DB_NullReplace(dt.Rows(0)("EDIHINSY"), "") 'EDI商品種別
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BTOKB = DB_NullReplace(dt.Rows(0)("BTOKB"), "") 'BTO区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KONPOP = DB_NullReplace(dt.Rows(0)("KONPOP"), 0) '梱包ポイント
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .LOTSEQNO = DB_NullReplace(dt.Rows(0)("LOTSEQNO"), "") 'ロット連番
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KHNKB = DB_NullReplace(dt.Rows(0)("KHNKB"), "") '仮本区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
                ' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
                If Trim(.GNKTKDT) <> "" Then
                    If .GNKTKDT > pin_strKJNDT Then
                        .GNKTK = .OLDGNKTK
                        ' === 20080104 === INSERT S - ACE)Nagasawa
                        .PLANTK = .OLDPLNTK
                        ' === 20080104 === INSERT E -
                    End If
                End If
                ' === 20060828 === UPDATE E -

                ' === 20080104 === INSERT S - ACE)Nagasawa
                If Trim(.PLNTKDT) <> "" Then
                    If .PLNTKDT > pin_strKJNDT Then
                        .MDLCL = .OLDMDLCL
                    End If
                End If
                ' === 20080104 === INSERT E -

            End With

            DSPHINCD_SEARCH_B = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPHINCD_SEARCH_B" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    Public Function KNGMTA_SEARCH(ByVal pin_strKNGGRCD As String, ByRef pot_DB_KNGMTA As TYPE_DB_KNGMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody As U_Ody
            'Dim strTGRPCD As String

            'On Error GoTo ERR_KNGMTA_SEARCH

            KNGMTA_SEARCH = 9

            'Call DB_KNGMTA_Clear(pot_DB_KNGMTA)

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from KNGMTA "
            strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "    and KNGGRCD = '" & CF_Ora_Sgl(pin_strKNGGRCD) & "' "

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                KNGMTA_SEARCH = 1
                Exit Function
            End If

            ''DBアクセス
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

            'If CF_Ora_EOF(Usr_Ody) = True Then
            '    '取得データなし
            '    KNGMTA_SEARCH = 1
            '    GoTo END_KNGMTA_SEARCH
            'End If

            With pot_DB_KNGMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KNGGRCD = DB_NullReplace(dt.Rows(0)("KNGGRCD"), "") '権限グループ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SALTKKB = DB_NullReplace(dt.Rows(0)("SALTKKB"), "") '販売単価変更
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HDNTKKB = DB_NullReplace(dt.Rows(0)("HDNTKKB"), "") '発注単価変更
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SAPMODKB = DB_NullReplace(dt.Rows(0)("SAPMODKB"), "") '販売計画年初計画修正
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SAPCSVKB = DB_NullReplace(dt.Rows(0)("SAPCSVKB"), "") '販売計画CSV出力
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TRIUPDKB = DB_NullReplace(dt.Rows(0)("TRIUPDKB"), "") '取引先マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSUPDKB = DB_NullReplace(dt.Rows(0)("NHSUPDKB"), "") '納入先マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINUPDKB = DB_NullReplace(dt.Rows(0)("HINUPDKB"), "") '商品マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SIKUPDKB = DB_NullReplace(dt.Rows(0)("SIKUPDKB"), "") '仕切関連マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TUPUPDKB = DB_NullReplace(dt.Rows(0)("TUPUPDKB"), "") '海外販売単価マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SUPUPDKB = DB_NullReplace(dt.Rows(0)("SUPUPDKB"), "") '仕入単価マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SBNUPDKB = DB_NullReplace(dt.Rows(0)("SBNUPDKB"), "") '製番マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BMNUPDKB = DB_NullReplace(dt.Rows(0)("BMNUPDKB"), "") '部門マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TANUPDKB = DB_NullReplace(dt.Rows(0)("TANUPDKB"), "") '担当者マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KNGUPDKB = DB_NullReplace(dt.Rows(0)("KNGUPDKB"), "") '権限マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BNKUPDKB = DB_NullReplace(dt.Rows(0)("BNKUPDKB"), "") '銀行マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SOUUPDKB = DB_NullReplace(dt.Rows(0)("SOUUPDKB"), "") '倉庫マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MEIUPDKB = DB_NullReplace(dt.Rows(0)("MEIUPDKB"), "") '名称マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .FIXUPDKB = DB_NullReplace(dt.Rows(0)("FIXUPDKB"), "") '固定値マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TUKUPDKB = DB_NullReplace(dt.Rows(0)("TUKUPDKB"), "") 'レートマスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UNTUPDKB = DB_NullReplace(dt.Rows(0)("UNTUPDKB"), "") '単位マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLDUPDKB = DB_NullReplace(dt.Rows(0)("CLDUPDKB"), "") 'カレンダーマスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TAXUPDKB = DB_NullReplace(dt.Rows(0)("TAXUPDKB"), "") '消費税率マスタ更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TZNUPDKB = DB_NullReplace(dt.Rows(0)("TZNUPDKB"), "") '得意先残高更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SZNUPDKB = DB_NullReplace(dt.Rows(0)("SZNUPDKB"), "") '仕入先残高更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNUPDKB = DB_NullReplace(dt.Rows(0)("JDNUPDKB"), "") '受注更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HDNUPDKB = DB_NullReplace(dt.Rows(0)("HDNUPDKB"), "") '発注更新
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YOBKBA = DB_NullReplace(dt.Rows(0)("YOBKBA"), "") '予備区分A
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YOBKBB = DB_NullReplace(dt.Rows(0)("YOBKBB"), "") '予備区分B
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YOBKBC = DB_NullReplace(dt.Rows(0)("YOBKBC"), "") '予備区分C
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YOBKBD = DB_NullReplace(dt.Rows(0)("YOBKBD"), "") '予備区分D
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YOBKBE = DB_NullReplace(dt.Rows(0)("YOBKBE"), "") '予備区分E
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
            End With


            KNGMTA_SEARCH = 0

            'END_KNGMTA_SEARCH:
            '        'クローズ
            '        Call CF_Ora_CloseDyn(Usr_Ody)

            '        Exit Function

            'ERR_KNGMTA_SEARCH:
            '        GoTo END_KNGMTA_SEARCH
        Catch ex As Exception
            li_MsgRtn = MsgBox("KNGMTA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function







    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEIM_SEARCH
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEICDA : コード１
    '           pot_DB_MEIMTA : 検索結果
    '           pin_strMEICDB : コード２（省略された場合、検索条件に含めない）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEICDB As Object = Nothing) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_DSPMEIM_SEARCH

        DSPMEIM_SEARCH = 9

        strSQL = ""
        '20190618 DEL START
        'strSQL = strSQL & " Select * "
        'strSQL = strSQL & "   from MEIMTA "
        '20190618 DEL START

        strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pin_strMEICDB) = False Then
            'UPGRADE_WARNING: オブジェクト pin_strMEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
        End If

        Call GetRowsCommon("MEIMTA", strSQL)
        pot_DB_MEIMTA = DB_MEIMTA

        If DB_MEIMTA.DATKB Is Nothing Then
            DSPMEIM_SEARCH = 1
            Exit Function
        End If
        ''DBアクセス
        ''2019/03/14 CHG START
        ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        'Dim dt As DataTable = DB_GetTable(strSQL)
        ''2019/03/14 CHG E N D

        ''2019/03/14 CHG START
        ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
        'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
        '    '2019/03/14 CHG E N D
        '    '取得データなし
        '    DSPMEIM_SEARCH = 1
        '    GoTo END_DSPMEIM_SEARCH
        'End If

        '取得データ退避
        ' === 20060920 === UPDATE S - ACE)Sejima
        'D        With pot_DB_MEIMTA
        'D            .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '伝票削除区分
        'D            .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               'キー
        'D            .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '項目名
        'D            .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             'コード１
        'D            .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             'コード２
        'D            .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '名称１
        'D            .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '名称２
        'D            .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '名称３
        'D            .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '数値項目１
        'D            .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '数値項目２
        'D            .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '数値項目３
        'D            .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '区分１
        'D            .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '区分２
        'D            .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '区分３
        'D            .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '表示順序
        'D            .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '連携フラグ
        'D            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '最終作業者コード
        'D            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               'クライアントＩＤ
        'D            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               'タイムスタンプ（時間）
        'D            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               'タイムスタンプ（日付）
        'D            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
        'D            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         'タイムスタンプ（登録日）
        'D        End With
        ' === 20060920 === UPDATE ↓
        '2019/03/14 CHG START
        'Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
        ''Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
        'Call SetDataCommon("MEIMTA", dt)
        '2019/03/14 CHG E N D
        ' === 20060920 === UPDATE E

        DSPMEIM_SEARCH = 0

END_DSPMEIM_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_DSPMEIM_SEARCH:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEINMA_SEARCH_A1
    '   概要：  名称マスタ検索(名称１のあいまい検索）
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEINMA : 名称１
    '           pot_DB_MEIMTA : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMA_SEARCH_A1(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA, Optional ByRef pin_strMEICDA As Object = Nothing) As Short

        Dim strSQL As String
        Dim strSQLCount As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody
        Dim intIdx As Short

        On Error GoTo ERR_DSPMEINMA_SEARCH_A1

        DSPMEINMA_SEARCH_A1 = 9

        strSQL = ""
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
        'ADD START FKS)INABA 2009/07/17 ****************************************************************************
        '連絡票№FC09071701
        'UPGRADE_WARNING: オブジェクト pin_strMEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(pin_strMEICDA) = True Or Trim(pin_strMEICDA) = "" Then
        Else
            'UPGRADE_WARNING: オブジェクト pin_strMEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        End If
        strSQL = strSQL & "   ORDER BY MEICDA "
        'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************

        '件数取得
        strSQLCount = ""
        strSQLCount = strSQLCount & " Select Count(*) as DataCount "
        strSQLCount = strSQLCount & strSQL

        'DBアクセス
        '20190325 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)

        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)

        ''クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)

        'If intData = 0 Then
        '	'取得データなし
        '	DSPMEINMA_SEARCH_A1 = 1
        '	Exit Function
        '      End If

        Dim dt As DataTable = DB_GetTable(strSQLCount)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            DSPMEINMA_SEARCH_A1 = 1
            Exit Function
        End If
        intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
        dt = Nothing
        '20190325 CHG END

        strSQL = " Select * " & strSQL
        'DBアクセス
        '20190325 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '	'取得データなし
        '	DSPMEINMA_SEARCH_A1 = 1
        '	GoTo END_DSPMEINMA_SEARCH_A1
        'End If
        dt = DB_GetTable(strSQL)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            DSPMEINMA_SEARCH_A1 = 1
            Exit Function
        End If
        '20190325 CHG END


        '取得データ退避
        ReDim pot_DB_MEIMTA(intData)
        intIdx = 1

        '20190325 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        '	' === 20060920 === UPDATE S - ACE)Sejima
        '	'D            With pot_DB_MEIMTA(intIdx)
        '	'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '伝票削除区分
        '	'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               'キー
        '	'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '項目名
        '	'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             'コード１
        '	'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             'コード２
        '	'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '名称１
        '	'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '名称２
        '	'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '名称３
        '	'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '数値項目１
        '	'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '数値項目２
        '	'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '数値項目３
        '	'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '区分１
        '	'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '区分２
        '	'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '区分３
        '	'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '表示順序
        '	'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '連携フラグ
        '	'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '最終作業者コード
        '	'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               'クライアントＩＤ
        '	'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               'タイムスタンプ（時間）
        '	'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               'タイムスタンプ（日付）
        '	'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
        '	'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         'タイムスタンプ（登録日）
        '	'D            End With
        '          ' === 20060920 === UPDATE ↓
        '          Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intIdx))
        '          ' === 20060920 === UPDATE E
        '	intIdx = intIdx + 1
        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '      Loop
        For i As Integer = 0 To dt.Rows.Count - 1
            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA(intIdx), i)
            intIdx = intIdx + 1
        Next
        '20190325 CHG END

        DSPMEINMA_SEARCH_A1 = 0

END_DSPMEINMA_SEARCH_A1:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_DSPMEINMA_SEARCH_A1:

    End Function


    Sub Set_DB_MEIMTA(ByRef pDT As DataTable, ByRef pDB_MEIMTA As TYPE_DB_MEIMTA, ByVal DataCount As Integer)

        With pDB_MEIMTA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(pDT.Rows(DataCount)("DATKB"), "") '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .KEYCD = DB_NullReplace(pDT.Rows(DataCount)("KEYCD"), "") 'キー
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKMKNM = DB_NullReplace(pDT.Rows(DataCount)("MEIKMKNM"), "") '項目名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEICDA = DB_NullReplace(pDT.Rows(DataCount)("MEICDA"), "") 'コード１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEICDB = DB_NullReplace(pDT.Rows(DataCount)("MEICDB"), "") 'コード２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEINMA = DB_NullReplace(pDT.Rows(DataCount)("MEINMA"), "") '名称１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEINMB = DB_NullReplace(pDT.Rows(DataCount)("MEINMB"), "") '名称２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEINMC = DB_NullReplace(pDT.Rows(DataCount)("MEINMC"), "") '名称３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEISUA = DB_NullReplace(pDT.Rows(DataCount)("MEISUA"), 0) '数値項目１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEISUB = DB_NullReplace(pDT.Rows(DataCount)("MEISUB"), 0) '数値項目２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEISUC = DB_NullReplace(pDT.Rows(DataCount)("MEISUC"), 0) '数値項目３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKBA = DB_NullReplace(pDT.Rows(DataCount)("MEIKBA"), "") '区分１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKBB = DB_NullReplace(pDT.Rows(DataCount)("MEIKBB"), "") '区分２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .MEIKBC = DB_NullReplace(pDT.Rows(DataCount)("MEIKBC"), "") '区分３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DSPORD = DB_NullReplace(pDT.Rows(DataCount)("DSPORD"), "") '表示順序
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELFL = DB_NullReplace(pDT.Rows(DataCount)("RELFL"), "") '連携フラグ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FOPEID = DB_NullReplace(pDT.Rows(DataCount)("FOPEID"), "") '初回登録担当者ID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FCLTID = DB_NullReplace(pDT.Rows(DataCount)("FCLTID"), "") '初回登録クライアントID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(pDT.Rows(DataCount)("OPEID"), "") '更新担当者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(pDT.Rows(DataCount)("CLTID"), "") '更新クライアントＩＤ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(pDT.Rows(DataCount)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(pDT.Rows(DataCount)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UOPEID = DB_NullReplace(pDT.Rows(DataCount)("UOPEID"), "") 'バッチ更新担当者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UCLTID = DB_NullReplace(pDT.Rows(DataCount)("UCLTID"), "") 'バッチ更新クライアントID
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTTM = DB_NullReplace(pDT.Rows(DataCount)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .UWRTDT = DB_NullReplace(pDT.Rows(DataCount)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .PGID = DB_NullReplace(pDT.Rows(DataCount)("PGID"), "") 'ﾌﾟﾛｸﾞﾗﾑID
            ' === 20061227 === UPDATE E -
        End With

    End Sub


    'ADD START FKS)INABA 2009/07/17 ****************************************************************************
    '連絡票№FC09071701
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEINMA_SEARCH_A2
    '   概要：  名称マスタ検索(名称１でのあいまい検索(存在チェックのみ)）
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEINMA : 名称１
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMA_SEARCH_A2(ByVal pin_strKEYCD As String, ByVal pin_strMEINMA As String) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSQLCount As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody
            Dim intIdx As Short

            'On Error GoTo ERR_DSPMEINMA_SEARCH_A2

            DSPMEINMA_SEARCH_A2 = 9

            strSQL = ""
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
            strSQL = strSQL & "   and  MEINMA Like '" & pin_strMEINMA & "%' "
            strSQL = strSQL & "   ORDER BY MEICDA "

            '件数取得
            strSQLCount = ""
            strSQLCount = strSQLCount & " Select Count(*) as DataCount "
            strSQLCount = strSQLCount & strSQL

            'DBアクセス
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)

            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)

            ''クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If intData = 0 Then
            '	'取得データなし
            '	DSPMEINMA_SEARCH_A2 = 1
            '	Exit Function
            '      End If

            Dim dt As DataTable = DB_GetTable(strSQLCount)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEINMA_SEARCH_A2 = 1
                Exit Function
            End If
            intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
            dt = Nothing
            If intData = 0 Then
                '取得データなし
                DSPMEINMA_SEARCH_A2 = 1
                Exit Function
            End If
            '20190325 CHG END

            DSPMEINMA_SEARCH_A2 = 0

            '20190325 DEL START
            'END_DSPMEINMA_SEARCH_A2: 
            '		'クローズ
            '		Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '		Exit Function

            'ERR_DSPMEINMA_SEARCH_A2: 
            '20190325 DEL END
        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function
    'ADD  END  FKS)INABA 2009/07/17 ****************************************************************************


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEINMB_SEARCH
    '   概要：  名称マスタ検索(名称２の検索）
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEINMB : 名称２
    '           pot_DB_MEIMTA : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEINMB_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEINMB As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSQLCount As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody
            Dim intIdx As Short

            'On Error GoTo ERR_DSPMEINMB_SEARCH

            DSPMEINMB_SEARCH = 9

            strSQL = ""
            strSQL = " Select * " & strSQL
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  =    '" & pin_strKEYCD & "' "
            strSQL = strSQL & "   and  MEINMB =    '" & CF_Ora_String(pin_strMEINMB, 20) & "' "

            'DBアクセス
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '    '取得データなし
            '    DSPMEINMB_SEARCH = 1
            '    GoTo END_DSPMEINMB_SEARCH
            'End If

            ''取得データ退避
            'If CF_Ora_EOF(Usr_Ody_LC) = False Then
            '    ' === 20060920 === UPDATE S - ACE)Sejima 直送対応
            '    'D            With pot_DB_MEIMTA
            '    'D                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")               '伝票削除区分
            '    'D                .KEYCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEYCD", "")               'キー
            '    'D                .MEIKMKNM = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKMKNM", "")         '項目名
            '    'D                .MEICDA = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDA", "")             'コード１
            '    'D                .MEICDB = CF_Ora_GetDyn(Usr_Ody_LC, "MEICDB", "")             'コード２
            '    'D                .MEINMA = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMA", "")             '名称１
            '    'D                .MEINMB = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMB", "")             '名称２
            '    'D                .MEINMC = CF_Ora_GetDyn(Usr_Ody_LC, "MEINMC", "")             '名称３
            '    'D                .MEISUA = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUA", 0)              '数値項目１
            '    'D                .MEISUB = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUB", 0)              '数値項目２
            '    'D                .MEISUC = CF_Ora_GetDyn(Usr_Ody_LC, "MEISUC", 0)              '数値項目３
            '    'D                .MEIKBA = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBA", "")             '区分１
            '    'D                .MEIKBB = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBB", "")             '区分２
            '    'D                .MEIKBC = CF_Ora_GetDyn(Usr_Ody_LC, "MEIKBC", "")             '区分３
            '    'D                .DSPORD = CF_Ora_GetDyn(Usr_Ody_LC, "DSPORD", "")             '表示順序
            '    'D                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")               '連携フラグ
            '    'D                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")               '最終作業者コード
            '    'D                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")               'クライアントＩＤ
            '    'D                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")               'タイムスタンプ（時間）
            '    'D                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")               'タイムスタンプ（日付）
            '    'D                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")         'タイムスタンプ（登録時間）
            '    'D                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")         'タイムスタンプ（登録日）
            '    'D            End With
            '    ' === 20060920 === UPDATE ↓
            '    Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)
            '    ' === 20060920 === UPDATE E
            'End If

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEINMB_SEARCH = 1
                Exit Function
            End If

            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
            '20190325 CHG END

            DSPMEINMB_SEARCH = 0
            '20190325 DEL START
            'END_DSPMEINMB_SEARCH:
            '            'クローズ
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEINMB_SEARCH:
            '20190325 DEL END

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' === 20060920 === INSERT S - ACE)Sejima 直送対応
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEIKBA_SEARCH
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEIKBA : 区分１
    '           pot_DB_MEIMTA : 検索結果
    '           pin_strMEICDB : コード２（省略された場合、検索条件に含めない）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIKBA_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEIKBA As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPMEIKBA_SEARCH

            DSPMEIKBA_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
            strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "

            'DBアクセス
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '	'取得データなし
            '	DSPMEIKBA_SEARCH = 1
            '	GoTo END_DSPMEIKBA_SEARCH
            'End If

            ''取得データ退避
            'Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEIKBA_SEARCH = 1
                Exit Function
            End If

            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
            '20190325 CHG END

            DSPMEIKBA_SEARCH = 0

            'END_DSPMEIKBA_SEARCH:
            '            'クローズ
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEIKBA_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function
    ' === 20060920 === INSERT E

    ' === 20060822 === INSERT S - ACE)Sejima
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Get_KNNOUGYO
    '   概要：  今回納期－納入業者（納期情報登録用）取得
    '   引数：  pm_All           : 画面情報
    '           pot_intMaxLinNo  : 取得行№
    '   戻値：  0 : 正常　1 : 該当データなし　9 : 異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Get_KNNOUGYO(ByVal pin_strBINCD As String, ByRef pot_strKNNOUGYO As String) As Short

        Dim strKNNOUGYO As String
        Dim intRet As Short
        Dim Mst_Inf As TYPE_DB_MEIMTA
        Dim Ret_Value As Short

        On Error GoTo CF_Get_KNNOUGYO_Err

        'いったん「異常」
        Ret_Value = 9
        'いったん「なし」
        strKNNOUGYO = gc_strKNNOUGYO_NO

        If Trim(pin_strBINCD) <> "" Then

            '便名コードの入力がある場合、同コードをキーとして名称マスタを検索
            '20190618 CHG START
            'Call DB_MEIMTA_Clear(Mst_Inf)
            Call InitDataCommon("MEIMTA")
            '20190618 CHG END

            intRet = DSPMEIM_SEARCH(gc_strKEYCD_BINCD, pin_strBINCD, Mst_Inf)

            If intRet = 0 Then
                If Trim(Mst_Inf.MEINMB) <> "" Then
                    'データが取得でき、かつ名称２に値が入っている
                    '　⇒その値を返す（＝納入業者）
                    strKNNOUGYO = Trim(Mst_Inf.MEINMB)

                End If
            End If

        End If

        '「正常」
        Ret_Value = 0

CF_Get_KNNOUGYO_End:
        '取得したコードを返す
        pot_strKNNOUGYO = strKNNOUGYO

        CF_Get_KNNOUGYO = Ret_Value
        Exit Function

CF_Get_KNNOUGYO_Err:
        GoTo CF_Get_KNNOUGYO_End

    End Function
    ' === 20060822 === INSERT E

    ' === 20060921 === INSERT S - ACE)Sejima
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Get_CRM_RsnCnKb
    '   概要：  受注（ｷｬﾝｾﾙ）理由取得（CRM用）
    '   引数：　pin_strKEYCD   : キー
    '           pin_strMEICDA  : コード１
    '           pot_strRsnCnKb : 理由ｺｰﾄﾞ（名称３）
    '           pot_strRsnCnNm : 理由名称（名称２）
    '   戻値：　0:正常  9:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Get_CRM_RsnCnKb(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strRsnCnKb As String, ByRef pot_strRsnCnNm As String) As Short

        Dim Ret_Value As Short
        Dim Mst_Inf As TYPE_DB_MEIMTA

        On Error GoTo CF_Get_CRM_RsnCnKb_End

        CF_Get_CRM_RsnCnKb = 9

        'いったんエラー扱い
        Ret_Value = 9

        '戻す変数を初期化
        pot_strRsnCnKb = ""
        pot_strRsnCnNm = ""

        If DSPMEIM_SEARCH(pin_strKEYCD, pin_strMEICDA, Mst_Inf) = 0 Then
            '論理削除チェック
            If Mst_Inf.DATKB = "9" Then
            Else
                '取得値を格納
                pot_strRsnCnKb = Trim(Mst_Inf.MEINMC)
                pot_strRsnCnNm = Trim(Mst_Inf.MEINMB)
            End If
        End If

        'CRM編集用に加工
        pot_strRsnCnKb = CF_ZeroLenFormat(pot_strRsnCnKb, 6, True)
        pot_strRsnCnNm = CF_Ctr_AnsiLeftB(pot_strRsnCnNm & Space(40), 40)

        '正常扱い
        Ret_Value = 0

CF_Get_CRM_RsnCnKb_End:
        '戻り値を返す
        CF_Get_CRM_RsnCnKb = Ret_Value

    End Function
    ' === 20060921 === INSERT E

    ' === 20061110 === INSERT S - ACE)Nagasawa セットアップ仕変更対応
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEIM_SEARCH_ALL
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD  : キー１
    '           pot_DB_MEIMTA : 検索結果（配列）
    '   戻値：　0:正常終了 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIM_SEARCH_ALL(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim strSQL_Where As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPMEIM_SEARCH_ALL

            DSPMEIM_SEARCH_ALL = 9

            '戻り値のクリア
            Erase pot_DB_MEIMTA

            strSQL = ""
            strSQL = strSQL & " Select Count(*) As CNTDATA"

            strSQL_Where = ""
            strSQL_Where = strSQL_Where & "   from MEIMTA "
            strSQL_Where = strSQL_Where & "  Where KEYCD  = '" & pin_strKEYCD & "' "

            strSQL = strSQL & strSQL_Where

            'DBアクセス
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            ''件数取得
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))

            ''クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody_LC)

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEIM_SEARCH_ALL = 1
                Exit Function
            End If
            intData = DB_NullReplace(dt.Rows(0)("CNTDATA"), 0)
            dt = Nothing
            If intData = 0 Then
                '取得データなし
                DSPMEIM_SEARCH_ALL = 1
                Exit Function
            End If
            '20190325 CHG END

            '検索
            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & strSQL_Where

            ReDim pot_DB_MEIMTA(intData)

            'DBアクセス
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            ''取得データ退避
            'intData = 1
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

            '	Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))

            '	Call CF_Ora_MoveNext(Usr_Ody_LC)
            '	intData = intData + 1
            'Loop 

            dt = DB_GetTable(strSQL)
            intData = 1
            For i As Integer = 0 To dt.Rows.Count - 1
                Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA(intData), i)
                intData = intData + 1
            Next
            '20190325 CHG END

            DSPMEIM_SEARCH_ALL = 0

            'END_DSPMEIM_SEARCH_ALL:
            '            'クローズ
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEIM_SEARCH_ALL:

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function
    ' === 20061110 === INSERT E -

    ' === 20070213 === INSERT S - ACE)Nagasawa システム受注で機器受注を入力可とする
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEIKB_SEARCH
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD  : キー１
    '           pot_DB_MEIMTA : 検索結果
    '           pin_strMEIKBA : 区分１（省略された場合、検索条件に含めない）
    '           pin_strMEIKBB : 区分２（省略された場合、検索条件に含めない）
    '           pin_strMEIKBC : 区分３（省略された場合、検索条件に含めない）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：  区分での検索
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIKB_SEARCH(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, Optional ByVal pin_strMEIKBA As String = "", Optional ByVal pin_strMEIKBB As String = "", Optional ByVal pin_strMEIKBC As String = "") As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPMEIKB_SEARCH

            DSPMEIKB_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from MEIMTA "
            strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "

            '区分１
            If Trim(pin_strMEIKBA) <> "" Then
                strSQL = strSQL & "   and  MEIKBA = '" & pin_strMEIKBA & "' "
            End If

            '区分２
            If Trim(pin_strMEIKBB) <> "" Then
                strSQL = strSQL & "   and  MEIKBB = '" & pin_strMEIKBB & "' "
            End If

            '区分３
            If Trim(pin_strMEIKBC) <> "" Then
                strSQL = strSQL & "   and  MEIKBC = '" & pin_strMEIKBC & "' "
            End If

            '並び順
            strSQL = strSQL & "  Order By KEYCD, MEICDA "

            'DBアクセス
            '20190325 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '    '取得データなし
            '    DSPMEIKB_SEARCH = 1
            '    GoTo END_DSPMEIKB_SEARCH
            'End If

            ''取得データ退避
            'Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA)

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                DSPMEIKB_SEARCH = 1
                Exit Function
            End If

            Call Set_DB_MEIMTA(dt, pot_DB_MEIMTA, 0)
            '20190325 CHG END

            DSPMEIKB_SEARCH = 0

            'END_DSPMEIKB_SEARCH:
            '            'クローズ
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_DSPMEIKB_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function
    ' === 20070213 === INSERT E -

    ' === 20130719 === INSERT S - FWEST)Koroyasau エンドユーザ対応
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function ENDUSRNM_SEARCH
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD     : キー１
    '           pin_strMEICDA    : コード
    '           pot_strENDUSRNM  : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRNM_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByRef pot_strENDUSRNM As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_ENDUSRNM_SEARCH

        ENDUSRNM_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select "
        strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strMEICDA) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '取得データなし
            ENDUSRNM_SEARCH = 1
            GoTo END_ENDUSRNM_SEARCH
        End If

        '取得データ退避
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")

        ENDUSRNM_SEARCH = 0

END_ENDUSRNM_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_ENDUSRNM_SEARCH:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function ENDUSRNM_SEARCH2
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEINM  : 名称
    '           pot_DB_MEIMTA : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRNM_SEARCH2(ByVal pin_strKEYCD As String, ByVal pin_strMEINM As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_ENDUSRNM_SEARCH2

        ENDUSRNM_SEARCH2 = 9

        strSQL = ""
        strSQL = strSQL & " Select "
        strSQL = strSQL & "        Rtrim(MEINMA) "
        strSQL = strSQL & "        , Rtrim(MEINMB) "
        strSQL = strSQL & "        , Rtrim(MEINMC) "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "   and  KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC)  = '" & Trim(pin_strMEINM) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
            '取得データなし
            ENDUSRNM_SEARCH2 = 1
            GoTo END_ENDUSRNM_SEARCH2
        End If

        ENDUSRNM_SEARCH2 = 0

END_ENDUSRNM_SEARCH2:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_ENDUSRNM_SEARCH2:

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function RPTTKA_CHK_SEARCH
    '   概要：  名称マスタ検索
    '   引数：  pin_strMEINM  : 名称
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function RPTTKA_CHK_SEARCH(ByVal pin_strMEINM As String) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_RPTTKA_CHK_SEARCH

        RPTTKA_CHK_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select MEINMA "
        strSQL = strSQL & "   from MEIMTA "
        strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "   and  KEYCD  = '" & gc_strKEYCD_YUKOKGN & "' "
        strSQL = strSQL & "   and  MEINMA  = '" & Trim(pin_strMEINM) & "' "
        strSQL = strSQL & "   and  MEIKBA  = '" & gc_strRPTTKA_ON & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        If CF_Ora_RecordCount(Usr_Ody_LC) = 0 Then
            '取得データなし
            RPTTKA_CHK_SEARCH = 1
            GoTo END_RPTTKA_CHK_SEARCH
        End If

        RPTTKA_CHK_SEARCH = 0

END_RPTTKA_CHK_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_RPTTKA_CHK_SEARCH:

    End Function
    ' === 20130719 === INSERT E -






    Function MEINMA_Check(ByVal MEICDA As Object, ByVal MEINMA As Object, ByVal EX_MEINMA As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short

        'UPGRADE_WARNING: オブジェクト MEINMA_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        MEINMA_Check = 0 '正常終了。
        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMA = " "
        End If
    End Function

    Function MEINMA_Derived(ByVal MEICDA As Object, ByVal MEINMA As Object, ByVal DE_INDEX As Object) As Object

        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMA = " "
            'UPGRADE_WARNING: オブジェクト MEINMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            MEINMA = DB_MEIMTA.MEINMA
        End If
        'MEINMA_Derived = MEINMA

    End Function



    Function MEINMB_Check(ByVal MEICDA As Object, ByVal MEINMB As Object, ByVal EX_MEINMB As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short

        'UPGRADE_WARNING: オブジェクト MEINMB_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        MEINMB_Check = 0 '正常終了。
        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMB = " "
        End If
    End Function

    Function MEINMB_Derived(ByVal MEICDA As Object, ByVal MEINMB As Object, ByVal DE_INDEX As Object) As Object

        'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(MEICDA) = "" Then
            DB_MEIMTA.MEINMB = " "
            'UPGRADE_WARNING: オブジェクト MEINMB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            MEINMB = DB_MEIMTA.MEINMB
        End If
        'MEINMB_Derived = MEINMB

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function MF_Chk_UWRTDTTM
    '   概要：  更新時間チェック処理
    '   引数：  pin_strWRTDT    : 更新日付
    '           pin_strWRTTM    : 更新時刻
    '           pin_strUWRTDT   : バッチ更新日付
    '           pin_strUWRTTM   : バッチ更新時刻
    '   戻値：　True：チェックOK　False：チェックNG
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_Chk_UWRTDTTM(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String) As Boolean


        On Error GoTo MF_Chk_UWRTDTTM_err

        MF_Chk_UWRTDTTM = False


        '更新時間チェック
        If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_inf.WRTDT) & Trim(M_MOTO_inf.WRTTM) & Trim(M_MOTO_inf.UWRTDT) & Trim(M_MOTO_inf.UWRTTM) Then
            GoTo MF_Chk_UWRTDTTM_End
        End If

        MF_Chk_UWRTDTTM = True

MF_Chk_UWRTDTTM_End:
        Exit Function

MF_Chk_UWRTDTTM_err:
        GoTo MF_Chk_UWRTDTTM_End

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function MF_Chk_UWRTDTTM_T
    '   概要：  更新時間チェック処理
    '   引数：  pin_strWRTDT    : 更新日付
    '           pin_strWRTTM    : 更新時刻
    '           pin_strUWRTDT   : バッチ更新日付
    '           pin_strUWRTTM   : バッチ更新時刻
    '           pin_intIDX      : 多明細の場合　　　　明細行（0～）
    '   　　　　　　　　　　　　　得意先Ｍ登録の場合　0…得意先 1…仕入先
    '   戻値：　True：チェックOK　False：チェックNG
    '   備考：  多明細及び、得意先Ｍ登録用
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_Chk_UWRTDTTM_T(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean


        On Error GoTo MF_Chk_UWRTDTTM_T_err

        MF_Chk_UWRTDTTM_T = False

        '''    MsgBox "A " & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM)
        '''    MsgBox "B " & Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & _
        'Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM)

        'CHG START FKS)ASANO 2008/03/18
        If InStr(Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then

            '更新時間チェック
            If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM) Then
                GoTo MF_Chk_UWRTDTTM_T_End
            End If
        End If

        'CHG END FKS)ASANO 2008/03/18

        MF_Chk_UWRTDTTM_T = True

MF_Chk_UWRTDTTM_T_End:
        Exit Function

MF_Chk_UWRTDTTM_T_err:
        GoTo MF_Chk_UWRTDTTM_T_End

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function MF_CmnMsgLibrary
    '   概要：  メッセージ表示処理
    '   引数：  pin_strMsgCode  : メッセージコード
    '   戻値：  選択ボタン
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_DspMsg(ByVal pin_strMsgCode As String) As Short

        Dim intRet As Short

        On Error Resume Next

        MF_DspMsg = False

        'メッセージ表示
        intRet = DSP_MsgBox(SSS_ERROR, pin_strMsgCode, 0)

        MF_DspMsg = intRet

MF_DspMsg_End:
        Exit Function

MF_DspMsg_err:
        GoTo MF_DspMsg_End

    End Function

    '2007/12/24 add-str M.SUEZAWA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function MF_UpDown_UWRTDTTM
    '   概要：  明細　削除・挿入処理
    '   引数：  pin_intIDX      : 対象行
    '           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
    '   戻値：　True：処理OK　False：処理NG
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean

        On Error GoTo MF_UpDown_UWRTDTTM_err

        MF_UpDown_UWRTDTTM = False

        '更新時間　配列移動
        M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT
        M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM
        M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT
        M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM

        M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
        M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
        M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
        M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""

        MF_UpDown_UWRTDTTM = True

MF_UpDown_UWRTDTTM_End:
        Exit Function

MF_UpDown_UWRTDTTM_err:
        GoTo MF_UpDown_UWRTDTTM_End

    End Function
    '2007/12/24 add-end M.SUEZAWA

    '2007/12/24 add-str M.SUEZAWA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function MF_SaveRestore_UWRTDTTM
    '   概要：  明細　退避・復元処理
    '   引数：  pin_intIDX      : 対象行
    '           pin_intKBN      : 0…退避　1…復元
    '   戻値：　True：処理OK　False：処理NG
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean

        On Error GoTo MF_SaveRestore_UWRTDTTM_err

        MF_SaveRestore_UWRTDTTM = False

        If pin_intKBN = 0 Then
            '退避・復元処理
            M_MOTO_inf.WRTDT = M_MOTO_A_inf(pin_intIDX).WRTDT
            M_MOTO_inf.WRTTM = M_MOTO_A_inf(pin_intIDX).WRTTM
            M_MOTO_inf.UWRTDT = M_MOTO_A_inf(pin_intIDX).UWRTDT
            M_MOTO_inf.UWRTTM = M_MOTO_A_inf(pin_intIDX).UWRTTM
        Else
            '復元処理
            M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_inf.WRTDT
            M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_inf.WRTTM
            M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_inf.UWRTDT
            M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_inf.UWRTTM
        End If

        MF_SaveRestore_UWRTDTTM = True

MF_SaveRestore_UWRTDTTM_End:
        Exit Function

MF_SaveRestore_UWRTDTTM_err:
        GoTo MF_SaveRestore_UWRTDTTM_End

    End Function
    '2007/12/24 add-end M.SUEZAWA

    '2007/12/24 add-str M.SUEZAWA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function MF_Clear_UWRTDTTM
    '   概要：  明細　対象行クリア処理
    '   引数：  pin_intIDX      : 対象行
    '   戻値：　True：処理OK　False：処理NG
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean

        On Error GoTo MF_Clear_UWRTDTTM_err

        MF_Clear_UWRTDTTM = False
        '更新時間　配列クリア
        M_MOTO_A_inf(pin_intIDX).WRTDT = ""
        M_MOTO_A_inf(pin_intIDX).WRTTM = ""
        M_MOTO_A_inf(pin_intIDX).UWRTDT = ""
        M_MOTO_A_inf(pin_intIDX).UWRTTM = ""

        MF_Clear_UWRTDTTM = True

MF_Clear_UWRTDTTM_End:
        Exit Function

MF_Clear_UWRTDTTM_err:
        GoTo MF_Clear_UWRTDTTM_End

    End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPNHSCD_SEARCH
    '   概要：  納入先コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPNHSCD_SEARCH(ByVal pin_strNHSCD As String, ByRef pot_DB_NHSMTA As TYPE_DB_NHSMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPNHSCD_SEARCH

        DSPNHSCD_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from NHSMTA "
        strSQL = strSQL & "  Where NHSCD = '" & pin_strNHSCD & "' "


        'DBアクセス
        '2019/03/18 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/18 CHG E N D

        '2019/03/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/03/18 CHG E N D
            '取得データなし
            DSPNHSCD_SEARCH = 1
            GoTo END_DSPNHSCD_SEARCH
        End If

        '2019/03/18 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    With pot_DB_NHSMTA
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "") 'マスタ区分（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '納入先コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "") '納入先名称１
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "") '納入先名称２
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSRN", "") '納入先略称
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSNK = CF_Ora_GetDyn(Usr_Ody, "NHSNK", "") '納入先名称カナ
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSRNNK = CF_Ora_GetDyn(Usr_Ody, "NHSRNNK", "") '納入先略称カナ
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSZP = CF_Ora_GetDyn(Usr_Ody, "NHSZP", "") '納入先郵便番号
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "") '納入先住所１
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "") '納入先住所２
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "") '納入先住所３
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSTL = CF_Ora_GetDyn(Usr_Ody, "NHSTL", "") '納入先電話番号
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSFX = CF_Ora_GetDyn(Usr_Ody, "NHSFX", "") '納入先ＦＡＸ番号
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSBOSNM = CF_Ora_GetDyn(Usr_Ody, "NHSBOSNM", "") '納入先代表者名
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCTANM = CF_Ora_GetDyn(Usr_Ody, "NHSCTANM", "") '納入先御担当者名
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSMLAD = CF_Ora_GetDyn(Usr_Ody, "NHSMLAD", "") '納入先メールアドレス
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLAKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLAKB", "") '分類区分１（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLBKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLBKB", "") '分類区分２（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLCKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLCKB", "") '分類区分３（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLAID = CF_Ora_GetDyn(Usr_Ody, "NHSCLAID", "") '分類コード１（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLBID = CF_Ora_GetDyn(Usr_Ody, "NHSCLBID", "") '分類コード２（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLCID = CF_Ora_GetDyn(Usr_Ody, "NHSCLCID", "") '分類コード３（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLANM = CF_Ora_GetDyn(Usr_Ody, "NHSCLANM", "") '分類名称１（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLBNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLBNM", "") '分類名称２（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSCLCNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLCNM", "") '分類名称３（納入先）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "") '名称マニュアル入力区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OLDNHSCD = CF_Ora_GetDyn(Usr_Ody, "OLDNHSCD", "") '旧納入先コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .NGRPCD = CF_Ora_GetDyn(Usr_Ody, "NGRPCD", "") 'グループ会社コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OLNGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLNGRPCD", "") '旧グループ会社コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "") '業種
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "") '地域
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "") '便区分
        '        ' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '海外取引区分
        '        ' === 20061224 === INSERT E -
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
        '    End With
        'End If
        With pot_DB_NHSMTA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSMSTKB = DB_NullReplace(dt.Rows(0)("NHSMSTKB"), "") 'マスタ区分（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCD = DB_NullReplace(dt.Rows(0)("NHSCD"), "") '納入先コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSNMA = DB_NullReplace(dt.Rows(0)("NHSNMA"), "") '納入先名称１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSNMB = DB_NullReplace(dt.Rows(0)("NHSNMB"), "") '納入先名称２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSRN = DB_NullReplace(dt.Rows(0)("NHSRN"), "") '納入先略称
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSNK = DB_NullReplace(dt.Rows(0)("NHSNK"), "") '納入先名称カナ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSRNNK = DB_NullReplace(dt.Rows(0)("NHSRNNK"), "") '納入先略称カナ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSZP = DB_NullReplace(dt.Rows(0)("NHSZP"), "") '納入先郵便番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSADA = DB_NullReplace(dt.Rows(0)("NHSADA"), "") '納入先住所１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSADB = DB_NullReplace(dt.Rows(0)("NHSADB"), "") '納入先住所２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSADC = DB_NullReplace(dt.Rows(0)("NHSADC"), "") '納入先住所３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSTL = DB_NullReplace(dt.Rows(0)("NHSTL"), "") '納入先電話番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSFX = DB_NullReplace(dt.Rows(0)("NHSFX"), "") '納入先ＦＡＸ番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSBOSNM = DB_NullReplace(dt.Rows(0)("NHSBOSNM"), "") '納入先代表者名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCTANM = DB_NullReplace(dt.Rows(0)("NHSCTANM"), "") '納入先御担当者名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSMLAD = DB_NullReplace(dt.Rows(0)("NHSMLAD"), "") '納入先メールアドレス
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLAKB = DB_NullReplace(dt.Rows(0)("NHSCLAKB"), "") '分類区分１（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLBKB = DB_NullReplace(dt.Rows(0)("NHSCLBKB"), "") '分類区分２（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLCKB = DB_NullReplace(dt.Rows(0)("NHSCLCKB"), "") '分類区分３（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLAID = DB_NullReplace(dt.Rows(0)("NHSCLAID"), "") '分類コード１（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLBID = DB_NullReplace(dt.Rows(0)("NHSCLBID"), "") '分類コード２（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLCID = DB_NullReplace(dt.Rows(0)("NHSCLCID"), "") '分類コード３（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLANM = DB_NullReplace(dt.Rows(0)("NHSCLANM"), "") '分類名称１（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLBNM = DB_NullReplace(dt.Rows(0)("NHSCLBNM"), "") '分類名称２（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSCLCNM = DB_NullReplace(dt.Rows(0)("NHSCLCNM"), "") '分類名称３（納入先）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NHSNMMKB = DB_NullReplace(dt.Rows(0)("NHSNMMKB"), "") '名称マニュアル入力区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OLDNHSCD = DB_NullReplace(dt.Rows(0)("OLDNHSCD"), "") '旧納入先コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .NGRPCD = DB_NullReplace(dt.Rows(0)("NGRPCD"), "") 'グループ会社コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OLNGRPCD = DB_NullReplace(dt.Rows(0)("OLNGRPCD"), "") '旧グループ会社コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .GYOSHU = DB_NullReplace(dt.Rows(0)("GYOSHU"), "") '業種
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CHIIKI = DB_NullReplace(dt.Rows(0)("CHIIKI"), "") '地域
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .BINCD = DB_NullReplace(dt.Rows(0)("BINCD"), "") '便区分
            ' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .FRNKB = DB_NullReplace(dt.Rows(0)("FRNKB"), "") '海外取引区分
            ' === 20061224 === INSERT E -
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
        End With
        '2019/03/18 CHG E N D

        DSPNHSCD_SEARCH = 0

END_DSPNHSCD_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPNHSCD_SEARCH:
        GoTo END_DSPNHSCD_SEARCH

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPNHSNMA_SEARCH
    '   概要：  納入先名称１検索
    '   引数：　pin_strNHSNMA :　納入先名称１
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPNHSNMA_SEARCH(ByVal pin_strNHSNMA As String, ByRef pot_DB_NHSMTA As TYPE_DB_NHSMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPNHSNMA_SEARCH

        DSPNHSNMA_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from NHSMTA "
        strSQL = strSQL & "  Where TRIM(NHSNMA) = '" & Trim(pin_strNHSNMA) & "' "


        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPNHSNMA_SEARCH = 1
            GoTo END_DSPNHSNMA_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_NHSMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "") 'マスタ区分（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '納入先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "") '納入先名称１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "") '納入先名称２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSRN = CF_Ora_GetDyn(Usr_Ody, "NHSRN", "") '納入先略称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNK = CF_Ora_GetDyn(Usr_Ody, "NHSNK", "") '納入先名称カナ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSRNNK = CF_Ora_GetDyn(Usr_Ody, "NHSRNNK", "") '納入先略称カナ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSZP = CF_Ora_GetDyn(Usr_Ody, "NHSZP", "") '納入先郵便番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "") '納入先住所１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "") '納入先住所２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "") '納入先住所３
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSTL = CF_Ora_GetDyn(Usr_Ody, "NHSTL", "") '納入先電話番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSFX = CF_Ora_GetDyn(Usr_Ody, "NHSFX", "") '納入先ＦＡＸ番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSBOSNM = CF_Ora_GetDyn(Usr_Ody, "NHSBOSNM", "") '納入先代表者名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCTANM = CF_Ora_GetDyn(Usr_Ody, "NHSCTANM", "") '納入先御担当者名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSMLAD = CF_Ora_GetDyn(Usr_Ody, "NHSMLAD", "") '納入先メールアドレス
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLAKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLAKB", "") '分類区分１（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLBKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLBKB", "") '分類区分２（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLCKB = CF_Ora_GetDyn(Usr_Ody, "NHSCLCKB", "") '分類区分３（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLAID = CF_Ora_GetDyn(Usr_Ody, "NHSCLAID", "") '分類コード１（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLBID = CF_Ora_GetDyn(Usr_Ody, "NHSCLBID", "") '分類コード２（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLCID = CF_Ora_GetDyn(Usr_Ody, "NHSCLCID", "") '分類コード３（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLANM = CF_Ora_GetDyn(Usr_Ody, "NHSCLANM", "") '分類名称１（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLBNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLBNM", "") '分類名称２（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCLCNM = CF_Ora_GetDyn(Usr_Ody, "NHSCLCNM", "") '分類名称３（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "") '名称マニュアル入力区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OLDNHSCD = CF_Ora_GetDyn(Usr_Ody, "OLDNHSCD", "") '旧納入先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NGRPCD = CF_Ora_GetDyn(Usr_Ody, "NGRPCD", "") 'グループ会社コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OLNGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLNGRPCD", "") '旧グループ会社コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "") '業種
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "") '地域
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "") '便区分
                ' === 20061224 === INSERT S - ACE)Nagasawa 郵便番号/電話番号/FAX番号の追加
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '海外取引区分
                ' === 20061224 === INSERT E -
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            End With
        End If

        DSPNHSNMA_SEARCH = 0

END_DSPNHSNMA_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPNHSNMA_SEARCH:
        GoTo END_DSPNHSNMA_SEARCH

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPSOUCD_SEARCH
    '   概要：  倉庫コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPSOUCD_SEARCH(ByVal pin_strSOUCD As String, ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPSOUCD_SEARCH

        DSPSOUCD_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SOUMTA "
        strSQL = strSQL & "  Where SOUCD = '" & pin_strSOUCD & "' "


        'DBアクセス
        '2019/03/14 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/14 CHG E N D

        '2019/03/14 CHG START
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/03/14 CHG E N D
            '取得データなし
            DSPSOUCD_SEARCH = 1
            Exit Function
        End If

        '2019/03/14 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        '    With pot_DB_SOUMTA
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB"), "") '伝票削除区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD"), "") '倉庫コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM"), "") '倉庫名
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUZP = CF_Ora_GetDyn(Usr_Ody, "SOUZP"), "") '倉庫郵便番号
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUADA = CF_Ora_GetDyn(Usr_Ody, "SOUADA"), "") '倉庫住所１
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUADB = CF_Ora_GetDyn(Usr_Ody, "SOUADB"), "") '倉庫住所２
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUADC = CF_Ora_GetDyn(Usr_Ody, "SOUADC"), "") '倉庫住所３
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUTL = CF_Ora_GetDyn(Usr_Ody, "SOUTL"), "") '倉庫電話番号
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUFX = CF_Ora_GetDyn(Usr_Ody, "SOUFX"), "") '倉庫ＦＡＸ番号
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUBSCD = CF_Ora_GetDyn(Usr_Ody, "SOUBSCD"), "") '場所コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUKB = CF_Ora_GetDyn(Usr_Ody, "SOUKB"), "") '倉庫種別
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SRSCNKB = CF_Ora_GetDyn(Usr_Ody, "SRSCNKB"), "") 'シリアルスキャン要否区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB"), "") '資産元区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD"), "") '取引先コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB"), "") '倉庫区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .HIKKB = CF_Ora_GetDyn(Usr_Ody, "HIKKB"), "") '引当対象区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SALPALKB = CF_Ora_GetDyn(Usr_Ody, "SALPALKB"), "") '販売計画対象区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL"), "") '連携フラグ
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID"), "") '最終作業者コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID"), "") 'クライアントＩＤ
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM"), "") 'タイムスタンプ（時間）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT"), "") 'タイムスタンプ（日付）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM"), "") 'タイムスタンプ（登録時間）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT"), "") 'タイムスタンプ（登録日）
        '    End With
        'End If
        With pot_DB_SOUMTA
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUCD = DB_NullReplace(dt.Rows(0)("SOUCD"), "") '倉庫コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUNM = DB_NullReplace(dt.Rows(0)("SOUNM"), "") '倉庫名
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUZP = DB_NullReplace(dt.Rows(0)("SOUZP"), "") '倉庫郵便番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUADA = DB_NullReplace(dt.Rows(0)("SOUADA"), "") '倉庫住所１
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUADB = DB_NullReplace(dt.Rows(0)("SOUADB"), "") '倉庫住所２
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUADC = DB_NullReplace(dt.Rows(0)("SOUADC"), "") '倉庫住所３
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUTL = DB_NullReplace(dt.Rows(0)("SOUTL"), "") '倉庫電話番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUFX = DB_NullReplace(dt.Rows(0)("SOUFX"), "") '倉庫ＦＡＸ番号
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUBSCD = DB_NullReplace(dt.Rows(0)("SOUBSCD"), "") '場所コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUKB = DB_NullReplace(dt.Rows(0)("SOUKB"), "") '倉庫種別
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SRSCNKB = DB_NullReplace(dt.Rows(0)("SRSCNKB"), "") 'シリアルスキャン要否区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SISNKB = DB_NullReplace(dt.Rows(0)("SISNKB"), "") '資産元区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUTRICD = DB_NullReplace(dt.Rows(0)("SOUTRICD"), "") '取引先コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SOUKOKB = DB_NullReplace(dt.Rows(0)("SOUKOKB"), "") '倉庫区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .HIKKB = DB_NullReplace(dt.Rows(0)("HIKKB"), "") '引当対象区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .SALPALKB = DB_NullReplace(dt.Rows(0)("SALPALKB"), "") '販売計画対象区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
        End With
        '2019/03/14 CHG E N D

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        DSPSOUCD_SEARCH = 0

        Exit Function

ERR_DSPSOUCD_SEARCH:

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SYSTBA_SEARCH
    '   概要：  ユーザー情報管理テーブル検索
    '   引数：  pot_DB_SYSTBA   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function SYSTBA_SEARCH(ByRef pot_DB_SYSTBA As TYPE_DB_SYSTBA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            SYSTBA_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from SYSTBA "

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                SYSTBA_SEARCH = 1
                Exit Function
            End If

            With pot_DB_SYSTBA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRID = DB_NullReplace(dt.Rows(0)("USRID"), "") 'ユーザーID
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRNMA = DB_NullReplace(dt.Rows(0)("USRNMA"), "") 'ユーザー名1(漢字)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRNMB = DB_NullReplace(dt.Rows(0)("USRNMB"), "") 'ユーザー名2(漢字)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRRN = DB_NullReplace(dt.Rows(0)("USRRN"), "") 'ユーザー略称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRNK = DB_NullReplace(dt.Rows(0)("USRNK"), "") 'ユーザー名称(カナ)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRZP = DB_NullReplace(dt.Rows(0)("USRZP"), "") 'ユーザー郵便番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRADA = DB_NullReplace(dt.Rows(0)("USRADA"), "") 'ユーザー住所1
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRADB = DB_NullReplace(dt.Rows(0)("USRADB"), "") 'ユーザー住所2
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRADC = DB_NullReplace(dt.Rows(0)("USRADC"), "") 'ユーザー住所3
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRTL = DB_NullReplace(dt.Rows(0)("USRTL"), "") 'ユーザー電話番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRFX = DB_NullReplace(dt.Rows(0)("USRFX"), "") 'ユーザーFAX番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRBOSNM = DB_NullReplace(dt.Rows(0)("USRBOSNM"), "") 'ユーザー代表者名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .USRTANNM = DB_NullReplace(dt.Rows(0)("USRTANNM"), "") 'ユーザー担当者名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMAMM = DB_NullReplace(dt.Rows(0)("SMAMM"), "") '決算月
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMADD = DB_NullReplace(dt.Rows(0)("SMADD"), "") '決算日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMAMONDD = DB_NullReplace(dt.Rows(0)("SMAMONDD"), "") '月次決算日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMEDD = DB_NullReplace(dt.Rows(0)("SMEDD"), "") '締め日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KESCC = DB_NullReplace(dt.Rows(0)("KESCC"), "") '回収支払月
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KESDD = DB_NullReplace(dt.Rows(0)("KESDD"), "") '回収支払日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "") '伝票管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RECNO = DB_NullReplace(dt.Rows(0)("RECNO"), "") 'レコード管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STTDATNO = DB_NullReplace(dt.Rows(0)("STTDATNO"), "") '開始伝票管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ENDDATNO = DB_NullReplace(dt.Rows(0)("ENDDATNO"), "") '終了伝票管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .STTRECNO = DB_NullReplace(dt.Rows(0)("STTRECNO"), "") '開始レコード管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ENDRECNO = DB_NullReplace(dt.Rows(0)("ENDRECNO"), "") '終了レコード管理NO.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GYMSTTDT = DB_NullReplace(dt.Rows(0)("GYMSTTDT"), "") '業務開始日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSSAKB = DB_NullReplace(dt.Rows(0)("TOKSSAKB"), "") '得意先請求締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSMAKB = DB_NullReplace(dt.Rows(0)("TOKSMAKB"), "") '得意先経理締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SIRSSAKB = DB_NullReplace(dt.Rows(0)("SIRSSAKB"), "") '仕入先支払締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SIRSMAKB = DB_NullReplace(dt.Rows(0)("SIRSMAKB"), "") '仕入先経理締処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMAUPDDT = DB_NullReplace(dt.Rows(0)("SMAUPDDT"), "") '前回経理締実行日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UKSMEDT = DB_NullReplace(dt.Rows(0)("UKSMEDT"), "") '月次仮締日（売り）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SKSMEDT = DB_NullReplace(dt.Rows(0)("SKSMEDT"), "") '月次仮締日（仕入）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MINSPCCP = DB_NullReplace(dt.Rows(0)("MINSPCCP"), "") '最低空き容量(Ｍ)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MONUPDSC = DB_NullReplace(dt.Rows(0)("MONUPDSC"), "") 'トラン保存期間(月)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YERUPDSC = DB_NullReplace(dt.Rows(0)("YERUPDSC"), "") 'サマリ保存期間(月)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MONUPDDT = DB_NullReplace(dt.Rows(0)("MONUPDDT"), "") '前回月次更新実行日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .YERUPDDT = DB_NullReplace(dt.Rows(0)("YERUPDDT"), "") '前回年次更新実行日
                '和暦採用区分
                'For intCnt = 0 To 1
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGKB(intCnt) = DB_NullReplace(dt.Rows(0)("NEGKB") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGKB00 = DB_NullReplace(dt.Rows(0)("NEGKB00"), "")
                .NEGKB01 = DB_NullReplace(dt.Rows(0)("NEGKB01"), "")

                '元年(西暦)
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGDT(intCnt) = DB_NullReplace(dt.Rows(0)("NEGDT") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGDT00 = DB_NullReplace(dt.Rows(0)("NEGDT00"), "")
                .NEGDT01 = DB_NullReplace(dt.Rows(0)("NEGDT01"), "")
                .NEGDT02 = DB_NullReplace(dt.Rows(0)("NEGDT02"), "")
                .NEGDT03 = DB_NullReplace(dt.Rows(0)("NEGDT03"), "")
                .NEGDT04 = DB_NullReplace(dt.Rows(0)("NEGDT04"), "")

                '元号(年)
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGYY(intCnt) = DB_NullReplace(dt.Rows(0)("NEGYY") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGYY00 = DB_NullReplace(dt.Rows(0)("NEGYY00"), "")
                .NEGYY01 = DB_NullReplace(dt.Rows(0)("NEGYY01"), "")
                .NEGYY02 = DB_NullReplace(dt.Rows(0)("NEGYY02"), "")
                .NEGYY03 = DB_NullReplace(dt.Rows(0)("NEGYY03"), "")
                .NEGYY04 = DB_NullReplace(dt.Rows(0)("NEGYY04"), "")

                '元号
                'For intCnt = 0 To 4
                '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '    .NEGNM(intCnt) = DB_NullReplace(dt.Rows(0)("NEGNM") & VB6.Format(intCnt, "00"), "")
                'Next
                .NEGNM00 = DB_NullReplace(dt.Rows(0)("NEGNM00"), "")
                .NEGNM01 = DB_NullReplace(dt.Rows(0)("NEGNM01"), "")
                .NEGNM02 = DB_NullReplace(dt.Rows(0)("NEGNM02"), "")
                .NEGNM03 = DB_NullReplace(dt.Rows(0)("NEGNM03"), "")
                .NEGNM04 = DB_NullReplace(dt.Rows(0)("NEGNM04"), "")

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .VERNO = DB_NullReplace(dt.Rows(0)("VERNO"), "") 'VERNO
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .LEVNO = DB_NullReplace(dt.Rows(0)("LEVNO"), "") 'LEBEL NO
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZAIHYKKB = DB_NullReplace(dt.Rows(0)("ZAIHYKKB"), "") '在庫評価方法
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .GNKHYKKB = DB_NullReplace(dt.Rows(0)("GNKHYKKB"), "") '原価評価方法-粗利用
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HYKSTTDT = DB_NullReplace(dt.Rows(0)("HYKSTTDT"), "") '評価計算開始日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日付)
            End With

            SYSTBA_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("SYSTBA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPZEIRT_SEARCH
    '   概要：  消費税率検索
    '   引数：  pin_strZEIDT    : 基準日
    '           pin_strZEIRNKKB : 消費税ランク
    '           pot_DB_SYSTBB   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPZEIRT_SEARCH(ByVal pin_strZEIDT As String, ByVal pin_strZEIRNKKB As String, ByRef pot_DB_SYSTBB As TYPE_DB_SYSTBB) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_DSPZEIRT_SEARCH

        DSPZEIRT_SEARCH = 9

        ' === 20131203 === INSERT S - RS)Ishida 消費税法改正対応
        'パラメータの取得日付より、"/"を消去する。
        pin_strZEIDT = Replace(pin_strZEIDT, "/", "")
        ' === 20131203 === INSERT E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SYSTBB "
        strSQL = strSQL & "  Where ZEIDT    <= '" & pin_strZEIDT & "' "
        strSQL = strSQL & "    and ZEIRNKKB  = '" & pin_strZEIRNKKB & "' "
        strSQL = strSQL & "  Order by ZEIDT DESC "

        'DBアクセス
        '2019/04/09 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/09 CHG E N D

        '2019/04/09 CHG START     
        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/09 CHG E N D
            '取得データなし
            DSPZEIRT_SEARCH = 1
            Exit Function
        End If

        '2019/04/09 CHG START
        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '    With pot_DB_SYSTBB
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZEIDT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIDT", "") '伝票削除区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRNKKB", "") '伝票削除区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .ZEIRT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRT", 0) '伝票削除区分
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "") '最終作業者コード
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "") 'クライアントＩＤ
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "") 'タイムスタンプ（時間）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "") 'タイムスタンプ（日付）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
        '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "") 'タイムスタンプ（登録日）
        '    End With
        'End If
        With pot_DB_SYSTBB
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZEIDT = DB_NullReplace(dt.Rows(0)("ZEIDT"), "") '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZEIRNKKB = DB_NullReplace(dt.Rows(0)("ZEIRNKKB"), "") '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .ZEIRT = DB_NullReplace(dt.Rows(0)("ZEIRT"), 0) '伝票削除区分
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
        End With
        '2019/04/09 CHG E N D

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)


        DSPZEIRT_SEARCH = 0

        Exit Function

ERR_DSPZEIRT_SEARCH:


    End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMSGCM_SEARCH
    '   概要：  システムメッセージ検索
    '   引数：  pin_strMSGKB    : メッセージ種別
    '           pin_strMSGNM    : メッセージアイテム
    '           pin_strMSGSQ　　: メッセージ連番
    '           pot_DB_SYSTBH   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, ByVal pin_strMSGNM As String, ByVal pin_strMSGSQ As String, ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            DSPMSGCM_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from SYSTBH "
            strSQL = strSQL & "  Where MSGKB     = '" & CF_Ora_Sgl(pin_strMSGKB) & "' "
            strSQL = strSQL & "    and MSGNM     = '" & CF_Ora_Sgl(pin_strMSGNM) & "' "
            strSQL = strSQL & "    and MSGSQ     = '" & CF_Ora_Sgl(pin_strMSGSQ) & "' "

            'DBアクセス
            '2019/03/14 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/14 CHG E N D

            '2019/03/14 CHG START
            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/14 CHG E N D
                '取得データなし
                DSPMSGCM_SEARCH = 1
                Exit Function
            End If

            With pot_DB_SYSTBH
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MSGKB = DB_NullReplace(dt.Rows(0)("MSGKB"), "") 'メッセージ種別
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MSGNM = DB_NullReplace(dt.Rows(0)("MSGNM"), "") 'メッセージアイテム
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MSGSQ = DB_NullReplace(dt.Rows(0)("MSGSQ"), "") 'メッセージ連番
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BTNKB = DB_NullReplace(dt.Rows(0)("BTNKB"), 0) 'ボタン種別
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BTNON = DB_NullReplace(dt.Rows(0)("BTNON"), 0) 'ボタン初期値
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ICNKB = DB_NullReplace(dt.Rows(0)("ICNKB"), 0) 'アイコン種別
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MSGCM = DB_NullReplace(dt.Rows(0)("MSGCM"), "") 'メッセージ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .COLSQ = DB_NullReplace(dt.Rows(0)("COLSQ"), "") '色シーケンス
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            End With

            DSPMSGCM_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPMSGCM_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    Public Function DSPTANCD_SEARCH(ByVal pin_strTANCD As String, ByRef pot_DB_TANMTA As TYPE_DB_TANMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            DSPTANCD_SEARCH = 9

            Dim tableCond As String = ""

            If DB_NullReplace(pin_strTANCD, "") = "" Then
                tableCond = ""
            Else
                tableCond = "where TANCD = '" & pin_strTANCD & "'"
            End If

            '20190618 CHG START
            'DB_GetData("TANMTA", tableCond, "")

            'If dsList.Tables("TANMTA").Rows.Count <= 0 Then
            '    '取得データなし
            '    DSPTANCD_SEARCH = 1
            '    Exit Function
            'End If

            ''2019/03/15 CHG START
            ''DB_TANMTA = TANMTA_GetNext(0)
            'pot_DB_TANMTA = TANMTA_GetNext(0)
            ''2019/03/15 CHG E N D

            GetRowsCommon("TANMTA", tableCond)
            pot_DB_TANMTA = DB_TANMTA

            If pot_DB_TANMTA.DATKB Is Nothing Then
                DSPTANCD_SEARCH = 9
                Exit Function
            End If
            '20190618 CHG END

            DSPTANCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTANCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPTOKCD_SEARCH
    '   概要：  得意先コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKCD_SEARCH(ByVal pin_strTOKCD As String, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            DSPTOKCD_SEARCH = 9

            Dim tableCond As String = ""

            If DB_NullReplace(pin_strTOKCD, "") = "" Then
                tableCond = ""
            Else
                tableCond = "where TOKCD = '" & pin_strTOKCD & "'"
            End If

            DB_GetData("TOKMTA", tableCond, "")

            If dsList.Tables("TOKMTA").Rows.Count <= 0 Then
                '取得データなし
                DSPTOKCD_SEARCH = 1
                Exit Function
            End If

            '20190619 CHG START
            '2019/03/15 CHG START
            'DB_TOKMTA = TOKMTA_GetNext(0)
            'pot_DB_TOKMTA = TOKMTA_GetNext(0)
            '2019/03/15 CHG E N D

            GetRowsCommon("TOKMTA", tableCond)
            pot_DB_TOKMTA = DB_TOKMTA
            '20190619 CHG END


            DSPTOKCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTOKCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPTOKRN_SEARCH
    '   概要：  得意先略称検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKRN_SEARCH(ByVal pin_strTOKRN As String, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            DSPTOKRN_SEARCH = 9

            Dim tableCond As String = ""

            If DB_NullReplace(pin_strTOKRN, "") = "" Then
                tableCond = ""
            Else
                tableCond = "where TOKRN = '" & pin_strTOKRN & "'"
            End If

            DB_GetData("TOKMTA", tableCond, "")

            If dsList.Tables("TOKMTA").Rows.Count <= 0 Then
                '取得データなし
                DSPTOKRN_SEARCH = 1
                Exit Function
            End If

            '20190619 CHG START
            'DB_TOKMTA = TOKMTA_GetNext(0)
            GetRowsCommon("TOKMTA", tableCond)
            '20190619 CHG END

            DSPTOKRN_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTOKRN_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPLMTKN_SEARCH
    '   概要：  与信限度額検索
    '   引数：　pin_strTOKCD  : 得意先コード
    '           pin_strTGRPCD : 得意先グループコード
    '           pot_curLMTKN  : 与信限度額
    '   戻値：　0:正常終了 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPLMTKN_SEARCH(ByVal pin_strTOKCD As String, ByVal pin_strTGRPCD As String, ByRef pot_curLMTKN As Decimal) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody As U_Ody
            Dim strTOKCD_Where As String

            'On Error GoTo ERR_DSPLMTKN_SEARCH

            DSPLMTKN_SEARCH = 9
            pot_curLMTKN = 0

            If Trim(pin_strTGRPCD) = "" Then
                strTOKCD_Where = pin_strTOKCD
            Else
                strTOKCD_Where = pin_strTGRPCD
            End If

            strSQL = ""
            strSQL = strSQL & " Select LMTKN "
            strSQL = strSQL & "   from TOKMTA "
            strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(strTOKCD_Where) & "' "


            '2019/03/14 CHG START MIYAMOTO
            ''DBアクセス
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

            'If CF_Ora_EOF(Usr_Ody) = False Then
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "") '与信限度額
            '	DSPLMTKN_SEARCH = 0

            '	GoTo END_DSPLMTKN_SEARCH
            'End If
            DB_GetTable(strSQL)

            If dsList.Tables("tableName").Rows.Count > 0 Then
                pot_curLMTKN = dsList.Tables("tableName").Rows(0).Item("LMTKN")
                DSPLMTKN_SEARCH = 0
            End If
            '2019/03/14 CHG END MIYAMOTO


            '取得データが存在しなかった場合で、自分が親以外の場合
            If strTOKCD_Where <> pin_strTOKCD Then
                '2019/03/14 DEL START MIYAMOTO
                ''クローズ
                'Call CF_Ora_CloseDyn(Usr_Ody)
                '2019/03/14 DEL END MIYAMOTO

                strSQL = ""
                strSQL = strSQL & " Select LMTKN "
                strSQL = strSQL & "   from TOKMTA "
                strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
                strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(pin_strTOKCD) & "' "


                '2019/03/14 CHG START MIYAMOTO
                ''DBアクセス
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

                'If CF_Ora_EOF(Usr_Ody) = False Then
                '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '	pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "") '与信限度額
                '         End If
                DB_GetTable(strSQL)

                If dsList.Tables("tableName").Rows.Count > 0 Then
                    pot_curLMTKN = dsList.Tables("tableName").Rows(0).Item("LMTKN")
                    DSPLMTKN_SEARCH = 0
                End If
                '2019/03/14 CHG END MIYAMOTO

            End If

            DSPLMTKN_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPTOKRN_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

        'END_DSPLMTKN_SEARCH: 
        '		'クローズ
        '		Call CF_Ora_CloseDyn(Usr_Ody)

        '		Exit Function

        'ERR_DSPLMTKN_SEARCH: 

    End Function


    Public Function DSPUNYDT_SEARCH(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA) As Short

        Dim li_MsgRtn As Integer

        Try

            DSPUNYDT_SEARCH = 9

            DB_GetData("UNYMTA", "", "")

            If dsList.Tables("UNYMTA").Rows.Count <= 0 Then
                '取得データなし
                DSPUNYDT_SEARCH = 1
                Exit Function
            End If

            '2019/03/18 CHG START
            'DB_UNYMTA = UNYMTA_GetNext(0)
            'pot_DB_UNYMTA = UNYMTA_GetNext(0)
            GetRowsCommon("UNYMTA", "")
            pot_DB_UNYMTA = DB_UNYMTA
            '20190619 CHG END
            '2019/03/18 CHG E N D

            DSPUNYDT_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPUNYDT_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    Sub UNYMTA_RClear()
        DB_UNYMTA = Nothing
    End Sub

    '2019/03/20 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CHK_UNYDT
    '   概要：  運用日付チェック
    '   引数：
    '   戻値：　0:正常(運用日付が引数の日付と同一) -1:運用日マスタ無
    '　　　　　 1:運用日付が引数の日付より大きい 2:運用日付が引数の日付より小さい
    '   備考：連絡票№739
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Function CHK_UNYDT(ByRef CHK_DT As String) As Short

        '戻り値
        Dim rtnVal As Short = -1

        'SQL文
        Dim strSQL As String

        Dim ls_UNYDT As String
        Dim ls_CHK_DT As String

        Try
            ls_CHK_DT = Trim(CHK_DT)

            strSQL = ""
            strSQL &= " SELECT "
            strSQL &= "  UNYDT "
            strSQL &= " FROM UNYMTA "

            'DBアクセス 
            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '取得データなし
                rtnVal = -1
            Else
                ls_UNYDT = DB_NullReplace(dt.Rows(0)("UNYDT"), "") '運用日付

                If ls_UNYDT = ls_CHK_DT Then
                    rtnVal = 0
                ElseIf ls_UNYDT > ls_CHK_DT Then
                    rtnVal = 1
                Else
                    rtnVal = 2
                End If
            End If

        Catch ex As Exception

            MsgBox("CHK_UNYDT" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")

            'Finally

        End Try

        Return rtnVal

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPBANK_SEARCH
    '   概要：  銀行マスタ検索
    '   引数：  pin_strBNKCD    : 銀行コード
    '           pot_DB_BNKMTA   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPBANK_SEARCH(ByVal pin_strBNKCD As String, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPBANK_SEARCH

            DSPBANK_SEARCH = 9

            strSQL = ""
            '20190619 DEL START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from BNKMTA "
            '20190619 DEL END
            strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "  and   BNKCD    = '" & CF_Ora_Sgl(pin_strBNKCD) & "' "
            strSQL = strSQL & "  Order by BNKCD "


            '20190619 CHG START
            'DBアクセス
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '取得データなし
            ''    DSPBANK_SEARCH = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_BNKMTA_SetData(Usr_Ody_LC, pot_DB_BNKMTA)
            ''End If

            '''クローズ
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPBANK_SEARCH = 1
            '    Exit Function
            'End If

            'Call Set_DB_BNKMTA(dt, pot_DB_BNKMTA, 0)
            ''20190403 CHG END

            GetRowsCommon("BNKMTA", strSQL)
            pot_DB_BNKMTA = DB_BNKMTA
            '20190619 CHG END


            DSPBANK_SEARCH = 0

            'Exit Function

            'ERR_DSPBANK_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPBANK_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPBANK_SEARCH_ALL
    '   概要：  銀行マスタ検索
    '   引数：  pin_strBNKCD    : 銀行コード
    '           pot_DB_BNKMTA   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPBANK_SEARCH_ALL(ByVal pin_strBNKCD As String, ByRef pot_DB_BNKMTA As TYPE_DB_BNKMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPBANK_SEARCH_ALL

            DSPBANK_SEARCH_ALL = 9

            strSQL = ""
            '20190619 DEL START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from BNKMTA "
            '20190619 DEL END
            strSQL = strSQL & "  Where BNKCD    = '" & CF_Ora_Sgl(pin_strBNKCD) & "' "

            '20190619 CHG START
            'DBアクセス
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '取得データなし
            ''    DSPBANK_SEARCH_ALL = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_BNKMTA_SetData(Usr_Ody_LC, pot_DB_BNKMTA)
            ''End If

            '''クローズ
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPBANK_SEARCH_ALL = 1
            '    Exit Function
            'End If

            'Call Set_DB_BNKMTA(dt, pot_DB_BNKMTA, 0)
            ''20190403 CHG END
            GetRowsCommon("BNKMTA", strSQL)
            pot_DB_BNKMTA = DB_BNKMTA
            '20190619 CHG END

            DSPBANK_SEARCH_ALL = 0

            'Exit Function

            'ERR_DSPBANK_SEARCH_ALL:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPBANK_SEARCH_ALL" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function ENDUSRNM_SEARCH3
    '   概要：  エンドユーザマスタより名称取得
    '             存在しない場合、名称マスタ参照
    '   引数：pin_strMEICDA    : コード
    '           pin_LoadingFlg     : 見積/受注情報読込時か否か判断する
    '           pot_strENDUSRNM  : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRNM_SEARCH3(ByVal pin_strENDUSRCD As String, ByVal pin_LoadingFlg As Short, ByRef pot_strENDUSRNM As String) As Short


        'Dim intData As Short
        ''UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        'Dim Usr_Ody_LC As U_Ody

        'On Error GoTo ERR_ENDUSRNM_SEARCH3
        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            ENDUSRNM_SEARCH3 = 9

            strSQL = ""
            strSQL = strSQL & " Select "
            strSQL = strSQL & "        Rtrim(ENDUSRNM) NAME "
            strSQL = strSQL & "   from ENDMTA "
            strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "   and  Trim(ENDUSRCD) = '" & Trim(pin_strENDUSRCD) & "' "

            'DBアクセス
            '2019/03/18 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/18 CHG E N D

            '2019/03/18 CHG START
            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/18 CHG E N D
                If pin_LoadingFlg = 1 Then
                    '見積/受注情報読込時でエンドユーザマスタにない場合名称マスタから取得
                    strSQL = ""
                    strSQL = strSQL & " Select "
                    strSQL = strSQL & "        Rtrim(MEINMA) || Rtrim(MEINMB) || Rtrim(MEINMC) NAME "
                    strSQL = strSQL & "   from MEIMTA "
                    strSQL = strSQL & "  Where DATKB  = '" & gc_strDATKB_USE & "' "
                    strSQL = strSQL & "   and  KEYCD  = '114' "
                    strSQL = strSQL & "   and  Trim(MEICDA) = '" & Trim(pin_strENDUSRCD) & "' "

                    'DBアクセス
                    '2019/03/18 CHG START
                    'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
                    dt = Nothing
                    dt = DB_GetTable(strSQL)
                    '2019/03/18 CHG E N D

                    '2019/03/18 CHG START
                    'If CF_Ora_EOF(Usr_Ody_LC) = True Then
                    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                        '2019/03/18 CHG E N D
                        '取得データなし
                        pot_strENDUSRNM = ""
                        'ENDUSRNM_SEARCH3 = 1
                        'GoTo END_ENDUSRNM_SEARCH3
                        Exit Function
                    End If
                Else
                    '見積/受注情報読込時でない場合
                    '取得データなし
                    pot_strENDUSRNM = ""
                    'ENDUSRNM_SEARCH3 = 1
                    'GoTo END_ENDUSRNM_SEARCH3
                    Exit Function
                End If
            End If

            '取得データ退避
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'pot_strENDUSRNM = CF_Ora_GetDyn(Usr_Ody_LC, "NAME", "")
            pot_strENDUSRNM = DB_NullReplace(dt.Rows(0)("NAME"), "")

            ENDUSRNM_SEARCH3 = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("ENDUSRNM_SEARCH3" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try



        'END_ENDUSRNM_SEARCH3:
        '            'クローズ
        '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

        '            Exit Function

        'ERR_ENDUSRNM_SEARCH3:

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function ENDUSRCD_SEARCH
    '   概要：  見積見出分類トランよりエンドユーザコード取得
    '   引数：　pDATNO    : 伝票番号
    '             pMITNO     : 見積番号
    '             pMITNOV   : 版数
    '             pin_strENDUSRCD : エンドユーザコード
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRCD_SEARCH(ByVal pDATNO As String, ByVal pMITNO As String, ByVal pMITNOV As String, ByRef pin_strENDUSRCD As String) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String

            ENDUSRCD_SEARCH = 9

            If pDATNO = "" Then
                strSQL = ""
                strSQL = strSQL & "   Select "
                strSQL = strSQL & "   Rtrim(ENDUSRCD) AS ENDUSRCD"
                strSQL = strSQL & "   from MITTHB "
                strSQL = strSQL & "   ,MITTHA"
                strSQL = strSQL & "   Where MITTHA.DATNO = MITTHB.DATNO"
                strSQL = strSQL & "   and MITTHB.DATNO = (SELECT DATNO from MITTHA"
                strSQL = strSQL & "   Where MITTHA.DATKB = 1"
                strSQL = strSQL & "   and  MITTHA.MITNO  = '" & pMITNO & "' "
                strSQL = strSQL & "   and  MITTHA.MITNOV = '" & pMITNOV & "' )"
                strSQL = strSQL & "   and  MITTHB.MITNO  = '" & pMITNO & "' "
                strSQL = strSQL & "   and  MITTHB.MITNOV = '" & pMITNOV & "' "
            Else
                strSQL = ""
                strSQL = strSQL & " Select "
                strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
                strSQL = strSQL & " from MITTHB "
                strSQL = strSQL & " Where DATNO  = '" & pDATNO & "' "
                strSQL = strSQL & " and  MITNO  = '" & pMITNO & "' "
                strSQL = strSQL & " and  MITNOV = '" & pMITNOV & "' "
            End If

            'DBアクセス
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                pin_strENDUSRCD = ""
                ENDUSRCD_SEARCH = 1
                Exit Function
            Else
                pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
            End If

            ENDUSRCD_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("ENDUSRCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try


        'Dim intData As Short
        ''UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        'Dim Usr_Ody_LC As U_Ody

        'On Error GoTo ERR_ENDUSRCD_SEARCH



        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '	'取得データなし
        '	pin_strENDUSRCD = ""
        '	ENDUSRCD_SEARCH = 1
        '	GoTo END_ENDUSRCD_SEARCH
        'End If

        ''取得データ退避
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

        'END_ENDUSRCD_SEARCH: 
        '		'クローズ
        '		Call CF_Ora_CloseDyn(Usr_Ody_LC)

        '		Exit Function

        'ERR_ENDUSRCD_SEARCH: 

    End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function ENDUSRCD_SEARCH2
    '   概要：  エンドユーザ紐付けテーブルよりエンドユーザコード取得
    '   引数：　pJDNNO    : 受注番号
    '             pin_strENDUSRCD : エンドユーザコード
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function ENDUSRCD_SEARCH2(ByVal pJDNNO As String, ByRef pin_strENDUSRCD As String) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_ENDUSRCD_SEARCH2

            ENDUSRCD_SEARCH2 = 9

            strSQL = ""
            strSQL = strSQL & " Select "
            strSQL = strSQL & " Rtrim(ENDUSRCD) AS ENDUSRCD"
            strSQL = strSQL & " from JDNTHE "
            strSQL = strSQL & " Where JDNNO  = '" & pJDNNO & "' "

            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                pin_strENDUSRCD = ""
                ENDUSRCD_SEARCH2 = 1
                Exit Function
            Else
                pin_strENDUSRCD = DB_NullReplace(dt.Rows(0)("ENDUSRCD"), "")
            End If

            ''DBアクセス
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            'If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '    '取得データなし
            '    pin_strENDUSRCD = ""
            '    ENDUSRCD_SEARCH2 = 1
            '    GoTo END_ENDUSRCD_SEARCH2
            'End If

            ''取得データ退避
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'pin_strENDUSRCD = CF_Ora_GetDyn(Usr_Ody_LC, "ENDUSRCD", "")

            ENDUSRCD_SEARCH2 = 0

            'END_ENDUSRCD_SEARCH2:
            '            'クローズ
            '            Call CF_Ora_CloseDyn(Usr_Ody_LC)

            '            Exit Function

            'ERR_ENDUSRCD_SEARCH2:
        Catch ex As Exception
            li_MsgRtn = MsgBox("ENDUSRCD_SEARCH2" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPFBTRA_SEARCH
    '   概要：  ＦＢトラン検索
    '   引数：  pin_strFBRFNO   : 照会番号
    '           pot_DB_FBTRA    : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPFBTRA_SEARCH(ByVal pin_strFBRFNO As String, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPFBTRA_SEARCH

            DSPFBTRA_SEARCH = 9

            strSQL = ""
            '20190619 CHG START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from FBTRA "
            '20190619 CHG END
            strSQL = strSQL & "  Where DATKB    = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "  and   FBRFNO   = '" & CF_Ora_Sgl(pin_strFBRFNO) & "' "
            strSQL = strSQL & "  Order by BNKCD "

            '20190619 CHG START
            'DBアクセス
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '取得データなし
            ''    DSPFBTRA_SEARCH = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_FBTRA_SetData(Usr_Ody_LC, pot_DB_FBTRA)
            ''End If

            '''クローズ
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPFBTRA_SEARCH = 1
            '    Exit Function
            'End If

            'Call Set_DB_FBTRA(dt, pot_DB_FBTRA, 0)
            ''20190403 CHG END
            GetRowsCommon("FBTRA", strSQL)
            pot_DB_FBTRA = DB_FBTRA
            '20190619 CHG END


            DSPFBTRA_SEARCH = 0

            'Exit Function

            'ERR_DSPFBTRA_SEARCH:
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPFBTRA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPFBTRA_SEARCH_ALL
    '   概要：  ＦＢトラン検索
    '   引数：  pin_strFBRFNO   : 照会番号
    '           pot_DB_FBTRA    : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPFBTRA_SEARCH_ALL(ByVal pin_strFBRFNO As String, ByRef pot_DB_FBTRA As TYPE_DB_FBTRA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            Dim intData As Short
            'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPFBTRA_SEARCH_ALL

            DSPFBTRA_SEARCH_ALL = 9

            strSQL = ""
            '20190619 DEL START
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from FBTRA "
            '20190619 DEL END
            strSQL = strSQL & "  Where FBRFNO   = '" & CF_Ora_Sgl(pin_strFBRFNO) & "' "

            '20190619 CHG START
            'DBアクセス
            ''20190403 CHG START
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
            'Dim dt As DataTable = DB_GetTable(strSQL)
            ''20190403 CHG END

            ''20190403 CHG START
            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''    '取得データなし
            ''    DSPFBTRA_SEARCH_ALL = 1
            ''    Exit Function
            ''End If

            ''If CF_Ora_EOF(Usr_Ody_LC) = False Then
            ''    Call DB_FBTRA_SetData(Usr_Ody_LC, pot_DB_FBTRA)
            ''End If

            '''クローズ
            ''Call CF_Ora_CloseDyn(Usr_Ody_LC)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPFBTRA_SEARCH_ALL = 1
            '    Exit Function
            'End If

            'Call Set_DB_FBTRA(dt, pot_DB_FBTRA, 0)
            ''20190403 CHG END

            GetRowsCommon("FBTRA", strSQL)
            pot_DB_FBTRA = DB_FBTRA
            '20190619 CHG END

            DSPFBTRA_SEARCH_ALL = 0

            'Exit Function

            'ERR_DSPFBTRA_SEARCH_ALL:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPFBTRA_SEARCH_ALL" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPCTLCD_SEARCH
    '   概要：  管理コード検索
    '   引数：  pin_strCTLCD  : 検索対象管理コード
    '           pot_DB_FIXMTA : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPCTLCD_SEARCH(ByVal pin_strCTLCD As String, ByRef pot_DB_FIXMTA As TYPE_DB_FIXMTA) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPCTLCD_SEARCH

            DSPCTLCD_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from FIXMTA "
            strSQL = strSQL & "  Where CTLCD = '" & pin_strCTLCD & "' "

            'DBアクセス
            '2019/03/14 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
            Dim dt As DataTable = DB_GetTable(strSQL)
            '2019/03/14 CHG E N D

            '2019/03/14 CHG START
            'If CF_Ora_EOF(Usr_Ody) = True Then
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '2019/03/14 CHG E N D
                '取得データなし
                DSPCTLCD_SEARCH = 1
                Exit Function
                'GoTo END_DSPCTLCD_SEARCH
            End If

            '2019/03/14 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_FIXMTA
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CTLCD = CF_Ora_GetDyn(Usr_Ody, "CTLCD", "") '管理コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CTLNM = CF_Ora_GetDyn(Usr_Ody, "CTLNM", "") '管理名称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .FIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "") '固定値
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .REMARK = CF_Ora_GetDyn(Usr_Ody, "REMARK", "") '備考
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            '    End With
            'End If
            With pot_DB_FIXMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CTLCD = DB_NullReplace(dt.Rows(0)("CTLCD"), "") '管理コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CTLNM = DB_NullReplace(dt.Rows(0)("CTLNM"), "") '管理名称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .FIXVAL = DB_NullReplace(dt.Rows(0)("FIXVAL"), "") '固定値
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .REMARK = DB_NullReplace(dt.Rows(0)("REMARK"), "") '備考
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = DB_NullReplace(dt.Rows(0)("RELFL"), "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
            End With
            '2019/03/14 CHG E N D

            DSPCTLCD_SEARCH = 0

            'END_DSPCTLCD_SEARCH:
            '            'クローズ
            '            Call CF_Ora_CloseDyn(Usr_Ody)

            '            Exit Function

            'ERR_DSPCTLCD_SEARCH:
            '            GoTo END_DSPCTLCD_SEARCH
        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPCTLCD_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPJDNTHA_SEARCH
    '   概要：  受注見出しトラン検索
    '   引数：　pin_strJDNNO          :受注番号
    '           pot_DB_JDNTHA　　　　 :受注見出しトランデータ
    '           pin_strDATKB 　　　　 :伝票削除区分（Optional、渡されない場合"1"）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPJDNTHA_SEARCH(ByVal pin_strJDNNO As String, ByRef pot_DB_JDNTHA As TYPE_DB_JDNTHA, Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody As U_Ody

            'On Error GoTo ERR_DSPJDNTHA_SEARCH

            DSPJDNTHA_SEARCH = 9

            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from JDNTHA "
            strSQL = strSQL & "  Where JDNNO = '" & pin_strJDNNO & "' "
            strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

            'DBアクセス
            '20190319 CHG START
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

            'If CF_Ora_EOF(Usr_Ody) = True Then
            '    '取得データなし
            '    DSPJDNTHA_SEARCH = 1
            '    Exit Function
            'End If
            Dim dt As DataTable = DB_GetTable(strSQL)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '取得データなし
                DSPJDNTHA_SEARCH = 1
                Exit Function
            End If
            '20190319 CHG END

            '20190319 CHG START
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '    With pot_DB_JDNTHA
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "") '伝票管理№
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "") '伝票区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "") '受注番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JHDNO = CF_Ora_GetDyn(Usr_Ody, "JHDNO", "") '受発注№
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JDNDT = CF_Ora_GetDyn(Usr_Ody, "JDNDT", "") '受注伝票日付
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DENDT = CF_Ora_GetDyn(Usr_Ody, "DENDT", "") '受注日付
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "") '納期
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "") '得意先コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "") '得意先略称
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "") '納入先コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "") '納入先名称１
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "") '納入先名称２
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "") '担当者コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "") '担当者名
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "") '部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "") '部門名
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "") '請求先コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "") '倉庫コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "") '倉庫名
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "") '取引区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "") '取引区分名
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SMADT = CF_Ora_GetDyn(Usr_Ody, "SMADT", "") '経理締日付
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JDNENDKB = CF_Ora_GetDyn(Usr_Ody, "JDNENDKB", "") '受注完了区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SBAUODKN = CF_Ora_GetDyn(Usr_Ody, "SBAUODKN", 0) '受注金額（本体合計）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SBAUZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZEKN", 0) '受注金額（消費税額）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SBAUZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZKKN", 0) '受注金額（伝票計）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DENCM = CF_Ora_GetDyn(Usr_Ody, "DENCM", "") '備考
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "") '締区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "") '締初期日付（売上）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "TOKSMECC", "") '締サイクル（売上）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "") '締め曜日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "") '回収サイクル
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "") '回収日付
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "") '回収曜日
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .LSTID = CF_Ora_GetDyn(Usr_Ody, "LSTID", "") '伝票種別
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "TKNRPSKB", "") '金額端数処理桁数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "TKNZRNKB", "") '金額端数処理区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "") '消費税区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "TOKZCLKB", "") '消費税算出区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "TOKRPSKB", "") '消費税端数処理桁数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "TOKZRNKB", "") '消費税端数処理区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "") '名称ﾏﾆｭｱﾙ入力区分（得意先）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "") '名称ﾏﾆｭｱﾙ入力区分（納入先）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "") 'マスタ区分（得意先）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "") 'マスタ区分（納入先）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TANMSTKB = CF_Ora_GetDyn(Usr_Ody, "TANMSTKB", "") 'マスタ区分（担当者）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "") '見積番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "") '版数
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "") '案件ＩＤ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLMDL = CF_Ora_GetDyn(Usr_Ody, "CLMDL", "") '分類型式
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .URIKJN = CF_Ora_GetDyn(Usr_Ody, "URIKJN", "") '売上基準
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "") '便名コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "") '件名１
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "") '件名２
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BKTHKKB = CF_Ora_GetDyn(Usr_Ody, "BKTHKKB", "") '分割不可区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .MAEUKKB = CF_Ora_GetDyn(Usr_Ody, "MAEUKKB", "") '前受区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SEIKB = CF_Ora_GetDyn(Usr_Ody, "SEIKB", "") '請求区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "") '受注取引区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "") '納入先住所１
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "") '納入先住所２
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "") '納入先住所３
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JDNINKB = CF_Ora_GetDyn(Usr_Ody, "JDNINKB", "") '受注取込種別
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DFKJDNNO = CF_Ora_GetDyn(Usr_Ody, "DFKJDNNO", "") 'ダイフク受注番号
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "TOKJDNNO", "") '客先注文No.
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .HDKEIKN = CF_Ora_GetDyn(Usr_Ody, "HDKEIKN", 0) 'ハード契約金額
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .HDSIKKN = CF_Ora_GetDyn(Usr_Ody, "HDSIKKN", 0) 'ハード仕切金額
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SFKEIKN = CF_Ora_GetDyn(Usr_Ody, "SFKEIKN", 0) 'ソフト契約金額
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SFSIKKN = CF_Ora_GetDyn(Usr_Ody, "SFSIKKN", 0) 'ソフト仕切金額
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CMPKTCD = CF_Ora_GetDyn(Usr_Ody, "CMPKTCD", "") 'コンピュータ型式コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CMPKTNM = CF_Ora_GetDyn(Usr_Ody, "CMPKTNM", "") 'コンピュータ型式名
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .PRDTBMCD = CF_Ora_GetDyn(Usr_Ody, "PRDTBMCD", "") '生産担当部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "") '通貨区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SBAFRCKN = CF_Ora_GetDyn(Usr_Ody, "SBAFRCKN", 0) '外貨受注金額（伝票計）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JODRSNKB = CF_Ora_GetDyn(Usr_Ody, "JODRSNKB", "") '受注理由区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JODCNKB = CF_Ora_GetDyn(Usr_Ody, "JODCNKB", "") '受注キャンセル理由区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JSKTANCD = CF_Ora_GetDyn(Usr_Ody, "JSKTANCD", "") '地域実績担当者コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JSKTANNM = CF_Ora_GetDyn(Usr_Ody, "JSKTANNM", "") '地域実績担当者名
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JSKBMNCD = CF_Ora_GetDyn(Usr_Ody, "JSKBMNCD", "") '地域実績部門コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JSKBMNNM = CF_Ora_GetDyn(Usr_Ody, "JSKBMNNM", "") '地域実績部門名
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "") '海外取引区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "") '仕向地
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JDNPRKB = CF_Ora_GetDyn(Usr_Ody, "JDNPRKB", "") '発行区分
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .DENCMIN = CF_Ora_GetDyn(Usr_Ody, "DENCMIN", "") '社内備考
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .JDNENDNM = CF_Ora_GetDyn(Usr_Ody, "JDNENDNM", "") '受注完了区分名
            '    End With
            'End If

            ''クローズ
            'Call CF_Ora_CloseDyn(Usr_Ody)

            With pot_DB_JDNTHA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "") '伝票管理№
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '伝票削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DENKB = DB_NullReplace(dt.Rows(0)("DENKB"), "") '伝票区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNNO = DB_NullReplace(dt.Rows(0)("JDNNO"), "") '受注番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JHDNO = DB_NullReplace(dt.Rows(0)("JHDNO"), "") '受発注№
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNDT = DB_NullReplace(dt.Rows(0)("JDNDT"), "") '受注伝票日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DENDT = DB_NullReplace(dt.Rows(0)("DENDT"), "") '受注日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DEFNOKDT = DB_NullReplace(dt.Rows(0)("DEFNOKDT"), "") '納期
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKCD = DB_NullReplace(dt.Rows(0)("TOKCD"), "") '得意先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKRN = DB_NullReplace(dt.Rows(0)("TOKRN"), "") '得意先略称
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSCD = DB_NullReplace(dt.Rows(0)("NHSCD"), "") '納入先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNMA = DB_NullReplace(dt.Rows(0)("NHSNMA"), "") '納入先名称１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNMB = DB_NullReplace(dt.Rows(0)("NHSNMB"), "") '納入先名称２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TANCD = DB_NullReplace(dt.Rows(0)("TANCD"), "") '担当者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TANNM = DB_NullReplace(dt.Rows(0)("TANNM"), "") '担当者名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BUMCD = DB_NullReplace(dt.Rows(0)("BUMCD"), "") '部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BUMNM = DB_NullReplace(dt.Rows(0)("BUMNM"), "") '部門名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSEICD = DB_NullReplace(dt.Rows(0)("TOKSEICD"), "") '請求先コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SOUCD = DB_NullReplace(dt.Rows(0)("SOUCD"), "") '倉庫コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SOUNM = DB_NullReplace(dt.Rows(0)("SOUNM"), "") '倉庫名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZKTKB = DB_NullReplace(dt.Rows(0)("ZKTKB"), "") '取引区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .ZKTNM = DB_NullReplace(dt.Rows(0)("ZKTNM"), "") '取引区分名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SMADT = DB_NullReplace(dt.Rows(0)("SMADT"), "") '経理締日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNENDKB = DB_NullReplace(dt.Rows(0)("JDNENDKB"), "") '受注完了区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SBAUODKN = DB_NullReplace(dt.Rows(0)("SBAUODKN"), 0) '受注金額（本体合計）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SBAUZEKN = DB_NullReplace(dt.Rows(0)("SBAUZEKN"), 0) '受注金額（消費税額）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SBAUZKKN = DB_NullReplace(dt.Rows(0)("SBAUZKKN"), 0) '受注金額（伝票計）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DENCM = DB_NullReplace(dt.Rows(0)("DENCM"), "") '備考
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSMEKB = DB_NullReplace(dt.Rows(0)("TOKSMEKB"), "") '締区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSMEDD = DB_NullReplace(dt.Rows(0)("TOKSMEDD"), "") '締初期日付（売上）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSMECC = DB_NullReplace(dt.Rows(0)("TOKSMECC"), "") '締サイクル（売上）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKSDWKB = DB_NullReplace(dt.Rows(0)("TOKSDWKB"), "") '締め曜日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKKESCC = DB_NullReplace(dt.Rows(0)("TOKKESCC"), "") '回収サイクル
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKKESDD = DB_NullReplace(dt.Rows(0)("TOKKESDD"), "") '回収日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKKDWKB = DB_NullReplace(dt.Rows(0)("TOKKDWKB"), "") '回収曜日
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .LSTID = DB_NullReplace(dt.Rows(0)("LSTID"), "") '伝票種別
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TKNRPSKB = DB_NullReplace(dt.Rows(0)("TKNRPSKB"), "") '金額端数処理桁数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TKNZRNKB = DB_NullReplace(dt.Rows(0)("TKNZRNKB"), "") '金額端数処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKZEIKB = DB_NullReplace(dt.Rows(0)("TOKZEIKB"), "") '消費税区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKZCLKB = DB_NullReplace(dt.Rows(0)("TOKZCLKB"), "") '消費税算出区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKRPSKB = DB_NullReplace(dt.Rows(0)("TOKRPSKB"), "") '消費税端数処理桁数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKZRNKB = DB_NullReplace(dt.Rows(0)("TOKZRNKB"), "") '消費税端数処理区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKNMMKB = DB_NullReplace(dt.Rows(0)("TOKNMMKB"), "") '名称ﾏﾆｭｱﾙ入力区分（得意先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSNMMKB = DB_NullReplace(dt.Rows(0)("NHSNMMKB"), "") '名称ﾏﾆｭｱﾙ入力区分（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKMSTKB = DB_NullReplace(dt.Rows(0)("TOKMSTKB"), "") 'マスタ区分（得意先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSMSTKB = DB_NullReplace(dt.Rows(0)("NHSMSTKB"), "") 'マスタ区分（納入先）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TANMSTKB = DB_NullReplace(dt.Rows(0)("TANMSTKB"), "") 'マスタ区分（担当者）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MITNO = DB_NullReplace(dt.Rows(0)("MITNO"), "") '見積番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MITNOV = DB_NullReplace(dt.Rows(0)("MITNOV"), "") '版数
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .AKNID = DB_NullReplace(dt.Rows(0)("AKNID"), "") '案件ＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLMDL = DB_NullReplace(dt.Rows(0)("CLMDL"), "") '分類型式
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .URIKJN = DB_NullReplace(dt.Rows(0)("URIKJN"), "") '売上基準
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BINCD = DB_NullReplace(dt.Rows(0)("BINCD"), "") '便名コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KENNMA = DB_NullReplace(dt.Rows(0)("KENNMA"), "") '件名１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .KENNMB = DB_NullReplace(dt.Rows(0)("KENNMB"), "") '件名２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .BKTHKKB = DB_NullReplace(dt.Rows(0)("BKTHKKB"), "") '分割不可区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .MAEUKKB = DB_NullReplace(dt.Rows(0)("MAEUKKB"), "") '前受区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SEIKB = DB_NullReplace(dt.Rows(0)("SEIKB"), "") '請求区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "") '受注取引区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSADA = DB_NullReplace(dt.Rows(0)("NHSADA"), "") '納入先住所１
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSADB = DB_NullReplace(dt.Rows(0)("NHSADB"), "") '納入先住所２
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .NHSADC = DB_NullReplace(dt.Rows(0)("NHSADC"), "") '納入先住所３
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNINKB = DB_NullReplace(dt.Rows(0)("JDNINKB"), "") '受注取込種別
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DFKJDNNO = DB_NullReplace(dt.Rows(0)("DFKJDNNO"), "") 'ダイフク受注番号
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TOKJDNNO = DB_NullReplace(dt.Rows(0)("TOKJDNNO"), "") '客先注文No.
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HDKEIKN = DB_NullReplace(dt.Rows(0)("HDKEIKN"), 0) 'ハード契約金額
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HDSIKKN = DB_NullReplace(dt.Rows(0)("HDSIKKN"), 0) 'ハード仕切金額
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SFKEIKN = DB_NullReplace(dt.Rows(0)("SFKEIKN"), 0) 'ソフト契約金額
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SFSIKKN = DB_NullReplace(dt.Rows(0)("SFSIKKN"), 0) 'ソフト仕切金額
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CMPKTCD = DB_NullReplace(dt.Rows(0)("CMPKTCD"), "") 'コンピュータ型式コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CMPKTNM = DB_NullReplace(dt.Rows(0)("CMPKTNM"), "") 'コンピュータ型式名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .PRDTBMCD = DB_NullReplace(dt.Rows(0)("PRDTBMCD"), "") '生産担当部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .TUKKB = DB_NullReplace(dt.Rows(0)("TUKKB"), "") '通貨区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SBAFRCKN = DB_NullReplace(dt.Rows(0)("SBAFRCKN"), 0) '外貨受注金額（伝票計）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JODRSNKB = DB_NullReplace(dt.Rows(0)("JODRSNKB"), "") '受注理由区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JODCNKB = DB_NullReplace(dt.Rows(0)("JODCNKB"), "") '受注キャンセル理由区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JSKTANCD = DB_NullReplace(dt.Rows(0)("JSKTANCD"), "") '地域実績担当者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JSKTANNM = DB_NullReplace(dt.Rows(0)("JSKTANNM"), "") '地域実績担当者名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JSKBMNCD = DB_NullReplace(dt.Rows(0)("JSKBMNCD"), "") '地域実績部門コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JSKBMNNM = DB_NullReplace(dt.Rows(0)("JSKBMNNM"), "") '地域実績部門名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .FRNKB = DB_NullReplace(dt.Rows(0)("FRNKB"), "") '海外取引区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SIMUKE = DB_NullReplace(dt.Rows(0)("SIMUKE"), "") '仕向地
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNPRKB = DB_NullReplace(dt.Rows(0)("JDNPRKB"), "") '発行区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DENCMIN = DB_NullReplace(dt.Rows(0)("DENCMIN"), "") '社内備考
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .JDNENDNM = DB_NullReplace(dt.Rows(0)("JDNENDNM"), "") '受注完了区分名
            End With
            '20190319 CHG END

            DSPJDNTHA_SEARCH = 0

            '            Exit Function

            'ERR_DSPJDNTHA_SEARCH:

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPJDNTHA_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPRNKM_SEARCH
    '   概要：  ランク別仕切率マスタ検索
    '   引数：　pin_strHINGRP   : 商品群
    '           pin_strRNKCD    : ランク
    '           pin_strURISETDT : 販売単価設定日付
    '           pot_DB_RNKMTA 　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPRNKM_SEARCH(ByVal pin_strHINGRP As String, ByVal pin_strRNKCD As String, ByVal pin_strURISETDT As String, ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPRNKM_SEARCH

        DSPRNKM_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from RNKMTA "
        strSQL = strSQL & "  Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "  and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "  and URISETDT = ( Select MAX(URISETDT) AS _MAX_URISETDT "
        strSQL = strSQL & "                     from RNKMTA "
        strSQL = strSQL & "                    Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "                      and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "                      and URISETDT <= '" & pin_strURISETDT & "' )"

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPRNKM_SEARCH = 1
            Exit Function
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_RNKMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "") '商品群
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RNKCD = CF_Ora_GetDyn(Usr_Ody, "RNKCD", "") 'ランク
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .URISETDT = CF_Ora_GetDyn(Usr_Ody, "URISETDT", "") '販売単価設定日付
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .SIKRT = CF_Ora_GetDyn(Usr_Ody, "SIKRT", 0) '仕切率
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            End With
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)


        DSPRNKM_SEARCH = 0

        Exit Function

ERR_DSPRNKM_SEARCH:


    End Function



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPYSN_SEARCH
    '   概要：  与信限度ファイル検索
    '   引数：  pin_strTOKCD　　 : 得意先コード
    '           pin_strTGRPCD　　: グループ会社コード
    '   　　　　pin_strYSNUPDT 　: 登録日
    '   　　　　pot_DB_YSNTRA  　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPYSN_SEARCH(ByVal pin_strTOKCD As String, ByVal pin_strTGRPCD As String, ByVal pin_strYSNUPDT As String, ByRef pot_DB_YSNTRA As TYPE_DB_YSNTRA) As Short

        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strTGRPCD As String

        On Error GoTo ERR_DSPYSN_SEARCH

        DSPYSN_SEARCH = 9

        '20190619 DEL START
        'Call DB_YSNTRA_Clear(pot_DB_YSNTRA)
        '20190619 DEL END

        If Trim(pin_strTGRPCD) = "" Then
            strTGRPCD = pin_strTOKCD
        Else
            strTGRPCD = pin_strTGRPCD
        End If

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from YSNTRA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TGRPCD  = '" & CF_Ora_Sgl(strTGRPCD) & "' "
        strSQL = strSQL & "    and YSNUPDT = '" & CF_Ora_Sgl(pin_strYSNUPDT) & "' "


        '20190827 CHG START
        'DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        Dim dt As DataTable = Nothing
        dt = DB_GetTable(strSQL)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt.Rows.Count = 0 Then
            '取得データなし
            DSPYSN_SEARCH = 1
            GoTo END_DSPYSN_SEARCH
        End If

        'If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_YSNTRA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
                .DATKB = DB_NullReplace(dt.Rows(0)("DATKB"), "") '削除区分

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "") 'グループ会社コード
                .TGRPCD = DB_NullReplace(dt.Rows(0)("TGRPCD"), "") 'グループ会社コード

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.YSNUPDT = CF_Ora_GetDyn(Usr_Ody, "YSNUPDT", "") '登録日
                .YSNUPDT = DB_NullReplace(dt.Rows(0)("YSNUPDT"), "") '登録日

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0) '売掛残金額
                .URKZANKN = DB_NullReplace(dt.Rows(0)("URKZANKN"), 0) '売掛残金額

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.YSNJDNKN = CF_Ora_GetDyn(Usr_Ody, "YSNJDNKN", 0) '受注残金額
                .YSNJDNKN = DB_NullReplace(dt.Rows(0)("YSNJDNKN"), 0) '受注残金額

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.YSNTEGKN = CF_Ora_GetDyn(Usr_Ody, "YSNTEGKN", 0) '受手残金額
                .YSNTEGKN = DB_NullReplace(dt.Rows(0)("YSNTEGKN"), 0) '受手残金額

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "") '最終作業者コード

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "") 'クライアントＩＤ

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）

                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）

            End With
        'End If

        '20190827 CHG END

        DSPYSN_SEARCH = 0

END_DSPYSN_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPYSN_SEARCH:
        GoTo END_DSPYSN_SEARCH

    End Function

    '20190628 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPUNTCD_SEARCH
    '   概要：  単位マスタ検索
    '   引数：  pin_strUNTCD　　 : 単位コード
    '   　　　　pot_DB_UNTMTA  　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPUNTCD_SEARCH(ByVal pin_strUNTCD As String, ByRef pot_DB_UNTMTA As TYPE_DB_UNTMTA) As Short

        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPUNTCD_SEARCH

        DSPUNTCD_SEARCH = 9

        '20190628 CHG START
        'Call DB_UNTMTA_Clear(pot_DB_UNTMTA)
        Call InitDataCommon("UNTMTA")
        '20190628 CHG END

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from UNTMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and UNTCD   = '" & CF_Ora_Sgl(pin_strUNTCD) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPUNTCD_SEARCH = 1
            GoTo END_DSPUNTCD_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_UNTMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "") '単位コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "") '単位名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            End With
        End If

        DSPUNTCD_SEARCH = 0

END_DSPUNTCD_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPUNTCD_SEARCH:
        GoTo END_DSPUNTCD_SEARCH

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPUNTNM_SEARCH
    '   概要：  単位マスタ検索（単位名より）
    '   引数：  pin_strUNTNM　　 : 単位名
    '   　　　　pot_DB_UNTMTA  　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPUNTNM_SEARCH(ByVal pin_strUNTNM As String, ByRef pot_DB_UNTMTA As TYPE_DB_UNTMTA) As Short

        Dim strSQL As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        On Error GoTo ERR_DSPUNTNM_SEARCH

        DSPUNTNM_SEARCH = 9

        '20190628 CHG START
        'Call DB_UNTMTA_Clear(pot_DB_UNTMTA)
        Call InitDataCommon("UNTMTA")
        '20190628 CHG END

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from UNTMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and UNTNM   = '" & CF_Ora_String(pin_strUNTNM, 4) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPUNTNM_SEARCH = 1
            GoTo END_DSPUNTNM_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_UNTMTA
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '削除区分
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "") '単位コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "") '単位名
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "") '連携フラグ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            End With
        End If

        DSPUNTNM_SEARCH = 0

END_DSPUNTNM_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function

ERR_DSPUNTNM_SEARCH:
        GoTo END_DSPUNTNM_SEARCH

    End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPANID_SEARCH
    '   概要：  案件情報検索
    '   引数：  pin_strANID   : 案件ID
    '           pot_DB_ANKNVIEW : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPANID_SEARCH(ByVal pin_strANID As String, ByRef pot_DB_ANKNVIEW As TYPE_DB_ANKNVIEW) As Short

        Dim li_MsgRtn As Integer

        Try
            Dim strSQL As String
            'Dim intData As Short
            ''UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
            'Dim Usr_Ody_LC As U_Ody

            'On Error GoTo ERR_DSPANID_SEARCH

            '20190809 DEL START
            'DSPANID_SEARCH = 9

            'strSQL = ""
            'strSQL = strSQL & " Select * "
            'strSQL = strSQL & "   from cszIncidentHanbai@HSODBC "
            'strSQL = strSQL & "  Where ""iIncidentid""   = " & CF_Get_CCurString(pin_strANID) & " "

            'Dim dt As DataTable = DB_GetTable(strSQL)

            'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '    DSPANID_SEARCH = 1
            '    Exit Function
            'End If

            '''DBアクセス
            ''Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

            ''If CF_Ora_EOF(Usr_Ody_LC) = True Then
            ''	'取得データなし
            ''	DSPANID_SEARCH = 1
            ''	GoTo END_DSPANID_SEARCH
            ''End If

            ''取得データ退避
            'With pot_DB_ANKNVIEW
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .ANKNID = DB_NullReplace(dt.Rows(0)("iIncidentid"), "") '案件ID
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .KKYKID = DB_NullReplace(dt.Rows(0)("iOwnerId"), "") '顧客ID
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .TOKRN = DB_NullReplace(dt.Rows(0)("CompanyName"), "") '会社漢字名
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .SYAINNM_L = DB_NullReplace(dt.Rows(0)("CustomerNameSei"), "") '社員漢字姓
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .SYAINNM_F = DB_NullReplace(dt.Rows(0)("CustomerNameMei"), "") '社員漢字名
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .CATEGORY = DB_NullReplace(dt.Rows(0)("iIncidentCategory"), "") 'カテゴリ
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .TKAFL = DB_NullReplace(dt.Rows(0)("iIncidentTypeId"), "") '内容分類
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .KENNM = DB_NullReplace(dt.Rows(0)("vchDesc1"), "") '内容
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .STS = DB_NullReplace(dt.Rows(0)("iStatusId"), "") 'ステータス
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .CODE1 = DB_NullReplace(dt.Rows(0)("iCode1"), "") '解決コード１
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .CODE2 = DB_NullReplace(dt.Rows(0)("iCode2"), "") '解決コード２
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .TANID = DB_NullReplace(dt.Rows(0)("chAssignedTo"), "") '担当者ID
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .TANNM = DB_NullReplace(dt.Rows(0)("chAssignedName"), "") '担当者名
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .KAKID = DB_NullReplace(dt.Rows(0)("vchUser1Id"), "") '受注規模/確度ID
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .KAKNM = DB_NullReplace(dt.Rows(0)("vchUser1"), "") '受注規模/確度名
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .SBAUZKKN = DB_NullReplace(dt.Rows(0)("vchUser2"), "") '受注予定金額
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .JDNYTDT = DB_NullReplace(dt.Rows(0)("vchUser3"), "") '受注予定日
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .DEFNOKDT = DB_NullReplace(dt.Rows(0)("vchUser4"), "") '予定納期
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .NHSNMA = DB_NullReplace(dt.Rows(0)("vchUser5"), "") '納入先
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .HINNMA = DB_NullReplace(dt.Rows(0)("vchUser6"), "") '代表型式
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .ANSU = DB_NullReplace(dt.Rows(0)("vchUser7"), "") '数量
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .MITNO = DB_NullReplace(dt.Rows(0)("vchUser8"), "") '見積No
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .JDNNO = DB_NullReplace(dt.Rows(0)("vchUser9"), "") '受注No
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .ANID_OYA = DB_NullReplace(dt.Rows(0)("vchUser10"), "") '親案件ID
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .OPEID = DB_NullReplace(dt.Rows(0)("chInsertBy"), "") '作成者ID
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .WRTFSTTM = DB_NullReplace(dt.Rows(0)("dtInsertDate"), "") '作成日時
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .UPDOPEID = DB_NullReplace(dt.Rows(0)("chUpdateBy"), "") '更新者ID
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .WRTTM = DB_NullReplace(dt.Rows(0)("dtUpdateDate"), "") '更新日時
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .RECSTS = DB_NullReplace(dt.Rows(0)("tiRecordStatus"), "") 'レコードステータス
            'End With
            '20190809 DEL END

            DSPANID_SEARCH = 0

        Catch ex As Exception
            li_MsgRtn = MsgBox("DSPANID_SEARCH" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try

        'END_DSPANID_SEARCH:
        '        'クローズ
        '        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        '        Exit Function

        'ERR_DSPANID_SEARCH:
        '        GoTo END_DSPANID_SEARCH

    End Function
    '20190628 ADD START

    '20190701 ADD START

    ' === 20060920 === INSERT E

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMEIC_SEARCH
    '   概要：  名称マスタ検索
    '   引数：  pin_strKEYCD  : キー１
    '           pin_strMEICDA : コード１
    '           pot_DB_MEIMTC : 検索結果
    '           pin_strMEICDB : コード２（省略された場合、検索条件に含めない）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPMEIC_SEARCH(ByVal pin_strKEYCD As String, ByVal pin_strMEICDA As String, ByVal pin_strTKDT As String, ByRef pot_DB_MEIMTC As TYPE_DB_MEIMTC, Optional ByVal pin_strMEICDB As Object = Nothing) As Short

        Dim strSQL As String
        Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        On Error GoTo ERR_DSPMEIC_SEARCH

        DSPMEIC_SEARCH = 9

        strSQL = ""
        '20190701 DEL START
        'strSQL = strSQL & " Select * "
        'strSQL = strSQL & "   from MEIMTC "
        '20190701 DEL END
        strSQL = strSQL & "  Where KEYCD  = '" & pin_strKEYCD & "' "
        strSQL = strSQL & "   and  MEICDA = '" & pin_strMEICDA & "' "
        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        If IsNothing(pin_strMEICDB) = False Then
            'UPGRADE_WARNING: オブジェクト pin_strMEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSQL = strSQL & "   and  MEICDB = '" & pin_strMEICDB & "' "
        End If
        strSQL = strSQL & "   and  STTTKDT <= '" & pin_strTKDT & "' "
        strSQL = strSQL & "   and  ENDTKDT >= '" & pin_strTKDT & "' "

        'DBアクセス
        ' 'change 20190405 START saiki
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        '      If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '	'取得データなし
        '	DSPMEIC_SEARCH = 1
        '	GoTo END_DSPMEIC_SEARCH
        'End If

        ''取得データ退避
        'Call DB_MEIMTC_SetData(Usr_Ody_LC, pot_DB_MEIMTC)


        'Dim dt As DataTable = DB_GetTable(strSQL)

        'If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
        '    '取得データなし
        '    DSPMEIC_SEARCH = 1
        '    GoTo END_DSPMEIC_SEARCH
        'End If

        'Call DB_MEIMTC_SetData(dt, pot_DB_MEIMTC, 0)
        'change 20190405 END saiki

        '20190701 ADD START
        GetRowsCommon("MEIMTC", strSQL)

        pot_DB_MEIMTC = DB_MEIMTC

        If pot_DB_MEIMTC.DATKB Is Nothing Then
            '取得データなし
            DSPMEIC_SEARCH = 1
            GoTo END_DSPMEIC_SEARCH
        End If
        '20190701 ADD END


        DSPMEIC_SEARCH = 0

END_DSPMEIC_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)

        Exit Function

ERR_DSPMEIC_SEARCH:

    End Function
    '20190701 ADD END


    '20190703 ADD START
    Function DELTRN() As Short
        'Dim PlStat As Long
        'Dim I%
        '    '
        '    ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される
        '    If G_PlCnd.nJobMode <> 2 Then Exit Function  'Delete以外
        '    FR_SSSMAIN.Enabled = False
        '
        '    For I = 0 To MAX_CNDARR - 1
        '        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
        '        G_PlCnd.nCndNum(I) = I + 1
        '    Next I
        '
        '    G_PlCnd.sOpeID = SSS_OPEID
        '    G_PlCnd.sCltID = SSS_CLTID
        '
        '    G_PlInfo.FCnt = 2
        '    G_PlInfo.Fno(0) = DBN_JDNTRA
        '    G_PlInfo.RCnt(0) = 1
        '    G_PlInfo.ArrayFlg(0) = 1
        '    G_PlInfo.Fno(1) = DBN_JDNTHA
        '    G_PlInfo.RCnt(1) = 1
        '    G_PlInfo.ArrayFlg(1) = 0
        '
        '    DB_JDNTHA.JDNNO = RD_SSSMAIN_JDNNO(-1)
        '
        '    PlStat = DB_PlStart
        '    PlStat = DB_PlCndSet
        '    PlStat = DB_PlSet(DBN_JDNTHA, 0)
        '    PlStat = DB_PlSet(DBN_JDNTRA, 0)
        '
        '    Call DB_BeginTransaction(BTR_Exclude)
        '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_JDNTRA")
        '    If PlStat <> 0 And PlStat <> 1485 Then
        '        MsgBox "PL/SQL Error：" & PlStat
        '        DELTRN = False
        '        DB_AbortTransaction
        '    Else
        '        DELTRN = True
        '        Call DB_EndTransaction
        '    End If
        '
        '    PlStat = DB_PlFree
        '
        '    FR_SSSMAIN.Enabled = True
    End Function

    Function WRTTRN() As Short
        'Dim I As Integer
        'Dim PlStat As Long
        '    '
        '    FR_SSSMAIN.Enabled = False
        '
        '    ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される
        '
        '    For I = 0 To MAX_CNDARR - 1
        '        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
        '        G_PlCnd.nCndNum(I) = I + 1
        '    Next I
        '
        '    G_PlCnd.sOpeID = SSS_OPEID
        '    G_PlCnd.sCltID = SSS_CLTID
        '
        '    G_PlInfo.FCnt = 2
        '    G_PlInfo.Fno(0) = DBN_JDNTRA
        '    G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
        '    G_PlInfo.ArrayFlg(0) = 1
        '    G_PlInfo.Fno(1) = DBN_JDNTHA
        '    G_PlInfo.RCnt(1) = 1
        '    G_PlInfo.ArrayFlg(1) = 0
        '
        '    '
        '    Call JDNTHA_RClear
        '    Call JDNTHA_FromSCR(-1)
        '    DB_JDNTHA.DATKB = "1"
        '    DB_JDNTHA.DENKB = "1"
        '    DB_JDNTHA.JDNKB = "1"   '1999/10/19 Insert
        '    DB_JDNTHA.SMADT = SSS_SMADT
        '    '
        '    PlStat = DB_PlStart
        '    PlStat = DB_PlCndSet
        '    PlStat = DB_PlSet(DBN_JDNTHA, 0)
        '    I = 0
        '    Do While I < PP_SSSMAIN.LastDe
        '        Call JDNTRA_RClear
        '        Call Mfil_FromSCR(I)
        '        DB_JDNTRA.DATKB = "1"
        '        DB_JDNTRA.DENKB = "1"
        '        DB_JDNTRA.JDNKB = "1"   '1999/10/19 Insert
        '        DB_JDNTRA.SMADT = SSS_SMADT
        '        PlStat = DB_PlSet(DBN_JDNTRA, I)
        '        I = I + 1
        '    Loop
        '
        '    Call DB_BeginTransaction(BTR_Exclude)
        '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_JDNTRA")
        '    If PlStat <> 0 And PlStat <> 1485 Then
        '        MsgBox "PL/SQL Error：" & PlStat
        '        WRTTRN = False
        '        DB_AbortTransaction
        '    Else
        '        WRTTRN = True
        '        Call DB_EndTransaction
        ''1998/05/12  １行追加
        '        Call DP_SSSMAIN_JDNNO(-1, G_PlCnd2.sCndStr(1))
        '    End If
        '
        '    PlStat = DB_PlFree
        '
        '    FR_SSSMAIN.Enabled = True
    End Function
    '20190703 ADD END

End Module