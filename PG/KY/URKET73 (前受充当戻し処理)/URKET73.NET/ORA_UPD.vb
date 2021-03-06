Option Strict Off
Option Explicit On
Module ORA_UPD
	
	
	
	'---------------------------
	'■種別単位の消込金額情報
	'---------------------------
	Structure TYPE_NKSSMB_KS
		Dim SEQ As Short '消込順
		Dim UPDID As String '消込更新用ｲﾝﾃﾞｯｸｽ
		Dim DATKB As String '取引区分コード
		Dim ZAN_KIN As Decimal '消し込んだ残り金額
		Dim SSANYUKN As Decimal '入金金額
		Dim KSKNYKKN As Decimal '消込金額
		Dim KSKZANKN As Decimal '消込残金額
	End Structure
	Public ARY_NKSSMB_KS() As TYPE_NKSSMB_KS
	
	'---------------------------
	'■排他（売上トラン）
	'---------------------------
	Structure TYPE_UDNTRA_HAITA
		Dim DATNO As String ' 伝票管理NO.
		Dim LINNO As String ' 行番号
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（時間）
		Dim WRTDT As String ' タイムスタンプ（日付）
		Dim UOPEID As String ' ユーザID（バッチ）
		Dim UCLTID As String ' クライアントID（バッチ）
		Dim UWRTDT As String ' タイムスタンプ（バッチ更新日付）
		Dim UWRTTM As String ' タイムスタンプ（バッチ更新時間）
	End Structure
	Public ARY_UDNTRA_HAITA() As TYPE_UDNTRA_HAITA
	
	'---------------------------
	'■排他（受注トラン）
	'---------------------------
	Structure TYPE_JDNTRA_HAITA
		Dim DATNO As String ' 伝票管理NO.
		Dim JDNNO As String ' 受注伝票番号
		Dim LINNO As String ' 行番号
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（時間）
		Dim WRTDT As String ' タイムスタンプ（日付）
		Dim UOPEID As String ' ユーザID（バッチ）
		Dim UCLTID As String ' クライアントID（バッチ）
		Dim UWRTDT As String ' タイムスタンプ（バッチ更新日付）
		Dim UWRTTM As String ' タイムスタンプ（バッチ更新時間）
	End Structure
	Public ARY_JDNTRA_HAITA() As TYPE_JDNTRA_HAITA
	
	'---------------------------
	'■排他（入金消込サマリー）
	'---------------------------
	Structure TYPE_NKSSMB_HAITA
		Dim TOKCD As String ' 得意先コード
		Dim SMADT As String ' 経理締日付
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（時間）
		Dim WRTDT As String ' タイムスタンプ（日付）
	End Structure
	Public ARY_NKSSMB_HAITA() As TYPE_NKSSMB_HAITA
	
	'---------------------------
	'■排他（入金消込トラン）
	'---------------------------
	Structure TYPE_NKSTRA_HAITA
		Dim KDNNO As String ' 消込伝票番号��
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（時間）
		Dim WRTDT As String ' タイムスタンプ（日付）
		Dim UOPEID As String ' ユーザID（バッチ）
		Dim UCLTID As String ' クライアントID（バッチ）
		Dim UWRTDT As String ' タイムスタンプ（バッチ更新日付）
		Dim UWRTTM As String ' タイムスタンプ（バッチ更新時間）
	End Structure
	
	Public ARY_NKSTRA_HAITA() As TYPE_NKSTRA_HAITA
	
	
	'---------------------------
	'■排他（売上トラン入金レコード）
	'---------------------------
	Structure TYPE_UDNTRA_NYU_HAITA
		Dim DATNO As String ' 伝票管理NO.
		Dim LINNO As String ' 行番号
		Dim OKRJONO As String ' 送り状��
		Dim UDNNO As String ' 売上伝票番号
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（時間）
		Dim WRTDT As String ' タイムスタンプ（日付）
		Dim UOPEID As String ' ユーザID（バッチ）
		Dim UCLTID As String ' クライアントID（バッチ）
		Dim UWRTDT As String ' タイムスタンプ（バッチ更新日付）
		Dim UWRTTM As String ' タイムスタンプ（バッチ更新時間）
	End Structure
	
	Public ARY_UDNTRA_NYU_HAITA() As TYPE_UDNTRA_NYU_HAITA
	Public ARY_UDNTRA_NYU_CNT As Short '入金レコードカウント変数
	
	
	'---------------------------
	'■種別単位の入金金額情報
	'---------------------------
	Structure TYPE_NYUKN_KS
		Dim SEQ As Short '消込順
		Dim UPDID As String '消込更新用ｲﾝﾃﾞｯｸｽ
		Dim DKBID As String '取引区分コード
		Dim ZANKN As Decimal '消し込んだ残り金額
		Dim OKRJONO As String '送り状��
		'**** 2009/09/16 ADD START FKS)NAKATA
		Dim NYUKB As String '入金区分
		'**** 2009/09/16 ADD E.N.D FKS)NAKATA
		'**** 2009/10/09 ADD START FKS)NAKATA
		Dim UDNDT As String '売上日(入金日)
		'**** 2009/10/09 ADD E.N.D FKS)NAKATA
	End Structure
	Public ARY_NYUKN_KS() As TYPE_NYUKN_KS
	Public ARY_NYUKN_KS_CNT As Short '入金レコードカウント変数
	
	'*** 2009/08/26 DEL START FKS)NAKATA v1.02
	'Public ARY_NYUKN_KS_OKRJONO     As String   '二度読み回避用変数
	'*** 2009/08/26 DEL E.N.D FKS)NAKATA v1.02
	
	Private varSpdValue(COL_HENPI) As Object 'スプレッドの値を格納(登録時に使用)
	
	
	'売掛サマリの入金額に更新を行う
	Private Function setTOKSMA(ByRef strTokcd As String, ByRef strUPDID As String, ByRef intKesikn As Decimal, ByVal strSMADT As String) As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim i As Short
		
		On Error GoTo SETTOKSMA_ERROR
		
		setTOKSMA = False
		
		'サマリ存在チェック
		strSql = "SELECT * FROM toksma WHERE smadt = '" & strSMADT & "' " & "AND tokcd = '" & strTokcd & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'ﾃﾞｰﾀがあるとき
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPDATE文を実行する
			strSql = "UPDATE toksma SET smanyukn" & strUPDID & " = smanyukn" & strUPDID & " + " & intKesikn & " " & "WHERE smadt = '" & strSMADT & "' " & "AND tokcd = '" & strTokcd & "' "
			
			'ﾃﾞｰﾀが無い時
		Else
			'INSERT文を実行する
			strSql = "INSERT INTO toksma ( tokcd, smadt, " & "smaurikn00, smaurikn01, smaurikn02, smaurikn03, smaurikn04, smaurikn05, smaurikn06, smaurikn07, smaurikn08, smaurikn09, smauzekn, " & "szakzikn00, szakzikn01, szakzikn02, szakzokn00, szakzokn01, szakzokn02, szbkzikn00, szbkzikn01, szbkzikn02, szbkzokn00, szbkzokn01, szbkzokn02, " & "smagnkkn00, smagnkkn01, smagnkkn02, smagnkkn03, smagnkkn04, smagnkkn05, smagnkkn06, smagnkkn07, smagnkkn08, smagnkkn09," & "smanyukn00, smanyukn01, smanyukn02, smanyukn03, smanyukn04, smanyukn05, smanyukn06, smanyukn07, smanyukn08, smanyukn09, " & "datno,  wrttm,  wrtdt ) VALUES (" & "'" & CF_Ora_String(strTokcd, 10) & "', '" & strSMADT & "', " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			
			For i = 0 To 9
				'UPGRADE_WARNING: オブジェクト SSSVal(strUPDID) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If i = SSSVal(strUPDID) Then
					strSql = strSql & intKesikn & ", "
				Else
					strSql = strSql & "0, "
				End If
			Next i
			
			strSql = strSql & "'" & Space(10) & "', '" & GV_SysTime & "', '" & GV_SysDate & "')"
		End If
		
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo SETTOKSMA_ERROR
		End If
		
		setTOKSMA = True
		Exit Function
		
SETTOKSMA_ERROR: 
		Call SSSWIN_LOGWRT("SETTOKSMA_ERROR")
		
	End Function
	
	'売上トランの入金額に更新を行う
	'*** 2009/09/16 CHG STRAT FKS)NAKATA
	'Private Function setUDNTRA(strDATNO As String, strLINNO As String, intKesikn As Currency) As Boolean
	Private Function setUDNTRA(ByRef strDATNO As String, ByRef strLINNO As String, ByRef intKesikn As Decimal, ByVal strNYUKB As String) As Boolean
		'*** 2009/09/16 CHG E.N.D FKS)NAKATA
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim intZankn As Decimal '未消込額を格納
		Dim intJkesikn As Decimal '消込済額を格納
		
		On Error GoTo SETUDNTRA_ERROR
		
		setUDNTRA = False
		
		'まず金額を加算するUPDATE文を実行する
		strSql = "UPDATE udntra SET jkesikn = jkesikn + " & intKesikn & " " & "WHERE datno = '" & strDATNO & "' " & "AND linno = '" & strLINNO & "' "
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo SETUDNTRA_ERROR
		End If
		
		
		'加算した売上データを取得
		strSql = "SELECT urikn + uzekn - jkesikn zankn, jkesikn FROM udntra WHERE datno = '" & strDATNO & "' " & "AND linno = '" & strLINNO & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intZankn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "zankn", ""))
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "jkesikn", ""))
		End If
		
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		
		'更新結果により再度売上UPDATEを実施
		strSql = "UPDATE udntra SET "
		
		'消込額と税込み売上額が等しい時 kesikb = 1
		If intZankn = 0 Then
			strSql = strSql & "kesikb  = 1, "
		Else
			strSql = strSql & "kesikb = 9, "
		End If
		'消込額が0のとき nyudt = "" nyukb = ""
		If intJkesikn = 0 Then
			strSql = strSql & "nyudt = '" & Space(8) & "', " & "nyukb = '" & Space(1) & "', "
		Else
			strSql = strSql & "nyudt = '" & gstrKesidt.Value & "', "
			'2009/09/16 CHG START FKS)NAKATA
			'        '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2
			'        If DB_TOKMTA.SHAKB = 5 Or DB_TOKMTA.SHAKB = 6 Then
			'            strSql = strSql & "nyukb = '2', "
			'        Else
			'            strSql = strSql & "nyukb = '1', "
			'        End If
			strSql = strSql & "nyukb = '" & strNYUKB & "', "
			'2009/09/16 CHG E.N.D FKS)NAKATA
		End If
		
		
		'UPDATE文を実行する
		strSql = strSql & "uopeid = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "', " & "ucltid = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "', " & "uwrttm = '" & GV_SysTime & "', " & "uwrtdt = '" & GV_SysDate & "', " & "pgid = '" & SSS_PrgId & "' " & "WHERE datno = '" & strDATNO & "' " & "AND linno = '" & strLINNO & "' "
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo SETUDNTRA_ERROR
		End If
		
		setUDNTRA = True
		Exit Function
		
SETUDNTRA_ERROR: 
		Call SSSWIN_LOGWRT("SETUDNTRA_ERROR")
		
	End Function
	
	'受注トランの入金額に更新を行う
	'**** 2009/09/16 CHG STRART FKS)NAKATA
	'Private Function setJDNTRA(strJdnno As String, strLINNO As String, intKesikn As Currency) As Boolean
	Private Function setJDNTRA(ByRef strJdnno As String, ByRef strLINNO As String, ByRef intKesikn As Decimal, ByRef strNYUKB As String) As Boolean
		'**** 2009/09/16 CHG E.N.D FKS)NAKATA
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim intNyukn As Decimal
		
		On Error GoTo SETJDNTRA_ERROR
		
		setJDNTRA = False
		
		'まず金額を加算するUPDATE文を実行する(黒伝票)
		strSql = "UPDATE jdntra SET nyukn = nyukn + " & intKesikn & " " & "WHERE jdnno = '" & strJdnno & "' " & "AND linno = '" & strLINNO & "' " & "AND akakrokb = '1'"
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo SETJDNTRA_ERROR
		End If
		
		
		'(赤伝票)
		strSql = "UPDATE jdntra SET nyukn = nyukn + " & intKesikn * (-1) & " " & "WHERE jdnno = '" & strJdnno & "' " & "AND linno = '" & strLINNO & "' " & "AND akakrokb = '9'"
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo SETJDNTRA_ERROR
		End If
		
		
		'加算した受注データを取得
		strSql = "SELECT nyukn FROM jdntra WHERE jdnno = '" & strJdnno & "' " & "AND linno = '" & strLINNO & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intNyukn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "nyukn", ""))
		End If
		
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		
		'更新結果により再度売上UPDATEを実施
		strSql = "UPDATE jdntra SET "
		
		'消込額が0のとき nyudt = "", nyukb = ""
		If intNyukn = 0 Then
			strSql = strSql & "nyudt = '" & Space(8) & "', " & "nyukb = '" & Space(1) & "', "
		Else
			strSql = strSql & "nyudt = '" & gstrKesidt.Value & "', "
			'2009/09/16 CHG START FKS)NAKATA
			'        '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2
			'        If DB_TOKMTA.SHAKB = 5 Or DB_TOKMTA.SHAKB = 6 Then
			'            strSql = strSql & "nyukb = '2', "
			'        Else
			'            strSql = strSql & "nyukb = '1', "
			'        End If
			strSql = strSql & "nyukb = '" & strNYUKB & "', "
			'2009/09/16 CHG E.N.D FKS)NAKATA
		End If
		
		'UPDATE文を実行する
		strSql = strSql & "uopeid = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "', " & "ucltid = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "', " & "uwrttm = '" & GV_SysTime & "', " & "uwrtdt = '" & GV_SysDate & "', " & "pgid = '" & SSS_PrgId & "' " & "WHERE jdnno = '" & strJdnno & "' " & "AND linno = '" & strLINNO & "' "
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo SETJDNTRA_ERROR
		End If
		
		setJDNTRA = True
		Exit Function
		
SETJDNTRA_ERROR: 
		Call SSSWIN_LOGWRT("setJDNTRA_ERROR")
		
	End Function
	
	'売上トラン（入金伝票）の入金額・消込済金額に更新を行う
	Private Function setUDNTRA_NYUKN() As Boolean
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		'UPGRADE_WARNING: 構造体 Usr_Ody2 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody2 As U_Ody
		'UPGRADE_WARNING: 構造体 Usr_Ody3 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody3 As U_Ody
		
		
		Dim strOkrjono As String '送り状��(受注番号)
		
		Dim strJdnno As String '消込トラン.受注番号
		Dim strJdnlinno As String '消込トラン.受注行番号
		Dim strTEGDT As String '消込トラン.手形期日
		Dim strUPDID As String '消込トラン.更新用インデックス
		
		Dim strJdntrkb As String '受注見出しトラン.受注取引区分
		
		
		
		Dim wkZankn As Decimal
		
		
		On Error GoTo setUDNTRA_NYUKN_ERROR
		
		
		
		setUDNTRA_NYUKN = False
		
		'今回作成された消込トランの取得
		strSql = ""
		strSql = strSql & " SELECT  NKS.JDNNO AS JDNNO"
		strSql = strSql & "     ,   NKS.JDNLINNO AS JDNLINNO"
		strSql = strSql & "     ,   NKS.UPDID AS UPDID"
		strSql = strSql & "     ,   NKS.TEGDT AS TEGDT"
		strSql = strSql & "     ,   JDN.JDNTRKB AS JDNTRKB"
		strSql = strSql & " FROM   NKSTRA NKS"
		strSql = strSql & "  ,     JDNTHA JDN"
		strSql = strSql & " WHERE   NKS.WRTDT   =   '" & GV_SysDate & "'"
		strSql = strSql & "  AND    NKS.WRTTM   =   '" & GV_SysTime & "'"
		strSql = strSql & "  AND    NKS.OPEID   =   '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSql = strSql & "  AND    NKS.UCLTID  =   '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSql = strSql & "  AND    NKS.UWRTDT  =   '" & GV_SysDate & "'"
		strSql = strSql & "  AND    NKS.UWRTTM  =   '" & GV_SysTime & "'"
		strSql = strSql & "  AND    NKS.UOPEID  =   '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
		strSql = strSql & "  AND    NKS.UCLTID  =   '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
		strSql = strSql & "  AND    NKS.JDNDATNO = JDN.DATNO "
		strSql = strSql & "GROUP BY  NKS.JDNNO , NKS.JDNLINNO , NKS.UPDID , NKS.TEGDT ,JDN.JDNTRKB"
		
		
		'ﾃﾞｰﾀ取得
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		Do While CF_Ora_EOF(Usr_Ody) = False
			
			
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJdnno = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJdnlinno = VB6.Format(SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), "000")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strUPDID = CF_Ora_GetDyn(Usr_Ody, "UPDID", "")
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strJdntrkb = VB6.Format(SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")), "00")
			
			
			
			'受注番号＋行番号を送り状�ｂﾖ変換
			'システム・セットアップ受注の場合は行番号を「001」とする
			If strJdntrkb = "11" Or strJdntrkb = "21" Then
				strOkrjono = Trim(strJdnno) & "001"
			Else
				strOkrjono = Trim(strJdnno) & Trim(strJdnlinno)
			End If
			
			
			'該当する入金伝票の取得
			'**** 2009/09/16 CHG START FKS)NAKATA
			'分納対応
			'                        strSql = strSql & "SELECT   SUM(URIKN + UZEKN)  -   SUM(JKESIKN) ZANKN"
			'                        strSql = strSql & "  FROM   UDNTRA"
			'                        strSql = strSql & " WHERE   DATKB       =   '1'"
			'                        strSql = strSql & "   AND   IRISU       <>  '9'"
			'                        strSql = strSql & "   AND   JDNNO       =  '" & Trim(strJdnno) & "'"
			'
			'                        'セットアップ・システム以外の場合は、明細行にて検索する。
			'                        If strJdntrkb = "11" Or strJdntrkb = "21" Then
			'                        Else
			'                            strSql = strSql & "   AND   JDNLINNO    =  '" & Trim(strJdnlinno) & "'"
			'                        End If
			
			strSql = "" & vbCrLf
			strSql = strSql & "SELECT NYU.NYUKN - UDN.KESIKN AS ZANKN" & vbCrLf
			strSql = strSql & "FROM  " & vbCrLf
			strSql = strSql & " (" & vbCrLf
			strSql = strSql & "     SELECT  SUM(NYUKN) AS NYUKN" & vbCrLf
			strSql = strSql & "       FROM  UDNTRA" & vbCrLf
			strSql = strSql & "      WHERE  OKRJONO = '" & strOkrjono & "'" & vbCrLf
			strSql = strSql & "        AND  DATKB   = '1'" & vbCrLf
			strSql = strSql & "        AND  DENKB   = '8'" & vbCrLf
			strSql = strSql & "        AND  DKBID   != '09'" & vbCrLf
			strSql = strSql & " ) NYU" & vbCrLf
			strSql = strSql & " ," & vbCrLf
			strSql = strSql & " (" & vbCrLf
			strSql = strSql & " SELECT   SUM(JKESIKN) AS KESIKN" & vbCrLf
			strSql = strSql & "   FROM   UDNTRA" & vbCrLf
			strSql = strSql & "  WHERE   DATKB       =   '1'" & vbCrLf
			strSql = strSql & "    AND   IRISU       <>  '9'" & vbCrLf
			strSql = strSql & "    AND   JDNNO       =  '" & Trim(strJdnno) & "'" & vbCrLf
			'セットアップ・システム以外の場合は、明細行にて検索する。
			If strJdntrkb = "11" Or strJdntrkb = "21" Then
			Else
				strSql = strSql & "AND   JDNLINNO    =  '" & Trim(strJdnlinno) & "'"
			End If
			strSql = strSql & " )UDN" & vbCrLf
			'**** 2009/09/16 CHG E.N.D FKS)NAKATA
			
			
			'DBアクセス
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSql)
			
			If CF_Ora_EOF(Usr_Ody2) = False Then
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				wkZankn = SSSVal(CF_Ora_GetDyn(Usr_Ody2, "ZANKN", ""))
			End If
			
			Call CF_Ora_CloseDyn(Usr_Ody2) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
			
			
			'更新結果により再度売上UPDATEを実施
			strSql = " "
			strSql = strSql & " UPDATE UDNTRA SET "
			
			'入金額−消込金額が「0」の場合
			If wkZankn = 0 Then
				strSql = strSql & " KESIKB = '1' " '充当完了
			Else
				strSql = strSql & " KESIKB = '9' " '充当未完了
			End If
			
			strSql = strSql & " ,UOPEID  =   '" & CF_Ora_String(SSS_OPEID.Value, 8) & "'"
			strSql = strSql & " ,UCLTID  =   '" & CF_Ora_String(SSS_CLTID.Value, 5) & "'"
			strSql = strSql & " ,UWRTTM  =   '" & GV_SysTime & "'"
			strSql = strSql & " ,UWRTDT  =   '" & GV_SysDate & "'"
			strSql = strSql & " ,PGID    =   '" & SSS_PrgId & "'"
			strSql = strSql & "  WHERE  OKRJONO =   '" & strOkrjono & "'"
			strSql = strSql & "   AND   DATKB   =  '1'"
			strSql = strSql & "   AND   DENKB   =  '8'"
			strSql = strSql & "   AND   DKBID  !=  '09'"
			
			
			'SQL実行
			If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
				GoTo setUDNTRA_NYUKN_ERROR
			End If
			
			
			'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Usr_Ody.Obj_Ody.MoveNext()
			
		Loop 
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		
		setUDNTRA_NYUKN = True
		Exit Function
		
		
