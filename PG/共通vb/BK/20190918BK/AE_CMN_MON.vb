Option Strict Off
Option Explicit On

'2019/04/26 ADD START
Imports Oracle.DataAccess.Client
'2019/04/26 ADD E N D

Module AE_CMN_MON
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function funcMNTPR_WK_INS
	'   概要： 帳票用ワークの作成
	'   引数： strLIST_ID      出力帳票ＩＤ
	'          strPRT_SEQ      帳票シーケンス
	'   戻値： TRUE : 正常 FALSE : 異常
	'   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function funcMNTPR_WK_INS(ByVal strLIST_ID As String, ByRef strPRT_SEQ As String) As Boolean

    '        Dim bolRet As Boolean
    '        Dim bolTrans As Boolean
    '        Dim strSQL As String

    '        On Error GoTo Err_Run

    '        funcMNTPR_WK_INS = False

    '        'USR1でトランザクション開始
    '        Call CF_Ora_BeginTrans(gv_Oss_USR1)
    '        bolTrans = True

    '        'SEQの取得
    '        strPRT_SEQ = GetPrtSeq()
    '        If strPRT_SEQ = "" Then
    '            GoTo Err_Run
    '        End If

    '        '帳票用ワーク作成処理の呼び出し（PLSQL）
    '        strSQL = "DECLARE "
    '        strSQL = strSQL & "BEGIN "
    '        strSQL = strSQL & Get_DBHEAD() & "_" & ORA_MAX_USR1 & "." & strLIST_ID & "_PACK." & strLIST_ID & "BAT"
    '        strSQL = strSQL & "( "
    '        strSQL = strSQL & " '" & SSS_OPEID.Value & "'" '出力担当者
    '        strSQL = strSQL & ", " & strPRT_SEQ '帳票シーケンス
    '        strSQL = strSQL & "); "
    '        strSQL = strSQL & "END;"

    '        'SQL実行
    '        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    '        If Not bolRet Then
    '            GoTo Err_Run
    '        End If

    '        'コミット
    '        bolRet = CF_Ora_CommitTrans(gv_Oss_USR1)
    '        If Not bolRet Then
    '            GoTo Err_Run
    '        End If
    '        bolTrans = False

    '        funcMNTPR_WK_INS = True

    'Exit_Run:

    '        Exit Function

    'Err_Run:

    '        If bolTrans = True Then
    '            'ロールバック
    '            Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    '        End If

    '        GoTo Exit_Run

    '    End Function
    Public Function funcMNTPR_WK_INS(ByVal strLIST_ID As String, ByRef strPRT_SEQ As String) As Boolean

        '戻り値
        Dim rtnVal As Boolean = False

        'SQL文
        Dim strSQL As String = Nothing

        'OracleCommand
        Dim cmd As New OracleCommand

        Try
            '//トランザクション開始
            Call DB_BeginTrans(CON)

            'SEQの取得
            strPRT_SEQ = GetPrtSeq()
            If strPRT_SEQ = "" Then
                Return rtnVal
            End If

            cmd.Connection = CON
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = strLIST_ID & "_PACK." & strLIST_ID & "BAT"

            '//パラメータ設定
            Dim inPARA_USR As OracleParameter = New OracleParameter '出力担当者
            inPARA_USR.ParameterName = "PARA_USR"
            inPARA_USR.Direction = ParameterDirection.Input
            inPARA_USR.OracleDbType = OracleDbType.Char
            inPARA_USR.Value = SSS_OPEID.Value
            cmd.Parameters.Add(inPARA_USR)

            Dim inPARA_SEQ As OracleParameter = New OracleParameter '帳票シーケンス
            inPARA_SEQ.ParameterName = "PARA_SEQ"
            inPARA_SEQ.Direction = ParameterDirection.Input
            inPARA_SEQ.OracleDbType = OracleDbType.Decimal
            inPARA_SEQ.Value = strPRT_SEQ
            cmd.Parameters.Add(inPARA_SEQ)

            '//実行
            cmd.ExecuteNonQuery()

            '//コミット
            Call DB_Commit()

            rtnVal = True

        Catch ex As Exception

            Call DB_Rollback()
            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function funcMNTPR_WK_DEL
	'   概要： 帳票用ワークの削除
	'   引数： strLIST_ID      出力帳票ＩＤ
	'          strPRT_SEQ      帳票シーケンス
	'   戻値： TRUE : 正常 FALSE : 異常
	'   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '	Public Function funcMNTPR_WK_DEL(ByVal strLIST_ID As String, ByVal strPRT_SEQ As String) As Boolean

    '		Dim bolRet As Boolean
    '		Dim bolTrans As Boolean
    '		Dim strSQL As String

    '		On Error GoTo Err_Run

    '		funcMNTPR_WK_DEL = False

    '		'USR9でトランザクション開始
    '		Call CF_Ora_BeginTrans(gv_Oss_USR9)
    '		bolTrans = True

    '		'SQL生成
    '		strSQL = ""
    '		strSQL = strSQL & " DELETE " & vbCrLf
    '		strSQL = strSQL & " FROM " & strLIST_ID & vbCrLf
    '		strSQL = strSQL & " WHERE " & vbCrLf
    '		strSQL = strSQL & "     PRTTANID = '" & SSS_OPEID.Value & "' " & vbCrLf
    '		strSQL = strSQL & " AND PRTSEQ = '" & strPRT_SEQ & "' "

    '		'SQL実行
    '		bolRet = CF_Ora_Execute(gv_Odb_USR9, strSQL)
    '		If bolRet = False Then
    '			GoTo Err_Run
    '		End If

    '		'コミット
    '		bolRet = CF_Ora_CommitTrans(gv_Oss_USR9)
    '		If Not bolRet Then
    '			GoTo Err_Run
    '		End If
    '		bolTrans = False

    '		funcMNTPR_WK_DEL = True

    'Exit_Run: 

    '		Exit Function

    'Err_Run: 

    '		If bolTrans = True Then
    '			'ロールバック
    '			Call CF_Ora_RollbackTrans(gv_Oss_USR9)
    '		End If

    '		GoTo Exit_Run

    '    End Function
    Public Function funcMNTPR_WK_DEL(ByVal strLIST_ID As String, ByVal strPRT_SEQ As String) As Boolean

        '戻り値
        Dim rtnVal As Boolean = False

        'SQL文
        Dim strSQL As String = Nothing

        Try
            '//トランザクション開始
            Call DB_BeginTrans(CON)


            '//SQL
            strSQL = ""
            strSQL &= vbCrLf & " DELETE "
            strSQL &= vbCrLf & " FROM CNT_USR9." & strLIST_ID
            strSQL &= vbCrLf & " WHERE PRTTANID = '" & SSS_OPEID.Value & "' "
            strSQL &= vbCrLf & " AND   PRTSEQ = '" & strPRT_SEQ & "' "

            '//実行
            Call DB_Execute(strSQL)

            '//コミット
            Call DB_Commit()

            rtnVal = True

        Catch ex As Exception

            Call DB_Rollback()
            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Sub GetPrtSeq
    '   概要： 帳票用シーケンス取得処理
    '   引数： なし
    '   戻値： 取得したシーケンス　異常終了の場合は空文字を返す
    '   備考： USR9への接続は呼び出し元で行うこと
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function GetPrtSeq() As String

    '        Dim strSQL As String
    '        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '        Dim Usr_Ody As U_Ody
    '        Dim strSeq As String

    '        GetPrtSeq = ""

    '        'SQL文の作成
    '        strSQL = ""
    '        strSQL = strSQL & " SELECT PRTSEQ.NEXTVAL PRTSEQ " & vbCrLf
    '        strSQL = strSQL & " FROM DUAL "

    '        'DBアクセス
    '        If CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody, strSQL) = False Then
    '            GoTo Err_Run
    '        End If

    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        strSeq = CStr(CF_Ora_GetDyn(Usr_Ody, "PRTSEQ", 0))

    '        GetPrtSeq = strSeq

    'Exit_Run:

    '        'クローズ
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        Exit Function

    'Err_Run:

    '        GoTo Exit_Run

    '    End Function
    Public Function GetPrtSeq() As String

        '戻り値
        Dim rtnVal As String = ""

        'SQL文
        Dim strSQL As String = Nothing

        Try
            '//SQL
            strSQL = ""
            strSQL &= vbCrLf & " SELECT "
            strSQL &= vbCrLf & "  CNT_USR9.PRTSEQ.NEXTVAL PRTSEQ "
            strSQL &= vbCrLf & " FROM DUAL "

            '//実行
            Dim dt As DataTable = DB_GetTable(strSQL)

            rtnVal = CStr(DB_NullReplace(dt.Rows(0)("PRTSEQ"), 0))

        Catch ex As Exception

            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function funcGetColComment
	'   概要： コメント取得SQL作成
	'   引数： strTBL_NAME    : テーブル名
	'          strCOL_NAME    : 列名
	'   戻値： コメント取得SQL
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcGetColComment(ByVal strTBL_NAME As String, ByVal strCOL_NAME As String) As String
		
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & "SELECT COMMENTS "
		strSQL = strSQL & "FROM USER_COL_COMMENTS "
		strSQL = strSQL & "WHERE TABLE_NAME = '" & strTBL_NAME & "' "
		strSQL = strSQL & "AND COLUMN_NAME = '" & strCOL_NAME & "'"
		
		funcGetColComment = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function funcGetOutName
	'   概要： ファイル名作成処理
	'   引数： strOUT_PATH    : ファイルパス
	'          strOUT_NAME    : 変換前ファイル名
	'          strOUT_TYPE    : 拡張子
	'          strCNT_FORM    : カウントのフォーマット
	'          strFILEPATH    : 変換後ファイル名(拡張子付)
	'   戻値： TRUE : 正常 FALSE : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function funcGetOutName(ByVal strOUT_PATH As String, ByVal strOUT_NAME As String, ByVal strOUT_TYPE As String, ByVal strCNT_FORM As String, ByRef strFILEPATH As String) As Boolean

    '        Dim cnt As Short
    '        Dim cntMax As Short
    '        Dim strPath As String
    '        Dim strDir As String
    '        Dim strGETUDO As String
    '        Dim strCnt As String
    '        Dim strSQL As String
    '        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '        Dim Usr_Ody As U_Ody

    '        On Error GoTo Err_Run

    '        funcGetOutName = False
    '        strPath = strOUT_NAME
    '        cnt = 0
    '        cntMax = 0
    '        strGETUDO = ""
    '        strCnt = ""

    '        '月次仮締日（売り）より月度を取得
    '        'SQL文の作成
    '        strSQL = ""
    '        strSQL = strSQL & "SELECT GET_GETUDO(" & vbCrLf
    '        strSQL = strSQL & "         (SELECT UKSMEDT     FROM SYSTBA)," & vbCrLf
    '        strSQL = strSQL & "         (SELECT SMEDD       FROM SYSTBA)" & vbCrLf
    '        strSQL = strSQL & "     ) GETUDO" & vbCrLf
    '        strSQL = strSQL & " FROM DUAL"

    '        'DBアクセス
    '        If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL) = False Then
    '            GoTo Err_Run
    '        End If

    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        strGETUDO = CStr(CF_Ora_GetDyn(Usr_Ody, "GETUDO", 0))
    '        strGETUDO = Mid(strGETUDO, 1, 4) & "年" & Mid(strGETUDO, 5, 2) & "月度"

    '        strPath = strPath & "_" & strGETUDO

    '        'ファイルのカウント取得
    '        If Right(Trim(strOUT_PATH), 1) <> "\" Then
    '            strOUT_PATH = Trim(strOUT_PATH) & "\"
    '        End If

    '        'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
    '        strDir = Dir(strOUT_PATH & strPath & "*" & strOUT_TYPE)
    '        Do While (strDir <> "")
    '            strDir = Replace(strDir, strPath & "_", "")
    '            strDir = Replace(strDir, strOUT_TYPE, "")
    '            If IsNumeric(strDir) Then
    '                cnt = CShort(strDir)
    '            Else
    '                cnt = 0
    '            End If

    '            If cnt > cntMax Then
    '                cntMax = cnt
    '            End If
    '            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
    '            strDir = Dir()
    '        Loop

    '        strCnt = VB6.Format(cntMax + 1, strCNT_FORM)

    '        strFILEPATH = strPath & "_" & strCnt & strOUT_TYPE

    '        funcGetOutName = True

    'Exit_Run:

    '        'クローズ
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        Exit Function

    'Err_Run:

    '        GoTo Exit_Run

    '    End Function
    Public Function funcGetOutName(ByVal strOUT_PATH As String, ByVal strOUT_NAME As String, ByVal strOUT_TYPE As String, ByVal strCNT_FORM As String, ByRef strFILEPATH As String) As Boolean

        '戻り値
        Dim rtnVal As Boolean = False

        'SQL文
        Dim strSQL As String = Nothing

        Try
            Dim cnt As Short
            Dim cntMax As Short
            Dim strPath As String
            Dim strDir As String
            Dim strGETUDO As String
            strPath = strOUT_NAME
            cnt = 0
            cntMax = 0
            strGETUDO = ""

            '//SQL
            strSQL = ""
            strSQL &= vbCrLf & " SELECT GET_GETUDO((SELECT UKSMEDT FROM SYSTBA),(SELECT SMEDD FROM SYSTBA)) GETUDO"
            strSQL &= vbCrLf & " FROM DUAL "

            '//実行
            Dim dt As DataTable = DB_GetTable(strSQL)

            strGETUDO = CStr(DB_NullReplace(dt.Rows(0)("GETUDO"), 0))
            strGETUDO = Mid(strGETUDO, 1, 4) & "年" & Mid(strGETUDO, 5, 2) & "月度"

            strPath = strPath & "_" & strGETUDO

            'ファイルのカウント取得
            If Right(Trim(strOUT_PATH), 1) <> "\" Then
                strOUT_PATH = Trim(strOUT_PATH) & "\"
            End If

            strDir = Dir(strOUT_PATH & strPath & "*" & strOUT_TYPE)
            Do While (strDir <> "")
                strDir = Replace(strDir, strPath & "_", "")
                strDir = Replace(strDir, strOUT_TYPE, "")
                If IsNumeric(strDir) Then
                    cnt = CShort(strDir)
                Else
                    cnt = 0
                End If

                If cnt > cntMax Then
                    cntMax = cnt
                End If

                strDir = Dir()
            Loop

            strFILEPATH = strPath & "_" & VB6.Format(cntMax + 1, strCNT_FORM) & strOUT_TYPE

            rtnVal = True

        Catch ex As Exception

            Throw ex

        Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function funcOutput
	'   概要： ファイル出力処理
	'   引数： pin_strOUT_PATH    : 出力ファイルパス
	'          pin_strOUT_NAME    : 出力ファイル名
	'   戻値： 0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcOutput(ByVal pin_strOUT_PATH As String, ByVal pin_strOUT_NAME As String, ByVal pin_strOUT_TXT As Object) As Short
		
		Dim intFNo As Short
		Dim strOUT As String
		Dim bolOpen As Boolean
		
		On Error GoTo Err_Run
		
		funcOutput = 9
		bolOpen = False
		
		intFNo = FreeFile
		
		If Right(Trim(pin_strOUT_PATH), 1) <> "\" Then
			pin_strOUT_PATH = Trim(pin_strOUT_PATH) & "\"
		End If
		
		'ファイルオープン
		FileOpen(intFNo, Trim(pin_strOUT_PATH) & Trim(pin_strOUT_NAME), OpenMode.Append)
		bolOpen = True
		
		'UPGRADE_WARNING: オブジェクト pin_strOUT_TXT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strOUT = pin_strOUT_TXT
		
		PrintLine(intFNo, strOUT)
		
		funcOutput = 0
		
