Option Strict Off
Option Explicit On
Module URKET52_DBM
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPUDNTHA_SEARCH
	'   概要：  売上見出トラン データ検索
	'   引数：  pin_strDATNO     : 売上伝票管理番号
	'           pot_DB_UDNTHA    : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPUDNTHA_SEARCH(ByVal pin_strDATNO As String, ByRef pot_DB_UDNTHA As TYPE_DB_UDNTHA) As Short
		
		Dim strSQL As String
		Dim strCountSQL As String
		Dim intData As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_LC As U_Ody

        '2019/06/03 ADD START
        Dim dt As DataTable = New DataTable
        '2019/06/03 ADD END

        On Error GoTo ERR_DSPUDNTHA_SEARCH

        DSPUDNTHA_SEARCH = 9

        strSQL = ""
        strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM UDNTHA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_Sgl(pin_strDATNO) & "'"

        'DBアクセス
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        '      If CF_Ora_EOF(Usr_Ody_LC) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/06/03 CHG END

            '取得データなし
            DSPUDNTHA_SEARCH = 1
            GoTo END_DSPUDNTHA_SEARCH
        End If

        '取得データ退避
        '2019/06/03 CHG START
        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '    Call DB_UDNTHA_SetData(Usr_Ody_LC, pot_DB_UDNTHA)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_UDNTHA_SetData(dt, pot_DB_UDNTHA)
            '2019/06/03 CHG END
        End If

        DSPUDNTHA_SEARCH = 0