setUDNTRA_NYUKN_ERROR: 
		Call SSSWIN_LOGWRT("setUDNTRA_NYUKN_ERROR")
		
	End Function
	
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function GET_SYSTBA_NOGET
	'   概要：  ＤＡＴＮＯ／ＲＥＣＮＯを取得
	'   引数：　pot_DATNO  : ＤＡＴＮＯ
	'       ：　pot_RECNO  : ＲＥＣＮＯ
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function GET_SYSTBA_NOGET(ByRef pot_DATNO As String, ByRef pot_RECNO As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_GET_SYSTBA_NOGET
		
		GET_SYSTBA_NOGET = 9
		
		strSql = ""
		strSql = strSql & "Select"
		strSql = strSql & " DATNO"
		strSql = strSql & ",RECNO"
		strSql = strSql & " From SYSTBA"
		strSql = strSql & " Where USRID  = '001'"
		
		strSql = strSql & " FOR UPDATE "
		
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_RECNO = CF_Ora_GetDyn(Usr_Ody, "RECNO", "")
			GET_SYSTBA_NOGET = 0
			
			GoTo END_GET_SYSTBA_NOGET
		End If
		
		GET_SYSTBA_NOGET = 0
		
END_GET_SYSTBA_NOGET: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_GET_SYSTBA_NOGET: 
		GoTo END_GET_SYSTBA_NOGET
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SYSTBA_Update
	'   概要：  管理番号更新処理
	'   引数：  pin_strDATNO : ＤＡＴＮＯ
	'       ：  pin_strRECNO : ＲＥＣＮＯ
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBA_Update(ByVal pin_strDATNO As String, ByVal pin_strRECNO As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBA_Update_ERROR
		
		F_SYSTBA_Update = 9
		
		'管理番号更新処理
		strSql = ""
		strSql = strSql & vbCrLf & "Update SYSTBA Set"
		strSql = strSql & vbCrLf & " DATNO  = " & "'" & pin_strDATNO & "'" 'ＤＡＴＮＯ
		strSql = strSql & vbCrLf & ",RECNO  = " & "'" & pin_strRECNO & "'" 'ＲＥＣＮＯ
		strSql = strSql & vbCrLf & ",WRTTM  = " & "'" & GV_SysTime & "'" 'タイムスタンプ（時間）
		strSql = strSql & vbCrLf & ",WRTDT  = " & "'" & GV_SysDate & "'" 'タイムスタンプ（日付）
		strSql = strSql & vbCrLf & " Where USRID  = '001'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
		If bolRet = False Then
			GoTo F_SYSTBA_Update_ERROR
		End If
		
		F_SYSTBA_Update = 0
		
F_SYSTBA_Update_END: 
		Exit Function
		
F_SYSTBA_Update_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET73_E_034, Main_Inf, "F_SYSTBA_Update")
		GoTo F_SYSTBA_Update_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SYSTBC_Update
	'   概要：  伝票番号更新処理
	'   引数：  pin_strDKBSB : 伝票区分
	'   　　：  pin_strDENNO : 消込伝票番号
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBC_Update(ByVal pin_strDKBSB As String, ByVal pin_strDENNO As String) As Short
		
		Dim strSql As String
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBC_Update_ERROR
		
		F_SYSTBC_Update = 9
		
		'更新
		strSql = ""
		strSql = strSql & vbCrLf & "Update SYSTBC Set"
		strSql = strSql & vbCrLf & " DENNO    = " & "'" & pin_strDENNO & "'" '消込伝票番号
		strSql = strSql & vbCrLf & ",OPEID    = " & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '最終作業者コード
		strSql = strSql & vbCrLf & ",CLTID    = " & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" 'クライアントＩＤ
		strSql = strSql & vbCrLf & ",WRTTM  = " & "'" & GV_SysTime & "'" 'タイムスタンプ（時間）
		strSql = strSql & vbCrLf & ",WRTDT  = " & "'" & GV_SysDate & "'" 'タイムスタンプ（日付）
		strSql = strSql & vbCrLf & " Where DKBSB    = " & "'" & pin_strDKBSB & "'"
		strSql = strSql & vbCrLf & "   And ADDDENCD = " & "'" & New String(" ", 13) & "'"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
		If bolRet = False Then
			GoTo F_SYSTBC_Update_ERROR
		End If
		
		F_SYSTBC_Update = 0
		
F_SYSTBC_Update_END: 
		Exit Function
		
F_SYSTBC_Update_ERROR: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET73_E_034, Main_Inf, "F_SYSTBC_Update")
		GoTo F_SYSTBC_Update_END
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UPDATE_SUB
	'   概要：  更新処理サブ（入金差額登録データ）
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_UPDATE_SUB() As Short
		
		Dim lngI As Integer
		Dim strUDNNO As String
		Dim strDATNO As String
		Dim strRECNO As String
		Dim strSSADT As String
		Dim strSMADT As String
		Dim curNYUKN As Decimal
		
		On Error GoTo F_UPDATE_SUB_ERROR
		
		F_UPDATE_SUB = 9
		
		'Call CF_Get_SysDt
		
		'現在時刻、日付をセット
		Call setSysdate(GV_SysTime, GV_SysDate)
		
		'売上伝票番号取得
		If GET_SYSTBC_DENNO2(gc_DKBSB_NKN, strUDNNO) <> 0 Then
			Exit Function
		End If
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		
		
		'管理ＮＯ取得
		Call GET_SYSTBA_NOGET(strDATNO, strRECNO)
		strDATNO = VB6.Format(CDec(strDATNO) + 1, "0000000000")
		
		
		curNYUKN = 0
		
		For lngI = 0 To 2
			'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(gtypeFR_SUB(lngI).SUB_DKBID) <> "" Then
				
				'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				curNYUKN = curNYUKN + SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN)
				
				'売上明細登録（入金レコード）
				strRECNO = VB6.Format(CDec(strRECNO) + 1, "0000000000")
				strSMADT = DeCNV_DATE(Get_Acedt(gstrKesidt.Value))
				'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If F_UDNTRA_Insert_SAGAKU(strDATNO, strRECNO, strUDNNO, VB6.Format(lngI + 1, "000"), strSMADT, CDec(gtypeFR_SUB(lngI).SUB_NYUKN)) = 9 Then GoTo F_UPDATE_SUB_ERROR
				
				'請求サマリ更新（入金額）
				strSSADT = DB_TOKMTA.KESISMEDT
				'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If F_TOKSSB_Update_SAGAKU(DB_TOKMTA.TOKSEICD, gtypeFR_SUB(lngI).SUB_UPDID, SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN), strSSADT) = 9 Then GoTo F_UPDATE_SUB_ERROR
				
				'TOKSMEの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
				If DB_TOKMTA.SHAKB = "5" Or DB_TOKMTA.SHAKB = "6" Then
				Else
					'売掛サマリ請求更新（邦貨入金額)
					'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If F_TOKSME_Update_SAGAKU(DB_TOKMTA.TOKSEICD, gtypeFR_SUB(lngI).SUB_UPDID, SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN), strSMADT) = 9 Then GoTo F_UPDATE_SUB_ERROR
				End If
				
				
				'入金消込サマリ更新（入金集計金額）
				'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If F_NKSSMB_SSA_Update(DB_TOKMTA.TOKSEICD, gtypeFR_SUB(lngI).SUB_UPDID, SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN), strSMADT) = 9 Then GoTo F_UPDATE_SUB_ERROR
				
				
			End If
		Next 
		
		'売上ヘッダ登録（入金レコード）
		If F_UDNTHA_Insert_SAGAKU(strDATNO, strUDNNO, curNYUKN) = 9 Then GoTo F_UPDATE_SUB_ERROR
		
		'管理ＮＯ更新
		If F_SYSTBA_Update(strDATNO, strRECNO) = 9 Then GoTo F_UPDATE_SUB_ERROR
		
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		
		'    If gc_CONTROL = "1" Then Debug.Print "SUB  -----------------------------------------"
		F_UPDATE_SUB = 1
		Exit Function
		