Exit_Run: 
		
		If bolOpen = True Then
			'クローズ
			FileClose(intFNo)
		End If
		
		Exit Function
		
Err_Run: 
		
		'''' ADD 2009/10/27  FKS) T.Yamamoto    Start    連絡票№FC09102703
		gv_Int_OraErr = CShort("0")
		gv_Str_OraErrText = Trim(pin_strOUT_PATH) & Trim(pin_strOUT_NAME) & "への書き込みに失敗しました。"
		'''' ADD 2009/10/27  FKS) T.Yamamoto    End
		GoTo Exit_Run
		
	End Function
	
	'''' ADD 2009/06/17  FKS) T.Yamamoto    Start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function funcGetMNTPR_PARA
	'   概要： パラメータ使用フラグと対象月度を取得
	'   引数： strLIST_ID        : 出力帳票ＩＤ
	'          strCOL_GETUDO     : 対象月度が格納されている列名
	'          strPARAFLG        : パラメータ使用フラグ
	'          strGETUDO         : 対象月度
	'   戻値： TRUE : 正常 FALSE : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/26 CHG START
    '    Public Function funcGetMNTPR_PARA(ByVal strLIST_ID As String, ByVal strCOL_GETUDO As String, ByRef strPARAFLG As String, ByRef strGETUDO As String) As Boolean

    '        Dim strSQL As String
    '        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '        Dim Usr_Ody As U_Ody

    '        On Error GoTo Err_Run

    '        funcGetMNTPR_PARA = False

    '        'SQL文の作成
    '        strSQL = ""
    '        strSQL = strSQL & "SELECT PARAFLG," & vbCrLf
    '        strSQL = strSQL & "       (" & vbCrLf
    '        strSQL = strSQL & "           CASE WHEN LENGTHB(RTRIM(" & strCOL_GETUDO & ")) = 6 THEN" & vbCrLf
    '        strSQL = strSQL & "               RTRIM(" & strCOL_GETUDO & ")" & vbCrLf
    '        strSQL = strSQL & "           ELSE" & vbCrLf
    '        strSQL = strSQL & "               GET_GETUDO(" & strCOL_GETUDO & ", (SELECT SMEDD FROM SYSTBA))" & vbCrLf
    '        strSQL = strSQL & "           END" & vbCrLf
    '        strSQL = strSQL & "       ) GETUDO" & vbCrLf
    '        strSQL = strSQL & " FROM  MNTPR_PARA"
    '        strSQL = strSQL & " WHERE LISTID = '" & strLIST_ID & "'"

    '        'DBアクセス
    '        If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL) = False Then
    '            GoTo Err_Run
    '        End If

    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        strPARAFLG = CStr(CF_Ora_GetDyn(Usr_Ody, "PARAFLG", 0))
    '        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        strGETUDO = CStr(CF_Ora_GetDyn(Usr_Ody, "GETUDO", 0))
    '        strGETUDO = Mid(strGETUDO, 1, 4) & "年" & Mid(strGETUDO, 5, 2) & "月度"


    '        funcGetMNTPR_PARA = True

    'Exit_Run:

    '        'クローズ
    '        Call CF_Ora_CloseDyn(Usr_Ody)

    '        Exit Function

    'Err_Run:

    '        GoTo Exit_Run

    '    End Function
    Public Function funcGetMNTPR_PARA(ByVal strLIST_ID As String, ByVal strCOL_GETUDO As String, ByRef strPARAFLG As String, ByRef strGETUDO As String) As Boolean

        '戻り値
        Dim rtnVal As Boolean = False

        'SQL文
        Dim strSQL As String = Nothing

        Try
            '//SQL
            strSQL = ""
            strSQL = strSQL & "SELECT PARAFLG," & vbCrLf
            strSQL = strSQL & "       (" & vbCrLf
            strSQL = strSQL & "           CASE WHEN LENGTHB(RTRIM(" & strCOL_GETUDO & ")) = 6 THEN" & vbCrLf
            strSQL = strSQL & "               RTRIM(" & strCOL_GETUDO & ")" & vbCrLf
            strSQL = strSQL & "           ELSE" & vbCrLf
            strSQL = strSQL & "               GET_GETUDO(" & strCOL_GETUDO & ", (SELECT SMEDD FROM SYSTBA))" & vbCrLf
            strSQL = strSQL & "           END" & vbCrLf
            strSQL = strSQL & "       ) GETUDO" & vbCrLf
            strSQL = strSQL & " FROM  MNTPR_PARA"
            strSQL = strSQL & " WHERE LISTID = '" & strLIST_ID & "'"

            '//実行
            Dim dt As DataTable = DB_GetTable(strSQL)

            strPARAFLG = CStr(DB_NullReplace(dt.Rows(0)("PARAFLG"), 0))
            strGETUDO = CStr(DB_NullReplace(dt.Rows(0)("GETUDO"), 0))
            strGETUDO = Mid(strGETUDO, 1, 4) & "年" & Mid(strGETUDO, 5, 2) & "月度"

            rtnVal = True

        Catch ex As Exception
            Throw ex

            'Finally

        End Try

        Return rtnVal

    End Function
    '2019/04/26 CHG E N D

	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function funcGetOutName2
	'   概要： ファイル名作成処理
	'   引数： strOUT_PATH    : ファイルパス
	'          strOUT_NAME    : 変換前ファイル名
	'          strGETUDO      : 対象月度
	'          strOUT_TYPE    : 拡張子
	'          strCNT_FORM    : カウントのフォーマット
	'   戻値： 変換後ファイル名(拡張子付)
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcGetOutName2(ByVal strOUT_PATH As String, ByVal strOUT_NAME As String, ByVal strGETUDO As String, ByVal strOUT_TYPE As String, ByVal strCNT_FORM As String) As Object
		
		Dim cnt As Short
		Dim cntMax As Short
		Dim strDir As String
		Dim strCnt As String
		Dim strSQL As String
        '2019/04/26 DEL START
        ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        'Dim Usr_Ody As U_Ody
        '2019/04/26 DEL E N D

		On Error GoTo Err_Run
		
		'UPGRADE_WARNING: オブジェクト funcGetOutName2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		funcGetOutName2 = strOUT_NAME & "_" & strGETUDO
		cnt = 0
		cntMax = 0
		strGETUDO = ""
		strCnt = ""
		
		'ファイルのカウント取得
		If Right(Trim(strOUT_PATH), 1) <> "\" Then
			strOUT_PATH = Trim(strOUT_PATH) & "\"
		End If
		
		'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		strDir = Dir(strOUT_PATH & funcGetOutName2 & "*" & strOUT_TYPE)
		Do While (strDir <> "")
			strDir = Replace(strDir, funcGetOutName2 & "_", "")
			strDir = Replace(strDir, strOUT_TYPE, "")
			If IsNumeric(strDir) Then
				cnt = CShort(strDir)
			Else
				cnt = 0
			End If
			
			If cnt > cntMax Then
				cntMax = cnt
			End If
			'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			strDir = Dir()
		Loop 
		
		strCnt = VB6.Format(cntMax + 1, strCNT_FORM)
		
		'UPGRADE_WARNING: オブジェクト funcGetOutName2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		funcGetOutName2 = funcGetOutName2 & "_" & strCnt
		
Exit_Run: 
		
		'UPGRADE_WARNING: オブジェクト funcGetOutName2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		funcGetOutName2 = funcGetOutName2 & strOUT_TYPE
		
        '2019/04/26 DEL START
        ''クローズ
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/26 DEL E N D

		Exit Function
		
Err_Run: 
		
		GoTo Exit_Run
		
	End Function
	'''' ADD 2009/06/17  FKS) T.Yamamoto    End
End Module