END_DSPUDNTHA_SEARCH: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_DSPUDNTHA_SEARCH: 
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_UDNTHA_SetData
    '   概要：  売上見出トラン データ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_UDNTHA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_UDNTHA As TYPE_DB_UDNTHA)
        'データ退避
        With pot_DB_UDNTHA
            '2019/06/03 CHG START
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DATNO = CF_Ora_GetDyn(pin_Usr_Ody, "DATNO", "") '伝票管理NO.
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.AKAKROKB = CF_Ora_GetDyn(pin_Usr_Ody, "AKAKROKB", "") '赤黒区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DENKB = CF_Ora_GetDyn(pin_Usr_Ody, "DENKB", "") '伝票区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "UDNNO", "") '売上伝票番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "FDNNO", "") '伝票管理NO.
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.JDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "JDNNO", "") '受注番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.USDNO = CF_Ora_GetDyn(pin_Usr_Ody, "USDNO", "") '直送伝票NO
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UDNDT = CF_Ora_GetDyn(pin_Usr_Ody, "UDNDT", "") '売上伝票日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DENDT = CF_Ora_GetDyn(pin_Usr_Ody, "DENDT", "") '伝票日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.REGDT = CF_Ora_GetDyn(pin_Usr_Ody, "REGDT", "") '初回伝票日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '得意先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKRN = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRN", "") '得意先略称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSCD = CF_Ora_GetDyn(pin_Usr_Ody, "NHSCD", "") '納入先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSRN = CF_Ora_GetDyn(pin_Usr_Ody, "NHSRN", "") '納入先略称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSNMA = CF_Ora_GetDyn(pin_Usr_Ody, "NHSNMA", "") '納入先名称１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSNMB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSNMB", "") '納入先名称２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANCD = CF_Ora_GetDyn(pin_Usr_Ody, "TANCD", "") '担当者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANNM = CF_Ora_GetDyn(pin_Usr_Ody, "TANNM", "") '担当者名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BUMCD = CF_Ora_GetDyn(pin_Usr_Ody, "BUMCD", "") '部門コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BUMNM = CF_Ora_GetDyn(pin_Usr_Ody, "BUMNM", "") '部門名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '請求先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SOUCD = CF_Ora_GetDyn(pin_Usr_Ody, "SOUCD", "") '倉庫コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SOUNM = CF_Ora_GetDyn(pin_Usr_Ody, "SOUNM", "") '倉庫名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NXTKB = CF_Ora_GetDyn(pin_Usr_Ody, "NXTKB", "") '帳端区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NXTNM = CF_Ora_GetDyn(pin_Usr_Ody, "NXTNM", "") '帳端名称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EMGODNKB = CF_Ora_GetDyn(pin_Usr_Ody, "EMGODNKB", "") '緊急出荷区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OKRJONO = CF_Ora_GetDyn(pin_Usr_Ody, "OKRJONO", "") '送り状№
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.INVNO = CF_Ora_GetDyn(pin_Usr_Ody, "INVNO", "") 'インボイス№
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SMADT = CF_Ora_GetDyn(pin_Usr_Ody, "SMADT", "") '経理締日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SSADT = CF_Ora_GetDyn(pin_Usr_Ody, "SSADT", "") '締日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KESDT = CF_Ora_GetDyn(pin_Usr_Ody, "KESDT", "") '決済日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NYUCD = CF_Ora_GetDyn(pin_Usr_Ody, "NYUCD", "") '入金区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZKTKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZKTKB", "") '取引区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZKTNM = CF_Ora_GetDyn(pin_Usr_Ody, "ZKTNM", "") '取引区分名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KENNMA = CF_Ora_GetDyn(pin_Usr_Ody, "KENNMA", "") '件名１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KENNMB = CF_Ora_GetDyn(pin_Usr_Ody, "KENNMB", "") '件名２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSADA = CF_Ora_GetDyn(pin_Usr_Ody, "NHSADA", "") '納入先住所１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSADB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSADB", "") '納入先住所２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSADC = CF_Ora_GetDyn(pin_Usr_Ody, "NHSADC", "") '納入先住所３
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MAEUKNM = CF_Ora_GetDyn(pin_Usr_Ody, "MAEUKNM", "") '前受区分名称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KEIBUMCD = CF_Ora_GetDyn(pin_Usr_Ody, "KEIBUMCD", "") '経理部門コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UPFKB = CF_Ora_GetDyn(pin_Usr_Ody, "UPFKB", "") '売上同時出荷区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SBAURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAURIKN", 0) '売上金額(本体合計)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SBAUZEKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAUZEKN", 0) '売上金額(消費税額)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SBAUZKKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAUZKKN", 0) '売上金額(伝票計)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SBAFRUKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAFRUKN", 0) '外貨売上金額(伝票計)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SBANYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBANYUKN", 0) '入金金額(伝票計)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SBAFRNKN = CF_Ora_GetDyn(pin_Usr_Ody, "SBAFRNKN", 0) '外貨入金額(伝票計)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DENCM = CF_Ora_GetDyn(pin_Usr_Ody, "DENCM", "") '備考
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DENCMIN = CF_Ora_GetDyn(pin_Usr_Ody, "DENCMIN", "") '社内備考
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSMEKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEKB", "") '締区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSMEDD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEDD", "") '締初期日付(売上)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSMECC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMECC", "") '締サイクル(売上)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSDWKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSDWKB", "") '締め曜日
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKKESCC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKKESCC", "") '回収サイクル
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKKESDD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKKESDD", "") '回収日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKKDWKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKKDWKB", "") '回収曜日
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.LSTID = CF_Ora_GetDyn(pin_Usr_Ody, "LSTID", "") '伝票種別
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKJUNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKJUNKB", "") '順位表出力区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMSTKB", "") 'マスタ区分(得意先)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TKNRPSKB = CF_Ora_GetDyn(pin_Usr_Ody, "TKNRPSKB", "") '金額端数処理桁数
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TKNZRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TKNZRNKB", "") '金額端数処理区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKZEIKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZEIKB", "") '消費税区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKZCLKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZCLKB", "") '消費税算出区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKRPSKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRPSKB", "") '消費税端数処理桁数
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKZRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZRNKB", "") '消費税端数処理区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMMKB", "") '名称ﾏﾆｭｱﾙ区分（得）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSMSTKB", "") 'マスタ区分(納入先)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSNMMKB", "") '名称ﾏﾆｭｱﾙ区分（納）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TANMSTKB", "") 'マスタ区分(担当者)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.URIKJN = CF_Ora_GetDyn(pin_Usr_Ody, "URIKJN", "") '売上基準
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MAEUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "MAEUKKB", "") '前受区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SEIKB = CF_Ora_GetDyn(pin_Usr_Ody, "SEIKB", "") '請求区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.JDNTRKB = CF_Ora_GetDyn(pin_Usr_Ody, "JDNTRKB", "") '受注取引区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "TUKKB", "") '通貨区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "FRNKB", "") '海外取引区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UDNPRAKB = CF_Ora_GetDyn(pin_Usr_Ody, "UDNPRAKB", "") '納品書発行区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UDNPRBKB = CF_Ora_GetDyn(pin_Usr_Ody, "UDNPRBKB", "") '個別請求発行区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MOTDATNO = CF_Ora_GetDyn(pin_Usr_Ody, "MOTDATNO", "") '元伝票管理番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '初回登録ﾕｰｻﾞｰID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '初回登録ｸﾗｲｱﾝﾄID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '最終作業者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") 'クライアントＩＤ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") 'ユーザID(ﾊﾞｯﾁ)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") 'プログラムID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DLFLG = CF_Ora_GetDyn(pin_Usr_Ody, "DLFLG", "") '削除フラグ

            .DATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATNO"), "") '伝票管理NO.
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '伝票削除区分
            .AKAKROKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("AKAKROKB"), "") '赤黒区分
            .DENKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENKB"), "") '伝票区分
            .UDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNNO"), "") '売上伝票番号
            .FDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("FDNNO"), "") '伝票管理NO.
            .JDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNNO"), "") '受注番号
            .USDNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("USDNO"), "") '直送伝票NO
            .UDNDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNDT"), "") '売上伝票日付
            .DENDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENDT"), "") '伝票日付
            .REGDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("REGDT"), "") '初回伝票日付
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCD"), "") '得意先コード
            .TOKRN = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRN"), "") '得意先略称
            .NHSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSCD"), "") '納入先コード
            .NHSRN = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSRN"), "") '納入先略称
            .NHSNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSNMA"), "") '納入先名称１
            .NHSNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSNMB"), "") '納入先名称２
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANCD"), "") '担当者コード
            .TANNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANNM"), "") '担当者名
            .BUMCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BUMCD"), "") '部門コード
            .BUMNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("BUMNM"), "") '部門名
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSEICD"), "") '請求先コード
            .SOUCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("SOUCD"), "") '倉庫コード
            .SOUNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("SOUNM"), "") '倉庫名
            .NXTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NXTKB"), "") '帳端区分
            .NXTNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("NXTNM"), "") '帳端名称
            .EMGODNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EMGODNKB"), "") '緊急出荷区分
            .OKRJONO = DB_NullReplace(pin_Usr_Ody.Rows(0)("OKRJONO"), "") '送り状№
            .INVNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("INVNO"), "") 'インボイス№
            .SMADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMADT"), "") '経理締日付
            .SSADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSADT"), "") '締日付
            .KESDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("KESDT"), "") '決済日付
            .NYUCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUCD"), "") '入金区分
            .ZKTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKTKB"), "") '取引区分
            .ZKTNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKTNM"), "") '取引区分名
            .KENNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("KENNMA"), "") '件名１
            .KENNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("KENNMB"), "") '件名２
            .NHSADA = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSADA"), "") '納入先住所１
            .NHSADB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSADB"), "") '納入先住所２
            .NHSADC = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSADC"), "") '納入先住所３
            .MAEUKNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAEUKNM"), "") '前受区分名称
            .KEIBUMCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KEIBUMCD"), "") '経理部門コード
            .UPFKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("UPFKB"), "") '売上同時出荷区分
            .SBAURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAURIKN"), "0") '売上金額(本体合計)
            .SBAUZEKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAUZEKN"), "0") '売上金額(消費税額)
            .SBAUZKKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAUZKKN"), "0") '売上金額(伝票計)
            .SBAFRUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAFRUKN"), "0") '外貨売上金額(伝票計)
            .SBANYUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBANYUKN"), "0") '入金金額(伝票計)
            .SBAFRNKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBAFRNKN"), "0") '外貨入金額(伝票計)
            .DENCM = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENCM"), "") '備考
            .DENCMIN = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENCMIN"), "") '社内備考
            .TOKSMEKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEKB"), "") '締区分
            .TOKSMEDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEDD"), "") '締初期日付(売上)
            .TOKSMECC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMECC"), "") '締サイクル(売上)
            .TOKSDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSDWKB"), "") '締め曜日
            .TOKKESCC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESCC"), "") '回収サイクル
            .TOKKESDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESDD"), "") '回収日付
            .TOKKDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKDWKB"), "") '回収曜日
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("LSTID"), "") '伝票種別
            .TOKJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKJUNKB"), "") '順位表出力区分
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMSTKB"), "") 'マスタ区分(得意先)
            .TKNRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNRPSKB"), "") '金額端数処理桁数
            .TKNZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNZRNKB"), "") '金額端数処理区分
            .TOKZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZEIKB"), "") '消費税区分
            .TOKZCLKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZCLKB"), "") '消費税算出区分
            .TOKRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRPSKB"), "") '消費税端数処理桁数
            .TOKZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZRNKB"), "") '消費税端数処理区分
            .TOKNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMMKB"), "") '名称ﾏﾆｭｱﾙ区分（得）
            .NHSMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSMSTKB"), "") 'マスタ区分(納入先)
            .NHSNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSNMMKB"), "") '名称ﾏﾆｭｱﾙ区分（納）
            .TANMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANMSTKB"), "") 'マスタ区分(担当者)
            .URIKJN = DB_NullReplace(pin_Usr_Ody.Rows(0)("URIKJN"), "") '売上基準
            .MAEUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAEUKKB"), "") '前受区分
            .SEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIKB"), "") '請求区分
            .JDNTRKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNTRKB"), "") '受注取引区分
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TUKKB"), "") '通貨区分
            .FRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("FRNKB"), "") '海外取引区分
            .UDNPRAKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNPRAKB"), "") '納品書発行区分
            .UDNPRBKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNPRBKB"), "") '個別請求発行区分
            .MOTDATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("MOTDATNO"), "") '元伝票管理番号
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FOPEID"), "") '初回登録ﾕｰｻﾞｰID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCLTID"), "") '初回登録ｸﾗｲｱﾝﾄID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '最終作業者コード
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") 'クライアントＩＤ
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UOPEID"), "") 'ユーザID(ﾊﾞｯﾁ)
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UCLTID"), "") 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(0)("PGID"), "") 'プログラムID
            .DLFLG = DB_NullReplace(pin_Usr_Ody.Rows(0)("DLFLG"), "") '削除フラグ
            '2019/06/03 CHG END

        End With
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_UDNTHA_Exicz
    '   概要：  売上見出トラン排他制御
    '   引数：  pin_strDATNO     ：伝票管理NO.
    '           pin_strFOPEID    ：初回登録ﾕｰｻﾞｰID
    '           pin_strFCLTID    ：初回登録ｸﾗｲｱﾝﾄID
    '           pin_strWRTFSTTM  ：ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
    '           pin_strWRTFSTDT  ：ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
    '           pin_strOPEID     ：最終作業者コード
    '           pin_strCLTID     ：クライアントＩＤ
    '           pin_strWRTTM     ：ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '           pin_strWRTDT     ：ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '           pin_strUOPEID    ：ユーザID(ﾊﾞｯﾁ)
    '           pin_strUCLTID    ：ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
    '           pin_strUWRTTM    ：ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '           pin_strUWRTDT    ：ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '   戻値：  0:正常   1:データ無し  9:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_UDNTHA_Exicz(ByVal pin_strDATNO As String, ByVal pin_strFOPEID As String, ByVal pin_strFCLTID As String, ByVal pin_strWRTFSTTM As String, ByVal pin_strWRTFSTDT As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strUWRTTM As String, ByVal pin_strUWRTDT As String) As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
        Dim strSQL As String
        '2019/06/03 ADD START
        Dim dt As DataTable
        '2019/06/03 ADD END

        On Error GoTo F_UDNTHA_Exicz_err
		
		F_UDNTHA_Exicz = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " SELECT FOPEID " '初回登録ﾕｰｻﾞｰID
		strSQL = strSQL & "      , FCLTID " '初回登録ｸﾗｲｱﾝﾄID
		strSQL = strSQL & "      , WRTFSTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
		strSQL = strSQL & "      , WRTFSTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
		strSQL = strSQL & "      , OPEID " '最終作業者コード
		strSQL = strSQL & "      , CLTID " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      , UOPEID " 'ユーザID(ﾊﾞｯﾁ)
		strSQL = strSQL & "      , UCLTID " 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
		strSQL = strSQL & "      , UWRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , UWRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & " FROM UDNTHA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '伝票管理NO.
		strSQL = strSQL & "   AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '伝票削除区分
		strSQL = strSQL & " FOR UPDATE "

        ' DBアクセス
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        If DBSTAT <> 0 Then
			' データなしの場合
			F_UDNTHA_Exicz = 1
			GoTo F_UDNTHA_Exicz_end
			
		Else
            ' 更新前データと異なるデータが存在した場合はエラーとする。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190826 kuwa
            'If pin_strFOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or pin_strFCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or pin_strWRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or pin_strWRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or pin_strOPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or pin_strCLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or pin_strWRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or pin_strWRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or pin_strUOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or pin_strUCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or pin_strUWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or pin_strUWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
            If pin_strFOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or pin_strFCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or pin_strWRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or pin_strWRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or pin_strOPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or pin_strCLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or pin_strWRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or pin_strWRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or pin_strUOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or pin_strUCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or pin_strUWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or pin_strUWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                'change end 20190826 kuwa
                GoTo F_UDNTHA_Exicz_end
            End If
        End If
		
		F_UDNTHA_Exicz = 0
		
