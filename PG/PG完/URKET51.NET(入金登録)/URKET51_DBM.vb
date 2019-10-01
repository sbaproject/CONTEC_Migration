Option Strict Off
Option Explicit On
Module URKET51_DBM
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPTOKMTA_KOZNO_SEARCH
	'   概要：  得意先コード検索
	'   引数：　なし
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DSPTOKMTA_KOZNO_SEARCH(ByVal pin_strKOZNO As String, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody

        '2019/04/02 ADD START
        Dim dt As DataTable = New DataTable
        '2019/04/02 ADD E N D

		On Error GoTo ERR_DSPTOKMTA_KOZNO_SEARCH
		
		DSPTOKMTA_KOZNO_SEARCH = 9

        '2019/06/27 CHG START
        'Call DB_TOKMTA_Clear(pot_DB_TOKMTA)
        pot_DB_TOKMTA = New TYPE_DB_TOKMTA
        '2019/06/27 CHG E N D

        strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from TOKMTA "
		strSQL = strSQL & "  Where KOZNO = '" & pin_strKOZNO & "' "
		
        'DBアクセス
        '2019/04/02 CHG START
        'Call CF_Ora_CreateDynK(gv_Odb_USR1, Usr_Ody, strSQL)
        'If CF_Ora_EOF(Usr_Ody) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/02 CHG E N D

            '取得データなし
            DSPTOKMTA_KOZNO_SEARCH = 1
            GoTo END_DSPTOKMTA_KOZNO_SEARCH
        End If

        '2019/04/02 CHG START
        'If CF_Ora_EOF(Usr_Ody) = False Then
        'Call DB_TOKMTA_SetData(Usr_Ody, pot_DB_TOKMTA)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_TOKMTA_SetData(dt, pot_DB_TOKMTA)
            '2019/04/02 CHG E N D
        End If

        DSPTOKMTA_KOZNO_SEARCH = 0

END_DSPTOKMTA_KOZNO_SEARCH:
        '2019/04/10 DEL START
        ''クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/10 DEL E N D
        Exit Function

ERR_DSPTOKMTA_KOZNO_SEARCH:
        GoTo END_DSPTOKMTA_KOZNO_SEARCH
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_TOKMTA_SetData
    '   概要：  得意先マスタ構造体データ退避
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/08 CHG START
    'Private Sub DB_TOKMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA)
    Private Sub DB_TOKMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA)
        '2019/04/08 CHG E N D
        'データ退避
        With pot_DB_TOKMTA
            '2019/04/08 CHG START
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DATKB = CF_Ora_GetDyn(pin_Usr_Ody, "DATKB", "") '伝票削除区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKMSTKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMSTKB", "") 'マスタ区分（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.THSCD = CF_Ora_GetDyn(pin_Usr_Ody, "THSCD", "") '取引先分類
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCD", "") '得意先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKNMA = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMA", "") '得意先名称１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKNMB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMB", "") '得意先名称２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKRN = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRN", "") '得意先略称
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKNK = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNK", "") '得意先名称カナ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKNMC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMC", "") '得意先名称半角１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKNMD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMD", "") '得意先名称半角２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKRNNK = CF_Ora_GetDyn(pin_Usr_Ody, "TOKRNNK", "") '得意先略称カナ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKZP = CF_Ora_GetDyn(pin_Usr_Ody, "TOKZP", "") '得意先郵便番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKADA = CF_Ora_GetDyn(pin_Usr_Ody, "TOKADA", "") '得意先住所１
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKADB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKADB", "") '得意先住所２
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKADC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKADC", "") '得意先住所３
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKTL = CF_Ora_GetDyn(pin_Usr_Ody, "TOKTL", "") '得意先電話番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKFX = CF_Ora_GetDyn(pin_Usr_Ody, "TOKFX", "") '得意先ＦＡＸ番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKBOSNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKBOSNM", "") '得意先代表者名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKTANNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKTANNM", "") '得意先御担当者名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKMLAD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKMLAD", "") '得意先メールアドレス
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANCD = CF_Ora_GetDyn(pin_Usr_Ody, "TANCD", "") '担当者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TANNM = CF_Ora_GetDyn(pin_Usr_Ody, "TANNM", "") '担当者名
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.LMTKN = CF_Ora_GetDyn(pin_Usr_Ody, "LMTKN", 0) '与信限度額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLAKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLAKB", "") '分類区分１（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLBKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLBKB", "") '分類区分２（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLCKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLCKB", "") '分類区分３（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLAID = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLAID", "") '分類コード１（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLBID = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLBID", "") '分類コード２（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLCID = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLCID", "") '分類コード３（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLANM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLANM", "") '与信限度設定日
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLBNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLBNM", "") '分類名称２（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKCLCNM = CF_Ora_GetDyn(pin_Usr_Ody, "TOKCLCNM", "") '分類名称３（得意先）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.DSPKB = CF_Ora_GetDyn(pin_Usr_Ody, "DSPKB", "") '検索表示区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKJUNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKJUNKB", "") '順位表出力区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSEICD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSEICD", "") '請求先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MAINHSCD = CF_Ora_GetDyn(pin_Usr_Ody, "MAINHSCD", "") '代表納入先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSMEKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEKB", "") '締区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSMEDD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEDD", "") '締初期日付（売上）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSMECC = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMECC", "") '締サイクル（売上）
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
            '.TOKNMMKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKNMMKB", "") '名称ﾏﾆｭｱﾙ区分(得)
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SKCHKB = CF_Ora_GetDyn(pin_Usr_Ody, "SKCHKB", "") '諸口区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.IKOUKB = CF_Ora_GetDyn(pin_Usr_Ody, "IKOUKB", "") '移行データ区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKLEADD = CF_Ora_GetDyn(pin_Usr_Ody, "TOKLEADD", "") '運送日数
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.URKZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "URKZANDT", "") '売掛残高日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.URKZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "URKZANKN", 0) '売掛残高金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SEIZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "SEIZANDT", "") '請求残高日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SEIZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "SEIZANKN", 0) '請求残高金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SMAZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "SMAZANDT", "") '経理締残高日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SMAZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "SMAZANKN", 0) '経理締残高金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SSAZANDT = CF_Ora_GetDyn(pin_Usr_Ody, "SSAZANDT", "") '請求・支払締残高日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SSAZANKN = CF_Ora_GetDyn(pin_Usr_Ody, "SSAZANKN", 0) '請求・支払締残高金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKSMEDT = CF_Ora_GetDyn(pin_Usr_Ody, "TOKSMEDT", "") '請求締日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SSKKZADT = CF_Ora_GetDyn(pin_Usr_Ody, "SSKKZADT", "") '請求締消込残高日付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OLDTOKCD = CF_Ora_GetDyn(pin_Usr_Ody, "OLDTOKCD", "") '旧取引先コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TGRPCD = CF_Ora_GetDyn(pin_Usr_Ody, "TGRPCD", "") '代表会社コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OLTGRPCD = CF_Ora_GetDyn(pin_Usr_Ody, "OLTGRPCD", "") '旧代表会社コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KIGYOCD = CF_Ora_GetDyn(pin_Usr_Ody, "KIGYOCD", "") '統一企業コード（識別）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KGYEDACD = CF_Ora_GetDyn(pin_Usr_Ody, "KGYEDACD", "") '統一企業コード（枝番）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KAKZUKE = CF_Ora_GetDyn(pin_Usr_Ody, "KAKZUKE", "") '格付
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BNKCD = CF_Ora_GetDyn(pin_Usr_Ody, "BNKCD", "") '銀行コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.YKNKB = CF_Ora_GetDyn(pin_Usr_Ody, "YKNKB", "") '預金種別
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.KOZNO = CF_Ora_GetDyn(pin_Usr_Ody, "KOZNO", "") '口座番号
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HMEIGI = CF_Ora_GetDyn(pin_Usr_Ody, "HMEIGI", "") '振込名義
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SHAKB = CF_Ora_GetDyn(pin_Usr_Ody, "SHAKB", "") '支払区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TEGSHKN = CF_Ora_GetDyn(pin_Usr_Ody, "TEGSHKN", 0) '手形支払金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TEGRT = CF_Ora_GetDyn(pin_Usr_Ody, "TEGRT", 0) '手形比率
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.NYUDD = CF_Ora_GetDyn(pin_Usr_Ody, "NYUDD", 0) 'サイト
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TEGSHBS = CF_Ora_GetDyn(pin_Usr_Ody, "TEGSHBS", "") '手形支払場所
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.HTSUKB = CF_Ora_GetDyn(pin_Usr_Ody, "HTSUKB", "") '振込手数料負担区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FCTCMCD = CF_Ora_GetDyn(pin_Usr_Ody, "FCTCMCD", "") 'ファクタリング会社コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.GYOSHU = CF_Ora_GetDyn(pin_Usr_Ody, "GYOSHU", "") '業種
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CHIIKI = CF_Ora_GetDyn(pin_Usr_Ody, "CHIIKI", "") '地域
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SEIHKKB = CF_Ora_GetDyn(pin_Usr_Ody, "SEIHKKB", "") '請求書発行区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TOKDNKB = CF_Ora_GetDyn(pin_Usr_Ody, "TOKDNKB", "") '客先指定伝票区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TUKKB = CF_Ora_GetDyn(pin_Usr_Ody, "TUKKB", "") '通貨区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BINCD = CF_Ora_GetDyn(pin_Usr_Ody, "BINCD", "") '便名コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.FRNKB = CF_Ora_GetDyn(pin_Usr_Ody, "FRNKB", "") '海外取引区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.SIMUKE = CF_Ora_GetDyn(pin_Usr_Ody, "SIMUKE", "") '仕向地
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKB = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKB", "") 'ＥＤＩ区分
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBC = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBC", "") 'ＥＤＩ処理区分（注文情報）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBCU = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBCU", "") 'ＥＤＩ処理区分（注文請）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBN = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBN", "") 'ＥＤＩ処理区分（納期回答）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBS = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBS", "") 'ＥＤＩ処理区分（出荷通知）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBSEI = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBSEI", "") 'ＥＤＩ処理区分（請求情報）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBNYU = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBNYU", "") 'ＥＤＩ処理区分（入金情報）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBP = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBP", "") 'ＥＤＩ処理区分（支払明細）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBYBA = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBYBA", "") 'ＥＤＩ処理区分（商品情報）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBYBB = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBYBB", "") 'ＥＤＩ処理区分（予備２）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.EDIKBYBC = CF_Ora_GetDyn(pin_Usr_Ody, "EDIKBYBC", "") 'ＥＤＩ処理区分（予備３）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.RELFL = CF_Ora_GetDyn(pin_Usr_Ody, "RELFL", "") '連携フラグ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.OPEID = CF_Ora_GetDyn(pin_Usr_Ody, "OPEID", "") '最終作業者コード
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CLTID = CF_Ora_GetDyn(pin_Usr_Ody, "CLTID", "") 'クライアントＩＤ
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTTM", "") 'タイムスタンプ（時間）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTDT", "") 'タイムスタンプ（日付）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTTM = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTTM", "") 'タイムスタンプ（登録時間）
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.WRTFSTDT = CF_Ora_GetDyn(pin_Usr_Ody, "WRTFSTDT", "") 'タイムスタンプ（登録日）
            .DATKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DATKB"), "") '伝票削除区分
            .TOKMSTKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMSTKB"), "") 'マスタ区分（得意先）
            .THSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("THSCD"), "") '取引先分類
            .TOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCD"), "") '得意先コード
            .TOKNMA = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMA"), "") '得意先名称１
            .TOKNMB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMB"), "") '得意先名称２
            .TOKRN = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRN"), "") '得意先略称
            .TOKNK = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNK"), "") '得意先名称カナ
            .TOKNMC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMC"), "") '得意先名称半角１
            .TOKNMD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMD"), "") '得意先名称半角２
            .TOKRNNK = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRNNK"), "") '得意先略称カナ
            .TOKZP = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZP"), "") '得意先郵便番号
            .TOKADA = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKADA"), "") '得意先住所１
            .TOKADB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKADB"), "") '得意先住所２
            .TOKADC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKADC"), "") '得意先住所３
            .TOKTL = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKTL"), "") '得意先電話番号
            .TOKFX = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKFX"), "") '得意先ＦＡＸ番号
            .TOKBOSNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKBOSNM"), "") '得意先代表者名
            .TOKTANNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKTANNM"), "") '得意先御担当者名
            .TOKMLAD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKMLAD"), "") '得意先メールアドレス
            .TANCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANCD"), "") '担当者コード
            .TANNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TANNM"), "") '担当者名
            .LMTKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("LMTKN"), 0) '与信限度額
            .TOKCLAKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLAKB"), "") '分類区分１（得意先）
            .TOKCLBKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLBKB"), "") '分類区分２（得意先）
            .TOKCLCKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLCKB"), "") '分類区分３（得意先）
            .TOKCLAID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLAID"), "") '分類コード１（得意先）
            .TOKCLBID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLBID"), "") '分類コード２（得意先）
            .TOKCLCID = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLCID"), "") '分類コード３（得意先）
            .TOKCLANM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLANM"), "") '与信限度設定日
            .TOKCLBNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLBNM"), "") '分類名称２（得意先）
            .TOKCLCNM = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKCLCNM"), "") '分類名称３（得意先）
            .DSPKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("DSPKB"), "") '検索表示区分
            .TOKJUNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKJUNKB"), "") '順位表出力区分
            .TOKSEICD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSEICD"), "") '請求先コード
            .MAINHSCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("MAINHSCD"), "") '代表納入先コード
            .TOKSMEKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEKB"), "") '締区分
            .TOKSMEDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEDD"), "") '締初期日付（売上）
            .TOKSMECC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMECC"), "") '締サイクル（売上）
            .TOKSDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSDWKB"), "") '締め曜日
            .TOKKESCC = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESCC"), "") '回収サイクル
            .TOKKESDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKESDD"), "") '回収日付
            .TOKKDWKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKKDWKB"), "") '回収曜日
            .LSTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("LSTID"), "") '伝票種別
            .TKNRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNRPSKB"), "") '金額端数処理桁数
            .TKNZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TKNZRNKB"), "") '金額端数処理区分
            .TOKZEIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZEIKB"), "") '消費税区分
            .TOKZCLKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZCLKB"), "") '消費税算出区分
            .TOKRPSKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKRPSKB"), "") '消費税端数処理桁数
            .TOKZRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKZRNKB"), "") '消費税端数処理区分
            .TOKNMMKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKNMMKB"), "") '名称ﾏﾆｭｱﾙ区分(得)
            .SKCHKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SKCHKB"), "") '諸口区分
            .IKOUKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("IKOUKB"), "") '移行データ区分
            .TOKLEADD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKLEADD"), "") '運送日数
            .URKZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("URKZANDT"), "") '売掛残高日付
            .URKZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("URKZANKN"), 0) '売掛残高金額
            .SEIZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIZANDT"), "") '請求残高日付
            .SEIZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIZANKN"), 0) '請求残高金額
            .SMAZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMAZANDT"), "") '経理締残高日付
            .SMAZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SMAZANKN"), 0) '経理締残高金額
            .SSAZANDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSAZANDT"), "") '請求・支払締残高日付
            .SSAZANKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSAZANKN"), 0) '請求・支払締残高金額
            .TOKSMEDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKSMEDT"), "") '請求締日付
            .SSKKZADT = DB_NullReplace(pin_Usr_Ody.Rows(0)("SSKKZADT"), "") '請求締消込残高日付
            .OLDTOKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("OLDTOKCD"), "") '旧取引先コード
            .TGRPCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("TGRPCD"), "") '代表会社コード
            .OLTGRPCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("OLTGRPCD"), "") '旧代表会社コード
            .KIGYOCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KIGYOCD"), "") '統一企業コード（識別）
            .KGYEDACD = DB_NullReplace(pin_Usr_Ody.Rows(0)("KGYEDACD"), "") '統一企業コード（枝番）
            .KAKZUKE = DB_NullReplace(pin_Usr_Ody.Rows(0)("KAKZUKE"), "") '格付
            .BNKCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BNKCD"), "") '銀行コード
            .YKNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("YKNKB"), "") '預金種別
            .KOZNO = DB_NullReplace(pin_Usr_Ody.Rows(0)("KOZNO"), "") '口座番号
            .HMEIGI = DB_NullReplace(pin_Usr_Ody.Rows(0)("HMEIGI"), "") '振込名義
            .SHAKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SHAKB"), "") '支払区分
            .TEGSHKN = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGSHKN"), 0) '手形支払金額
            .TEGRT = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGRT"), 0) '手形比率
            .NYUDD = DB_NullReplace(pin_Usr_Ody.Rows(0)("NYUDD"), 0) 'サイト
            .TEGSHBS = DB_NullReplace(pin_Usr_Ody.Rows(0)("TEGSHBS"), "") '手形支払場所
            .HTSUKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("HTSUKB"), "") '振込手数料負担区分
            .FCTCMCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("FCTCMCD"), "") 'ファクタリング会社コード
            .GYOSHU = DB_NullReplace(pin_Usr_Ody.Rows(0)("GYOSHU"), "") '業種
            .CHIIKI = DB_NullReplace(pin_Usr_Ody.Rows(0)("CHIIKI"), "") '地域
            .SEIHKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("SEIHKKB"), "") '請求書発行区分
            .TOKDNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TOKDNKB"), "") '客先指定伝票区分
            .TUKKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("TUKKB"), "") '通貨区分
            .BINCD = DB_NullReplace(pin_Usr_Ody.Rows(0)("BINCD"), "") '便名コード
            .FRNKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("FRNKB"), "") '海外取引区分
            .SIMUKE = DB_NullReplace(pin_Usr_Ody.Rows(0)("SIMUKE"), "") '仕向地
            .EDIKB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKB"), "") 'ＥＤＩ区分
            .EDIKBC = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBC"), "") 'ＥＤＩ処理区分（注文情報）
            .EDIKBCU = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBCU"), "") 'ＥＤＩ処理区分（注文請）
            .EDIKBN = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBN"), "") 'ＥＤＩ処理区分（納期回答）
            .EDIKBS = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBS"), "") 'ＥＤＩ処理区分（出荷通知）
            .EDIKBSEI = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBSEI"), "") 'ＥＤＩ処理区分（請求情報）
            .EDIKBNYU = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBNYU"), "") 'ＥＤＩ処理区分（入金情報）
            .EDIKBP = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBP"), "") 'ＥＤＩ処理区分（支払明細）
            .EDIKBYBA = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBYBA"), "") 'ＥＤＩ処理区分（商品情報）
            .EDIKBYBB = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBYBB"), "") 'ＥＤＩ処理区分（予備２）
            .EDIKBYBC = DB_NullReplace(pin_Usr_Ody.Rows(0)("EDIKBYBC"), "") 'ＥＤＩ処理区分（予備３）
            .RELFL = DB_NullReplace(pin_Usr_Ody.Rows(0)("RELFL"), "") '連携フラグ
            .OPEID = DB_NullReplace(pin_Usr_Ody.Rows(0)("OPEID"), "") '最終作業者コード
            .CLTID = DB_NullReplace(pin_Usr_Ody.Rows(0)("CLTID"), "") 'クライアントＩＤ
            .WRTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTTM"), "") 'タイムスタンプ（時間）
            .WRTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTDT"), "") 'タイムスタンプ（日付）
            .WRTFSTTM = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTTM"), "") 'タイムスタンプ（登録時間）
            .WRTFSTDT = DB_NullReplace(pin_Usr_Ody.Rows(0)("WRTFSTDT"), "") 'タイムスタンプ（登録日）

            '2019/04/08 CHG E N D
        End With
    End Sub

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
        '2019/10 ADD START
        Dim dt As DataTable
        '2019/04/10 ADD E N D

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
        '2019/04/10 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/04/10 CHG E N D

        '件数取得
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/04/10 CHG START
        'intData = CF_Get_CCurString(CF_Ora_GetDyn(Usr_Ody_LC, "CNTDATA", 0))
        intData = CF_Get_CCurString(DB_NullReplace(dt.Rows(0)("CNTDATA"), 0))
        '2019/04/10 CHG E N D

        '2019/04/10 DEL START
        ''クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/10 DEL E N D

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
        '2019/04/10 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        dt = DB_GetTable(strSQL)
        '2019/04/10 CHG E N D

        '取得データ退避
        intData = 1
        '2019/04/10 CHG START
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True

        '	Call DB_MEIMTA_SetData(Usr_Ody_LC, pot_DB_MEIMTA(intData))

        '	Call CF_Ora_MoveNext(Usr_Ody_LC)
        '	intData = intData + 1
        'Loop 
        For i As Integer = 0 To dt.Rows.Count - 1
            'change 20190807 START hou
            'Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData))
            Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData), intData)
            'change 20190807 END hou
            intData = intData + 1
        Next
        '2019/04/10 CHG E N D

        DSPMEIMTA_SEARCH_SORTUSE = 0