F_UPDATE_SUB_ERROR: 
		'ロールバック
		Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		Call SSSWIN_LOGWRT("F_UPDATE_SUB_ERROR")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTHA_Insert_SAGAKU
	'   概要：  売上ヘッダ追加処理（差額入金用）
	'   引数：  pin_DATNO  : 伝票管理No
	'           pin_DENNO  : 伝票番号
	'           pin_NYUKN  : 入金集計金額
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTHA_Insert_SAGAKU(ByVal pin_DATNO As String, ByVal pin_DENNO As String, ByVal pin_NYUKN As Decimal) As Short
		Dim strSql As String
		Dim bolRet As Boolean
		Dim intRet As Short
		Dim strKEIBUMCD As String
		
		On Error GoTo F_UDNTHA_Insert_SAGAKU_ERROR
		
		F_UDNTHA_Insert_SAGAKU = 9
		
		'経理部門コードを取得
		Call GET_TANMTA_KEIBMNCD(DB_TOKMTA.TANCD, strKEIBUMCD)
		
		strSql = ""
		strSql = strSql & "Insert Into UDNTHA"
		strSql = strSql & vbCrLf & "(DATNO" ' 1.伝票管理��
		strSql = strSql & vbCrLf & ",DATKB" ' 2.伝票削除区分
		strSql = strSql & vbCrLf & ",AKAKROKB" ' 3.赤黒区分
		strSql = strSql & vbCrLf & ",DENKB" ' 4.伝票区分
		strSql = strSql & vbCrLf & ",UDNNO" ' 5.売上伝票番号
		strSql = strSql & vbCrLf & ",FDNNO" ' 6.納品書番号
		strSql = strSql & vbCrLf & ",JDNNO" ' 7.受注伝票番号
		strSql = strSql & vbCrLf & ",USDNO" ' 8.直送伝票番号
		strSql = strSql & vbCrLf & ",UDNDT" ' 9.売上伝票日付
		strSql = strSql & vbCrLf & ",DENDT" '10.売上日付
		strSql = strSql & vbCrLf & ",REGDT" '11.初回伝票日付
		strSql = strSql & vbCrLf & ",TOKCD" '12.得意先コード
		strSql = strSql & vbCrLf & ",TOKRN" '13.得意先略称
		strSql = strSql & vbCrLf & ",NHSCD" '14.納入先コード
		strSql = strSql & vbCrLf & ",NHSRN" '15.納入先略称
		strSql = strSql & vbCrLf & ",NHSNMA" '16.納入先名称１
		strSql = strSql & vbCrLf & ",NHSNMB" '17.納入先名称２
		strSql = strSql & vbCrLf & ",TANCD" '18.担当者コード
		strSql = strSql & vbCrLf & ",TANNM" '19.担当者名
		strSql = strSql & vbCrLf & ",BUMCD" '20.部門コード
		strSql = strSql & vbCrLf & ",BUMNM" '21.部門名
		strSql = strSql & vbCrLf & ",TOKSEICD" '22.請求先コード
		strSql = strSql & vbCrLf & ",SOUCD" '23.倉庫コード
		strSql = strSql & vbCrLf & ",SOUNM" '24.倉庫名
		strSql = strSql & vbCrLf & ",NXTKB" '25.帳端区分
		strSql = strSql & vbCrLf & ",NXTNM" '26.帳端名称
		strSql = strSql & vbCrLf & ",EMGODNKB" '27.緊急出荷区分
		strSql = strSql & vbCrLf & ",OKRJONO" '28.送り状��
		strSql = strSql & vbCrLf & ",INVNO" '29.インボイス��
		strSql = strSql & vbCrLf & ",SMADT" '30.経理締日付
		strSql = strSql & vbCrLf & ",SSADT" '31.締日付
		strSql = strSql & vbCrLf & ",KESDT" '32.決済日付
		strSql = strSql & vbCrLf & ",NYUCD" '33.入金区分
		strSql = strSql & vbCrLf & ",ZKTKB" '34.取引区分
		strSql = strSql & vbCrLf & ",ZKTNM" '35.取引名称
		strSql = strSql & vbCrLf & ",KENNMA" '36.件名１
		strSql = strSql & vbCrLf & ",KENNMB" '37.件名２
		strSql = strSql & vbCrLf & ",NHSADA" '38.納入先住所１
		strSql = strSql & vbCrLf & ",NHSADB" '39.納入先住所２
		strSql = strSql & vbCrLf & ",NHSADC" '40.納入先住所３
		strSql = strSql & vbCrLf & ",MAEUKNM" '41.前受区分名称
		strSql = strSql & vbCrLf & ",KEIBUMCD" '42.経理部門コード
		strSql = strSql & vbCrLf & ",UPFKB" '43.売上同時出荷区分
		strSql = strSql & vbCrLf & ",SBAURIKN" '44.売上金額(本体合計)
		strSql = strSql & vbCrLf & ",SBAUZEKN" '45.売上金額(消費税)
		strSql = strSql & vbCrLf & ",SBAUZKKN" '46.売上金額(伝票計)
		strSql = strSql & vbCrLf & ",SBAFRUKN" '47.外貨売上金額(伝票計)
		strSql = strSql & vbCrLf & ",SBANYUKN" '48.入金金額(伝票計)
		strSql = strSql & vbCrLf & ",SBAFRNKN" '49.外貨入金額(伝票計)
		strSql = strSql & vbCrLf & ",DENCM" '50.備考
		strSql = strSql & vbCrLf & ",DENCMIN" '51.社内備考
		strSql = strSql & vbCrLf & ",TOKSMEKB" '52.締区分
		strSql = strSql & vbCrLf & ",TOKSMEDD" '53.締初期日付（売上）
		strSql = strSql & vbCrLf & ",TOKSMECC" '54.締サイクル（売上）
		strSql = strSql & vbCrLf & ",TOKSDWKB" '55.締曜日
		strSql = strSql & vbCrLf & ",TOKKESCC" '56.回収サイクル
		strSql = strSql & vbCrLf & ",TOKKESDD" '57.回収日付
		strSql = strSql & vbCrLf & ",TOKKDWKB" '58.回収曜日
		strSql = strSql & vbCrLf & ",LSTID" '59.伝票種別
		strSql = strSql & vbCrLf & ",TOKJUNKB" '60.順位表出力区分
		strSql = strSql & vbCrLf & ",TOKMSTKB" '61.マスタ区分（得意先）
		strSql = strSql & vbCrLf & ",TKNRPSKB" '62.金額端数処理桁数
		strSql = strSql & vbCrLf & ",TKNZRNKB" '63.金額端数処理区分
		strSql = strSql & vbCrLf & ",TOKZEIKB" '64.消費税区分
		strSql = strSql & vbCrLf & ",TOKZCLKB" '65.消費税算出区分
		strSql = strSql & vbCrLf & ",TOKRPSKB" '66.消費税端数処理桁数
		strSql = strSql & vbCrLf & ",TOKZRNKB" '67.消費税端数処理区分
		strSql = strSql & vbCrLf & ",TOKNMMKB" '68.名称マニュアル区分
		strSql = strSql & vbCrLf & ",NHSMSTKB" '69.マスタ区分（納入先）
		strSql = strSql & vbCrLf & ",NHSNMMKB" '70.名称マニュアル区分
		strSql = strSql & vbCrLf & ",TANMSTKB" '71.マスタ区分（担当者）
		strSql = strSql & vbCrLf & ",URIKJN" '72.売上基準
		strSql = strSql & vbCrLf & ",MAEUKKB" '73.前受区分
		strSql = strSql & vbCrLf & ",SEIKB" '74.請求区分
		strSql = strSql & vbCrLf & ",JDNTRKB" '75.受注取引区分
		strSql = strSql & vbCrLf & ",TUKKB" '76.通貨区分
		strSql = strSql & vbCrLf & ",FRNKB" '77.海外取引区分
		strSql = strSql & vbCrLf & ",UDNPRAKB" '78.納品書発行区分
		strSql = strSql & vbCrLf & ",UDNPRBKB" '79.個別請求発行区分
		strSql = strSql & vbCrLf & ",MOTDATNO" '80.元伝票管理番号
		strSql = strSql & vbCrLf & ",FOPEID" '81
		strSql = strSql & vbCrLf & ",FCLTID" '82
		strSql = strSql & vbCrLf & ",WRTFSTTM" '83
		strSql = strSql & vbCrLf & ",WRTFSTDT" '84
		strSql = strSql & vbCrLf & ",OPEID" '85
		strSql = strSql & vbCrLf & ",CLTID" '86
		strSql = strSql & vbCrLf & ",WRTTM" '87
		strSql = strSql & vbCrLf & ",WRTDT" '88
		strSql = strSql & vbCrLf & ",UOPEID" '89
		strSql = strSql & vbCrLf & ",UCLTID" '90
		strSql = strSql & vbCrLf & ",UWRTTM" '91
		strSql = strSql & vbCrLf & ",UWRTDT" '92
		strSql = strSql & vbCrLf & ",PGID" '93
		strSql = strSql & vbCrLf & ",DLFLG)" '94
		'
		strSql = strSql & vbCrLf & " Values"
		strSql = strSql & vbCrLf & "(" & "'" & pin_DATNO & "'" ' 1.DATNO
		strSql = strSql & vbCrLf & "," & "'" & "1" & "'" ' 2.DATKB
		strSql = strSql & vbCrLf & "," & "'" & "1" & "'" ' 3.AKAKROKB
		strSql = strSql & vbCrLf & "," & "'" & "8" & "'" ' 4.DENKB
		strSql = strSql & vbCrLf & "," & "'" & pin_DENNO & "'" ' 5.UDNNO
		strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" ' 6.FDNNO
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" ' 7.JDNNO
		strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" ' 8.USDNO
		strSql = strSql & vbCrLf & "," & "'" & gstrKesidt.Value & "'" ' 9.UDNDT
		strSql = strSql & vbCrLf & "," & "'" & gstrUnydt.Value & "'" '10.DENDT
		strSql = strSql & vbCrLf & "," & "'" & gstrKesidt.Value & "'" '11.REGDT
		'   strSQL = strSQL & vbCrLf & "," & "'" & DeCNV_DATE(FR_SSSMAIN.HD_KESIDT) & "'"       ' 9.UDNDT
		'   strSQL = strSQL & vbCrLf & "," & "'" & GV_UNYDate & "'"                             '10.DENDT
		'   strSQL = strSQL & vbCrLf & "," & "'" & DeCNV_DATE(FR_SSSMAIN.HD_KESIDT) & "'"       '11.REGDT
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSEICD & "'" '12.TOKCD
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(DB_TOKMTA.TOKRN, 40) & "'" '13.TOKRN
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_SEICD & "'"                    '12.TOKCD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_SEINM & "'"                    '13.TOKRN
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '14.NHSCD
		strSql = strSql & vbCrLf & "," & "'" & Space(40) & "'" '15.NHSRN
		strSql = strSql & vbCrLf & "," & "'" & Space(60) & "'" '16.NHSNMA
		strSql = strSql & vbCrLf & "," & "'" & Space(60) & "'" '17.NHSNHB
		strSql = strSql & vbCrLf & "," & "'" & Space(6) & "'" '18.TANCD
		strSql = strSql & vbCrLf & "," & "'" & Space(40) & "'" '19.TANNM
		strSql = strSql & vbCrLf & "," & "'" & Space(6) & "'" '20.BUMCD
		strSql = strSql & vbCrLf & "," & "'" & Space(40) & "'" '21.BUMNM
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSEICD & "'" '22.TOKSEICD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_SEICD & "'"                    '22.TOKSEICD
		strSql = strSql & vbCrLf & "," & "'" & Space(3) & "'" '23.SOUCD
		strSql = strSql & vbCrLf & "," & "'" & Space(20) & "'" '24.SOUNM
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '25.NXTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '26.NXTNM
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '27.EMGODNKB
		strSql = strSql & vbCrLf & "," & "'" & Space(15) & "'" '28.OKRJONO
		strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" '29.INVNO
		strSql = strSql & vbCrLf & "," & "'" & DeCNV_DATE(Get_Acedt(gstrKesidt.Value)) & "'" '30.SMADT
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.KESISMEDT & "'" '31.SSADT
		strSql = strSql & vbCrLf & "," & "'" & getKesdt(DB_TOKMTA.TOKSMEKB, DB_TOKMTA.TOKSMEDT, DB_TOKMTA.TOKSMECC, DB_TOKMTA.TOKSDWKB, DB_TOKMTA.TOKKESCC, DB_TOKMTA.TOKKESDD, DB_TOKMTA.TOKKDWKB, DB_TOKMTA.KESISMEDT) & "'" '32.KESDT
		'   strSql = strSql & vbCrLf & "," & "'" & DeCNV_DATE(Get_Acedt(FR_SSSMAIN.HD_KESIDT)) & "'"    '30.SMADT
		'   strSql = strSql & vbCrLf & "," & "'" & DeCNV_DATE(Get_Acedt(FR_SSSMAIN.HD_KESIDT)) & "'"    '31.SSADT
		'   strSql = strSql & vbCrLf & "," & "'" & DeCNV_DATE(Get_Acedt(FR_SSSMAIN.HD_KESIDT)) & "'"    '32.KESDT
		strSql = strSql & vbCrLf & "," & "'" & "1" & "'" '33.NYUCD
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '34.ZKTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(4) & "'" '35.ZKTNM
		strSql = strSql & vbCrLf & "," & "'" & Space(40) & "'" '36.KENNMA
		strSql = strSql & vbCrLf & "," & "'" & Space(40) & "'" '37.KENNMB
		strSql = strSql & vbCrLf & "," & "'" & Space(60) & "'" '38.NHSADA
		strSql = strSql & vbCrLf & "," & "'" & Space(60) & "'" '39.NHSADB
		strSql = strSql & vbCrLf & "," & "'" & Space(60) & "'" '40.NHSADC
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '41.MAEUKNM
		strSql = strSql & vbCrLf & "," & "'" & strKEIBUMCD & "'" '42.KEIBUMCD
		'   strSql = strSql & vbCrLf & "," & "'" & FR_SSSMAIN.HD_KEIBUMCD & "'"                 '42.KEIBUMCD
		strSql = strSql & vbCrLf & "," & "'" & "1" & "'" '43.UPFKB
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '44.SBAURIKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '45.SBAUZEKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '46.SBAUZKKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '47.SBAFRUKN
		strSql = strSql & vbCrLf & "," & "'" & pin_NYUKN & "'" '48.SBANYUKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '49.SBAFRNKN
		strSql = strSql & vbCrLf & "," & "'" & Space(40) & "'" '50.DENCM
		strSql = strSql & vbCrLf & "," & "'" & Space(40) & "'" '51.DENCMIN
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSMEKB & "'" '52.TOKSMEKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSMEDD & "'" '53.TOKSMEDD
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSMECC & "'" '54.TOKSMECC
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSDWKB & "'" '55.TOKSDWKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKKESCC & "'" '56.TOKKESCC
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKKESDD & "'" '57.TOKKESDD
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKKDWKB & "'" '58.TOKKDWKB
		strSql = strSql & vbCrLf & "," & "'" & Space(7) & "'" '59.LSTID
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKJUNKB & "'" '60.TOKJUNKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKMSTKB & "'" '61.TOKMSTKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TKNRPSKB & "'" '62.TKNRPSKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TKNZRNKB & "'" '63.TKNZRNKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKZEIKB & "'" '64.TOKZEIKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKZCLKB & "'" '65.TOKZCLKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKRPSKB & "'" '66.TOKRPSKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKZRNKB & "'" '67.TOKZRNKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKNMMKB & "'" '68.TOKNMMKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKSMEKB & "'"                 '52.TOKSMEKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKSMEDD & "'"                 '53.TOKSMEDD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKSMECC & "'"                 '54.TOKSMECC
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKSDWKB & "'"                 '55.TOKSDWKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKKESCC & "'"                 '56.TOKKESCC
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKKESDD & "'"                 '57.TOKKESDD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKKDWKB & "'"                 '58.TOKKDWKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & Space(7) & "'"                               '59.LSTID
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKJUNKB & "'"                 '60.TOKJUNKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKMSTKB & "'"                 '61.TOKMSTKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TKNRPSKB & "'"                 '62.TKNRPSKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TKNZRNKB & "'"                 '63.TKNZRNKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKZEIKB & "'"                 '64.TOKZEIKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKZCLKB & "'"                 '65.TOKZCLKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKRPSKB & "'"                 '66.TOKRPSKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKZRNKB & "'"                 '67.TOKZRNKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TOKNMMKB & "'"                 '68.TOKNMMKB
		strSql = strSql & vbCrLf & "," & "'" & "2" & "'" '69.NHSMSTKB
		strSql = strSql & vbCrLf & "," & "'" & "9" & "'" '70.NHSNMMKB
		strSql = strSql & vbCrLf & "," & "'" & "3" & "'" '71.TANMSTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '72.URIKJN
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '73.MAEUKKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '74.SEIKB
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '75.JDNTRKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TUKKB & "'" '76.TUKKB
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.FRNKB & "'" '77.FRNKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TUKKB & "'"                    '76.TUKKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_FRNKB & "'"                    '77.FRNKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '78.UDNPRAKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '79.UDNPRBKB
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '80.MOTDATNO
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '81.FOPEID
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" '82.FCLTID
		strSql = strSql & vbCrLf & "," & "'" & GV_SysTime & "'" '83.WRTFSTTM
		strSql = strSql & vbCrLf & "," & "'" & GV_SysDate & "'" '84.WRTFSTDT
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '85.OPEID
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" '86.CLTID
		strSql = strSql & vbCrLf & "," & "'" & GV_SysTime & "'" '87.WRTTM
		strSql = strSql & vbCrLf & "," & "'" & GV_SysDate & "'" '88.WRTDT
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '89.UOPEID
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" '90.UCLTID
		strSql = strSql & vbCrLf & "," & "'" & GV_SysTime & "'" '91.UWRTTM
		strSql = strSql & vbCrLf & "," & "'" & GV_SysDate & "'" '92.UWRTDT
		strSql = strSql & vbCrLf & "," & "'" & SSS_PrgId & "'" '93.PGID
		strSql = strSql & vbCrLf & "," & "'" & "2" & "'" '94.DLFLG
		strSql = strSql & vbCrLf & ")"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
		If bolRet = False Then
			GoTo F_UDNTHA_Insert_SAGAKU_ERROR
		End If
		
		F_UDNTHA_Insert_SAGAKU = 0
		Exit Function
		