F_UDNTHA_Exicz_end:

        'クローズ
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/06/03 DLT END

        Exit Function
		
F_UDNTHA_Exicz_err: 
		GoTo F_UDNTHA_Exicz_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPUDNTRA_SEARCH
	'   概要：  売上トラン データ検索
	'   引数：  pin_strDATNO     : 売上伝票管理番号
	'           pot_DB_UDNTHA    : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPUDNTRA_SEARCH(ByVal pin_strDATNO As String, ByRef pot_DB_UDNTRA() As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim strCountSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
        '2019/06/03 ADD START
        Dim dt As DataTable
        '2019/06/03 ADD END

        On Error GoTo ERR_DSPUDNTRA_SEARCH
		
		DSPUDNTRA_SEARCH = 9
		
		'戻り値のクリア
		Erase pot_DB_UDNTRA
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM UDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_Sgl(pin_strDATNO) & "'"
		strSQL = strSQL & " ORDER BY LINNO "
		
		'件数カウントSQL
		strCountSQL = ""
		strCountSQL = strCountSQL & " SELECT COUNT(*) AS CNTDATA "
		strCountSQL = strCountSQL & " FROM ( " & strSQL & " ) "

        'DBアクセス
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strCountSQL)
        dt = DB_GetTable(strCountSQL)
        '2019/06/03 CHG END

        '件数取得
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/06/03 CHG START
        'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
        intData = CF_Get_CCurString(DB_NullReplace(dt.Rows(0)("CNTDATA"), 0))
        '2019/06/03 CHG END

        'クローズ
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 CHG END

        ReDim pot_DB_UDNTRA(intData)

        'DBアクセス
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        '取得データ退避
        intData = 1
        '2019/06/03 CHG START
        '      Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '	Call DB_UDNTRA_SetData(Usr_Ody_LC, pot_DB_UDNTRA(intData))

        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '	intData = intData + 1
        'Loop 
        For i As Integer = 0 To dt.Rows.Count - 1
            'change start 20190827 kuwa
            'Call DB_UDNTRA_SetData(dt, pot_DB_UDNTRA(intData))
            Call DB_UDNTRA_SetData(dt, pot_DB_UDNTRA(intData), i)
            'change end 20190827 kuwa
            intData = intData + 1
        Next
        '2019/06/03 CHG END

        DSPUDNTRA_SEARCH = 0
		
END_DSPUDNTRA_SEARCH:
        'クローズ
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 DLT END
        Exit Function
		
