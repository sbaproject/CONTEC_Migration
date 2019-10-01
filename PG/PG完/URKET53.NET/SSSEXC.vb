Option Strict Off
Option Explicit On
Module SSSEXC_BAS
	
	'Private Main_Inf                    As Cls_All
	
	'**************************************************************************************************
	'プロシジャ名   ：
	'処理概要       ：業務排他制御モジュール
	'引数
	'
	'戻値
	'
	'**************************************************************************************************
	
	Public Function SSSEXC_EXCTBZ_OPEN() As Object

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        If GET_EXCTBZ(SSS_CLTID.Value, SSS_PrgId) = 9 Then
			If INS_EXCTBZ(SSS_CLTID.Value, SSS_PrgId, VB6.Format(Now, "hhnnss"), gc_strMsgEXCTBZ_ERROR) = 9 Then Exit Function
		Else
			If UPD_EXCTBZ(SSS_CLTID.Value, SSS_PrgId, VB6.Format(Now, "hhnnss"), gc_strMsgEXCTBZ_ERROR) = 9 Then Exit Function
		End If

        '2019/04/17 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/17 CHG E N D

    End Function
	
	Public Function SSSEXC_EXCTBZ_CLOSE() As Object

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        If GET_EXCTBZ(SSS_CLTID.Value, SSS_PrgId) = 9 Then
		Else
			If DEL_EXCTBZ(SSS_CLTID.Value, SSS_PrgId, gc_strMsgEXCTBZ_ERROR) = 9 Then Exit Function
		End If

        '2019/04/17 CHG START
        'Call CF_Ora_CommitTraKns(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/17 CHG E N D

    End Function
	
	Function SSSEXC_EXCTBZ_CHECK() As String
		'排他チェックエラー（Link_Shell関数は戻り値 "9" がエラー）
		'             "1"           : 正常.
		'             "9" & 業務名  : 排他.
		
		SSSEXC_EXCTBZ_CHECK = GET_GYMTBZ_CHECK(SSS_PrgId)
		
		
		''''Call DB_GetGrEq(DBN_GYMTBZ, 2, SSS_PrgId, BtrNormal)
		''''Do While (DBSTAT = 0) And _
		'''''         (Trim(DB_GYMTBZ.NGGYMCD) = Trim(SSS_PrgId)) And _
		'''''         (SSSEXC_EXCTBZ_CHECK = "1")
		''''
		''''    Call DB_GetEq(DBN_EXCTBZ, 2, DB_GYMTBZ.GYMCD, BtrNormal)
		''''    If DBSTAT = 0 Then
		''''        SSSEXC_EXCTBZ_CHECK = "9" & DB_GYMTBZ.GYMNM
		''''    End If
		''''    Call DB_GetNext(DBN_GYMTBZ, BtrNormal)
		''''
		''''Loop
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function GET_EXCTBZ
	'   概要：  排他テーブル検索
	'   引数：  pin_CLTID    : クライアントＩＤ
	'       ：  pin_GYMCD    : 業務コード
	'   戻値：  0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_EXCTBZ(ByVal pin_CLTID As String, ByVal pin_GYMCD As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo GET_EXCTBZ_ERROR
		
		GET_EXCTBZ = 9
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From EXCTBZ"
		strSql = strSql & vbCrLf & " Where CLTID    = " & "'" & pin_CLTID & "'"
		strSql = strSql & vbCrLf & "   And GYMCD    = " & "'" & pin_GYMCD & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	GET_EXCTBZ = 0

        '	GoTo GET_EXCTBZ_END
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            GET_EXCTBZ = 0

            GoTo GET_EXCTBZ_END

        End If
        '2019/04/23 CHG E N D