F_UDNTHA_Insert_SAGAKU_ERROR: 
		Call SSSWIN_LOGWRT("F_UDNTHA_Insert_SAGAKU_ERROR")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTRA_Insert_SAGAKU
	'   概要：  売上トラン追加処理（差額入金用）
	'   引数：  pin_DATNO  : 伝票管理No
	'           pin_RECNO  : レコード管理No
	'           pin_DENNO  : 売上伝票番号
	'           pin_LINNO  : 行番号
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_Insert_SAGAKU(ByVal pin_DATNO As String, ByVal pin_RECNO As String, ByVal pin_DENNO As String, ByVal pin_LINNO As String, ByVal pin_SMADT As String, ByVal pin_NYUKN As Decimal) As Short
		Dim strSql As String
		Dim bolRet As Boolean
		Dim intRet As Short
		Dim strLINCMA As String
		Dim strNYUKB As String
		
		On Error GoTo F_UDNTRA_Insert_SAGAKU_ERROR
		
		F_UDNTRA_Insert_SAGAKU = 9
		
		If DB_TOKMTA.SHAKB = "5" Or DB_TOKMTA.SHAKB = "6" Then
			strNYUKB = "2"
		Else
			strNYUKB = "1"
		End If
		
		
		strSql = ""
		strSql = strSql & "Insert Into UDNTRA "
		strSql = strSql & vbCrLf & "(DATNO" ' 1.伝票管理��
		strSql = strSql & vbCrLf & ",DATKB" ' 2.伝票削除区分
		strSql = strSql & vbCrLf & ",AKAKROKB" ' 3.赤黒区分
		strSql = strSql & vbCrLf & ",DENKB" ' 4.伝票区分
		strSql = strSql & vbCrLf & ",UDNNO" ' 5.売上伝票番号
		strSql = strSql & vbCrLf & ",LINNO" ' 6.行番号
		strSql = strSql & vbCrLf & ",ZKTKB" ' 7.取引区分
		strSql = strSql & vbCrLf & ",ODNNO" ' 8.出荷伝票番号
		strSql = strSql & vbCrLf & ",ODNLINNO" ' 9.行番号
		strSql = strSql & vbCrLf & ",JDNNO" '10.受注伝票番号
		strSql = strSql & vbCrLf & ",JDNLINNO" '11.受注伝票行番号
		strSql = strSql & vbCrLf & ",RECNO" '12.レコード管理��
		strSql = strSql & vbCrLf & ",USDNO" '13.直送伝票番号
		strSql = strSql & vbCrLf & ",UDNDT" '14.売上伝票日付
		strSql = strSql & vbCrLf & ",DKBSB" '15.伝票取引区分種別
		strSql = strSql & vbCrLf & ",DKBID" '16.取引区分コード
		strSql = strSql & vbCrLf & ",DKBNM" '17.取引区分名
		strSql = strSql & vbCrLf & ",HENRSNCD" '18.返品理由
		strSql = strSql & vbCrLf & ",HENSTTCD" '19.返品状態
		strSql = strSql & vbCrLf & ",SMADT" '20.経理締日付
		strSql = strSql & vbCrLf & ",SSADT" '21.締日付
		strSql = strSql & vbCrLf & ",KESDT" '22.決済日付
		strSql = strSql & vbCrLf & ",TOKCD" '23.受注数量
		strSql = strSql & vbCrLf & ",TANCD" '24.得意先コード
		strSql = strSql & vbCrLf & ",NHSCD" '25.納入先コード
		strSql = strSql & vbCrLf & ",TOKSEICD" '26.請求先コード
		strSql = strSql & vbCrLf & ",SOUCD" '27.倉庫コード
		strSql = strSql & vbCrLf & ",SBNNO" '28.製番
		strSql = strSql & vbCrLf & ",HINCD" '29.製品コード
		strSql = strSql & vbCrLf & ",TOKJDNNO" '30.客先注文番号
		strSql = strSql & vbCrLf & ",HINNMA" '31.型式
		strSql = strSql & vbCrLf & ",HINNMB" '32.商品名１
		strSql = strSql & vbCrLf & ",UNTCD" '33.単位コード
		strSql = strSql & vbCrLf & ",UNTNM" '34.単位名
		strSql = strSql & vbCrLf & ",IRISU" '35.入数
		strSql = strSql & vbCrLf & ",CASSU" '36.ケース数
		strSql = strSql & vbCrLf & ",URISU" '37.売上数量
		strSql = strSql & vbCrLf & ",URITK" '38.売上数量
		strSql = strSql & vbCrLf & ",GNKTK" '39.原価単価
		strSql = strSql & vbCrLf & ",SIKTK" '40.営業仕切単価
		strSql = strSql & vbCrLf & ",FURITK" '41.外貨単価
		strSql = strSql & vbCrLf & ",URIKN" '42.売上金額
		strSql = strSql & vbCrLf & ",FURIKN" '43.外貨売上金額
		strSql = strSql & vbCrLf & ",SIKKN" '44.営業仕切金額
		strSql = strSql & vbCrLf & ",UZEKN" '45.消費税金額
		strSql = strSql & vbCrLf & ",NYUDT" '46.入金日
		strSql = strSql & vbCrLf & ",NYUKN" '47.入金額
		strSql = strSql & vbCrLf & ",FNYUKN" '48.外貨入金額
		strSql = strSql & vbCrLf & ",GNKKN" '49.原価金額
		strSql = strSql & vbCrLf & ",JKESIKN" '50.消込金額
		strSql = strSql & vbCrLf & ",FKESIKN" '51.外貨消込金額
		strSql = strSql & vbCrLf & ",KESIKB" '52.消込区分
		strSql = strSql & vbCrLf & ",NYUKB" '53.入金種別
		strSql = strSql & vbCrLf & ",TNKID" '54.種別
		strSql = strSql & vbCrLf & ",TUKKB" '55.通貨区分
		strSql = strSql & vbCrLf & ",RATERT" '56.為替レート
		strSql = strSql & vbCrLf & ",EMGODNKB" '57.緊急出荷区分
		strSql = strSql & vbCrLf & ",OKRJONO" '58.送り状��
		strSql = strSql & vbCrLf & ",INVNO" '59.インボイス��
		strSql = strSql & vbCrLf & ",LINCMA" '60.明細備考１
		strSql = strSql & vbCrLf & ",LINCMB" '61.明細備考２
		strSql = strSql & vbCrLf & ",BNKCD" '62.銀行コード
		strSql = strSql & vbCrLf & ",BNKNM" '63.銀行名称
		strSql = strSql & vbCrLf & ",TEGNO" '64.手形番号
		strSql = strSql & vbCrLf & ",TEGDT" '65.手形期日
		strSql = strSql & vbCrLf & ",UPDID" '66.更新用インデックス
		strSql = strSql & vbCrLf & ",DFLDKBCD" '67.デフォルトコード
		strSql = strSql & vbCrLf & ",DKBZAIFL" '68.在庫関連フラグ
		strSql = strSql & vbCrLf & ",DKBTEGFL" '69.手形発生フラグ
		strSql = strSql & vbCrLf & ",DKBFLA" '70.ダミーフラグ１
		strSql = strSql & vbCrLf & ",DKBFLB" '71.ダミーフラグ２
		strSql = strSql & vbCrLf & ",DKBFLC" '72.ダミーフラグ３
		strSql = strSql & vbCrLf & ",LSTID" '73.伝票種別
		strSql = strSql & vbCrLf & ",HINZEIKB" '74.商品消費税区分
		strSql = strSql & vbCrLf & ",HINMSTKB" '75.マスタ区分（商品）
		strSql = strSql & vbCrLf & ",TOKMSTKB" '76.マスタ区分（得意先）
		strSql = strSql & vbCrLf & ",NHSMSTKB" '77.マスタ区分（納入先）
		strSql = strSql & vbCrLf & ",TANMSTKB" '78.マスタ区分（担当者）
		strSql = strSql & vbCrLf & ",ZEIRNKKB" '79.消費税ランク
		strSql = strSql & vbCrLf & ",HINKB" '80.商品区分
		strSql = strSql & vbCrLf & ",ZEIRT" '81.消費税率
		strSql = strSql & vbCrLf & ",ZAIKB" '82.在庫管理区分
		strSql = strSql & vbCrLf & ",MRPKB" '83.展開区分
		strSql = strSql & vbCrLf & ",HINJUNKB" '84.順位表出力区分
		strSql = strSql & vbCrLf & ",MAKCD" '85.メーカーコード
		strSql = strSql & vbCrLf & ",HINSIRCD" '86.商品仕入先コード
		strSql = strSql & vbCrLf & ",HINNMMKB" '87.名称マニュアル区分
		strSql = strSql & vbCrLf & ",HRTDD" '88.発注リードタイム
		strSql = strSql & vbCrLf & ",ORTDD" '89.出荷リードタイム
		strSql = strSql & vbCrLf & ",ZNKURIKN" '90.税抜課税対象額
		strSql = strSql & vbCrLf & ",ZKMURIKN" '91.税込課税対象額
		strSql = strSql & vbCrLf & ",ZKMUZEKN" '92.税込消費税
		strSql = strSql & vbCrLf & ",MOTDATNO" '93.元伝票管理番号
		strSql = strSql & vbCrLf & ",FOPEID" '94
		strSql = strSql & vbCrLf & ",FCLTID" '95
		strSql = strSql & vbCrLf & ",WRTFSTTM" '96
		strSql = strSql & vbCrLf & ",WRTFSTDT" '97
		strSql = strSql & vbCrLf & ",OPEID" '98
		strSql = strSql & vbCrLf & ",CLTID" '99
		strSql = strSql & vbCrLf & ",WRTTM" '100
		strSql = strSql & vbCrLf & ",WRTDT" '101
		strSql = strSql & vbCrLf & ",UOPEID" '102
		strSql = strSql & vbCrLf & ",UCLTID" '103
		strSql = strSql & vbCrLf & ",UWRTTM" '104
		strSql = strSql & vbCrLf & ",UWRTDT" '105
		strSql = strSql & vbCrLf & ",PGID" '106
		strSql = strSql & vbCrLf & ",DLFLG)" '107
		'
		strSql = strSql & vbCrLf & " Values"
		strSql = strSql & vbCrLf & "(" & "'" & pin_DATNO & "'" ' 1.DATNO
		strSql = strSql & vbCrLf & "," & "'" & "1" & "'" ' 2.DATKB
		strSql = strSql & vbCrLf & "," & "'" & "1" & "'" ' 3.AKAKROKB
		strSql = strSql & vbCrLf & "," & "'" & "8" & "'" ' 4.DENKB
		strSql = strSql & vbCrLf & "," & "'" & pin_DENNO & "'" ' 5.UDNNO
		strSql = strSql & vbCrLf & "," & "'" & pin_LINNO & "'" ' 6.LINNO
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" ' 7.ZKTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" ' 8.ODNNO
		strSql = strSql & vbCrLf & "," & "'" & Space(3) & "'" ' 9.ODNLINNO
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '10.JDNNO
		strSql = strSql & vbCrLf & "," & "'" & Space(3) & "'" '11.JDNLINNO
		strSql = strSql & vbCrLf & "," & "'" & pin_RECNO & "'" '12.RECNO
		strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" '13.USDNO
		strSql = strSql & vbCrLf & "," & "'" & gstrKesidt.Value & "'" '14.UDNDT   2007.03.05
		'    strSql = strSql & vbCrLf & "," & "'" & GV_UNYDate & "'"                     '14.UDNDT   2007.03.05
		strSql = strSql & vbCrLf & "," & "'" & gc_DKBSB_NKN & "'" '15.DKBSB
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DKBID & "'" '16.DKBID
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DKBNM, 6) & "'" '17.DKBNM
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DKBID(CLng(pin_LINNO) - 1) & "'"   '16.DKBID
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DKBNM(CLng(pin_LINNO) - 1) & "'"   '17.DKBNM
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '18.HENRSNCD
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '19.HENSTTCD
		strSql = strSql & vbCrLf & "," & "'" & pin_SMADT & "'" '20.SMADT
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.KESISMEDT & "'" '21.SSADT
		strSql = strSql & vbCrLf & "," & "'" & getKesdt(DB_TOKMTA.TOKSMEKB, DB_TOKMTA.TOKSMEDT, DB_TOKMTA.TOKSMECC, DB_TOKMTA.TOKSDWKB, DB_TOKMTA.TOKKESCC, DB_TOKMTA.TOKKESDD, DB_TOKMTA.TOKKDWKB, DB_TOKMTA.KESISMEDT) & "'" '22.KESDT
		'   strSql = strSql & vbCrLf & "," & "'" & pin_SMADT & "'"                      '21.SSADT
		'   strSql = strSql & vbCrLf & "," & "'" & pin_SMADT & "'"                      '22.KESDT
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSEICD & "'" '23.TOKCD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_SEICD & "'"            '23.TOKCD
		strSql = strSql & vbCrLf & "," & "'" & Space(6) & "'" '24.TANCD
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '25.NHSCD
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TOKSEICD & "'" '26.TOKSEICD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_SEICD & "'"            '26.TOKSEICD
		strSql = strSql & vbCrLf & "," & "'" & Space(3) & "'" '27.SOUCD
		strSql = strSql & vbCrLf & "," & "'" & Space(20) & "'" '28.SBNNO
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '29.HINCD
		strSql = strSql & vbCrLf & "," & "'" & Space(23) & "'" '30.TOKJDNNO
		strSql = strSql & vbCrLf & "," & "'" & Space(50) & "'" '31.HINNMA
		strSql = strSql & vbCrLf & "," & "'" & Space(50) & "'" '32.HINNMB
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '33.UNTCD
		strSql = strSql & vbCrLf & "," & "'" & Space(4) & "'" '34.UNTNM
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '35.IRISU
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '36.CASSU
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '37.URISU
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '38.URITK
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '39.GNKTK
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '40.SIKTK
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '41.FURITK
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '42.URIKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '43.FURIKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '44.SIKKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '45.UZEKN
		'更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
		If DB_TOKMTA.SHAKB = "5" Or DB_TOKMTA.SHAKB = "6" Then
			strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" '46.NYUDT   2007.02.27
		Else
			strSql = strSql & vbCrLf & "," & "'" & gstrKesidt.Value & "'" '46.NYUDT   2007.02.27
		End If
		
		strSql = strSql & vbCrLf & "," & "'" & pin_NYUKN & "'" '47.NYUKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '48.FNYUKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '49.GNKKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '50.JKESIKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '51.FKESIKN
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '52.KESIKB
		strSql = strSql & vbCrLf & "," & "'" & strNYUKB & "'" '53.NYUKB
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '54.TNKID
		strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA.TUKKB & "'" '55.TUKKB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_TUKKB & "'"            '55.TUKKB
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '56.RATERT
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '57.EMGODNKB
		strSql = strSql & vbCrLf & "," & "'" & Space(15) & "'" '58.OKRJONO
		strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" '59.INVNO
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_LINCMA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_LINCMA, 20) & "'" '60.LINCMA
		'   strSQL = strSQL & vbCrLf & "," & "'" & strLINCMA & "'"                      '60.LINCMA
		strSql = strSql & vbCrLf & "," & "'" & Space(20) & "'" '61.LINCMB
		strSql = strSql & vbCrLf & "," & "'" & Space(7) & "'" '62.BNKCD
		strSql = strSql & vbCrLf & "," & "'" & Space(50) & "'" '63.BNKNM
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '64.TEGNO
		'    strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'"                       '65.TEGDT
		strSql = strSql & vbCrLf & "," & "'" & gstrFridt.Value & "'" '65.TEGDT   '2007/03/19　ヘッダの振込期日をセット　Saito
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_UPDID & "'" '66.UPDID
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DFLDKBCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DFLDKBCD & "'" '67.DFLDKBCD
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBZAIFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DKBZAIFL & "'" '68.DKBZAIFL
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBTEGFL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DKBTEGFL & "'" '69.DKBTEGFL
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBFLA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DKBFLA & "'" '70.DKBFLA
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBFLB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DKBFLB & "'" '71.DKBFLB
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_DKBFLC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_DKBFLC & "'" '72.DKBFLC
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_UPDID(CLng(pin_LINNO) - 1) & "'"       '66.UPDID
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DFLDKBCD(CLng(pin_LINNO) - 1) & "'"    '67.DFLDKBCD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DKBZAIFL(CLng(pin_LINNO) - 1) & "'"    '68.DKBZAIFL
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DKBTEGFL(CLng(pin_LINNO) - 1) & "'"    '69.DKBTEGFL
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DKBFLA(CLng(pin_LINNO) - 1) & "'"      '70.DKBFLA
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DKBFLB(CLng(pin_LINNO) - 1) & "'"      '71.DKBFLB
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_DKBFLC(CLng(pin_LINNO) - 1) & "'"      '72.DKBFLC
		strSql = strSql & vbCrLf & "," & "'" & Space(7) & "'" '73.LSTID
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '74.HINZEIKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '75.HINMSTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '76.TOKMSTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '77.NHSMSTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '78.TANMSTKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '79.ZEIRNKKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '80.HINKB
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '81.ZEIRT
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '82.ZAIKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '83.MRPKB
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '84.HINJUNKB
		strSql = strSql & vbCrLf & "," & "'" & Space(6) & "'" '85.MAKCD
		'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_KOUZA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & vbCrLf & "," & "'" & gtypeFR_SUB(CInt(pin_LINNO) - 1).SUB_KOUZA & "'" '86.HINSIRCD
		'   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSSUB.SUB_KANKOZ(CLng(pin_LINNO) - 1) & "'"      '86.HINSIRCD
		strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '87.HINNMMKB
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '88.HRTDD
		strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '89.ORTDD
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '90.ZNKURIKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '91.ZKMURIKN
		strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '92.ZKMUZEKN
		strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '93.MOTDATNO
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '94.FOPEID
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" '95.FCLTID
		strSql = strSql & vbCrLf & "," & "'" & GV_SysTime & "'" '96.WRTFSTTM
		strSql = strSql & vbCrLf & "," & "'" & GV_SysDate & "'" '97.WRTFSTDT
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '98.OPEID
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" '99.CLTID
		strSql = strSql & vbCrLf & "," & "'" & GV_SysTime & "'" '100.WRTTM
		strSql = strSql & vbCrLf & "," & "'" & GV_SysDate & "'" '101.WRTDT
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '102.UOPEID
		strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" '103.UCLTID
		strSql = strSql & vbCrLf & "," & "'" & GV_SysTime & "'" '104.UWRTTM
		strSql = strSql & vbCrLf & "," & "'" & GV_SysDate & "'" '105.UWRTDT
		strSql = strSql & vbCrLf & "," & "'" & SSS_PrgId & "'" '106.PGID
		strSql = strSql & vbCrLf & "," & "'" & "2" & "'" '107.DLFLG
		strSql = strSql & vbCrLf & ")"
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
		If bolRet = False Then
			GoTo F_UDNTRA_Insert_SAGAKU_ERROR
		End If
		
		F_UDNTRA_Insert_SAGAKU = 0
		Exit Function
		
F_UDNTRA_Insert_SAGAKU_ERROR: 
		'   Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET73_E_034, Main_Inf, "F_UDNTRA_Insert_SAGAKU")
		Call SSSWIN_LOGWRT("F_UDNTRA_Insert_SAGAKU_ERROR")
		
	End Function
	
	'請求サマリの入金額に更新を行う（差額入金用）
	Private Function F_TOKSSB_Update_SAGAKU(ByRef strTokseicd As String, ByRef strUPDID As String, ByRef intKesikn As Decimal, ByVal strSSADT As String) As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim strKesdt As String
		Dim i As Short
		
		On Error GoTo F_TOKSSB_Update_SAGAKU_ERROR
		
		F_TOKSSB_Update_SAGAKU = 9
		
		'サマリ存在チェック
		strSql = "SELECT * FROM TOKSSB WHERE ssadt = '" & strSSADT & "' " & "AND tokcd = '" & strTokseicd & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'ﾃﾞｰﾀがあるとき
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPDATE文を実行する
			strSql = "UPDATE TOKSSB SET ssanyukn" & strUPDID & " = ssanyukn" & strUPDID & " + " & intKesikn & ", " & "kskzankn = kskzankn + " & intKesikn & " " & "WHERE ssadt = '" & strSSADT & "' " & "AND tokcd = '" & strTokseicd & "' "
			
			'ﾃﾞｰﾀが無い時
		Else
			'回収予定日取得
			strKesdt = getKesdt(DB_TOKMTA.TOKSMEKB, DB_TOKMTA.TOKSMEDT, DB_TOKMTA.TOKSMECC, DB_TOKMTA.TOKSDWKB, DB_TOKMTA.TOKKESCC, DB_TOKMTA.TOKKESDD, DB_TOKMTA.TOKKDWKB, strSSADT)
			'INSERT文を実行する
			strSql = "INSERT INTO TOKSSB ( tokcd, ssadt, kesdt, " & "ssaurikn00, ssaurikn01, ssaurikn02, ssaurikn03, ssaurikn04, ssaurikn05, ssaurikn06, ssaurikn07, ssaurikn08, ssaurikn09, ssauzekn, " & "szakzikn00, szakzikn01, szakzikn02, szakzokn00, szakzokn01, szakzokn02, szbkzikn00, szbkzikn01, szbkzikn02, szbkzokn00, szbkzokn01, szbkzokn02, " & "ssanyukn00, ssanyukn01, ssanyukn02, ssanyukn03, ssanyukn04, ssanyukn05, ssanyukn06, ssanyukn07, ssanyukn08, ssanyukn09, " & "ksknykkn, kskzankn, ssadensu, datno, wrttm, wrtdt ) VALUES (" & "'" & CF_Ora_String(strTokseicd, 10) & "', '" & strSSADT & "', '" & strKesdt & "', " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			
			For i = 0 To 9
				'UPGRADE_WARNING: オブジェクト SSSVal(strUPDID) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If i = SSSVal(strUPDID) Then
					strSql = strSql & intKesikn & ", "
				Else
					strSql = strSql & "0, "
				End If
			Next i
			
			strSql = strSql & "0, " & intKesikn & ", 0, '" & Space(10) & "', '" & GV_SysTime & "', '" & GV_SysDate & "')"
		End If
		
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_TOKSSB_Update_SAGAKU_ERROR
		End If
		
		F_TOKSSB_Update_SAGAKU = 1
		Exit Function
		
F_TOKSSB_Update_SAGAKU_ERROR: 
		Call SSSWIN_LOGWRT("F_TOKSSB_Update_SAGAKU_ERROR")
		
	End Function
	
	'売掛サマリ請求の入金額に更新を行う（差額入金用）
	Private Function F_TOKSME_Update_SAGAKU(ByRef strTokseicd As String, ByRef strUPDID As String, ByRef intKesikn As Decimal, ByVal strSMADT As String) As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim i As Short
		
		On Error GoTo F_TOKSME_Update_SAGAKU_ERROR
		
		F_TOKSME_Update_SAGAKU = 9
		
		'サマリ存在チェック
		strSql = "SELECT * FROM toksme WHERE smadt = '" & strSMADT & "' " & "AND tokcd = '" & strTokseicd & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'ﾃﾞｰﾀがあるとき
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPDATE文を実行する
			strSql = "UPDATE toksme SET smanyukn" & strUPDID & " = smanyukn" & strUPDID & " + " & intKesikn & " " & "WHERE smadt = '" & strSMADT & "' " & "AND tokcd = '" & strTokseicd & "' "
			
			'ﾃﾞｰﾀが無い時
		Else
			'INSERT文を実行する
			strSql = "INSERT INTO toksme ( tokcd, smadt, " & "smaurikn00, smaurikn01, smaurikn02, smaurikn03, smaurikn04, smaurikn05, smaurikn06, smaurikn07, smaurikn08, smaurikn09, smauzekn, " & "szakzikn00, szakzikn01, szakzikn02, szakzokn00, szakzokn01, szakzokn02, szbkzikn00, szbkzikn01, szbkzikn02, szbkzokn00, szbkzokn01, szbkzokn02, " & "smagnkkn00, smagnkkn01, smagnkkn02, smagnkkn03, smagnkkn04, smagnkkn05, smagnkkn06, smagnkkn07, smagnkkn08, smagnkkn09," & "smanyukn00, smanyukn01, smanyukn02, smanyukn03, smanyukn04, smanyukn05, smanyukn06, smanyukn07, smanyukn08, smanyukn09, " & "datno,  wrttm,  wrtdt ) VALUES (" & "'" & CF_Ora_String(strTokseicd, 10) & "', '" & strSMADT & "', " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			
			For i = 0 To 9
				'UPGRADE_WARNING: オブジェクト SSSVal(strUPDID) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If i = SSSVal(strUPDID) Then
					strSql = strSql & intKesikn & ", "
				Else
					strSql = strSql & "0, "
				End If
			Next i
			
			strSql = strSql & "'" & Space(10) & "', '" & GV_SysTime & "', '" & GV_SysDate & "')"
		End If
		
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_TOKSME_Update_SAGAKU_ERROR
		End If
		
		F_TOKSME_Update_SAGAKU = 1
		Exit Function
		
F_TOKSME_Update_SAGAKU_ERROR: 
		Call SSSWIN_LOGWRT("F_TOKSME_Update_SAGAKU_ERROR")
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function sRegistration
	'   概要：  登録処理
	'   引数：  なし
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function sRegistration(ByRef spd_body As vaSpread) As Short
		
		Dim i As Short
		Dim j As Short
		
		On Error GoTo SREGISTRATION_ERROR
		
		sRegistration = 9
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		
		'現在時刻、日付をセット
		Call setSysdate(GV_SysTime, GV_SysDate)
		
		
		'排他チェック
		If Chk_HAITA_UPD = False Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			Call showMsg("1", "URKET73_901", CStr(0)) '他のプログラムで更新されたため、登録できません。
			sRegistration = 1
			Exit Function
		End If
		
		
		'1行ごとにテーブルに値を更新する
		With spd_body
			'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			For i = 1 To .MaxRows
				
				'スプレッドの値を変数に格納
				For j = COL_CHK To COL_HENPI
					
					'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Row = i
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = j
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .Col = COL_HYFRIDT Then
						'振込期日が空白の時は、space(8)をセット
						'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If .Text = "" Then
							'UPGRADE_WARNING: オブジェクト varSpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							varSpdValue(j) = Space(8)
						Else
							'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト varSpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							varSpdValue(j) = DeCNV_DATE(.Text)
						End If
					Else
						'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト varSpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						varSpdValue(j) = .Text
					End If
				Next j
				
				
				'UPGRADE_WARNING: オブジェクト varSpdValue(COL_NO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If varSpdValue(COL_NO) = "" Then
					Exit For
				End If
				
				
				'NKSTRAの作成(その他トラン・サマリ更新含む)
				If setNKSTRA = False Then
					GoTo SREGISTRATION_ERROR
				End If
			Next i
		End With
		
		
		
		'★UDNTRA更新(入金伝票UDNTRA.DENKB=8)
		If setUDNTRA_NYUKN = False Then
			GoTo SREGISTRATION_ERROR
		End If
		
		
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
		sRegistration = 0
		Exit Function
		