ERR_DSPUDNTRA_SEARCH: 
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_UDNTRA_SetData
    '   概要：  売上トラン データ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_UDNTRA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_UDNTRA As TYPE_DB_UDNTRA)
        'データ退避
        With pot_DB_UDNTRA
            '2019/06/03 CHF START
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DATNO = CF_Ora_GetDyn(pin_Usr_Ody, "DATNO", "") '伝票管理NO.
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.AKAKROKB = CF_Ora_GetDyn(pin_Usr_Ody, "AKAKROKB", "") '赤黒区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DENKB = CF_Ora_GetDyn(pin_Usr_Ody, "DENKB", "") '伝票区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "UDNNO", "") '売上伝票番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.LINNO = CF_Ora_GetDyn(pin_Usr_Ody, "LINNO", "") '行番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZKTKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZKTKB", "") '取引区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ODNNO = CF_Ora_GetDyn(pin_Usr_Ody, "ODNNO", "") '出荷伝票番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ODNLINNO = CF_Ora_GetDyn(pin_Usr_Ody, "ODNLINNO", "") '行番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.JDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "JDNNO", "") '受注番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.JDNLINNO = CF_Ora_GetDyn(pin_Usr_Ody, "JDNLINNO", "") '受注行番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.RECNO = CF_Ora_GetDyn(pin_Usr_Ody, "RECNO", "") 'レコード管理NO.
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.USDNO = CF_Ora_GetDyn(pin_Usr_Ody, "USDNO", "") '直送伝票NO
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UDNDT = CF_Ora_GetDyn(pin_Usr_Ody, "UDNDT", "") '売上伝票日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBSB = CF_Ora_GetDyn(pin_Usr_Ody, "DKBSB", "") '伝票取引区分種別
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBID = CF_Ora_GetDyn(pin_Usr_Ody, "DKBID", "") '取引区分コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBNM = CF_Ora_GetDyn(pin_Usr_Ody, "DKBNM", "") '取引区分名称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HENRSNCD = CF_Ora_GetDyn(pin_Usr_Ody, "HENRSNCD", "") '返品理由
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HENSTTCD = CF_Ora_GetDyn(pin_Usr_Ody, "HENSTTCD", "") '返品状態
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SMADT = CF_Ora_GetDyn(pin_Usr_Ody, "SMADT", "") '経理締日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SSADT = CF_Ora_GetDyn(pin_Usr_Ody, "SSADT", "") '締日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KESDT = CF_Ora_GetDyn(pin_Usr_Ody, "KESDT", "") '決済日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '得意先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANCD = CF_Ora_GetDyn(pin_Usr_Ody, "TANCD", "") '担当者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSCD = CF_Ora_GetDyn(pin_Usr_Ody, "NHSCD", "") '納入先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '請求先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SOUCD = CF_Ora_GetDyn(pin_Usr_Ody, "SOUCD", "") '倉庫コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SBNNO = CF_Ora_GetDyn(pin_Usr_Ody, "SBNNO", "") '製番
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINCD = CF_Ora_GetDyn(pin_Usr_Ody, "HINCD", "") '製品コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKJDNNO = CF_Ora_GetDyn(pin_Usr_Ody, "TOKJDNNO", "") '客先注文番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINNMA = CF_Ora_GetDyn(pin_Usr_Ody, "HINNMA", "") '型式
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINNMB = CF_Ora_GetDyn(pin_Usr_Ody, "HINNMB", "") '商品名１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UNTCD = CF_Ora_GetDyn(pin_Usr_Ody, "UNTCD", "") '単位コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UNTNM = CF_Ora_GetDyn(pin_Usr_Ody, "UNTNM", "") '単位名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.IRISU = CF_Ora_GetDyn(pin_Usr_Ody, "IRISU", 0) '入数
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CASSU = CF_Ora_GetDyn(pin_Usr_Ody, "CASSU", 0) 'ケース数
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.URISU = CF_Ora_GetDyn(pin_Usr_Ody, "URISU", 0) '売上数量
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.URITK = CF_Ora_GetDyn(pin_Usr_Ody, "URITK", 0) '単価
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.GNKTK = CF_Ora_GetDyn(pin_Usr_Ody, "GNKTK", 0) '原価単価
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIKTK = CF_Ora_GetDyn(pin_Usr_Ody, "SIKTK", 0) '営業仕切単価
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FURITK = CF_Ora_GetDyn(pin_Usr_Ody, "FURITK", 0) '外貨単価
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.URIKN = CF_Ora_GetDyn(pin_Usr_Ody, "URIKN", 0) '売上金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "FURIKN", 0) '外貨売上金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIKKN = CF_Ora_GetDyn(pin_Usr_Ody, "SIKKN", 0) '営業仕切金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UZEKN = CF_Ora_GetDyn(pin_Usr_Ody, "UZEKN", 0) '消費税金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NYUDT = CF_Ora_GetDyn(pin_Usr_Ody, "NYUDT", "") '入金日
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKN", 0) '入金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FNYUKN = CF_Ora_GetDyn(pin_Usr_Ody, "FNYUKN", 0) '外貨入金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.GNKKN = CF_Ora_GetDyn(pin_Usr_Ody, "GNKKN", 0) '原価金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.JKESIKN = CF_Ora_GetDyn(pin_Usr_Ody, "JKESIKN", 0) '消込金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FKESIKN = CF_Ora_GetDyn(pin_Usr_Ody, "FKESIKN", 0) '外貨消込金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KESIKB = CF_Ora_GetDyn(pin_Usr_Ody, "KESIKB", "") '消込区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NYUKB = CF_Ora_GetDyn(pin_Usr_Ody, "NYUKB", "") '入金種別
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TNKID = CF_Ora_GetDyn(pin_Usr_Ody, "TNKID", "") '種別
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "TUKKB", "") '通貨区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.RATERT = CF_Ora_GetDyn(pin_Usr_Ody, "RATERT", 0) '為替レート
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EMGODNKB = CF_Ora_GetDyn(pin_Usr_Ody, "EMGODNKB", "") '緊急出荷区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OKRJONO = CF_Ora_GetDyn(pin_Usr_Ody, "OKRJONO", "") '送り状№
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.INVNO = CF_Ora_GetDyn(pin_Usr_Ody, "INVNO", "") 'インボイス№
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.LINCMA = CF_Ora_GetDyn(pin_Usr_Ody, "LINCMA", "") '明細備考１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.LINCMB = CF_Ora_GetDyn(pin_Usr_Ody, "LINCMB", "") '明細備考２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BNKCD = CF_Ora_GetDyn(pin_Usr_Ody, "BNKCD", "") '銀行コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BNKNM = CF_Ora_GetDyn(pin_Usr_Ody, "BNKNM", "") '銀行名称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TEGNO = CF_Ora_GetDyn(pin_Usr_Ody, "TEGNO", "") '手形番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TEGDT = CF_Ora_GetDyn(pin_Usr_Ody, "TEGDT", "") '手形期日
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UPDID = CF_Ora_GetDyn(pin_Usr_Ody, "UPDID", "") '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DFLDKBCD = CF_Ora_GetDyn(pin_Usr_Ody, "DFLDKBCD", "") 'デフォルトコード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBZAIFL = CF_Ora_GetDyn(pin_Usr_Ody, "DKBZAIFL", "") '在庫関連フラグ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBTEGFL = CF_Ora_GetDyn(pin_Usr_Ody, "DKBTEGFL", "") '手形発生フラグ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBFLA = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLA", "") 'ダミーフラグ１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBFLB = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLB", "") 'ダミーフラグ２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBFLC = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLC", "") 'ダミーフラグ３
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.LSTID = CF_Ora_GetDyn(pin_Usr_Ody, "LSTID", "") '伝票種別
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINZEIKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINZEIKB", "") '商品消費税区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINMSTKB", "") 'マスタ区分(商品)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMSTKB", "") 'マスタ区分(得意先)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NHSMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "NHSMSTKB", "") 'マスタ区分(納入先)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TANMSTKB", "") 'マスタ区分(担当者)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZEIRNKKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZEIRNKKB", "") '消費税ランク
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINKB", "") '商品区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZEIRT = CF_Ora_GetDyn(pin_Usr_Ody, "ZEIRT", 0) '消費税率
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZAIKB = CF_Ora_GetDyn(pin_Usr_Ody, "ZAIKB", "") '在庫管理区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MRPKB = CF_Ora_GetDyn(pin_Usr_Ody, "MRPKB", "") '展開区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINJUNKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINJUNKB", "") '順位表出力区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MAKCD = CF_Ora_GetDyn(pin_Usr_Ody, "MAKCD", "") 'メーカーコード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINSIRCD = CF_Ora_GetDyn(pin_Usr_Ody, "HINSIRCD", "") '商品仕入先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HINNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "HINNMMKB", "") '名称ﾏﾆｭｱﾙ区分（商）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HRTDD = CF_Ora_GetDyn(pin_Usr_Ody, "HRTDD", "") '発注リードタイム
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ORTDD = CF_Ora_GetDyn(pin_Usr_Ody, "ORTDD", "") '出荷リードタイム
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZNKURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "ZNKURIKN", 0) '税抜課税対象額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZKMURIKN = CF_Ora_GetDyn(pin_Usr_Ody, "ZKMURIKN", 0) '税込課税対象額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ZKMUZEKN = CF_Ora_GetDyn(pin_Usr_Ody, "ZKMUZEKN", 0) '税込消費税
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MOTDATNO = CF_Ora_GetDyn(pin_Usr_Ody, "MOTDATNO", "") '元伝票管理番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '初回登録ﾕｰｻﾞｰID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '初回登録ｸﾗｲｱﾝﾄID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '最終作業者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") 'クライアントＩＤ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") 'ユーザID(ﾊﾞｯﾁ)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") 'プログラムID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DLFLG = CF_Ora_GetDyn(pin_Usr_Ody, "DLFLG", "") '削除フラグ

            .DATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATNO"), "") '伝票管理NO.
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '伝票削除区分
            .AKAKROKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("AKAKROKB"), "") '赤黒区分
            .DENKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DENKB"), "") '伝票区分
            .UDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNNO"), "") '売上伝票番号
            .LINNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("LINNO"), "") '行番号	
            .ZKTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKTKB"), "") '取引区分
            .ODNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("ODNNO"), "") '出荷伝票番号
            .ODNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("ODNLINNO"), "") '行番号
            .JDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNNO"), "") '受注番号
            .JDNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("JDNLINNO"), "") '受注行番号
            .RECNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("RECNO"), "") 'レコード管理NO.
            .USDNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("USDNO"), "") '直送伝票NO
            .UDNDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UDNDT"), "") '売上伝票日付
            .DKBSB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBSB"), "") '伝票取引区分種別
            .DKBID = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBID"), "") '取引区分コード
            .DKBNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBNM"), "") '取引区分名称
            .HENRSNCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HENRSNCD"), "") '返品理由
            .HENSTTCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HENSTTCD"), "") '返品状態
            .SMADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMADT"), "") '経理締日付
            .SSADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSADT"), "") '締日付
            .KESDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("KESDT"), "") '決済日付
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCD"), "") '得意先コード
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANCD"), "") '担当者コード
            .NHSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSCD"), "") '納入先コード
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSEICD"), "") '請求先コード
            .SOUCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("SOUCD"), "") '倉庫コード
            .SBNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("SBNNO"), "") '製番
            .HINCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINCD"), "") '製品コード
            .TOKJDNNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKJDNNO"), "") '客先注文番号
            .HINNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINNMA"), "") '型式
            .HINNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINNMB"), "") '商品名１
            .UNTCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("UNTCD"), "") '単位コード
            .UNTNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UNTNM"), "") '単位名
            .IRISU = DB_NullReplace(pin_Usr_Ody.Rows(0)("IRISU"), "0") '入数
            .CASSU = DB_NullReplace(pin_Usr_Ody.Rows(0)("CASSU"), "0") 'ケース数
            .URISU = DB_NullReplace(pin_Usr_Ody.Rows(0)("URISU"), "0") '売上数量
            .URITK = DB_NullReplace(pin_Usr_Ody.Rows(0)("URITK"), "0") '単価
            .GNKTK = DB_NullReplace(pin_Usr_Ody.Rows(0)("GNKTK"), "0") '原価単価
            .SIKTK = DB_NullReplace(pin_Usr_Ody.Rows(0)("SIKTK"), "0") '営業仕切単価
            .FURITK = DB_NullReplace(pin_Usr_Ody.Rows(0)("FURITK"), "0") '外貨単価
            .URIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("URIKN"), "0") '売上金額
            .FURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("FURIKN"), "0") '外貨売上金額
            .SIKKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SIKKN"), "0") '営業仕切金額
            .UZEKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("UZEKN"), "0") '消費税金額
            .NYUDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUDT"), "") '入金日
            .NYUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUKN"), "0") '入金額
            .FNYUKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("FNYUKN"), "0") '外貨入金額
            .GNKKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("GNKKN"), "0") '原価金額
            .JKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("JKESIKN"), "0") '消込金額
            .FKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("FKESIKN"), "0") '外貨消込金額
            .KESIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("KESIKB"), "") '消込区分
            .NYUKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUKB"), "") '入金種別
            .TNKID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TNKID"), "") '種別
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TUKKB"), "") '通貨区分
            .RATERT = DB_NullReplace(pin_Usr_Ody.Rows(0)("RATERT"), "0") '為替レート
            .EMGODNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EMGODNKB"), "") '緊急出荷区分
            .OKRJONO = DB_NullReplace(pin_Usr_Ody.Rows(0)("OKRJONO"), "") '送り状№
            .INVNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("INVNO"), "") 'インボイス№
            .LINCMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("LINCMA"), "") '明細備考１
            .LINCMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("LINCMB"), "") '明細備考２
            .BNKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BNKCD"), "") '銀行コード
            .BNKNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("BNKNM"), "") '銀行名称
            .TEGNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGNO"), "") '手形番号
            .TEGDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGDT"), "") '手形期日
            .UPDID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UPDID"), "") '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
            .DFLDKBCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("DFLDKBCD"), "") 'デフォルトコード
            .DKBZAIFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBZAIFL"), "") '在庫関連フラグ
            .DKBTEGFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBTEGFL"), "") '手形発生フラグ
            .DKBFLA = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBFLA"), "") 'ダミーフラグ１
            .DKBFLB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBFLB"), "") 'ダミーフラグ２
            .DKBFLC = DB_NullReplace(pin_Usr_Ody.Rows(0)("DKBFLC"), "") 'ダミーフラグ３
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("LSTID"), "") '伝票種別
            .HINZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINZEIKB"), "") '商品消費税区分
            .HINMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINMSTKB"), "") 'マスタ区分(商品)
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMSTKB"), "") 'マスタ区分(得意先)
            .NHSMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("NHSMSTKB"), "") 'マスタ区分(納入先)
            .TANMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANMSTKB"), "") 'マスタ区分(担当者)
            .ZEIRNKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZEIRNKKB"), "") '消費税ランク
            .HINKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINKB"), "") '商品区分
            .ZEIRT = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZEIRT"), "0") '消費税率
            .ZAIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZAIKB"), "") '在庫管理区分
            .MRPKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MRPKB"), "") '展開区分
            .HINJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINJUNKB"), "") '順位表出力区分
            .MAKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAKCD"), "") 'メーカーコード
            .HINSIRCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINSIRCD"), "") '商品仕入先コード
            .HINNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HINNMMKB"), "") '名称ﾏﾆｭｱﾙ区分（商）
            .HRTDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("HRTDD"), "") '発注リードタイム
            .ORTDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("ORTDD"), "") '出荷リードタイム
            .ZNKURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZNKURIKN"), "0") '税抜課税対象額
            .ZKMURIKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKMURIKN"), "0") '税込課税対象額
            .ZKMUZEKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("ZKMUZEKN"), "0") '税込消費税
            .MOTDATNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("MOTDATNO"), "") '元伝票管理番号
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FOPEID"), "") '初回登録ﾕｰｻﾞｰID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCLTID"), "") '初回登録ｸﾗｲｱﾝﾄID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '最終作業者コード
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") 'クライアントＩＤ
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UOPEID"), "") 'ユーザID(ﾊﾞｯﾁ)
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UCLTID"), "") 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(0)("PGID"), "") 'プログラムID
            .DLFLG = DB_NullReplace(pin_Usr_Ody.Rows(0)("DLFLG"), "") '削除フラグ
            '2019/06/03 CHG END

        End With
    End Sub

    'add start 20190827 kuwa
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_UDNTRA_SetData
    '   概要：  売上トラン データ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_UDNTRA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_UDNTRA As TYPE_DB_UDNTRA, Optional ByRef i As Integer = 0)
        'データ退避
        With pot_DB_UDNTRA
            .DATNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("DATNO"), "") '伝票管理NO.
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DATKB"), "") '伝票削除区分
            .AKAKROKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("AKAKROKB"), "") '赤黒区分
            .DENKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DENKB"), "") '伝票区分
            .UDNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("UDNNO"), "") '売上伝票番号
            .LINNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("LINNO"), "") '行番号	
            .ZKTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZKTKB"), "") '取引区分
            .ODNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("ODNNO"), "") '出荷伝票番号
            .ODNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("ODNLINNO"), "") '行番号
            .JDNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("JDNNO"), "") '受注番号
            .JDNLINNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("JDNLINNO"), "") '受注行番号
            .RECNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("RECNO"), "") 'レコード管理NO.
            .USDNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("USDNO"), "") '直送伝票NO
            .UDNDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("UDNDT"), "") '売上伝票日付
            .DKBSB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBSB"), "") '伝票取引区分種別
            .DKBID = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBID"), "") '取引区分コード
            .DKBNM = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBNM"), "") '取引区分名称
            .HENRSNCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HENRSNCD"), "") '返品理由
            .HENSTTCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HENSTTCD"), "") '返品状態
            .SMADT = DB_NullReplace(pin_Usr_Ody.Rows(i)("SMADT"), "") '経理締日付
            .SSADT = DB_NullReplace(pin_Usr_Ody.Rows(i)("SSADT"), "") '締日付
            .KESDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("KESDT"), "") '決済日付
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKCD"), "") '得意先コード
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("TANCD"), "") '担当者コード
            .NHSCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("NHSCD"), "") '納入先コード
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKSEICD"), "") '請求先コード
            .SOUCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("SOUCD"), "") '倉庫コード
            .SBNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("SBNNO"), "") '製番
            .HINCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINCD"), "") '製品コード
            .TOKJDNNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKJDNNO"), "") '客先注文番号
            .HINNMA = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINNMA"), "") '型式
            .HINNMB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINNMB"), "") '商品名１
            .UNTCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("UNTCD"), "") '単位コード
            .UNTNM = DB_NullReplace(pin_Usr_Ody.Rows(i)("UNTNM"), "") '単位名
            .IRISU = DB_NullReplace(pin_Usr_Ody.Rows(i)("IRISU"), "0") '入数
            .CASSU = DB_NullReplace(pin_Usr_Ody.Rows(i)("CASSU"), "0") 'ケース数
            .URISU = DB_NullReplace(pin_Usr_Ody.Rows(i)("URISU"), "0") '売上数量
            .URITK = DB_NullReplace(pin_Usr_Ody.Rows(i)("URITK"), "0") '単価
            .GNKTK = DB_NullReplace(pin_Usr_Ody.Rows(i)("GNKTK"), "0") '原価単価
            .SIKTK = DB_NullReplace(pin_Usr_Ody.Rows(i)("SIKTK"), "0") '営業仕切単価
            .FURITK = DB_NullReplace(pin_Usr_Ody.Rows(i)("FURITK"), "0") '外貨単価
            .URIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("URIKN"), "0") '売上金額
            .FURIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("FURIKN"), "0") '外貨売上金額
            .SIKKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("SIKKN"), "0") '営業仕切金額
            .UZEKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("UZEKN"), "0") '消費税金額
            .NYUDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("NYUDT"), "") '入金日
            .NYUKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("NYUKN"), "0") '入金額
            .FNYUKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("FNYUKN"), "0") '外貨入金額
            .GNKKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("GNKKN"), "0") '原価金額
            .JKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("JKESIKN"), "0") '消込金額
            .FKESIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("FKESIKN"), "0") '外貨消込金額
            .KESIKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("KESIKB"), "") '消込区分
            .NYUKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("NYUKB"), "") '入金種別
            .TNKID = DB_NullReplace(pin_Usr_Ody.Rows(i)("TNKID"), "") '種別
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("TUKKB"), "") '通貨区分
            .RATERT = DB_NullReplace(pin_Usr_Ody.Rows(i)("RATERT"), "0") '為替レート
            .EMGODNKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("EMGODNKB"), "") '緊急出荷区分
            .OKRJONO = DB_NullReplace(pin_Usr_Ody.Rows(i)("OKRJONO"), "") '送り状№
            .INVNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("INVNO"), "") 'インボイス№
            .LINCMA = DB_NullReplace(pin_Usr_Ody.Rows(i)("LINCMA"), "") '明細備考１
            .LINCMB = DB_NullReplace(pin_Usr_Ody.Rows(i)("LINCMB"), "") '明細備考２
            .BNKCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("BNKCD"), "") '銀行コード
            .BNKNM = DB_NullReplace(pin_Usr_Ody.Rows(i)("BNKNM"), "") '銀行名称
            .TEGNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("TEGNO"), "") '手形番号
            .TEGDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("TEGDT"), "") '手形期日
            .UPDID = DB_NullReplace(pin_Usr_Ody.Rows(i)("UPDID"), "") '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
            .DFLDKBCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("DFLDKBCD"), "") 'デフォルトコード
            .DKBZAIFL = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBZAIFL"), "") '在庫関連フラグ
            .DKBTEGFL = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBTEGFL"), "") '手形発生フラグ
            .DKBFLA = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBFLA"), "") 'ダミーフラグ１
            .DKBFLB = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBFLB"), "") 'ダミーフラグ２
            .DKBFLC = DB_NullReplace(pin_Usr_Ody.Rows(i)("DKBFLC"), "") 'ダミーフラグ３
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("LSTID"), "") '伝票種別
            .HINZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINZEIKB"), "") '商品消費税区分
            .HINMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINMSTKB"), "") 'マスタ区分(商品)
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("TOKMSTKB"), "") 'マスタ区分(得意先)
            .NHSMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("NHSMSTKB"), "") 'マスタ区分(納入先)
            .TANMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("TANMSTKB"), "") 'マスタ区分(担当者)
            .ZEIRNKKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZEIRNKKB"), "") '消費税ランク
            .HINKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINKB"), "") '商品区分
            .ZEIRT = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZEIRT"), "0") '消費税率
            .ZAIKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZAIKB"), "") '在庫管理区分
            .MRPKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("MRPKB"), "") '展開区分
            .HINJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINJUNKB"), "") '順位表出力区分
            .MAKCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("MAKCD"), "") 'メーカーコード
            .HINSIRCD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINSIRCD"), "") '商品仕入先コード
            .HINNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(i)("HINNMMKB"), "") '名称ﾏﾆｭｱﾙ区分（商）
            .HRTDD = DB_NullReplace(pin_Usr_Ody.Rows(i)("HRTDD"), "") '発注リードタイム
            .ORTDD = DB_NullReplace(pin_Usr_Ody.Rows(i)("ORTDD"), "") '出荷リードタイム
            .ZNKURIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZNKURIKN"), "0") '税抜課税対象額
            .ZKMURIKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZKMURIKN"), "0") '税込課税対象額
            .ZKMUZEKN = DB_NullReplace(pin_Usr_Ody.Rows(i)("ZKMUZEKN"), "0") '税込消費税
            .MOTDATNO = DB_NullReplace(pin_Usr_Ody.Rows(i)("MOTDATNO"), "") '元伝票管理番号
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(i)("FOPEID"), "") '初回登録ﾕｰｻﾞｰID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("FCLTID"), "") '初回登録ｸﾗｲｱﾝﾄID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(i)("OPEID"), "") '最終作業者コード
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("CLTID"), "") 'クライアントＩＤ
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(i)("UOPEID"), "") 'ユーザID(ﾊﾞｯﾁ)
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(i)("UCLTID"), "") 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(i)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(i)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(i)("PGID"), "") 'プログラムID
            .DLFLG = DB_NullReplace(pin_Usr_Ody.Rows(i)("DLFLG"), "") '削除フラグ
            '2019/06/03 CHG END

        End With
    End Sub
    'add end 20190827 kuwa



    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_UDNTRA_Exicz
    '   概要：  売上トラン排他制御
    '   引数：  pin_strDATNO     ：伝票管理NO.
    '           pin_intLINNO     ：行番号
    '           pin_strFOPEID    ：初回登録ﾕｰｻﾞｰID
    '           pin_strFCLTID    ：初回登録ｸﾗｲｱﾝﾄID
    '           pin_strWRTFSTTM  ：ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
    '           pin_strWRTFSTDT  ：ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
    '           pin_strOPEID     ：最終作業者コード
    '           pin_strCLTID     ：クライアントＩＤ
    '           pin_strWRTTM     ：ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '           pin_strWRTDT     ：ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '           pin_strUOPEID    ：ユーザID(ﾊﾞｯﾁ)
    '           pin_strUCLTID    ：ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
    '           pin_strUWRTTM    ：ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '           pin_strUWRTDT    ：ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '   戻値：  0:正常   1:データ無し  9:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_UDNTRA_Exicz(ByVal pin_strDATNO As String, ByVal pin_intLINNO As Short, ByVal pin_strFOPEID As String, ByVal pin_strFCLTID As String, ByVal pin_strWRTFSTTM As String, ByVal pin_strWRTFSTDT As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strUWRTTM As String, ByVal pin_strUWRTDT As String) As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo F_UDNTRA_Exicz_err
		
		F_UDNTRA_Exicz = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " SELECT FOPEID " '初回登録ﾕｰｻﾞｰID
		strSQL = strSQL & "      , FCLTID " '初回登録ｸﾗｲｱﾝﾄID
		strSQL = strSQL & "      , WRTFSTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
		strSQL = strSQL & "      , WRTFSTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)
		strSQL = strSQL & "      , OPEID " '最終作業者コード
		strSQL = strSQL & "      , CLTID " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      , UOPEID " 'ユーザID(ﾊﾞｯﾁ)
		strSQL = strSQL & "      , UCLTID " 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
		strSQL = strSQL & "      , UWRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , UWRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & " FROM UDNTRA "
		strSQL = strSQL & " WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '伝票管理NO.
		strSQL = strSQL & "   AND LINNO = '" & VB6.Format(pin_intLINNO, "000") & "' " '行番号
		strSQL = strSQL & "   AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '伝票削除区分
		strSQL = strSQL & " FOR UPDATE "

        ' DBアクセス
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        If DBSTAT <> 0 Then
			' データなしの場合
			F_UDNTRA_Exicz = 1
			GoTo F_UDNTRA_Exicz_end
			
		Else
            ' 更新前データと異なるデータが存在した場合はエラーとする。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190826 kuwa
            'If pin_strFOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or pin_strFCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or pin_strWRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or pin_strWRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or pin_strOPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or pin_strCLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or pin_strWRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or pin_strWRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or pin_strUOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or pin_strUCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or pin_strUWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or pin_strUWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
            If pin_strFOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or pin_strFCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or pin_strWRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or pin_strWRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or pin_strOPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or pin_strCLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or pin_strWRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or pin_strWRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or pin_strUOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or pin_strUCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or pin_strUWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or pin_strUWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                'change end 20190826 kuwa
                GoTo F_UDNTRA_Exicz_end
            End If
        End If
		
		F_UDNTRA_Exicz = 0
		