END_DSPMEIMTA_SEARCH_SORTUSE:
        '2019/04/10 DEL START
        ''クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/01 DEL E N D
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
    '2019/04/10 CHG START
    'Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)

    'change 20190807 START hou
    'Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA)
    '    '2019/04/10 CHG E N D
    Private Sub DB_MEIMTA_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA, ByRef intData As Integer)
        'change 20190807 END hou
        'データ退避
        With pot_DB_MEIMTA
            '2019/04/10 CHG START
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

            'change 20190807 START  hou
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
            ''2019/04/10 CHG E N D
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
            'change 20190807 END hou
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
	Public Function SYSTBD_SEARCH(ByVal pin_strDKBSB As String, ByVal pin_strDKBID As String, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_SYSTBD_SEARCH
		
		SYSTBD_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(pin_strDKBSB) & "' "
            strSQL = strSQL & "    And DKBID = '" & CF_Ora_Sgl(pin_strDKBID) & "' "

        'DBアクセス
        '2019/04/08 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then

        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/08 CHG E N D
            '取得データなし
            SYSTBD_SEARCH = 1
            GoTo END_SYSTBD_SEARCH
        End If

        '2019/04/08 CHG START
        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        'Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD)
        'End If
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD, 0)
        End If
        '2019/04/08 CHG E N D

        SYSTBD_SEARCH = 0
		