SREGISTRATION_ERROR: 
		'ロールバック
		Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		
	End Function
	
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function GET_SYSTBC_DENNO2
	'   概要：  伝票番号を取得(別セッションで採番する) FOR UPDATE 版
	'   引数：　pin_DKBSB    : 伝票区分
	'   　　：　pot_strDENNO : 伝票番号
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function GET_SYSTBC_DENNO2(ByVal pin_DKBSB As String, ByRef pot_strDENNO As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strDENNO As String ' 伝票番号
		Dim strSTTNO As String ' 伝票番号開始
		Dim strENDNO As String ' 伝票番号終了
		
		On Error GoTo ERR_GET_SYSTBC_DENNO2
		
		GET_SYSTBC_DENNO2 = 9
		pot_strDENNO = ""
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Oss_USR_SAIBAN)
		
		strSql = ""
		strSql = strSql & "Select"
		strSql = strSql & vbCrLf & " DENNO"
		strSql = strSql & vbCrLf & ",STTNO"
		strSql = strSql & vbCrLf & ",ENDNO"
		strSql = strSql & vbCrLf & " From SYSTBC"
		strSql = strSql & vbCrLf & " Where DKBSB    = " & "'" & pin_DKBSB & "'"
		strSql = strSql & vbCrLf & "   And ADDDENCD = " & "'" & New String(" ", 13) & "'"
		strSql = strSql & vbCrLf & "   And ADDDENCD = " & "'" & New String(" ", 13) & "'"
		strSql = strSql & vbCrLf & " FOR UPDATE"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR_SAIBAN, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			
			'伝票番号の採番
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strDENNO = CF_Ora_GetDyn(Usr_Ody, "DENNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSTTNO = CF_Ora_GetDyn(Usr_Ody, "STTNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strENDNO = CF_Ora_GetDyn(Usr_Ody, "ENDNO", "")
			
			'消込伝票番号カウントアップ
			If CInt(strENDNO) < CInt(strDENNO) + 1 Then
				strDENNO = strSTTNO
			Else
				strDENNO = VB6.Format(CInt(strDENNO) + 1, "00000000")
			End If
			
			strSql = ""
			strSql = strSql & vbCrLf & "UPDATE SYSTBC SET"
			strSql = strSql & vbCrLf & " DENNO  = " & "'" & strDENNO & "'" '消込伝票番号
			strSql = strSql & vbCrLf & ",OPEID  = " & "'" & CF_Ora_String(SSS_OPEID.Value, 8) & "'" '最終作業者コード
			strSql = strSql & vbCrLf & ",CLTID  = " & "'" & CF_Ora_String(SSS_CLTID.Value, 5) & "'" 'クライアントＩＤ
			strSql = strSql & vbCrLf & ",WRTTM  = " & "'" & GV_SysTime & "'" 'タイムスタンプ（時間）
			strSql = strSql & vbCrLf & ",WRTDT  = " & "'" & GV_SysDate & "'" 'タイムスタンプ（日付）
			strSql = strSql & vbCrLf & " Where DKBSB    = " & "'" & pin_DKBSB & "'"
			strSql = strSql & vbCrLf & "   And ADDDENCD = " & "'" & New String(" ", 13) & "'"
			
			'SQL実行
			If CF_Ora_Execute(gv_Odb_USR_SAIBAN, strSql) = False Then
				Call CF_Ora_RollbackTrans(gv_Odb_USR_SAIBAN)
				GET_SYSTBC_DENNO2 = 9
				GoTo END_GET_SYSTBC_DENNO2
			End If
			
			' 戻り値に採番結果を設定
			pot_strDENNO = strDENNO
			
		Else
			GoTo END_GET_SYSTBC_DENNO2
		End If
		
		Call CF_Ora_CommitTrans(gv_Odb_USR_SAIBAN)
		
		GET_SYSTBC_DENNO2 = 0
		
END_GET_SYSTBC_DENNO2: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_GET_SYSTBC_DENNO2: 
		Call CF_Ora_RollbackTrans(gv_Odb_USR_SAIBAN)
		GET_SYSTBC_DENNO2 = 9
		GoTo END_GET_SYSTBC_DENNO2
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSTRA_UPDATE1
	'   概要：  入金消込トランの追加を行う(取消用レコード）
	'   引数：  pm_lstrKDNNO : 元消込伝票番号
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSTRA_UPDATE1(ByVal pm_lstrKDNNO As String) As Short
		
		Dim strSql As String
		
		On Error GoTo F_NKSTRA_UPDATE1_ERROR
		
		F_NKSTRA_UPDATE1 = 9
		
		'消込取消
		strSql = ""
		strSql = strSql & "UPDATE " & vbCrLf
		strSql = strSql & "       NKSTRA " & vbCrLf
		strSql = strSql & "SET " & vbCrLf
		strSql = strSql & "       DATKB     = '9' " & vbCrLf
		strSql = strSql & "      ,NYUDELDT  = '" & CF_Ora_Sgl(gstrKesidt.Value) & "'" & vbCrLf
		strSql = strSql & "      ,OPEID     = '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'" & vbCrLf
		strSql = strSql & "      ,CLTID     = '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'" & vbCrLf
		strSql = strSql & "      ,WRTTM     = '" & CF_Ora_Sgl(GV_SysTime) & "'" & vbCrLf
		strSql = strSql & "      ,WRTDT     = '" & CF_Ora_Sgl(GV_SysDate) & "'" & vbCrLf
		strSql = strSql & "      ,UOPEID    = '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'" & vbCrLf
		strSql = strSql & "      ,UCLTID    = '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'" & vbCrLf
		strSql = strSql & "      ,UWRTTM    = '" & CF_Ora_Sgl(GV_SysTime) & "'" & vbCrLf
		strSql = strSql & "      ,UWRTDT    = '" & CF_Ora_Sgl(GV_SysDate) & "'" & vbCrLf
		strSql = strSql & "      ,PGID      = '" & CF_Ora_Sgl(SSS_PrgId) & "' " & vbCrLf
		strSql = strSql & "      ,DLFLG     = '1' " & vbCrLf
		strSql = strSql & "WHERE " & vbCrLf
		strSql = strSql & "       DATKB = '1' " & vbCrLf
		strSql = strSql & "AND    KDNNO = '" & CF_Ora_Sgl(pm_lstrKDNNO) & "'" & vbCrLf
		
		'★UPDATE実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_NKSTRA_UPDATE1_ERROR
		End If
		
		F_NKSTRA_UPDATE1 = 0
		Exit Function
		
F_NKSTRA_UPDATE1_ERROR: 
		Call SSSWIN_LOGWRT("F_NKSTRA_UPDATE1_ERROR")
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSTRA_INSERT1
	'   概要：  入金消込トランの追加を行う(取消用レコード）
	'   引数：  pm_strSMADT  : レコードセット
	'           pm_strSMADT  : 経理締日付
	'           pm_lstrKDNNO : 元消込伝票番号
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSTRA_INSERT1(ByRef pm_Usr_Ody As U_Ody, ByVal pm_strSMADT As String, ByVal pm_lstrKDNNO As String) As Short
		
		Dim strSql As String
		
		On Error GoTo F_NKSTRA_INSERT1_ERROR
		
		F_NKSTRA_INSERT1 = 9
		
		'消込伝票番号の採番処理
		If GET_SYSTBC_DENNO2(gc_DKBSB_KES, strKDNNO) Then
			GoTo F_NKSTRA_INSERT1_ERROR
		End If
		
		'翌月消込取消
		strSql = ""
		strSql = strSql & "INSERT INTO NKSTRA ( " & vbCrLf
		strSql = strSql & "  KDNNO" & vbCrLf
		strSql = strSql & " ,DATKB" & vbCrLf
		strSql = strSql & " ,AKAKROKB" & vbCrLf
		strSql = strSql & " ,NYURECNO" & vbCrLf
		strSql = strSql & " ,UDNRECNO" & vbCrLf
		strSql = strSql & " ,NYUDT" & vbCrLf
		strSql = strSql & " ,JKESIKN" & vbCrLf
		strSql = strSql & " ,TOKSEICD" & vbCrLf
		strSql = strSql & " ,TOKCD" & vbCrLf
		strSql = strSql & " ,TANCD" & vbCrLf
		strSql = strSql & " ,JDNNO" & vbCrLf
		strSql = strSql & " ,JDNLINNO" & vbCrLf
		strSql = strSql & " ,UDNDT" & vbCrLf
		strSql = strSql & " ,URIKN" & vbCrLf
		strSql = strSql & " ,TEGDT" & vbCrLf
		strSql = strSql & " ,JDNDT" & vbCrLf
		strSql = strSql & " ,TUKKB" & vbCrLf
		strSql = strSql & " ,INVNO" & vbCrLf
		strSql = strSql & " ,FURIKN" & vbCrLf
		strSql = strSql & " ,FKESIKN" & vbCrLf
		strSql = strSql & " ,FRNKB" & vbCrLf
		strSql = strSql & " ,NYUKB" & vbCrLf
		strSql = strSql & " ,UDNDATNO" & vbCrLf
		strSql = strSql & " ,UDNLINNO" & vbCrLf
		strSql = strSql & " ,MAEUKKB" & vbCrLf
		strSql = strSql & " ,SMADT" & vbCrLf
		strSql = strSql & " ,REGDT" & vbCrLf
		strSql = strSql & " ,NYUDELDT" & vbCrLf
		strSql = strSql & " ,DKBID" & vbCrLf
		strSql = strSql & " ,UPDID" & vbCrLf
		strSql = strSql & " ,JDNDATNO" & vbCrLf
		strSql = strSql & " ,MOTKDNNO" & vbCrLf
		strSql = strSql & " ,FOPEID" & vbCrLf
		strSql = strSql & " ,FCLTID" & vbCrLf
		strSql = strSql & " ,WRTFSTTM" & vbCrLf
		strSql = strSql & " ,WRTFSTDT" & vbCrLf
		strSql = strSql & " ,OPEID" & vbCrLf
		strSql = strSql & " ,CLTID" & vbCrLf
		strSql = strSql & " ,WRTTM" & vbCrLf
		strSql = strSql & " ,WRTDT" & vbCrLf
		strSql = strSql & " ,UOPEID" & vbCrLf
		strSql = strSql & " ,UCLTID" & vbCrLf
		strSql = strSql & " ,UWRTTM" & vbCrLf
		strSql = strSql & " ,UWRTDT" & vbCrLf
		strSql = strSql & " ,PGID" & vbCrLf
		strSql = strSql & " ,DLFLG" & vbCrLf
		strSql = strSql & ") VALUES ( " & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(strKDNNO) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl("1") & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl("9") & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYURECNO", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNRECNO", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "JKESIKN", "") * -1 & "," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TOKSEICD", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TOKCD", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TANCD", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNNO", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNLINNO", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNDT", "")) & "'," & vbCrLf
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "URIKN", "") & "," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TEGDT", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNDT", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TUKKB", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "INVNO", "")) & "'," & vbCrLf
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "FURIKN", "") & "," & vbCrLf
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "FKESIKN", "") & "," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FRNKB", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYUKB", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNDATNO", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNLINNO", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "MAEUKKB", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(pm_strSMADT) & "'," & vbCrLf
		'''' UPD 2010/05/10  FKS) T.Yamamoto    Start    連絡票��818
		'    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "REGDT", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
		'''' UPD 2010/05/10  FKS) T.Yamamoto    End
		strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "DKBID", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UPDID", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNDATNO", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(pm_lstrKDNNO) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FOPEID", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FCLTID", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "WRTFSTTM", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "WRTFSTDT", "")) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysTime) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysDate) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysTime) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysDate) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_PrgId) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl("1") & "'" & vbCrLf
		strSql = strSql & ")"
		
		'★INSERT実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_NKSTRA_INSERT1_ERROR
		End If
		
		F_NKSTRA_INSERT1 = 0
		Exit Function
		
F_NKSTRA_INSERT1_ERROR: 
		Call SSSWIN_LOGWRT("F_NKSTRA_INSERT1_ERROR")
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSTRA_INSERT2
	'   概要：  入金消込トランの追加を行う(追加用レコード）
	'   引数：  pm_cur_KESIKIN  : レコードセット
	'           pm_strSMADT     : 経理締日付
	'           pm_strNYUKB     : 入金種別
	'           pm_int_UPDID    : UODID
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSTRA_INSERT2(ByVal pm_cur_KESIKIN As Decimal, ByVal pm_strSMADT As String, ByVal pm_strNyukb As String, ByVal pm_int_UPDID As Short) As Short
		
		Dim strSql As String
		
		On Error GoTo F_NKSTRA_INSERT2_ERROR
		
		F_NKSTRA_INSERT2 = 9
		
		'消込伝票番号の採番処理
		If GET_SYSTBC_DENNO2(gc_DKBSB_KES, strKDNNO) Then
			GoTo F_NKSTRA_INSERT2_ERROR
		End If
		
		'消込トラン書き込み
		strSql = ""
		strSql = strSql & "INSERT INTO NKSTRA ( " & vbCrLf
		strSql = strSql & "  KDNNO" & vbCrLf
		strSql = strSql & " ,DATKB" & vbCrLf
		strSql = strSql & " ,AKAKROKB" & vbCrLf
		strSql = strSql & " ,NYURECNO" & vbCrLf
		strSql = strSql & " ,UDNRECNO" & vbCrLf
		strSql = strSql & " ,NYUDT" & vbCrLf
		strSql = strSql & " ,JKESIKN" & vbCrLf
		strSql = strSql & " ,TOKSEICD" & vbCrLf
		strSql = strSql & " ,TOKCD" & vbCrLf
		strSql = strSql & " ,TANCD" & vbCrLf
		strSql = strSql & " ,JDNNO" & vbCrLf
		strSql = strSql & " ,JDNLINNO" & vbCrLf
		strSql = strSql & " ,UDNDT" & vbCrLf
		strSql = strSql & " ,URIKN" & vbCrLf
		strSql = strSql & " ,TEGDT" & vbCrLf
		strSql = strSql & " ,JDNDT" & vbCrLf
		strSql = strSql & " ,TUKKB" & vbCrLf
		strSql = strSql & " ,INVNO" & vbCrLf
		strSql = strSql & " ,FURIKN" & vbCrLf
		strSql = strSql & " ,FKESIKN" & vbCrLf
		strSql = strSql & " ,FRNKB" & vbCrLf
		strSql = strSql & " ,NYUKB" & vbCrLf
		strSql = strSql & " ,UDNDATNO" & vbCrLf
		strSql = strSql & " ,UDNLINNO" & vbCrLf
		strSql = strSql & " ,MAEUKKB" & vbCrLf
		strSql = strSql & " ,SMADT" & vbCrLf
		strSql = strSql & " ,REGDT" & vbCrLf
		strSql = strSql & " ,NYUDELDT" & vbCrLf
		strSql = strSql & " ,DKBID" & vbCrLf
		strSql = strSql & " ,UPDID" & vbCrLf
		strSql = strSql & " ,JDNDATNO" & vbCrLf
		strSql = strSql & " ,MOTKDNNO" & vbCrLf
		strSql = strSql & " ,FOPEID" & vbCrLf
		strSql = strSql & " ,FCLTID" & vbCrLf
		strSql = strSql & " ,WRTFSTTM" & vbCrLf
		strSql = strSql & " ,WRTFSTDT" & vbCrLf
		strSql = strSql & " ,OPEID" & vbCrLf
		strSql = strSql & " ,CLTID" & vbCrLf
		strSql = strSql & " ,WRTTM" & vbCrLf
		strSql = strSql & " ,WRTDT" & vbCrLf
		strSql = strSql & " ,UOPEID" & vbCrLf
		strSql = strSql & " ,UCLTID" & vbCrLf
		strSql = strSql & " ,UWRTTM" & vbCrLf
		strSql = strSql & " ,UWRTDT" & vbCrLf
		strSql = strSql & " ,PGID" & vbCrLf
		strSql = strSql & " ,DLFLG" & vbCrLf
		strSql = strSql & ") VALUES ( " & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(strKDNNO) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl("1") & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl("1") & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(Space(10)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(Space(10)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
		strSql = strSql & "  " & pm_cur_KESIKIN & "," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_TOKSEICD)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_TOKCD)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_TANCD)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_JDNNO)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_JDNLINNO)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_UDNDT)) & "'," & vbCrLf
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "  " & SSSVal(varSpdValue(COL_KOMIKN)) & "," & vbCrLf
		
		'*** 2009/09/16 CHG START FKS)NAKATA
		''    If ARY_NKSSMB_KS(pm_int_UPDID).DATKB = "03" Or ARY_NKSSMB_KS(pm_int_UPDID).DATKB = "08" Then
		''        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
		''    Else
		''        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
		''    End If
		
		If CDbl(pm_strNyukb) = 2 Then
			If Trim(CF_Ora_Sgl(varSpdValue(COL_HYFRIDT))) = "" Then
				strSql = strSql & " '" & CF_Ora_Sgl(gstrUnydt.Value) & "'," & vbCrLf
			Else
				strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
			End If
		Else
			strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
		End If
		'*** 2009/09/16 CHG E.N.D FKS)NAKATA
		
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_JDNDT)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_TUKKB)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_INVNO)) & "'," & vbCrLf
		strSql = strSql & "  " & 0 & "," & vbCrLf
		strSql = strSql & "  " & 0 & "," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_FRNKB)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(pm_strNyukb) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_UDNDATNO)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_UDNLINNO)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_MAEUKKB)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(pm_strSMADT) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(ARY_NKSSMB_KS(pm_int_UPDID).DATKB) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(ARY_NKSSMB_KS(pm_int_UPDID).UPDID) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_JDNDATNO)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysTime) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysDate) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysTime) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysDate) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysTime) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(GV_SysDate) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl(SSS_PrgId) & "'," & vbCrLf
		strSql = strSql & " '" & CF_Ora_Sgl("2") & "'" & vbCrLf
		strSql = strSql & ")"
		
		'★INSERT実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_NKSTRA_INSERT2_ERROR
		End If
		
		F_NKSTRA_INSERT2 = 0
		Exit Function
		