F_UDNTRA_Exicz_end:

        'クローズ
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/06/03 DLT END

        Exit Function
		
F_UDNTRA_Exicz_err: 
		GoTo F_UDNTRA_Exicz_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMEIMTA_SEARCH_SORTUSE
	'   概要：  名称マスタ検索
	'   引数：  pin_strKEYCD  : キー１
	'           pot_DB_MEIMTA : 検索結果（配列）
	'           pin_strSORT   : ソートSQL文字列
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPMEIMTA_SEARCH_SORTUSE(ByVal pin_strKEYCD As String, ByRef pot_DB_MEIMTA() As TYPE_DB_MEIMTA, ByVal pin_strSORT As String) As Short
		
		Dim strSQL As String
		Dim strSQL_Where As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
        '2019/06/03 ADD START
        Dim dt As DataTable
        '2019/06/03 ADD END

        On Error GoTo ERR_DSPMEIMTA_SEARCH_SORTUSE
		
		DSPMEIMTA_SEARCH_SORTUSE = 9
		
		'戻り値のクリア
		Erase pot_DB_MEIMTA
		
		strSQL = ""
		strSQL = strSQL & " Select Count(*) As CNTDATA"
		
		strSQL_Where = ""
		strSQL_Where = strSQL_Where & "   from MEIMTA "
		strSQL_Where = strSQL_Where & "  Where KEYCD  = '" & pin_strKEYCD & "' "
		
		strSQL = strSQL & strSQL_Where

        'DBアクセス
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        '件数取得
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/06/04 CHG START
        'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
        intData = CF_Get_CCurString(DB_NullReplace(dt.Rows(0)("CNTDATA"), 0))
        '2019/06/04 CHG END

        'クローズ
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 DLT END

        '検索
        strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & strSQL_Where
		
		'並び順
		If Trim(pin_strSORT) <> "" Then
			strSQL = strSQL & "  Order By " & pin_strSORT
		End If
		
		ReDim pot_DB_MEIMTA(intData)

        'DBアクセス
        '2019/06/03 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/06/03 CHG END

        '取得データ退避
        '2019/06/03 CHG START
        intData = 1
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '	Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))

        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '	intData = intData + 1
        'Loop 

        For i As Integer = 0 To dt.Rows.Count - 1
            'change 20190729 START hou
            'Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData))
            Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData), intData)
            'change 20190729 END hou
            intData = intData + 1
        Next
        '2019/06/03 CHG END

        DSPMEIMTA_SEARCH_SORTUSE = 0
		