GET_EXCTBZ_END:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
GET_EXCTBZ_ERROR: 
		GoTo GET_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function UPD_EXCTBZ
	'   概要：  排他テーブル更新
	'   引数：  pin_strCLTID : クライアントＩＤ
	'       ：  pin_strGYMCD : 業務コード
	'       ：  pin_strLCKTM : 時刻
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UPD_EXCTBZ(ByVal pin_strCLTID As String, ByVal pin_strGYMCD As String, ByVal pin_strLCKTM As String, ByVal pin_strErrNo As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo UPD_EXCTBZ_ERROR
		
		UPD_EXCTBZ = 9
		
		'排他テーブル更新
		strSql = ""
		strSql = strSql & vbCrLf & "Update EXCTBZ Set"
		strSql = strSql & vbCrLf & " LCKTM = " & "'" & pin_strLCKTM & "'" '時刻
		strSql = strSql & vbCrLf & " Where CLTID  = " & "'" & pin_strCLTID & "'"
		strSql = strSql & vbCrLf & "   And GYMCD  = " & "'" & pin_strGYMCD & "'"

        'SQL実行
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo UPD_EXCTBZ_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        UPD_EXCTBZ = 0
		
UPD_EXCTBZ_END: 
		Exit Function
		
UPD_EXCTBZ_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, pin_strErrNo, Main_Inf, "UPD_EXCTBZ")
		GoTo UPD_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function INS_EXCTBZ
	'   概要：  排他テーブル追加
	'   引数：  pin_strCLTID : クライアントＩＤ
	'       ：  pin_strGYMCD : 業務コード
	'       ：  pin_strLCKTM : 時刻
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function INS_EXCTBZ(ByVal pin_strCLTID As String, ByVal pin_strGYMCD As String, ByVal pin_strLCKTM As String, ByVal pin_strErrNo As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo INS_EXCTBZ_ERROR
		
		INS_EXCTBZ = 9
		
		'排他テーブル追加
		strSql = ""
		strSql = strSql & vbCrLf & "Insert Into EXCTBZ"
		strSql = strSql & vbCrLf & "(CLTID"
		strSql = strSql & vbCrLf & ",GYMCD"
		strSql = strSql & vbCrLf & ",LCKTM"
		strSql = strSql & vbCrLf & ",SEQNO"
		strSql = strSql & vbCrLf & ",INTLCD"
		strSql = strSql & vbCrLf & ",EXTCD)"
		strSql = strSql & vbCrLf & " Values"
		strSql = strSql & vbCrLf & "(" & "'" & pin_strCLTID & "'" 'クライアントＩＤ
		strSql = strSql & vbCrLf & "," & "'" & pin_strGYMCD & "'" '業務コード
		strSql = strSql & vbCrLf & "," & "'" & pin_strLCKTM & "'" '時刻
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '連番
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '内部コード
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '外部コード
		strSql = strSql & vbCrLf & ")"

        'SQL実行
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo INS_EXCTBZ_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        INS_EXCTBZ = 0
		
INS_EXCTBZ_END: 
		Exit Function
		
INS_EXCTBZ_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, pin_strErrNo, Main_Inf, "INS_EXCTBZ")
		GoTo INS_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DEL_EXCTBZ
	'   概要：  排他テーブル削除
	'   引数：  pin_strCLTID : クライアントＩＤ
	'       ：  pin_strGYMCD : 業務コード
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function DEL_EXCTBZ(ByVal pin_strCLTID As String, ByVal pin_strGYMCD As String, ByVal pin_strErrNo As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo DEL_EXCTBZ_ERROR
		
		DEL_EXCTBZ = 9
		
		strSql = ""
		strSql = strSql & vbCrLf & "Delete From EXCTBZ"
		strSql = strSql & vbCrLf & " Where CLTID  = " & "'" & pin_strCLTID & "'"
		strSql = strSql & vbCrLf & "   And GYMCD  = " & "'" & pin_strGYMCD & "'"

        'SQL実行
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo DEL_EXCTBZ_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D
        DEL_EXCTBZ = 0
		
DEL_EXCTBZ_END: 
		Exit Function
		
DEL_EXCTBZ_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, pin_strErrNo, Main_Inf, "DEL_EXCTBZ")
		GoTo DEL_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function GET_GYMTBZ_CHECK
	'   概要：  業務制御テーブル検索
	'   引数：  pin_NGGYMCD : 業務コード
	'   戻値：  1:正常終了 9:排他必要
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_GYMTBZ_CHECK(ByVal pin_NGGYMCD As String) As String
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strGYMCD As String
		
		On Error GoTo GET_GYMTBZ_CHECK_ERROR
		
		GET_GYMTBZ_CHECK = "1"
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From GYMTBZ"
		strSql = strSql & vbCrLf & " Where NGGYMCD  = " & "'" & pin_NGGYMCD & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'Do While CF_Ora_EOF(Usr_Ody) = False

        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strGYMCD = CF_Ora_GetDyn(Usr_Ody, "GYMCD", "")
        '	If GET_EXCTBZ_2(strGYMCD) = 0 Then
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		GET_GYMTBZ_CHECK = "9" & CF_Ora_GetDyn(Usr_Ody, "GYMNM", "")
        '		Exit Do
        '	End If

        '	'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	Usr_Ody.Obj_Ody.MoveNext()
        'Loop

        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                strGYMCD = DB_NullReplace(dt.Rows(i)("GYMCD"), "")
                If GET_EXCTBZ_2(strGYMCD) = 0 Then
                    GET_GYMTBZ_CHECK = "9" & DB_NullReplace(dt.Rows(i)("GYMNM"), "")
                    Exit For
                End If
            Next
        End If
        '2019/04/23 CHG E N D