F_NKSTRA_INSERT2_ERROR: 
		Call SSSWIN_LOGWRT("F_NKSTRA_INSERT2_ERROR")
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB_KSK_Update
	'   概要：  入金消込サマリの入金集計消込金額に対して更新を行う
	'   引数：  pm_strTokcd      : 得意先コード
	'           pm_strUpdid      : 更新項目ID情報
	'           pm_curKesikn     : 消込金額
	'           pm_strSMADT_DSP  : 経理締日付
	'           pm_strSMADT_TBL  : 経理締日付
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB_KSK_Update(ByVal pm_strTokcd As String, ByVal pm_strUpdid As String, ByVal pm_curKesikn As Decimal, ByVal pm_strSMADT_DSP As String, ByVal pm_strSMADT_TBL As String) As Short
		
		Dim i As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo F_NKSSMB_KSK_Update_ERROR
		
		F_NKSSMB_KSK_Update = 9
		
		'サマリ存在チェック
		strSql = ""
		strSql = strSql & "SELECT "
		strSql = strSql & "       TOKCD "
		strSql = strSql & "FROM "
		strSql = strSql & "       NKSSMB "
		strSql = strSql & "WHERE "
		strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
		strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT_DSP) & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'ﾃﾞｰﾀがあるとき
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPDATE文を実行する
			strSql = ""
			strSql = strSql & "UPDATE "
			strSql = strSql & "       NKSSMB "
			strSql = strSql & "SET "
			
			'**** 2009/09/16 CHG START FKS)NAKATA
			'        If pm_strSMADT_DSP <> pm_strSMADT_TBL Then
			'            strSql = strSql & "       SSANYUKN" & pm_strUpdid & " = " & "SSANYUKN" & pm_strUpdid & " + " & (-1) * pm_curKesikn & " "
			'        Else
			'            strSql = strSql & "       KSKNYKKN" & pm_strUpdid & " = " & "KSKNYKKN" & pm_strUpdid & " + " & pm_curKesikn & " "
			'        End If
			
			strSql = strSql & "       KSKNYKKN" & pm_strUpdid & " = " & "KSKNYKKN" & pm_strUpdid & " + " & pm_curKesikn & " "
			'**** 2009/09/16 CHG E.N.D FKS)NAKATA
			
			strSql = strSql & "      ,OPEID = '" & CF_Ora_Sgl(SSS_OPEID.Value) & "'"
			strSql = strSql & "      ,CLTID = '" & CF_Ora_Sgl(SSS_CLTID.Value) & "'"
			strSql = strSql & "      ,WRTTM = '" & CF_Ora_Sgl(GV_SysTime) & "'"
			strSql = strSql & "      ,WRTDT = '" & CF_Ora_Sgl(GV_SysDate) & "'"
			strSql = strSql & "WHERE "
			strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
			strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT_DSP) & "'"
			
			'ﾃﾞｰﾀが無い時
		Else
			'INSERT文を実行する
			strSql = ""
			strSql = strSql & "INSERT INTO NKSSMB ( "
			strSql = strSql & " TOKCD "
			strSql = strSql & ",SMADT "
			strSql = strSql & ",SSANYUKN00 "
			strSql = strSql & ",SSANYUKN01 "
			strSql = strSql & ",SSANYUKN02 "
			strSql = strSql & ",SSANYUKN03 "
			strSql = strSql & ",SSANYUKN04 "
			strSql = strSql & ",SSANYUKN05 "
			strSql = strSql & ",SSANYUKN06 "
			strSql = strSql & ",SSANYUKN07 "
			strSql = strSql & ",SSANYUKN08 "
			strSql = strSql & ",SSANYUKN09 "
			strSql = strSql & ",KSKNYKKN00 "
			strSql = strSql & ",KSKNYKKN01 "
			strSql = strSql & ",KSKNYKKN02 "
			strSql = strSql & ",KSKNYKKN03 "
			strSql = strSql & ",KSKNYKKN04 "
			strSql = strSql & ",KSKNYKKN05 "
			strSql = strSql & ",KSKNYKKN06 "
			strSql = strSql & ",KSKNYKKN07 "
			strSql = strSql & ",KSKNYKKN08 "
			strSql = strSql & ",KSKNYKKN09 "
			strSql = strSql & ",KSKZANKN00 "
			strSql = strSql & ",KSKZANKN01 "
			strSql = strSql & ",KSKZANKN02 "
			strSql = strSql & ",KSKZANKN03 "
			strSql = strSql & ",KSKZANKN04 "
			strSql = strSql & ",KSKZANKN05 "
			strSql = strSql & ",KSKZANKN06 "
			strSql = strSql & ",KSKZANKN07 "
			strSql = strSql & ",KSKZANKN08 "
			strSql = strSql & ",KSKZANKN09 "
			strSql = strSql & ",OPEID "
			strSql = strSql & ",CLTID "
			strSql = strSql & ",WRTTM "
			strSql = strSql & ",WRTDT "
			strSql = strSql & ") VALUES ( "
			strSql = strSql & "'" & CF_Ora_Sgl(pm_strTokcd) & "', "
			strSql = strSql & "'" & CF_Ora_Sgl(pm_strSMADT_DSP) & "',"
			
			'*** 2009/09/16 UPD START FKS)NAKATA
			'        If pm_strSMADT_DSP <> pm_strSMADT_TBL Then
			'            For i = 0 To 9
			'                If i = SSSVal(pm_strUpdid) Then
			'                    strSql = strSql & (-1) * pm_curKesikn & ", "
			'                Else
			'                    strSql = strSql & "0, "
			'                End If
			'            Next i
			'            strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			'        Else
			'            strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			'            For i = 0 To 9
			'                If i = SSSVal(pm_strUpdid) Then
			'                    strSql = strSql & pm_curKesikn & ", "
			'                Else
			'                    strSql = strSql & "0, "
			'                End If
			'            Next i
			'        End If
			strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			For i = 0 To 9
				'UPGRADE_WARNING: オブジェクト SSSVal(pm_strUpdid) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If i = SSSVal(pm_strUpdid) Then
					strSql = strSql & pm_curKesikn & ", "
				Else
					strSql = strSql & "0, "
				End If
			Next i
			'*** 2009/09/16 UPD E.N.D FKS)NAKATA
			
			
			strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			strSql = strSql & "'" & CF_Ora_Sgl(SSS_OPEID.Value) & "',"
			strSql = strSql & "'" & CF_Ora_Sgl(SSS_CLTID.Value) & "',"
			strSql = strSql & "'" & CF_Ora_Sgl(GV_SysTime) & "',"
			strSql = strSql & "'" & CF_Ora_Sgl(GV_SysDate) & "')"
		End If
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_NKSSMB_KSK_Update_ERROR
		End If
		
		F_NKSSMB_KSK_Update = 1
		Exit Function
		