END_DSPMEIMTA_SEARCH_SORTUSE:
        'クローズ
        '2019/06/03 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/03 DLT END

        Exit Function
		
ERR_DSPMEIMTA_SEARCH_SORTUSE: 
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_MEIMTA_SetData
    '   概要：  名称マスタ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, ByRef intData As Integer)
        'データ退避
        With pot_DB_MEIMTA
            '2019/06/04 CHG START
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KEYCD = CF_Ora_GetDyn(pin_Usr_Ody, "KEYCD", "") 'キー
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEIKMKNM = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKMKNM", "") '項目名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEICDA = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDA", "") 'コード１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEICDB = CF_Ora_GetDyn(pin_Usr_Ody, "MEICDB", "") 'コード２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEINMA = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMA", "") '名称１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEINMB = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMB", "") '名称２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEINMC = CF_Ora_GetDyn(pin_Usr_Ody, "MEINMC", "") '名称３
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEISUA = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUA", 0) '数値項目１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEISUB = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUB", 0) '数値項目２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEISUC = CF_Ora_GetDyn(pin_Usr_Ody, "MEISUC", 0) '数値項目３
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEIKBA = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBA", "") '区分１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEIKBB = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBB", "") '区分２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MEIKBC = CF_Ora_GetDyn(pin_Usr_Ody, "MEIKBC", "") '区分３
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DSPORD = CF_Ora_GetDyn(pin_Usr_Ody, "DSPORD", "") '表示順序
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "") '連携フラグ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "FOPEID", "") '初回登録担当者ID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "FCLTID", "") '初回登録クライアントID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '更新担当者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") '更新クライアントＩＤ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UOPEID = CF_Ora_GetDyn(pin_Usr_Ody, "UOPEID", "") 'バッチ更新担当者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UCLTID = CF_Ora_GetDyn(pin_Usr_Ody, "UCLTID", "") 'バッチ更新クライアントID
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UWRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UWRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "UWRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.PGID = CF_Ora_GetDyn(pin_Usr_Ody, "PGID", "") 'ﾌﾟﾛｸﾞﾗﾑID

            'change 20190729 START hou
            '.DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '伝票削除区分
            '.KEYCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KEYCD"), "") 'キー
            '.MEIKMKNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKMKNM"), "") '項目名
            '.MEICDA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEICDA"), "") 'コード１
            '.MEICDB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEICDB"), "") 'コード２
            '.MEINMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEINMA"), "") '名称１
            '.MEINMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEINMB"), "") '名称２
            '.MEINMC = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEINMC"), "") '名称３
            '.MEISUA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEISUA"), "0") '数値項目１
            '.MEISUB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEISUB"), "0") '数値項目２
            '.MEISUC = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEISUC"), "0") '数値項目３
            '.MEIKBA = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKBA"), "") '区分１
            '.MEIKBB = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKBB"), "") '区分２
            '.MEIKBC = DB_NullReplace(pin_Usr_Ody.Rows(0)("MEIKBC"), "") '区分３
            '.DSPORD = DB_NullReplace(pin_Usr_Ody.Rows(0)("DSPORD"), "") '表示順序
            '.RELFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("RELFL"), "") '連携フラグ
            '.FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FOPEID"), "") '初回登録担当者ID
            '.FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCLTID"), "") '初回登録クライアントID
            '.WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
            '.WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
            '.OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '更新担当者コード
            '.CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") '更新クライアントＩＤ
            '.WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
            '.WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
            '.UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UOPEID"), "") 'バッチ更新担当者コード
            '.UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("UCLTID"), "") 'バッチ更新クライアントID
            '.UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
            '.UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
            '.PGID = DB_NullReplace(pin_Usr_Ody.Rows(0)("PGID"), "") 'ﾌﾟﾛｸﾞﾗﾑID
            '2019/06/04 CHG END
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("DATKB"), "") '伝票削除区分
            .KEYCD = DB_NullReplace(pin_Usr_Ody.Rows(intData)("KEYCD"), "") 'キー
            .MEIKMKNM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKMKNM"), "") '項目名
            .MEICDA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEICDA"), "") 'コード１
            .MEICDB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEICDB"), "") 'コード２
            .MEINMA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEINMA"), "") '名称１
            .MEINMB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEINMB"), "") '名称２
            .MEINMC = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEINMC"), "") '名称３
            .MEISUA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEISUA"), "0") '数値項目１
            .MEISUB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEISUB"), "0") '数値項目２
            .MEISUC = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEISUC"), "0") '数値項目３
            .MEIKBA = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKBA"), "") '区分１
            .MEIKBB = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKBB"), "") '区分２
            .MEIKBC = DB_NullReplace(pin_Usr_Ody.Rows(intData)("MEIKBC"), "") '区分３
            .DSPORD = DB_NullReplace(pin_Usr_Ody.Rows(intData)("DSPORD"), "") '表示順序
            .RELFL = DB_NullReplace(pin_Usr_Ody.Rows(intData)("RELFL"), "") '連携フラグ
            .FOPEID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("FOPEID"), "") '初回登録担当者ID
            .FCLTID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("FCLTID"), "") '初回登録クライアントID
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTFSTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録時間)
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTFSTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(初回登録日付)
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("OPEID"), "") '更新担当者コード
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("CLTID"), "") '更新クライアントＩＤ
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新時間)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(intData)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(更新日付)
            .UOPEID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UOPEID"), "") 'バッチ更新担当者コード
            .UCLTID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UCLTID"), "") 'バッチ更新クライアントID
            .UWRTTM = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UWRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新時間)
            .UWRTDT = DB_NullReplace(pin_Usr_Ody.Rows(intData)("UWRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(バッチ更新日付)
            .PGID = DB_NullReplace(pin_Usr_Ody.Rows(intData)("PGID"), "") 'ﾌﾟﾛｸﾞﾗﾑID
            'change 20190729 END hou
        End With
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_SYSTBD_Clear
    '   概要：  システムメッセージテーブル構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Sub DB_SYSTBD_Clear(ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD)
		
		Dim Clr_DB_SYSTBD As TYPE_DB_SYSTBD
		
		'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_DB_SYSTBD = Clr_DB_SYSTBD
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SYSTBD_SEARCH
	'   概要：  取引区分テーブル検索
	'   引数：  pin_strDKBSB    : 伝票取引区分種別
	'           pin_strDKBID    : 取引区分コード
	'           pot_DB_SYSTBD   : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SYSTBD_SEARCH(ByVal Pin_strDKBSB As String, ByVal pin_strDKBID As String, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_SYSTBD_SEARCH
		
		SYSTBD_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(Pin_strDKBSB) & "' "
		strSQL = strSQL & "    And DKBID = '" & CF_Ora_Sgl(pin_strDKBID) & "' "

        'DBアクセス
        '2019/06/04 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/06/04 CHG END
            '取得データなし
            SYSTBD_SEARCH = 1
            GoTo END_SYSTBD_SEARCH
        End If
        '2019/06/04 CHG START
        '      If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '	Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD)
        'End If
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD, 0)
        End If
        '2019/06/04 CHG END

        SYSTBD_SEARCH = 0
		