GET_GYMTBZ_CHECK_END:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
GET_GYMTBZ_CHECK_ERROR: 
		GoTo GET_GYMTBZ_CHECK_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function GET_EXCTBZ_2
	'   概要：  排他テーブル検索
	'   引数：  pin_GYMCD    : 業務コード
	'   戻値：  0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_EXCTBZ_2(ByVal pin_GYMCD As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo GET_EXCTBZ_2_ERROR
		
		GET_EXCTBZ_2 = 9
		
		strSql = ""
		strSql = strSql & vbCrLf & "Select * From EXCTBZ"
		strSql = strSql & vbCrLf & " Where GYMCD    = " & "'" & pin_GYMCD & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	GET_EXCTBZ_2 = 0

        '	GoTo GET_EXCTBZ_2_END
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            GET_EXCTBZ_2 = 0

            GoTo GET_EXCTBZ_2_END

        End If
        '2019/04/23 CHG E N D

GET_EXCTBZ_2_END:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
GET_EXCTBZ_2_ERROR: 
		GoTo GET_EXCTBZ_2_END
		
	End Function
	
	' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_EXCTBZ_CHECK2
	'   概要：　排他チェック処理
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_EXCTBZ_CHECK2(ByRef pin_strGYMCD As Object) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo SSSWIN_EXCTBZ_CHECK2_ERROR
		
		SSSWIN_EXCTBZ_CHECK2 = 9
		
		strSql = ""
		strSql = strSql & " SELECT * "
		strSql = strSql & "  FROM "
		strSql = strSql & "        EXCTBZ " '排他テーブル
		strSql = strSql & "  WHERE "
		'UPGRADE_WARNING: オブジェクト pin_strGYMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "        GYMCD   = '" & Trim(pin_strGYMCD) & "'" '業務コード
        '2019/04/23 CHG START
        '     Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        '     If CF_Ora_EOF(Usr_Ody) = False Then
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'If Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) = SSS_CLTID.Value And Trim(CF_Ora_GetDyn(Usr_Ody, "INTLCD", "")) = SSS_PrgId Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            If Trim(DB_NullReplace(dt.Rows(0)("CLTID"), "")) = SSS_CLTID.Value And Trim(DB_NullReplace(dt.Rows(0)("INTLCD"), "")) = SSS_PrgId Then
                '2019/04/23 CHG E N D

                SSSWIN_EXCTBZ_CHECK2 = 0
            Else
                '検索結果が存在した場合
                SSSWIN_EXCTBZ_CHECK2 = 1
                '処理終了
                Exit Function
            End If
        Else
            '検索結果が0件の場合
            '排他制御（排他テーブルへ書き込み）
            bolRet = SSSWIN_Execute_EXCTBZ(pin_strGYMCD)
			If bolRet = False Then
				Exit Function
			End If
			SSSWIN_EXCTBZ_CHECK2 = 0
		End If
		