F_NKSSMB_KSK_Update_ERROR: 
		Call SSSWIN_LOGWRT("F_NKSSMB_KSK_Update_ERROR")
		
	End Function
	
	'**** 2009/09/16 DEL START FKS)NAKATA
	''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''   名称：  Function F_NKSSMB_KSK_Update2
	'''   概要：  入金消込サマリの入金集計消込金額に対して更新を行う
	'''   引数：  pm_strTokcd      : 得意先コード
	'''           pm_strUpdid      : 更新項目ID情報
	'''           pm_curKesikn     : 消込金額
	'''           pm_strSMADT_DSP  : 経理締日付
	'''           pm_strSMADT_TBL  : 経理締日付
	'''   戻値：　0 : 正常  1 : 警告  9 : 異常
	'''   備考：
	''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''Private Function F_NKSSMB_KSK_Update2( _
	''''                                    ByVal pm_strTokcd As String, _
	''''                                    ByVal pm_strUpdid As String, _
	''''                                    ByVal pm_curKesikn As Currency, _
	''''                                    ByVal pm_strSMADT_DSP As String, _
	''''                                    ByVal pm_strSMADT_TBL As String) As Integer
	'''
	'''    Dim i       As Integer
	'''    Dim Usr_Ody As U_Ody
	'''    Dim strSql  As String
	'''
	'''On Error GoTo F_NKSSMB_KSK_Update2_ERROR
	'''
	'''    F_NKSSMB_KSK_Update2 = 9
	'''
	'''    'サマリ存在チェック
	'''    strSql = ""
	'''    strSql = strSql & "SELECT "
	'''    strSql = strSql & "       TOKCD "
	'''    strSql = strSql & "FROM "
	'''    strSql = strSql & "       NKSSMB "
	'''    strSql = strSql & "WHERE "
	'''    strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
	'''    strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT_DSP) & "'"
	'''
	'''    'DBアクセス
	'''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'''
	'''    'ﾃﾞｰﾀがあるとき
	'''    If CF_Ora_EOF(Usr_Ody) = False Then
	'''        'UPDATE文を実行する
	'''        strSql = ""
	'''        strSql = strSql & "UPDATE "
	'''        strSql = strSql & "       NKSSMB "
	'''        strSql = strSql & "SET "
	'''        strSql = strSql & "       KSKNYKKN" & pm_strUpdid & " = " & "KSKNYKKN" & pm_strUpdid & " - " & pm_curKesikn & " "
	'''        strSql = strSql & "      ,OPEID = '" & CF_Ora_Sgl(SSS_OPEID) & "'"
	'''        strSql = strSql & "      ,CLTID = '" & CF_Ora_Sgl(SSS_CLTID) & "'"
	'''        strSql = strSql & "      ,WRTTM = '" & CF_Ora_Sgl(GV_SysTime) & "'"
	'''        strSql = strSql & "      ,WRTDT = '" & CF_Ora_Sgl(GV_SysDate) & "'"
	'''        strSql = strSql & "WHERE "
	'''        strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
	'''        strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT_DSP) & "'"
	'''
	'''    'ﾃﾞｰﾀが無い時
	'''    Else
	'''        'INSERT文を実行する
	'''        strSql = ""
	'''        strSql = strSql & "INSERT INTO NKSSMB ( "
	'''        strSql = strSql & " TOKCD "
	'''        strSql = strSql & ",SMADT "
	'''        strSql = strSql & ",SSANYUKN00 "
	'''        strSql = strSql & ",SSANYUKN01 "
	'''        strSql = strSql & ",SSANYUKN02 "
	'''        strSql = strSql & ",SSANYUKN03 "
	'''        strSql = strSql & ",SSANYUKN04 "
	'''        strSql = strSql & ",SSANYUKN05 "
	'''        strSql = strSql & ",SSANYUKN06 "
	'''        strSql = strSql & ",SSANYUKN07 "
	'''        strSql = strSql & ",SSANYUKN08 "
	'''        strSql = strSql & ",SSANYUKN09 "
	'''        strSql = strSql & ",KSKNYKKN00 "
	'''        strSql = strSql & ",KSKNYKKN01 "
	'''        strSql = strSql & ",KSKNYKKN02 "
	'''        strSql = strSql & ",KSKNYKKN03 "
	'''        strSql = strSql & ",KSKNYKKN04 "
	'''        strSql = strSql & ",KSKNYKKN05 "
	'''        strSql = strSql & ",KSKNYKKN06 "
	'''        strSql = strSql & ",KSKNYKKN07 "
	'''        strSql = strSql & ",KSKNYKKN08 "
	'''        strSql = strSql & ",KSKNYKKN09 "
	'''        strSql = strSql & ",KSKZANKN00 "
	'''        strSql = strSql & ",KSKZANKN01 "
	'''        strSql = strSql & ",KSKZANKN02 "
	'''        strSql = strSql & ",KSKZANKN03 "
	'''        strSql = strSql & ",KSKZANKN04 "
	'''        strSql = strSql & ",KSKZANKN05 "
	'''        strSql = strSql & ",KSKZANKN06 "
	'''        strSql = strSql & ",KSKZANKN07 "
	'''        strSql = strSql & ",KSKZANKN08 "
	'''        strSql = strSql & ",KSKZANKN09 "
	'''        strSql = strSql & ",OPEID "
	'''        strSql = strSql & ",CLTID "
	'''        strSql = strSql & ",WRTTM "
	'''        strSql = strSql & ",WRTDT "
	'''        strSql = strSql & ") VALUES ( "
	'''        strSql = strSql & "'" & CF_Ora_Sgl(pm_strTokcd) & "', "
	'''        strSql = strSql & "'" & CF_Ora_Sgl(pm_strSMADT_DSP) & "',"
	'''        strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
	'''        For i = 0 To 9
	'''            If i = SSSVal(pm_strUpdid) Then
	'''                strSql = strSql & (-1) * pm_curKesikn & ", "
	'''            Else
	'''                strSql = strSql & "0, "
	'''            End If
	'''        Next i
	'''        strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
	'''        strSql = strSql & "'" & CF_Ora_Sgl(SSS_OPEID) & "',"
	'''        strSql = strSql & "'" & CF_Ora_Sgl(SSS_CLTID) & "',"
	'''        strSql = strSql & "'" & CF_Ora_Sgl(GV_SysTime) & "',"
	'''        strSql = strSql & "'" & CF_Ora_Sgl(GV_SysDate) & "')"
	'''    End If
	'''    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
	'''
	'''    'SQL実行
	'''    If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
	'''        GoTo F_NKSSMB_KSK_Update2_ERROR
	'''    End If
	'''
	'''    F_NKSSMB_KSK_Update2 = 1
	'''    Exit Function
	'''
	'''F_NKSSMB_KSK_Update2_ERROR:
	'''    Call SSSWIN_LOGWRT("F_NKSSMB_KSK_Update2_ERROR")
	'''
	'''End Function
	'**** 2009/09/16 DEL E.N.D FKS)NAKATA
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB_SSA_Update
	'   概要：  入金消込サマリの入金集計消込金額に対して更新を行う
	'   引数：  pm_strTokcd  : 得意先コード
	'           pm_strUpdid  : 更新項目ID情報
	'           pm_curKesikn : 消込金額
	'           pm_strSMADT  : 経理締日付
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB_SSA_Update(ByVal pm_strTokcd As String, ByVal pm_strUpdid As String, ByVal pm_curKesikn As Decimal, ByVal pm_strSMADT As String) As Short
		
		Dim i As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo F_NKSSMB_SSA_Update_ERROR
		
		F_NKSSMB_SSA_Update = 9
		
		'サマリ存在チェック
		strSql = ""
		strSql = strSql & "SELECT "
		strSql = strSql & "       TOKCD "
		strSql = strSql & "FROM "
		strSql = strSql & "       NKSSMB "
		strSql = strSql & "WHERE "
		strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
		strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT) & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'ﾃﾞｰﾀがあるとき
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPDATE文を実行する
			strSql = ""
			strSql = strSql & "UPDATE "
			strSql = strSql & "       NKSSMB "
			strSql = strSql & "SET "
			strSql = strSql & "       SSANYUKN" & pm_strUpdid & " = " & "SSANYUKN" & pm_strUpdid & " + " & pm_curKesikn & " "
			strSql = strSql & "      ,OPEID = '" & CF_Ora_Sgl(SSS_OPEID.Value) & "' "
			strSql = strSql & "      ,CLTID = '" & CF_Ora_Sgl(SSS_CLTID.Value) & "' "
			strSql = strSql & "      ,WRTTM = '" & CF_Ora_Sgl(GV_SysTime) & "' "
			strSql = strSql & "      ,WRTDT = '" & CF_Ora_Sgl(GV_SysDate) & "' "
			strSql = strSql & "WHERE "
			strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "' "
			strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT) & "' "
			
			'ﾃﾞｰﾀが無い時
		Else
			'INSERT文を実行する
			strSql = ""
			strSql = strSql & "INSERT INTO NKSSMB ( "
			strSql = strSql & " TOKCD "
			strSql = strSql & ",SMADT "
			strSql = strSql & ",SSANYUKN00 "
			strSql = strSql & ",SSANYUKN01 "
			strSql = strSql & ",SSANYUKN02 "
			strSql = strSql & ",SSANYUKN03 "
			strSql = strSql & ",SSANYUKN04 "
			strSql = strSql & ",SSANYUKN05 "
			strSql = strSql & ",SSANYUKN06 "
			strSql = strSql & ",SSANYUKN07 "
			strSql = strSql & ",SSANYUKN08 "
			strSql = strSql & ",SSANYUKN09 "
			strSql = strSql & ",KSKNYKKN00 "
			strSql = strSql & ",KSKNYKKN01 "
			strSql = strSql & ",KSKNYKKN02 "
			strSql = strSql & ",KSKNYKKN03 "
			strSql = strSql & ",KSKNYKKN04 "
			strSql = strSql & ",KSKNYKKN05 "
			strSql = strSql & ",KSKNYKKN06 "
			strSql = strSql & ",KSKNYKKN07 "
			strSql = strSql & ",KSKNYKKN08 "
			strSql = strSql & ",KSKNYKKN09 "
			strSql = strSql & ",KSKZANKN00 "
			strSql = strSql & ",KSKZANKN01 "
			strSql = strSql & ",KSKZANKN02 "
			strSql = strSql & ",KSKZANKN03 "
			strSql = strSql & ",KSKZANKN04 "
			strSql = strSql & ",KSKZANKN05 "
			strSql = strSql & ",KSKZANKN06 "
			strSql = strSql & ",KSKZANKN07 "
			strSql = strSql & ",KSKZANKN08 "
			strSql = strSql & ",KSKZANKN09 "
			strSql = strSql & ",OPEID "
			strSql = strSql & ",CLTID "
			strSql = strSql & ",WRTTM "
			strSql = strSql & ",WRTDT "
			strSql = strSql & ") VALUES ( "
			strSql = strSql & "'" & CF_Ora_Sgl(pm_strTokcd) & "', "
			strSql = strSql & "'" & CF_Ora_Sgl(pm_strSMADT) & "',"
			For i = 0 To 9
				'UPGRADE_WARNING: オブジェクト SSSVal(pm_strUpdid) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If i = SSSVal(pm_strUpdid) Then
					strSql = strSql & pm_curKesikn & ", "
				Else
					strSql = strSql & "0, "
				End If
			Next i
			strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
			strSql = strSql & "'" & CF_Ora_Sgl(SSS_OPEID.Value) & "',"
			strSql = strSql & "'" & CF_Ora_Sgl(SSS_CLTID.Value) & "',"
			strSql = strSql & "'" & CF_Ora_Sgl(GV_SysTime) & "',"
			strSql = strSql & "'" & CF_Ora_Sgl(GV_SysDate) & "')"
		End If
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_NKSSMB_SSA_Update_ERROR
		End If
		
		F_NKSSMB_SSA_Update = 0
		Exit Function
		
F_NKSSMB_SSA_Update_ERROR: 
		Call SSSWIN_LOGWRT("F_NKSSMB_SSA_Update_ERROR")
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB_SSA_Update
	'   概要：  更新時の排他チェックを実施する
	'   引数：  無し
	'   戻値：　True：排他エラー無し False:排他エラー有り
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Chk_HAITA_UPD() As Boolean
		
		Dim strSql As Object
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim i As Integer
		
		Chk_HAITA_UPD = False
		
		'売上トラン排他チェック
		For i = 1 To UBound(ARY_UDNTRA_HAITA)
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = ""
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       OPEID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,CLTID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTDT  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTTM  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UOPEID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UCLTID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTDT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTTM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       UDNTRA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       DATNO = '" & CF_Ora_Sgl(ARY_UDNTRA_HAITA(i).DATNO) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    LINNO = '" & CF_Ora_Sgl(ARY_UDNTRA_HAITA(i).LINNO) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FOR UPDATE " & vbCrLf
			
			'DBアクセス
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			'ﾃﾞｰﾀがあるとき
			If CF_Ora_EOF(Usr_Ody) = False Then
				' 更新前データと異なるデータが存在した場合はエラーとする。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If ARY_UDNTRA_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_UDNTRA_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_UDNTRA_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_UDNTRA_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or ARY_UDNTRA_HAITA(i).UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or ARY_UDNTRA_HAITA(i).UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or ARY_UDNTRA_HAITA(i).UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or ARY_UDNTRA_HAITA(i).UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
					GoTo Chk_HAITA_UPD_ERROR
				End If
			End If
			
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		Next i
		
		'受注トラン排他チェック
		For i = 1 To UBound(ARY_JDNTRA_HAITA)
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = ""
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       OPEID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,CLTID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTDT  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTTM  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UOPEID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UCLTID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTDT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTTM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       JDNTRA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       DATNO = '" & CF_Ora_Sgl(ARY_JDNTRA_HAITA(i).DATNO) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    LINNO = '" & CF_Ora_Sgl(ARY_JDNTRA_HAITA(i).LINNO) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FOR UPDATE " & vbCrLf
			
			'DBアクセス
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			'ﾃﾞｰﾀがあるとき
			If CF_Ora_EOF(Usr_Ody) = False Then
				' 更新前データと異なるデータが存在した場合はエラーとする。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If ARY_JDNTRA_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_JDNTRA_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_JDNTRA_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_JDNTRA_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or ARY_JDNTRA_HAITA(i).UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or ARY_JDNTRA_HAITA(i).UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or ARY_JDNTRA_HAITA(i).UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or ARY_JDNTRA_HAITA(i).UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
					GoTo Chk_HAITA_UPD_ERROR
				End If
			End If
			
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
			
			
			'MAX(DATNO)の取得
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = ""
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       MAX(DATNO) AS DATNO  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       JDNTRA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       JDNNO = '" & CF_Ora_Sgl(ARY_JDNTRA_HAITA(i).JDNNO) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    LINNO = '" & CF_Ora_Sgl(ARY_JDNTRA_HAITA(i).LINNO) & "'" & vbCrLf
			
			
			'DBアクセス
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			'ﾃﾞｰﾀがあるとき
			If CF_Ora_EOF(Usr_Ody) = False Then
				' 更新前データがMAX(DATNO)で無い場合はエラーとする。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, DATNO, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If ARY_JDNTRA_HAITA(i).DATNO <> CF_Ora_GetDyn(Usr_Ody, "DATNO", "") Then
					GoTo Chk_HAITA_UPD_ERROR
				End If
			End If
			
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
			
		Next i
		
		
		'売上トラン.入金レコード排他チェック
		For i = 0 To UBound(ARY_UDNTRA_NYU_HAITA)
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = ""
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       OPEID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,CLTID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTDT  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTTM  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UOPEID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UCLTID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTDT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTTM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       UDNTRA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       DATNO = '" & CF_Ora_Sgl(ARY_UDNTRA_NYU_HAITA(i).DATNO) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    LINNO = '" & CF_Ora_Sgl(ARY_UDNTRA_NYU_HAITA(i).LINNO) & "'" & vbCrLf
			'    strSql = strSql & "FOR UPDATE " & vbCrLf
			
			'DBアクセス
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			'ﾃﾞｰﾀがあるとき
			If CF_Ora_EOF(Usr_Ody) = False Then
				' 更新前データと異なるデータが存在した場合はエラーとする。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If ARY_UDNTRA_NYU_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_UDNTRA_NYU_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_UDNTRA_NYU_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_UDNTRA_NYU_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or ARY_UDNTRA_NYU_HAITA(i).UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or ARY_UDNTRA_NYU_HAITA(i).UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or ARY_UDNTRA_NYU_HAITA(i).UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or ARY_UDNTRA_NYU_HAITA(i).UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
					GoTo Chk_HAITA_UPD_ERROR
				End If
			End If
			
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
			
			
			'        'MAX(DATNO)の取得
			'        strSql = ""
			'        strSql = strSql & "SELECT  MAX(DATNO) AS DATNO" & vbCrLf
			'        strSql = strSql & " FROM   UDNTRA" & vbCrLf
			'        strSql = strSql & "WHERE   DATKB   =   '1'" & vbCrLf
			'        strSql = strSql & " AND    OKRJONO =   '" & CF_Ora_Sgl(ARY_UDNTRA_NYU_HAITA(i).OKRJONO) & "'" & vbCrLf
			'        strSql = strSql & " AND    UDNNO   =   '" & CF_Ora_Sgl(ARY_UDNTRA_NYU_HAITA(i).UDNNO) & "'" & vbCrLf
			'        strSql = strSql & " AND    LINNO   =   '" & CF_Ora_Sgl(ARY_UDNTRA_NYU_HAITA(i).LINNO) & "'" & vbCrLf
			'
			'
			'        'DBアクセス
			'        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			'
			'        'ﾃﾞｰﾀがあるとき
			'        If CF_Ora_EOF(Usr_Ody) = False Then
			'            ' 更新前データがMAX(DATNO)で無い場合はエラーとする。
			'            If ARY_UDNTRA_NYU_HAITA(i).DATNO <> CF_Ora_GetDyn(Usr_Ody, "DATNO", "") Then
			'                GoTo Chk_HAITA_UPD_ERROR
			'            End If
			'        End If
			'
			'        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
			
		Next i
		
		
		
		'入金消込サマリー排他チェック
		For i = 1 To UBound(ARY_NKSSMB_HAITA)
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = ""
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       OPEID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,CLTID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTDT  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTTM  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       NKSSMB " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(ARY_NKSSMB_HAITA(i).TOKCD) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(ARY_NKSSMB_HAITA(i).SMADT) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FOR UPDATE " & vbCrLf
			
			'DBアクセス
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			'ﾃﾞｰﾀがあるとき
			If CF_Ora_EOF(Usr_Ody) = False Then
				' 更新前データと異なるデータが存在した場合はエラーとする。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If ARY_NKSSMB_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_NKSSMB_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_NKSSMB_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_NKSSMB_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Then
					GoTo Chk_HAITA_UPD_ERROR
				End If
			End If
			
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		Next i
		
		'入金消込トラン排他チェック
		For i = 1 To UBound(ARY_NKSTRA_HAITA)
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = ""
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       OPEID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,CLTID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTDT  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTTM  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UOPEID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UCLTID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTDT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTTM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       NKSTRA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       KDNNO = '" & CF_Ora_Sgl(ARY_NKSTRA_HAITA(i).KDNNO) & "'" & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FOR UPDATE " & vbCrLf
			
			'DBアクセス
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			'ﾃﾞｰﾀがあるとき
			If CF_Ora_EOF(Usr_Ody) = False Then
				' 更新前データと異なるデータが存在した場合はエラーとする。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If ARY_NKSTRA_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_NKSTRA_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_NKSTRA_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_NKSTRA_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or ARY_NKSTRA_HAITA(i).UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or ARY_NKSTRA_HAITA(i).UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or ARY_NKSTRA_HAITA(i).UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or ARY_NKSTRA_HAITA(i).UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
					GoTo Chk_HAITA_UPD_ERROR
				End If
			End If
			
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		Next i
		
		Chk_HAITA_UPD = True
		
		Exit Function
		
Chk_HAITA_UPD_ERROR: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSB_Update
	'   概要：  TOKSSBの更新(無ければ新規に作成する)
	'   引数：  pm_strTokseicd  : 得意先コード
	'           pm_intKesikn : 消込金額
	'           pm_strSSADT  : 締日付
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_Update(ByRef pm_strTokseicd As String, ByRef pm_intKesikn As Decimal, ByVal pm_strSSADT As String) As Boolean
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strKesdt As String
		Dim strMOT_KSKNYKKN As Decimal
		Dim strMOT_KSKZANKN As Decimal
		Dim strKSKNYKKN As Decimal
		Dim strKSKZANKN As Decimal
		Dim strJKESIKN As Decimal
		
		On Error GoTo F_TOKSSB_Update_ERROR
		
		F_TOKSSB_Update = 9
		
		'サマリ存在チェック
		strSql = ""
		strSql = strSql & "SELECT "
		strSql = strSql & "       KSKNYKKN , KSKZANKN "
		strSql = strSql & "FROM "
		strSql = strSql & "       TOKSSB "
		strSql = strSql & "WHERE "
		strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokseicd) & "'"
		strSql = strSql & "AND    SSADT = '" & CF_Ora_Sgl(pm_strSSADT) & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'ﾃﾞｰﾀがない時
		If CF_Ora_EOF(Usr_Ody) = True Then
			
			'回収予定日取得
			strKesdt = getKesdt(DB_TOKMTA.TOKSMEKB, DB_TOKMTA.TOKSMEDT, DB_TOKMTA.TOKSMECC, DB_TOKMTA.TOKSDWKB, DB_TOKMTA.TOKKESCC, DB_TOKMTA.TOKKESDD, DB_TOKMTA.TOKKDWKB, pm_strSSADT)
			
			'該当データが無い場合はInsert処理
			strSql = ""
			strSql = strSql & " INSERT INTO TOKSSB("
			strSql = strSql & "   TOKCD ,"
			strSql = strSql & "   SSADT,"
			strSql = strSql & "   KESDT,"
			strSql = strSql & "   SSAURIKN00,"
			strSql = strSql & "   SSAURIKN01,"
			strSql = strSql & "   SSAURIKN02,"
			strSql = strSql & "   SSAURIKN03,"
			strSql = strSql & "   SSAURIKN04,"
			strSql = strSql & "   SSAURIKN05,"
			strSql = strSql & "   SSAURIKN06,"
			strSql = strSql & "   SSAURIKN07,"
			strSql = strSql & "   SSAURIKN08,"
			strSql = strSql & "   SSAURIKN09,"
			strSql = strSql & "   SSAUZEKN,"
			strSql = strSql & "   SZAKZIKN00,"
			strSql = strSql & "   SZAKZIKN01,"
			strSql = strSql & "   SZAKZIKN02,"
			strSql = strSql & "   SZAKZOKN00,"
			strSql = strSql & "   SZAKZOKN01,"
			strSql = strSql & "   SZAKZOKN02,"
			strSql = strSql & "   SZBKZIKN00,"
			strSql = strSql & "   SZBKZIKN01,"
			strSql = strSql & "   SZBKZIKN02,"
			strSql = strSql & "   SZBKZOKN00,"
			strSql = strSql & "   SZBKZOKN01,"
			strSql = strSql & "   SZBKZOKN02,"
			strSql = strSql & "   SSANYUKN00,"
			strSql = strSql & "   SSANYUKN01,"
			strSql = strSql & "   SSANYUKN02,"
			strSql = strSql & "   SSANYUKN03,"
			strSql = strSql & "   SSANYUKN04,"
			strSql = strSql & "   SSANYUKN05,"
			strSql = strSql & "   SSANYUKN06,"
			strSql = strSql & "   SSANYUKN07,"
			strSql = strSql & "   SSANYUKN08,"
			strSql = strSql & "   SSANYUKN09,"
			strSql = strSql & "   KSKNYKKN,"
			strSql = strSql & "   KSKZANKN,"
			strSql = strSql & "   SSADENSU,"
			strSql = strSql & "   DATNO,"
			strSql = strSql & "   WRTTM,"
			strSql = strSql & "   WRTDT) "
			
			strSql = strSql & " VALUES(  "
			
			strSql = strSql & "   '" & Trim(pm_strTokseicd) & "'," '得意先コード
			strSql = strSql & "   '" & Trim(pm_strSSADT) & "'," '締日付
			strSql = strSql & "   '" & Trim(strKesdt) & "'," '決済日付
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '0',"
			strSql = strSql & "   '" & Space(10) & "'," '伝票管理��
			strSql = strSql & "   '" & Trim(GV_SysTime) & "'," 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
			strSql = strSql & "   '" & Trim(GV_SysDate) & "')" 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
			
			'SQL実行
			If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
				GoTo F_TOKSSB_Update_ERROR
			End If
			
			strMOT_KSKNYKKN = 0 '消込入金額
			strMOT_KSKZANKN = 0 '消込入金額残
			
		Else
			
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strMOT_KSKNYKKN = CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN", "") '消込入金額
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strMOT_KSKZANKN = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN", "") '消込入金額残
			
		End If
		
		strJKESIKN = pm_intKesikn
		
		'請求サマリの消込入金額と消込入金残額の計算を行う
		strKSKNYKKN = strMOT_KSKNYKKN + strJKESIKN
		strKSKZANKN = strMOT_KSKZANKN - strJKESIKN
		
		'請求サマリの更新
		strSql = ""
		strSql = strSql & "  UPDATE TOKSSB"
		strSql = strSql & "  SET KSKNYKKN =  '" & Trim(CStr(strKSKNYKKN)) & "'"
		strSql = strSql & "  ,   KSKZANKN =  '" & Trim(CStr(strKSKZANKN)) & "'"
		strSql = strSql & ",     WRTTM = '" & Trim(GV_SysTime) & "'"
		strSql = strSql & ",     WRTDT = '" & Trim(GV_SysDate) & "'"
		
		strSql = strSql & "  WHERE TOKCD   = '" & Trim(pm_strTokseicd) & "'"
		strSql = strSql & "  AND   SSADT   = '" & Trim(pm_strSSADT) & "'"
		
		'SQL実行
		If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
			GoTo F_TOKSSB_Update_ERROR
		End If
		
		F_TOKSSB_Update = 0
		Exit Function
		
F_TOKSSB_Update_ERROR: 
		Call SSSWIN_LOGWRT("F_TOKSSB_Update_ERROR")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function getUpdid
	'   概要： 支払区分より入金種別のUPDIDを取得
	'   引数： strSHAKB   : 支払区分
	'   戻値： UPDID
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'**** 2009/09/16 CHG START FKS)NAKATA
	'Public Function getUpdid() As String
	Public Function getUpdid(Optional ByRef pm_strNyukb As String = "") As String
		'**** 2009/09/16 CHG E.N.D FKS)NAKATA
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		Dim strDKBID As String
		'**** 2009/09/16 ADD START FKS)NAKATA
		Dim strNYUKB As String
		'**** 2009/09/16 ADD E.N.D FKS)NAKATA
		
		
		Dim strRECNO1 As String
		Dim strLINNO1 As String
		Dim strDATNO2 As String
		Dim strLINNO2 As String
		
		On Error GoTo ERR_GET_UPDID
		
		getUpdid = ""
		
		'元黒のデータを入手
		
		'売上トラン
		strSql = ""
		strSql = strSql & "SELECT "
		strSql = strSql & "       RECNO , JDNLINNO "
		strSql = strSql & "FROM "
		strSql = strSql & "       UDNTRA "
		strSql = strSql & "WHERE "
		strSql = strSql & "       DKBID IN ('02','06') "
		'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "AND    DATNO = '" & varSpdValue(COL_UDNDATNO) & "' "
		'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "AND    LINNO = '" & varSpdValue(COL_UDNLINNO) & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'ﾃﾞｰﾀがない時
			GoTo GET_DEF_DKBID
		Else
			'ﾃﾞｰﾀがある時
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strRECNO1 = CF_Ora_GetDyn(Usr_Ody, "RECNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strLINNO1 = CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")
		End If
		
		'売上トラン
		strSql = ""
		strSql = strSql & "SELECT "
		strSql = strSql & "       DATNO , LINNO "
		strSql = strSql & "FROM "
		strSql = strSql & "       UDNTRA "
		strSql = strSql & "WHERE "
		strSql = strSql & "       DKBID = '01' "
		strSql = strSql & "AND    RECNO = '" & strRECNO1 & "' "
		strSql = strSql & "AND    JDNLINNO = '" & strLINNO1 & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'ﾃﾞｰﾀがない時
			GoTo GET_DEF_DKBID
		Else
			'ﾃﾞｰﾀがある時
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strDATNO2 = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strLINNO2 = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
		End If
		
		'入金消込トラン
		strSql = ""
		strSql = strSql & "SELECT "
		strSql = strSql & "       * "
		strSql = strSql & "FROM "
		strSql = strSql & "       NKSTRA "
		strSql = strSql & "WHERE "
		strSql = strSql & "       DATKB    = '1' "
		strSql = strSql & "AND    AKAKROKB = '1' "
		strSql = strSql & "AND    UDNDATNO = '" & strDATNO2 & "' "
		strSql = strSql & "AND    UDNLINNO = '" & strLINNO2 & "' "
		strSql = strSql & "AND    KDNNO NOT IN (SELECT MOTKDNNO FROM NKSTRA WHERE TRIM(MOTKDNNO) IS NOT NULL) "
		strSql = strSql & " ORDER BY KDNNO DESC "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'ﾃﾞｰﾀがない時
			GoTo GET_DEF_DKBID
		Else
			'ﾃﾞｰﾀがある時
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strDKBID = CF_Ora_GetDyn(Usr_Ody, "DKBID", "")
			'**** 2009/09/16 ADD START FKS)NAKATA
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_strNyukb = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
			'**** 2009/09/16 ADD E.N.D FKS)NAKATA
			
		End If
		
		GoTo GET_SYSTBD_UPDID
		
GET_DEF_DKBID: 
		
		'**** 2009/09/16 CHG START FKS)NAKATA
		'    Select Case DB_TOKMTA.SHAKB
		'        Case "3"
		'            strDKBID = "02"
		'        Case "4"
		'            strDKBID = "02"
		'        Case "5"
		'            strDKBID = "08"
		'        Case "5"
		'            strDKBID = "08"
		'        Case "6"
		'            strDKBID = "08"
		'        Case Else
		'            strDKBID = "02"
		'    End Select
		
		Select Case DB_TOKMTA.SHAKB
			Case "3"
				strDKBID = "02"
				pm_strNyukb = "1"
			Case "4"
				strDKBID = "02"
				pm_strNyukb = "1"
			Case "5"
				strDKBID = "08"
				pm_strNyukb = "2"
			Case "6"
				strDKBID = "08"
				pm_strNyukb = "2"
			Case Else
				strDKBID = "02"
				pm_strNyukb = "1"
		End Select
		
		Call SSSWIN_LOGWRT("getUpdid_getDEFAULT")
		'**** 2009/09/16 CHG E.N.D FKS)NAKATA
		
		
GET_SYSTBD_UPDID: 
		
		strSql = "SELECT * FROM SYSTBD " & "WHERE DKBSB = '050' " & "AND DKBID = '" & strDKBID & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			getUpdid = CF_Ora_GetDyn(Usr_Ody, "updid", "")
		End If
		
END_GET_UPDID: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_GET_UPDID: 
		GoTo END_GET_UPDID
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function setNKSTRA
	'   概要：  入金消込トランの更新と他テーブル更新
	'   引数：  なし
	'   戻値：　0 : 正常  1 : 警告  9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function setNKSTRA() As Boolean
		
		Dim strSql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: 構造体 Usr_Ody_1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_1 As U_Ody
		
		Dim strSMADT_DSP As String '経理締日付(画面)
		Dim strSMADT_TBL As String '経理締日付(入金消込トラン)
		Dim strNYUDT_DSP As String '請求締め(画面)
		Dim strNYUDT_TBL As String '請求締め(入金消込トラン)
		
		Dim lstrKDNNO As String '前回消込伝票番号
		Dim intJkesikn As Decimal '前回消込額
		Dim intKesikn As Decimal '今回消込額
		
		Dim intRet As Short
		
		Dim cur_KESIZAN As Decimal
		Dim cur_KESIKIN As Decimal
		Dim cur_KIN_WK As Decimal
		
		Dim strDKBID As String
		Dim strUPDID As String
		Dim strTEGDT As String
		Dim strNYUKB As String
		Dim int_UPDID As Short
		
		Dim i As Short
		Dim j As Short
		
		setNKSTRA = False
		
		'経理締め
		strSMADT_DSP = DeCNV_DATE(Get_Acedt(gstrKesidt.Value)) '経理締日付(画面)
		
		'請求締め
		strNYUDT_DSP = getSmedt(gstrKesidt.Value, DB_TOKMTA.TOKSMEKB, DB_TOKMTA.TOKSMEDD, DB_TOKMTA.TOKSMECC, DB_TOKMTA.TOKSDWKB) '請求締め(画面)
		
		'今回消込額を格納(消込金額−消込金額(締日前))
		'UPGRADE_WARNING: オブジェクト SSSVal(varSpdValue(COL_KESIKN_MAE)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))
		
		'-------------------------------------------------------------------------------------------
		
		'変更前消込金額(絶対値)が消込金額(絶対値)より大きい時は元NKSTRAを更新する　→派生してJDNTRA,UDNTRA,TOKSSB,TOKSMAの更新
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If System.Math.Abs(SSSVal(varSpdValue(COL_KESIKN))) < System.Math.Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
			
			'削除対象のNKSTRAデータを取得(NKSTRA一明細ごとにサマリの戻しを行う必要があるため)
			strSql = ""
			strSql = strSql & "SELECT " & vbCrLf
			strSql = strSql & "       * " & vbCrLf
			strSql = strSql & "FROM " & vbCrLf
			strSql = strSql & "       NKSTRA " & vbCrLf
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       UDNDATNO = '" & varSpdValue(COL_UDNDATNO) & "' " & vbCrLf
			'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    UDNLINNO = '" & varSpdValue(COL_UDNLINNO) & "' " & vbCrLf
			strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
			strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
			
			'DBアクセス
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			Do While CF_Ora_EOF(Usr_Ody) = False
				
				'取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
				strSql = ""
				strSql = strSql & "SELECT " & vbCrLf
				strSql = strSql & "       * " & vbCrLf
				strSql = strSql & "FROM " & vbCrLf
				strSql = strSql & "       NKSTRA " & vbCrLf
				strSql = strSql & "WHERE " & vbCrLf
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf
				
				'DBアクセス
				Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
				
				If CF_Ora_EOF(Usr_Ody_1) Then
					
					'消込伝票番号
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					lstrKDNNO = CF_Ora_GetDyn(Usr_Ody, "KDNNO", "")
					
					'消込金額
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JKESIKN", ""))
					
					
					'経理締め
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSMADT_TBL = DeCNV_DATE(Get_Acedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""))) '経理締日付(入金消込トラン)
					
					'請求締め
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strNYUDT_TBL = getSmedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""), DB_TOKMTA.TOKSMEKB, DB_TOKMTA.TOKSMEDD, DB_TOKMTA.TOKSMECC, DB_TOKMTA.TOKSDWKB) '請求締め(入金消込トラン)
					
					
					'更新IDと入金種別を取得
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strUPDID = CF_Ora_GetDyn(Usr_Ody, "UPDID", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strNYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strDKBID = CF_Ora_GetDyn(Usr_Ody, "DKBID", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
					
					
					'★NKSTRA更新・追加
					'CHG START FKS)INABA 2010/05/20 *******************************************************************************
					'連絡票��818(画面消込月度とテーブルの消込月度が同一の場合かつ画面請求締月度とテーブルの請求締月度が等しい場合)
					If strSMADT_DSP = strSMADT_TBL And strNYUDT_DSP = strNYUDT_TBL Then
						'                If strSMADT_DSP = strSMADT_TBL Then
						'                    ' 画面消込月度とテーブルの消込月度が同一の場合
						'CHG START FKS)INABA 2010/05/20 *******************************************************************************
						If F_NKSTRA_UPDATE1(lstrKDNNO) = 9 Then
							Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
							Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
							Exit Function
						End If
					Else
						' 画面消込月度とテーブルの消込月度が異なる場合
						If F_NKSTRA_INSERT1(Usr_Ody, strSMADT_DSP, lstrKDNNO) = 9 Then
							Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
							Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
							Exit Function
						End If
					End If
					
					'★TOKSSB更新(DATKB=9よりマイナス更新する)
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If F_TOKSSB_Update(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, strNYUDT_DSP) = 9 Then
						Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					
					'**** 2009/09/16 CHG START FKS)NAKATA
					''                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
					''                If DB_TOKMTA.SHAKB = "5" Or DB_TOKMTA.SHAKB = "6" Then
					''                    Else
					'TOKSMAの更新は請求先の支払条件に関わらず、入金区分にて判断する(入金区分「1」「3」の時のみ更新)
					If strNYUKB = "1" Or strNYUKB = "3" Then
						'**** 2009/09/16 CHG E.N.D FKS)NAKATA
						'★TOKSMA更新(DATKB=9よりマイナス更新する)
						'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", (-1) * intJkesikn, strSMADT_DSP) = False Then
							Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
							Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
							Exit Function
						End If
					End If
					
					
					
					'★UDNTRA更新(売上伝票DENKB=1) (DATKB=9よりマイナス更新する)
					'**** 2009/09/16 CHG START FKS)NAKATA
					'                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn) = False Then
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn, strNYUKB) = False Then
						'**** 2009/09/16 CHG E.N.D FKS)NAKATA
						Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					
					'★JDNTRA更新(DATKB=9よりマイナス更新する)
					'**** 2009/09/16 CHG START FKS)NAKATA
					'                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn, strNYUKB) = False Then
						'**** 2009/09/16 CHG E.N.D FKS)NAKATA
						Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					'★消込トランより取得した振込期日が<=運用日の場合、現金とする
					If Trim(strNYUKB) = "2" Or Trim(strNYUKB) = "3" Then
						If Trim(strTEGDT) <> "" Then
							If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
								strUPDID = "00" '01:現金
							End If
						End If
					End If
					
					
					'**** 2009/10/01 ADD START FKS)NAKATA
					'★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
					If strDKBID = "03" Then
						If Trim(strTEGDT) <> "" Then
							If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
								strUPDID = "00" '01:現金
							End If
						End If
					End If
					'**** 2009/10/01 ADD E.N.D FKS)NAKATA
					
					
					'★入金消込サマリ更新（入金消し込み集計金額）
					If F_NKSSMB_KSK_Update(DB_TOKMTA.TOKSEICD, strUPDID, (-1) * intJkesikn, strSMADT_DSP, strSMADT_TBL) = 9 Then
						Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
				End If
				
				Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
				'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Usr_Ody.Obj_Ody.MoveNext()
				
			Loop 
			
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
			
			'前回消込金額を0とする
			'        varSpdValue(COL_AFKESIKN) = 0
			'UPGRADE_WARNING: オブジェクト varSpdValue(COL_KESIKN_MAE) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			varSpdValue(COL_KESIKN_MAE) = 0
			
		End If
		
		'-------------------------------------------------------------------------------------------
		
		'締日以降消込金額(絶対値)が消込金額(絶対値)より小きい時は差額を新規に作成
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If System.Math.Abs(SSSVal(varSpdValue(COL_KESIKN))) > System.Math.Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
			'UPGRADE_WARNING: オブジェクト SSSVal(varSpdValue(COL_KESIKN_MAE)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))
			
			'消し込み金額取得
			cur_KIN_WK = intKesikn
			
			'UPGRADE_WARNING: オブジェクト SSSVal(varSpdValue(COL_KOMIKN)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(varSpdValue(COL_KESIKN)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト varSpdValue(COL_HENPI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If varSpdValue(COL_HENPI) = "1" And SSSVal(varSpdValue(COL_KESIKN)) <= SSSVal(varSpdValue(COL_KOMIKN)) Then
				
				'●●●●●返品時消し込み●●●●●
				
				cur_KESIKIN = cur_KIN_WK
				
				'ここで返品時のUPDIDを入手
				int_UPDID = CShort(getUpdid(strNYUKB))
				
				'更新IDと入金種別を取得
				strUPDID = ARY_NKSSMB_KS(int_UPDID).UPDID
				strDKBID = ARY_NKSSMB_KS(int_UPDID).DATKB
				
				
				'*** 2009/09/16 DEL START FKS)NAKATA
				'            '取引区分="03"(手形) or "08"(振込仮) で期日振込日が入力されているデータを入金区分=2で設定する。
				'            'それ以外は１を設定する。
				'            strNyukb = "1"
				'            With ARY_NKSSMB_KS(int_UPDID)
				'                If .DATKB = "03" Or .DATKB = "08" Then
				'                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
				'                        strNyukb = "2"
				'                    End If
				'                End If
				'            End With
				'*** 2009/09/16 DEL E.N.D FKS)NAKATA
				
				
				'★NKSTRA追加
				If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
					Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
					Exit Function
				End If
				
				'★TOKSSB更新
				'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If F_TOKSSB_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA.KESISMEDT) = 9 Then
					Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
					Exit Function
				End If
				
				
				'**** 2009/09/16 CHG START FKS)NAKATA
				''                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
				''                If DB_TOKMTA.SHAKB = "5" Or DB_TOKMTA.SHAKB = "6" Then
				''                    Else
				'TOKSMAの更新は請求先の支払条件に関わらず、入金区分にて判断する(入金区分「1」「3」の時のみ更新)
				If strNYUKB = "1" Or strNYUKB = "3" Then
					'**** 2009/09/16 CHG E.N.D FKS)NAKATA
					'★TOKSMA更新
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
				End If
				
				
				'★UDNTRA更新
				'**** 2009/09/16 CHG START FKS)NAKATA
				''           If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
				'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
					'**** 2009/09/16 CHG E.N.D FKS)NAKATA
					Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
					Exit Function
				End If
				
				
				'★JDNTRA更新
				'**** 2009/09/16 CHG START FKS)NAKATA
				'            If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
				'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
					'**** 2009/09/16 CHG E.N.D FKS)NAKATA
					Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
					Exit Function
				End If
				
				
				'振込期日 <= 運用日の場合、現金として消込サマリを更新する
				If Trim(strNYUKB) = "2" Or Trim(strNYUKB) = "3" Then
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
						'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt.Value) Then
							strUPDID = "00" '01:現金
						End If
					End If
				End If
				
				
				'**** 2009/10/01 ADD START FKS)NAKATA
				'★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
				If strDKBID = "03" Then
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
						'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt.Value) Then
							strUPDID = "00" '01:現金
						End If
					End If
				End If
				'**** 2009/10/01 ADD E.N.D FKS)NAKATA
				
				
				
				'★入金消込サマリ更新（入金消し込み集計金額）
				'**** 2009/09/16 CHG START FKS)NAKATA
				''                If F_NKSSMB_KSK_Update(DB_TOKMTA.TOKSEICD, ARY_NKSSMB_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
				If F_NKSSMB_KSK_Update(DB_TOKMTA.TOKSEICD, strUPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
					'**** 2009/09/16 CHG START FKS)NAKATA
					Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
					Exit Function
				End If
				
			Else
				
				
				'●●●●●通常消し込み●●●●●
				Do 
					
					'消込可能金額取得
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Get_KESIKIN(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KIN_WK, cur_KESIKIN, cur_KESIZAN, int_UPDID, strNYUKB) = False Then
						Exit Function
					End If
					
					'消込残金額
					cur_KIN_WK = cur_KESIZAN
					
					
					'更新IDと入金種別を取得
					strUPDID = ARY_NKSSMB_KS(int_UPDID).UPDID
					strDKBID = ARY_NKSSMB_KS(int_UPDID).DATKB
					
					'*** 2009/09/16 DEL START FKS)NAKATA
					'入金区分は売上トランの入金レコードより取得
					''                '取引区分="03"(手形) or "08"(振込仮) で、期日振込日が入力されているデータを入金区分=2で設定する。
					''                'それ以外は1を設定する｡
					''                strNYUKB = "1"
					''                With ARY_NKSSMB_KS(int_UPDID)
					''                    If .DATKB = "03" Or .DATKB = "08" Then
					''                        If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
					''                            strNYUKB = "2"
					''                        End If
					''                    End If
					''                End With
					'*** 2009/09/16 DEL E.N.D FKS)NAKATA
					
					
					'★NKSTRA追加
					If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					'★TOKSSB更新
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If F_TOKSSB_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA.KESISMEDT) = 9 Then
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					
					'**** 2009/09/16 CHG START FKS)NAKATA
					''                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
					''                If DB_TOKMTA.SHAKB = "5" Or DB_TOKMTA.SHAKB = "6" Then
					''                    Else
					'TOKSMAの更新は請求先の支払条件に関わらず、入金区分にて判断する(入金区分「1」「3」の時のみ更新)
					If strNYUKB = "1" Or strNYUKB = "3" Then
						'**** 2009/09/16 CHG E.N.D FKS)NAKATA
						'★TOKSMA更新
						'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
							Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
							Exit Function
						End If
					End If
					
					
					'★UDNTRA更新
					'**** 2009/09/16 CHG START FKS)NAKATA
					''                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
						'**** 2009/09/16 CHG E.N.D FKS)NAKATA
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					
					'★JDNTRA更新
					'**** 2009/09/16 CHG START FKS)NAKATA
					'                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
					'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
						'**** 2009/09/16 CHG E.N.D FKS)NAKATA
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					
					'振込期日 <= 運用日の場合、現金として消込サマリを更新する
					If Trim(strNYUKB) = "2" Or Trim(strNYUKB) = "3" Then
						'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
							'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt.Value) Then
								strUPDID = "00" '01:現金
							End If
						End If
					End If
					
					'**** 2009/10/01 ADD START FKS)NAKATA
					'★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
					If strDKBID = "03" Then
						'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
							'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt.Value) Then
								strUPDID = "00" '01:現金
							End If
						End If
					End If
					'**** 2009/10/01 ADD E.N.D FKS)NAKATA
					
					
					'★入金消込サマリ更新（入金消し込み集計金額）
					'**** 2009/09/16 CHG START FKS)NAKATA
					''                If F_NKSSMB_KSK_Update(DB_TOKMTA.TOKSEICD, ARY_NKSSMB_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
					If F_NKSSMB_KSK_Update(DB_TOKMTA.TOKSEICD, strUPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
						'**** 2009/09/16 CHG START FKS)NAKATA
						
						
						Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
						Exit Function
					End If
					
					If cur_KIN_WK = 0 Then
						Exit Do
					End If
				Loop 
				
			End If
		End If
		
		setNKSTRA = True
		Exit Function
		
SETNKSTRA_ERROR: 
		Call SSSWIN_LOGWRT("SETNKSTRA_ERROR")
		
	End Function
	
	'*** 2009/07/06 ADD START FKS)NAKATA v1.01
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Get_KESIKIN
	'   概要：  消込可能金額取得
	'   引数：  pcur_JDNNO        : 受注番号
	'           pcur_JDNLINNO     : 受注行番号
	'           pcur_KESIKIN      : 消込金額
	'           pcur_KESIKOMIKIN  : 消込した金額
	'           pcur_KESIKOMIZAN  : 消込したができなかった残金額
	'           pint_KESIKOMIID   : 更新項目ID情報
	'   戻値：　true : 正常  false : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function Get_KESIKIN(ByVal pstr_JDNNO As String, ByVal pstr_JDNLINNO As String, ByVal pstr_UDNDATNO As String, ByVal pstr_UDNLINNO As String, ByVal pcur_KESIKIN As Decimal, ByRef pcur_KESIKOMIKIN As Decimal, ByRef pcur_KESIKOMIZAN As Decimal, ByRef pint_KESIKOMIID As Short, ByRef pstr_NYUKB As Object) As Boolean
		
		
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim i As Short
		Dim j As Short
		
		Dim BlnEndLoop As Boolean
		
		
		Dim str_JDNTRKB As String
		Dim str_OKRJONO As String '送り状��
		Dim str_HENRSNCD As String '返品理由
		
		Dim cur_KESIKIN As Decimal
		Dim cur_KESIZAN As Decimal
		Dim int_KESIID As Short
		Dim str_NYUKB As String
		
		Dim cur_ZANKN As Decimal
		
		
		Get_KESIKIN = False
		BlnEndLoop = False
		
		
		'受注番号より送り状�ｂ�取得する。
		str_OKRJONO = getOKRJONO(pstr_JDNNO, pstr_JDNLINNO)
		
		
		'消込順序で消込む
		For i = 0 To UBound(ARY_NYUKN_KS)
			
			'受注番号
			If ARY_NYUKN_KS(i).OKRJONO = str_OKRJONO Then
				
				'その金種で消込可能かの判断を行う。
				If ARY_NYUKN_KS(i).ZANKN > 0 Then
					
					'消込処理
					If ARY_NYUKN_KS(i).ZANKN - pcur_KESIKIN >= 0 Then
						'消込んだ金額を設定
						cur_KESIKIN = pcur_KESIKIN
						'消込できなかった金額を設定
						cur_KESIZAN = 0
						'消込んだ金額を考慮にいれて残額を反映する
						ARY_NYUKN_KS(i).ZANKN = ARY_NYUKN_KS(i).ZANKN - pcur_KESIKIN
						'更新IDを設定
						int_KESIID = CShort(VB6.Format(ARY_NYUKN_KS(i).UPDID, CStr(0)))
						'入金種別を設定
						str_NYUKB = ARY_NYUKN_KS(i).NYUKB
						'ループ終了
						BlnEndLoop = True
					Else
						'消込んだ金額を設定
						cur_KESIKIN = ARY_NYUKN_KS(i).ZANKN
						'消込できなかった金額を設定
						cur_KESIZAN = pcur_KESIKIN - ARY_NYUKN_KS(i).ZANKN
						'消込んだ金額を考慮にいれて残額を反映する
						ARY_NYUKN_KS(i).ZANKN = 0
						'更新IDを設定
						int_KESIID = CShort(VB6.Format(ARY_NYUKN_KS(i).UPDID, CStr(0)))
						'入金種別を設定
						str_NYUKB = ARY_NYUKN_KS(i).NYUKB
						'ループ終了
						BlnEndLoop = True
					End If
					
					'*** 2009/10/02 ADD START FKS)NAKATA
					'残がマイナスの場合
				ElseIf ARY_NYUKN_KS(i).ZANKN < 0 Then 
					
					'消込んだ金額を設定
					cur_KESIKIN = ARY_NYUKN_KS(i).ZANKN
					'消込できなかった金額を設定
					cur_KESIZAN = pcur_KESIKIN - ARY_NYUKN_KS(i).ZANKN
					'消込んだ金額を考慮にいれて残額を反映する
					ARY_NYUKN_KS(i).ZANKN = 0
					'更新IDを設定
					int_KESIID = CShort(VB6.Format(ARY_NYUKN_KS(i).UPDID, CStr(0)))
					'入金種別を設定
					str_NYUKB = ARY_NYUKN_KS(i).NYUKB
					'ループ終了
					BlnEndLoop = True
					
					'*** 2009/10/02 ADD E.N.D FKS)NAKATA
					
				End If
			End If
			
			'終了フラグがTRUEの場合は終わる
			If BlnEndLoop = True Then
				Exit For
			End If
			
		Next i
		
		
		'計算結果の反映
		pcur_KESIKOMIKIN = cur_KESIKIN
		pcur_KESIKOMIZAN = cur_KESIZAN
		pint_KESIKOMIID = int_KESIID
		'UPGRADE_WARNING: オブジェクト pstr_NYUKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pstr_NYUKB = str_NYUKB
		
		Get_KESIKIN = True
		
		
	End Function
	'*** 2009/07/06 ADD E.N.D FKS)NAKATA
End Module