END_SYSTBD_SEARCH:

        'クローズ
        '2019/06/04 CHG START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/04 CHG END

        Exit Function
		
ERR_SYSTBD_SEARCH: 
		GoTo END_SYSTBD_SEARCH
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SYSTBD_SEARCH_ALL
	'   概要：  取引区分テーブル検索
	'   引数：  pin_strDKBSB    : 伝票取引区分種別
	'           pot_DB_SYSTBD   : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SYSTBD_SEARCH_ALL(ByVal Pin_strDKBSB As String, ByRef pot_DB_SYSTBD() As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
        Dim intIdx As Short
        '2019/06/04 CHG START
        Dim dt As DataTable
        '2019/06/04 CHG END
        On Error GoTo ERR_SYSTBD_SEARCH_ALL
		
		SYSTBD_SEARCH_ALL = 9
		
		strSQL = ""
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(Pin_strDKBSB) & "' "
		strSQL = strSQL & " order by DKBID "
		
		'件数取得
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL

        'DBアクセス
        '2019/06/04 CHG START
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)

        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)
        dt = DB_GetTable(strSQLCount)
        intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
        '2019/06/04 CHG END

        'クローズ
        '2019/06/04 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/04 DLT END

        If intData = 0 Then
			'取得データなし
			SYSTBD_SEARCH_ALL = 1
			Exit Function
		End If
		
		strSQL = " Select * " & strSQL

        'DBアクセス
        '2019/06/04 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/06/04 CHG END
            '取得データなし
            SYSTBD_SEARCH_ALL = 1
            GoTo END_SYSTBD_SEARCH_ALL
        End If

        '取得データ退避
        ReDim pot_DB_SYSTBD(intData)
        '2019/06/04 CHG START
        'intIdx = 1
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        '	Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD(intIdx))
        '	intIdx = intIdx + 1
        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        'Loop 
        For i As Integer = 0 To dt.Rows.Count - 1
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD(i), i)
        Next
        '2019/06/04 CHG END

        SYSTBD_SEARCH_ALL = 0
		