SSSWIN_EXCTBZ_CHECK2_END:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function
		
SSSWIN_EXCTBZ_CHECK2_ERROR: 
		GoTo SSSWIN_EXCTBZ_CHECK2_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_Execute_EXCTBZ
	'   概要：  排他制御処理
	'   引数：  pin_strGYMCD：業務コード
	'   戻値：　True : 正常 False : 異常
	'   備考：  排他制御を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_Execute_EXCTBZ(ByRef pin_strGYMCD As Object) As Boolean
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo SSSWIN_Execute_EXCTBZ_ERROR
		
		SSSWIN_Execute_EXCTBZ = False

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        strSql = ""
		strSql = strSql & " INSERT INTO "
		strSql = strSql & "        EXCTBZ " '排他テーブル
		strSql = strSql & "      ( CLTID " 'クライアントID
		strSql = strSql & "      , GYMCD " '受注番号
		strSql = strSql & "      , LCKTM " 'タイムスタンプ
		strSql = strSql & "      , INTLCD " 'プログラムID
		strSql = strSql & "      ) "
		strSql = strSql & " VALUES "
		strSql = strSql & "      ( '" & SSS_CLTID.Value & "' " 'クライアントID
		'UPGRADE_WARNING: オブジェクト pin_strGYMCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "      , '" & Trim(pin_strGYMCD) & "' " '業務コード
		strSql = strSql & "      , '" & VB6.Format(Now, "hhnnss") & "' " 'タイムスタンプ
		strSql = strSql & "      , '" & SSS_PrgId & "'" 'プログラムID
        strSql = strSql & "      ) "

        '2019/04/17 CHG START
        'Call CF_Ora_Execute(gv_Odb_USR1, strSql)

        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Execute(strSql)

        Call DB_Commit()
        '2019/04/17 CHG E N D

        SSSWIN_Execute_EXCTBZ = True
		
SSSWIN_Execute_EXCTBZ_END:
        'クローズ
        '2019/04/17 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/17 DEL E N D

        Exit Function
		
SSSWIN_Execute_EXCTBZ_ERROR: 
		GoTo SSSWIN_Execute_EXCTBZ_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SSSWIN_Unlock_EXCTBZ
	'   概要：　排他制御解除処理
	'   引数：
	'   戻値：　True : 正常  False : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function SSSWIN_Unlock_EXCTBZ() As Boolean
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo SSSWIN_Unlock_EXCTBZ_ERROR
		
		SSSWIN_Unlock_EXCTBZ = False

        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        strSql = ""
		strSql = strSql & " DELETE FROM "
		strSql = strSql & "        EXCTBZ " '排他テーブル
		strSql = strSql & "  WHERE "
		strSql = strSql & "        CLTID    = '" & SSS_CLTID.Value & "' " 'クライアントID
        strSql = strSql & "    AND INTLCD   = '" & SSS_PrgId & "' " 'プログラムID
        '2019/04/17 CHG START
        'Call CF_Ora_Execute(gv_Odb_USR1, strSql)

        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Execute(strSql)

        Call DB_Commit()
        '2019/04/17 CHG E N D

        SSSWIN_Unlock_EXCTBZ = True
		
SSSWIN_Unlock_EXCTBZ_END:
        'クローズ
        '2019/04/17 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/17 DEL E N D
        Exit Function
		
SSSWIN_Unlock_EXCTBZ_ERROR: 
		GoTo SSSWIN_Unlock_EXCTBZ_END
		
	End Function
	' === 20130708 === INSERT E -
End Module