END_SYSTBD_SEARCH:

        '2019/04/08 DEL START
        ''クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/08 DEL E N D

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
	Public Function SYSTBD_SEARCH_ALL(ByVal pin_strDKBSB As String, ByRef pot_DB_SYSTBD() As TYPE_DB_SYSTBD) As Short
		
		Dim strSQL As String
		Dim strSQLCount As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim intIdx As Short
        '2019/04/10 ADD START
        Dim dt As DataTable
        '2019/04/10 ADD E N D
        On Error GoTo ERR_SYSTBD_SEARCH_ALL
		
		SYSTBD_SEARCH_ALL = 9
		
		strSQL = ""
		strSQL = strSQL & "   from SYSTBD "
		strSQL = strSQL & "  Where DKBSB = '" & CF_Ora_Sgl(pin_strDKBSB) & "' "
		strSQL = strSQL & " order by DKBID "
		
		'件数取得
		strSQLCount = ""
		strSQLCount = strSQLCount & " Select Count(*) as DataCount "
		strSQLCount = strSQLCount & strSQL

        'DBアクセス
        '2019/04/10 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQLCount)
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'intData = CF_Ora_GetDyn(Usr_Ody_LC, "DataCount", 0)

        dt = DB_GetTable(strSQLCount)
        intData = DB_NullReplace(dt.Rows(0)("DataCount"), 0)
        '2019/04/10 CHG E N D

        '2019/04/10 DEL START
        ''クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/10 DEL E N D

        If intData = 0 Then
			'取得データなし
			SYSTBD_SEARCH_ALL = 1
			Exit Function
		End If
		
		strSQL = " Select * " & strSQL

        'DBアクセス
        '2019/04/08 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

        'If CF_Ora_EOF(Usr_Ody_LC) = True Then
        dt = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/08 CHG E N D
            '取得データなし
            SYSTBD_SEARCH_ALL = 1
            GoTo END_SYSTBD_SEARCH_ALL
        End If

        '取得データ退避
        ReDim pot_DB_SYSTBD(intData)
        '2019/04.08 CHG START
        'intIdx = 1
        'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        '    Call DB_SYSTBD_SetData(Usr_Ody_LC, pot_DB_SYSTBD(intIdx))
        '    intIdx = intIdx + 1
        '    Call CF_Ora_MoveNext(Usr_Ody_LC)
        'Loop

        For i As Integer = 0 To dt.Rows.Count - 1
            Call DB_SYSTBD_SetData(dt, pot_DB_SYSTBD(i), i)
        Next
        '2019/04/08 CHG E N D

        SYSTBD_SEARCH_ALL = 0
		
END_SYSTBD_SEARCH_ALL:
        '2019/04/09 DEL START
        'クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody_LC)
        '2019/04/09 DEL E N D
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
    'Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As U_Ody, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD)
    Private Sub DB_SYSTBD_SetData(ByRef pin_Usr_Ody As DataTable, ByRef pot_DB_SYSTBD As TYPE_DB_SYSTBD, ByVal DataCount As Integer)
        'データ退避
        With pot_DB_SYSTBD
            '2019/04/08 CHG START
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
            '2019/04/08 CHG E N D
        End With
    End Sub
End Module