END_SYSTBD_SEARCH_ALL:

        'クローズ
        '2019/06/04 DLT START
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/06/04 DLT END
        Exit Function
		
ERR_SYSTBD_SEARCH_ALL: 
		GoTo END_SYSTBD_SEARCH_ALL
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_SYSTBD_SetData
    '   概要：  取引区分テーブル構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD)
    Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD, ByVal DataCount As Integer)

        'データ退避
        With pot_DB_SYSTBD
            ''2019/06/04 CHG START
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBSB = CF_Ora_GetDyn(pin_Usr_Ody, "DKBSB", "") '伝票取引区分種別
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBID = CF_Ora_GetDyn(pin_Usr_Ody, "DKBID", "") '取引区分コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBNM = CF_Ora_GetDyn(pin_Usr_Ody, "DKBNM", "") '取引区分名称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.UPDID = CF_Ora_GetDyn(pin_Usr_Ody, "UPDID", "") '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DFLDKBCD = CF_Ora_GetDyn(pin_Usr_Ody, "DFLDKBCD", "") 'デフォルトコード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBZAIFL = CF_Ora_GetDyn(pin_Usr_Ody, "DKBZAIFL", "") '在庫関連フラグ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBTEGFL = CF_Ora_GetDyn(pin_Usr_Ody, "DKBTEGFL", "") '手形発生フラグ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBFLA = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLA", "") 'ダミーフラグ１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBFLB = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLB", "") 'ダミーフラグ２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DKBFLC = CF_Ora_GetDyn(pin_Usr_Ody, "DKBFLC", "") 'ダミーフラグ３
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '最終作業者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") 'クライアントＩＤ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)

            .DKBSB = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBSB"), "") '伝票取引区分種別
            .DKBID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBID"), "") '取引区分コード
            .DKBNM = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBNM"), "") '取引区分名称
            .UPDID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("UPDID"), "") '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
            .DFLDKBCD = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DFLDKBCD"), "") 'デフォルトコード
            .DKBZAIFL = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBZAIFL"), "") '在庫関連フラグ
            .DKBTEGFL = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBTEGFL"), "") '手形発生フラグ
            .DKBFLA = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBFLA"), "") 'ダミーフラグ１
            .DKBFLB = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBFLB"), "") 'ダミーフラグ２
            .DKBFLC = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("DKBFLC"), "") 'ダミーフラグ３
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("OPEID"), "") '最終作業者コード
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("CLTID"), "") 'クライアントＩＤ
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("WRTTM"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(DataCount)("WRTDT"), "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            '2019/06/04 CHG END
        End With
    End Sub
End Module