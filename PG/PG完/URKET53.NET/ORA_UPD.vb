Option Strict Off
Option Explicit On
Module ORA_UPD
	
	'// V2.00↓ DEL
	'''---------------------------
	'''■ORACLE TABLEへの更新処理
	'''---------------------------
	'''2007/12/10 FKS)minamoto ADD START
	''Type TYPE_HAITA_UPDDT
	''    DATNO          As String        '伝票管理NO.
	''    LINNO          As String        '行番号
	''    WRTTM          As String        'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
	''    WRTDT          As String        'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
	''    UWRTTM         As String        'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
	''    UWRTDT         As String        'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
	''End Type
	'''2007/12/10 FKS)minamoto ADD END
	'// V2.00↑ DEL
	
	'// V2.00↓ ADD
	'---------------------------
	'■種別単位の消込金額情報
	'---------------------------
	Structure TYPE_NKSSMA_KS
		Dim SEQ As Short '消込順
		Dim UPDID As String '消込更新用ｲﾝﾃﾞｯｸｽ
		Dim DATKB As String '取引区分コード(本来の項目名はDKBIDです。名前が間違っています)
		Dim ZAN_KIN As Decimal '消し込んだ残り金額
		Dim SSANYUKN As Decimal '入金金額
		Dim KSKNYKKN As Decimal '消込金額
		Dim KSKZANKN As Decimal '消込残金額
	End Structure
	Public ARY_NKSSMA_KS() As TYPE_NKSSMA_KS
	
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
	Structure TYPE_NKSSMA_HAITA
		Dim TOKCD As String ' 得意先コード
		Dim SMADT As String ' 経理締日付
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（時間）
		Dim WRTDT As String ' タイムスタンプ（日付）
	End Structure
	Public ARY_NKSSMA_HAITA() As TYPE_NKSSMA_HAITA
	
	'---------------------------
	'■排他（入金消込トラン）
	'---------------------------
	Structure TYPE_NKSTRA_HAITA
		Dim KDNNO As String ' 消込伝票番号№
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
	'// V2.00↑ ADD
	
	'2009/09/15 UPD START RISE)MIYAJIMA
	''// V2.03↓ DEL
	'''''Private varSpdValue(35) As Variant          'スプレッドの値を格納(登録時に使用)
	'Private varSpdValue(COL_HENPI) As Variant          'スプレッドの値を格納(登録時に使用)
	''// V2.03↑ ADD
	Private varSpdValue(COL_SSADT) As Object 'スプレッドの値を格納(登録時に使用)
	'2009/09/15 UPD E.N.D RISE)MIYAJIMA
	
	'2009/10/22 ADD START RISE)MIYAJIMA
	Public intProcErrFlg As Short '更新時残額と一致しない消し込みが発生した時のエラーフラグ
    '2009/10/22 ADD E.N.D RISE)MIYAJIMA

    '// V2.00↓ DEL
    ''
    '''登録処理
    ''Public Function sRegistration(spd_body As vaSpread) As Boolean
    ''    Dim i As Integer
    ''    Dim j As Integer
    ''
    ''On Error GoTo SREGISTRATION_ERROR
    ''
    ''    sRegistration = False
    ''
    ''    'トランザクション開始
    ''    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    ''
    ''    '現在時刻、日付をセット
    ''    Call setSysdate(GV_SysTime, GV_SysDate)
    ''
    ''    '現在の最大KDNNOを取得
    ''    If GET_SYSTBC_DENNO(gc_DKBSB_KES, strKDNNO, strKDNNO_MIN, strKDNNO_MAX) <> 0 Then
    ''        GoTo SREGISTRATION_ERROR
    ''    End If
    ''
    ''    '1行ごとにテーブルに値を更新する
    ''    With spd_body
    ''        For i = 1 To .MaxRows
    ''            'スプレッドの値を変数に格納
    ''            For j = COL_CHK To COL_JDNDATNO
    ''                .Row = i
    ''                .Col = j
    ''                If .Col = COL_HYFRIDT Then
    ''                    '振込期日が空白の時は、space(8)をセット
    ''                    If .Text = "" Then
    ''                        varSpdValue(j) = Space(8)
    ''                    Else
    ''                        varSpdValue(j) = DeCNV_DATE(.Text)
    ''                    End If
    ''                Else
    ''                    varSpdValue(j) = .Text
    ''                End If
    ''            Next j
    ''
    ''            'NKSTRAの作成
    ''            If setNKSTRA = False Then
    ''                GoTo SREGISTRATION_ERROR
    ''            End If
    ''        Next i
    ''    End With
    ''
    ''    'KDNNOをSYSTBCに更新する
    ''    If F_SYSTBC_Update(gc_DKBSB_KES, strKDNNO) = 9 Then
    ''        GoTo SREGISTRATION_ERROR
    ''    End If
    ''
    ''    'コミット
    ''    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    ''
    ''    sRegistration = True
    ''    Exit Function
    ''
    ''SREGISTRATION_ERROR:
    ''    'ロールバック
    ''    Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    ''
    ''End Function
    ''
    ''
    '''NKSTRAの作成
    ''Private Function setNKSTRA() As Boolean
    ''    Dim strSql      As String
    ''    Dim Usr_Ody     As U_Ody
    ''
    ''    Dim lstrKDNNO   As String       '前回消込伝票番号
    ''    Dim lstrNYUDT   As String       '前回入金日
    ''    Dim intJkesikn  As Currency     '前回消込額
    ''
    ''    Dim intKesikn   As Currency     '今回消込額
    ''    Dim strSMADT    As String       '経理締日付
    ''
    ''    Dim strNYUKB    As String       '2007.03.05
    ''    '2007/12/11 FKS)minamoto ADD START
    ''    Dim intRet      As Integer
    ''    '2007/12/11 FKS)minamoto ADD END
    ''
    ''    setNKSTRA = False
    ''
    ''    '今回消込額を格納(消込金額－消込金額(締日前))
    ''    intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_BFKESIKN))
    ''
    ''    '更新モードにより処理を変更
    ''    If UPDATE_MODE = 1 Then
    ''        '●前回消込情報は削除、消込額で新規作成
    ''
    ''        '締日以降消込金額があるときは元NKSTRAを更新する　→派生してJDNTRA,UDNTRA,TOKSSA,TOKSMAの更新
    ''        If SSSVal(varSpdValue(COL_AFKESIKN)) <> 0 Then
    ''
    ''            '削除対象のNKSTRAデータを取得(NKSTRA一明細ごとにサマリの戻しを行う必要があるため)
    ''            strSql = "SELECT * FROM nkstra " _
    '''                    & "WHERE datkb = '1' " _
    '''                      & "AND udndatno = '" & varSpdValue(COL_UDNDATNO) & "' " _
    '''                      & "AND udnlinno = '" & varSpdValue(COL_UDNLINNO) & "' " _
    '''                      & "AND nyudt > '" & DB_SYSTBA.SMAUPDDT & "'"
    ''
    ''            'DBアクセス
    ''            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''            '2007/12/11 FKS)minamoto ADD START
    ''            '排他日時判定
    ''
    '''NAKATA
    '''XX            intRet = Execute_PLSQL_PRC_URKET53_02(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), CStr(DB_SYSTBA.SMAUPDDT))
    '''XX            If intRet <> 0 Then
    '''XX                'エラー
    '''XX                Call showMsg("2", "URKET53_039", 0) '他のプログラムで更新されたため、登録できません。
    '''XX                Exit Function
    '''XX            End If
    ''            '2007/12/11 FKS)minamoto ADD END
    ''
    ''            Do While CF_Ora_EOF(Usr_Ody) = False
    ''                lstrKDNNO = CF_Ora_GetDyn(Usr_Ody, "kdnno", "")
    ''                lstrNYUDT = CF_Ora_GetDyn(Usr_Ody, "nyudt", "")
    ''                '締日付に変換
    ''                strSMADT = DeCNV_DATE(Get_Acedt(lstrNYUDT))     '経理締め
    ''                lstrNYUDT = getSmedt(lstrNYUDT, DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB) '請求締め
    ''                intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "jkesikn", ""))
    ''
    ''                strSql = "UPDATE nkstra SET datkb = '9' " _
    '''                             & ",opeid = '" & SSS_OPEID & "', cltid = '" & SSS_CLTID & "' " _
    '''                             & ",wrttm = '" & GV_SysTime & "', wrtdt = '" & GV_SysDate & "' " _
    '''                             & ",uopeid = '" & SSS_OPEID & "', ucltid = '" & SSS_CLTID & "' " _
    '''                             & ",uwrttm = '" & GV_SysTime & "', uwrtdt = '" & GV_SysDate & "' " _
    '''                             & ",pgid = '" & SSS_PrgId & "' "
    ''
    ''                '消込金額－消込金額(締日前)が0の時は削除ﾌﾗｸﾞを1に更新する
    ''                If intKesikn = 0 Then
    ''                    strSql = strSql & ", dlflg = '1' "
    ''                End If
    ''
    ''                strSql = strSql & "WHERE datkb = '1' " _
    '''                                  & "AND kdnno = '" & lstrKDNNO & "'"
    ''
    ''                '★UPDATE実行
    ''                If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    GoTo SETNKSTRA_ERROR
    ''                End If
    ''
    ''                '★TOKSSA更新(DATKB=9よりマイナス更新する)
    ''                If setTOKSSA(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, lstrNYUDT) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''                Else
    ''                    '★TOKSMA更新(DATKB=9よりマイナス更新する)
    ''                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", (-1) * intJkesikn, strSMADT) = False Then
    ''                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                        Exit Function
    ''                    End If
    ''                End If
    ''
    ''                '★UDNTRA更新(DATKB=9よりマイナス更新する)
    ''                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                '★JDNTRA更新(DATKB=9よりマイナス更新する)
    ''''''''''''''''''If setJDNTRA(CStr(varSpdValue(COL_JDNDATNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then  '2007.03.05
    ''                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                Usr_Ody.Obj_Ody.MoveNext
    ''            Loop
    ''
    ''            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''        End If
    ''
    ''        '消込金額－消込金額(締日前)が0でない時はNKSTRAを新規に作成
    ''        If intKesikn <> 0 Then
    ''
    ''            '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2             '2007.03.05
    ''            If DB_TOKMTA2.SHAKB = 5 Or DB_TOKMTA2.SHAKB = 6 Then
    ''                strNYUKB = "2"
    ''            Else
    ''                strNYUKB = "1"
    ''            End If
    ''
    ''            '消込伝票番号カウントアップ
    ''            If CLng(strKDNNO_MAX) < CLng(strKDNNO) + 1 Then
    ''                strKDNNO = strKDNNO_MIN
    ''            Else
    ''                strKDNNO = Format(CLng(strKDNNO) + 1, "00000000")
    ''            End If
    ''
    ''            strSql = "INSERT INTO nkstra (" _
    '''                               & "kdnno, datkb, nyurecno, udnrecno, nyudt, jkesikn, tokseicd, tokcd, " _
    '''                               & "tancd, jdnno, jdnlinno, udndt, urikn, tegdt, jdndt, tukkb, invno, " _
    '''                               & "furikn, fkesikn, frnkb, nyukb, udndatno, udnlinno, maeukkb, " _
    '''                               & "fopeid, fcltid, wrtfsttm, wrtfstdt, opeid, cltid, wrttm, wrtdt, " _
    '''                               & "uopeid , ucltid, uwrttm, uwrtdt, pgid, dlflg) " _
    '''                            & "VALUES (" _
    '''                               & "'" & strKDNNO & "', '1', " _
    '''                               & "'" & Space(10) & "', '" & Space(10) & "', " _
    '''                               & "'" & gstrKesidt & "', " _
    '''                               & intKesikn & ", " _
    '''                               & "'" & CF_Ora_String(varSpdValue(COL_TOKSEICD), 10) & "', " _
    '''                               & "'" & CF_Ora_String(varSpdValue(COL_TOKCD), 10) & "', " _
    '''                               & "'" & varSpdValue(COL_TANCD) & "', " _
    '''                               & "'" & CF_Ora_String(varSpdValue(COL_JDNNO), 10) & "', " _
    '''                               & "'" & varSpdValue(COL_JDNLINNO) & "', " _
    '''                               & "'" & varSpdValue(COL_UDNDT) & "', " _
    '''                               & SSSVal(varSpdValue(COL_KOMIKN)) & ", " _
    '''                               & "'" & varSpdValue(COL_HYFRIDT) & "', " _
    '''                               & "'" & varSpdValue(COL_JDNDT) & "', " _
    '''                               & "'" & varSpdValue(COL_TUKKB) & "', " _
    '''                               & "'" & varSpdValue(COL_INVNO) & "', " _
    '''                               & "0, 0, " _
    '''                               & "'" & varSpdValue(COL_FRNKB) & "', "
    '''''                            & "1, "                                      '2007.03.05
    ''            strSql = strSql & "'" & strNYUKB & "', "
    ''
    ''            strSql = strSql _
    '''                               & "'" & varSpdValue(COL_UDNDATNO) & "', " _
    '''                               & "'" & varSpdValue(COL_UDNLINNO) & "', " _
    '''                               & "'" & varSpdValue(COL_MAEUKKB) & "', " _
    '''                               & "'" & SSS_OPEID & "', " _
    '''                               & "'" & SSS_CLTID & "', " _
    '''                               & "'" & GV_SysTime & "', " _
    '''                               & "'" & GV_SysDate & "', " _
    '''                               & "'" & SSS_OPEID & "', " _
    '''                               & "'" & SSS_CLTID & "', " _
    '''                               & "'" & GV_SysTime & "', " _
    '''                               & "'" & GV_SysDate & "', " _
    '''                               & "'" & SSS_OPEID & "', " _
    '''                               & "'" & SSS_CLTID & "', " _
    '''                               & "'" & GV_SysTime & "', " _
    '''                               & "'" & GV_SysDate & "', " _
    '''                               & "'" & SSS_PrgId & "',"
    ''
    ''            '消込金額(締日以降)が0の時はDLFLGは2:新規
    ''            If SSSVal(varSpdValue(COL_AFKESIKN)) = 0 Then
    ''                strSql = strSql & "'2')"
    ''            Else
    ''                strSql = strSql & "'3')"
    ''            End If
    ''
    ''            '★INSERT実行
    ''            If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
    ''                GoTo SETNKSTRA_ERROR
    ''            End If
    ''
    ''            '★TOKSSA更新
    ''            If setTOKSSA(CStr(varSpdValue(COL_TOKSEICD)), intKesikn, DB_TOKMTA2.KESISMEDT) = False Then
    ''                Exit Function
    ''            End If
    ''
    ''            'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''            If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''            Else
    ''                '★TOKSMA更新
    ''                strSMADT = DeCNV_DATE(Get_Acedt(gstrKesidt))     '経理締め
    ''                If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", intKesikn, strSMADT) = False Then
    ''                    Exit Function
    ''                End If
    ''            End If
    ''
    ''            '★UDNTRA更新
    ''            If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), intKesikn) = False Then
    ''                Exit Function
    ''            End If
    ''
    ''            '★JDNTRA更新
    ''''''        If setJDNTRA(CStr(varSpdValue(COL_JDNDATNO)), CStr(varSpdValue(COL_JDNLINNO)), intKesikn) = False Then      '2007.03.05
    ''            If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then
    ''                Exit Function
    ''            End If
    ''        End If
    ''
    ''    ElseIf UPDATE_MODE = 2 Then
    ''        '●差額を追加する更新（前データは残す)
    ''
    ''        '締日以降消込金額(絶対値)が消込金額(絶対値)より大きい時は元NKSTRAを更新する　→派生してJDNTRA,UDNTRA,TOKSSA,TOKSMAの更新
    ''        If Abs(intKesikn) < Abs(SSSVal(varSpdValue(COL_AFKESIKN))) Then
    ''
    ''
    ''            '削除対象のNKSTRAデータを取得(NKSTRA一明細ごとにサマリの戻しを行う必要があるため)
    ''            strSql = "SELECT * FROM nkstra " _
    '''                    & "WHERE datkb = '1' " _
    '''                      & "AND udndatno = '" & varSpdValue(COL_UDNDATNO) & "' " _
    '''                      & "AND udnlinno = '" & varSpdValue(COL_UDNLINNO) & "' " _
    '''                      & "AND nyudt > '" & DB_SYSTBA.SMAUPDDT & "'"
    ''
    ''            'DBアクセス
    ''            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''            '2007/12/11 FKS)minamoto ADD START
    ''            '排他日時判定
    ''
    '''NAKATA
    '''XX            intRet = Execute_PLSQL_PRC_URKET53_02(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), CStr(DB_SYSTBA.SMAUPDDT))
    '''XX            If intRet <> 0 Then
    '''XX                'エラー
    '''XX                Call showMsg("2", "URKET53_039", 0) '他のプログラムで更新されたため、登録できません。
    '''XX                Exit Function
    '''XX
    '''XX            End If
    ''            '2007/12/11 FKS)minamoto ADD END
    ''
    ''            Do While CF_Ora_EOF(Usr_Ody) = False
    ''                lstrKDNNO = CF_Ora_GetDyn(Usr_Ody, "kdnno", "")
    ''                lstrNYUDT = CF_Ora_GetDyn(Usr_Ody, "nyudt", "")
    ''                '締日付に変換
    ''                strSMADT = DeCNV_DATE(Get_Acedt(lstrNYUDT))     '経理締め
    ''                lstrNYUDT = getSmedt(lstrNYUDT, DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB)
    ''                intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "jkesikn", ""))
    ''
    ''
    ''                strSql = "UPDATE nkstra SET datkb = '9' " _
    '''                             & ",opeid = '" & SSS_OPEID & "', cltid = '" & SSS_CLTID & "' " _
    '''                             & ",wrttm = '" & GV_SysTime & "', wrtdt = '" & GV_SysDate & "' " _
    '''                             & ",uopeid = '" & SSS_OPEID & "', ucltid = '" & SSS_CLTID & "' " _
    '''                             & ",uwrttm = '" & GV_SysTime & "', uwrtdt = '" & GV_SysDate & "' " _
    '''                             & ",pgid = '" & SSS_PrgId & "' "
    ''
    ''                '消込金額－消込金額(締日前)が0の時は削除ﾌﾗｸﾞを1に更新する →常に1に更新する 2007/03/28
    ''                'If intKesikn = 0 Then
    ''                    strSql = strSql & ", dlflg = '1' "
    ''                'End If
    ''
    ''                strSql = strSql & "WHERE datkb = '1' " _
    '''                                  & "AND kdnno = '" & lstrKDNNO & "'"
    ''
    ''                '★UPDATE実行
    ''                If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    GoTo SETNKSTRA_ERROR
    ''                End If
    ''
    ''                '★TOKSSA更新(DATKB=9よりマイナス更新する)
    ''                If setTOKSSA(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, lstrNYUDT) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''                Else
    ''                    '★TOKSMA更新(DATKB=9よりマイナス更新する)
    ''                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", (-1) * intJkesikn, strSMADT) = False Then
    ''                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                        Exit Function
    ''                    End If
    ''                End If
    ''
    ''                '★UDNTRA更新(DATKB=9よりマイナス更新する)
    ''                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                '★JDNTRA更新(DATKB=9よりマイナス更新する)
    ''''''            If setJDNTRA(CStr(varSpdValue(COL_JDNDATNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then
    ''                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                Usr_Ody.Obj_Ody.MoveNext
    ''            Loop
    ''
    ''            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''
    ''            '前回消込金額を0とする
    ''            varSpdValue(COL_AFKESIKN) = 0
    ''        End If
    ''
    ''        '締日以降消込金額(絶対値)が消込金額(絶対値)より小きい時は差額を新規に作成
    ''        If Abs(intKesikn) > Abs(SSSVal(varSpdValue(COL_AFKESIKN))) Then
    ''            intKesikn = intKesikn - SSSVal(varSpdValue(COL_AFKESIKN))
    ''
    ''            '消込伝票番号カウントアップ
    ''            If CLng(strKDNNO_MAX) < CLng(strKDNNO) + 1 Then
    ''                strKDNNO = strKDNNO_MIN
    ''            Else
    ''                strKDNNO = Format(CLng(strKDNNO) + 1, "00000000")
    ''            End If
    ''
    ''            '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2             '2007.03.05
    ''            If DB_TOKMTA2.SHAKB = 5 Or DB_TOKMTA2.SHAKB = 6 Then
    ''                strNYUKB = "2"
    ''            Else
    ''                strNYUKB = "1"
    ''            End If
    ''
    ''            strSql = "INSERT INTO nkstra (" _
    '''                               & "kdnno, datkb, nyurecno, udnrecno, nyudt, jkesikn, tokseicd, tokcd, " _
    '''                               & "tancd, jdnno, jdnlinno, udndt, urikn, tegdt, jdndt, tukkb, invno, " _
    '''                               & "furikn, fkesikn, frnkb, nyukb, udndatno, udnlinno, maeukkb, " _
    '''                               & "fopeid, fcltid, wrtfsttm, wrtfstdt, opeid, cltid, wrttm, wrtdt, " _
    '''                               & "uopeid , ucltid, uwrttm, uwrtdt, pgid, dlflg) " _
    '''                            & "VALUES (" _
    '''                               & "'" & strKDNNO & "', '1', " _
    '''                               & "'" & Space(10) & "', '" & Space(10) & "', " _
    '''                               & "'" & gstrKesidt & "', " _
    '''                               & intKesikn & ", " _
    '''                               & "'" & CF_Ora_String(varSpdValue(COL_TOKSEICD), 10) & "', " _
    '''                               & "'" & CF_Ora_String(varSpdValue(COL_TOKCD), 10) & "', " _
    '''                               & "'" & varSpdValue(COL_TANCD) & "', " _
    '''                               & "'" & CF_Ora_String(varSpdValue(COL_JDNNO), 10) & "', " _
    '''                               & "'" & varSpdValue(COL_JDNLINNO) & "', " _
    '''                               & "'" & varSpdValue(COL_UDNDT) & "', " _
    '''                               & SSSVal(varSpdValue(COL_KOMIKN)) & ", " _
    '''                               & "'" & varSpdValue(COL_HYFRIDT) & "', " _
    '''                               & "'" & varSpdValue(COL_JDNDT) & "', " _
    '''                               & "'" & varSpdValue(COL_TUKKB) & "', " _
    '''                               & "'" & varSpdValue(COL_INVNO) & "', " _
    '''                               & "0, 0, " _
    '''                               & "'" & varSpdValue(COL_FRNKB) & "', "
    '''''                            & "1, "                                      '2007.03.05
    ''            strSql = strSql & "'" & strNYUKB & "', "
    ''
    ''            strSql = strSql _
    '''                               & "'" & varSpdValue(COL_UDNDATNO) & "', " _
    '''                               & "'" & varSpdValue(COL_UDNLINNO) & "', " _
    '''                               & "'" & varSpdValue(COL_MAEUKKB) & "', " _
    '''                               & "'" & SSS_OPEID & "', " _
    '''                               & "'" & SSS_CLTID & "', " _
    '''                               & "'" & GV_SysTime & "', " _
    '''                               & "'" & GV_SysDate & "', " _
    '''                               & "'" & SSS_OPEID & "', " _
    '''                               & "'" & SSS_CLTID & "', " _
    '''                               & "'" & GV_SysTime & "', " _
    '''                               & "'" & GV_SysDate & "', " _
    '''                               & "'" & SSS_OPEID & "', " _
    '''                               & "'" & SSS_CLTID & "', " _
    '''                               & "'" & GV_SysTime & "', " _
    '''                               & "'" & GV_SysDate & "', " _
    '''                               & "'" & SSS_PrgId & "'," _
    '''                               & "'2')"   '必ず新規
    ''
    ''            '★INSERT実行
    ''            If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
    ''                GoTo SETNKSTRA_ERROR
    ''            End If
    ''
    ''            '★TOKSSA更新
    ''            If setTOKSSA(CStr(varSpdValue(COL_TOKSEICD)), intKesikn, DB_TOKMTA2.KESISMEDT) = False Then
    ''                Exit Function
    ''            End If
    ''
    ''            'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''            If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''            Else
    ''                '★TOKSMA更新
    ''                strSMADT = DeCNV_DATE(Get_Acedt(gstrKesidt))     '経理締め
    ''                If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", intKesikn, strSMADT) = False Then
    ''                    Exit Function
    ''                End If
    ''            End If
    ''
    ''            '★UDNTRA更新
    ''            If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), intKesikn) = False Then
    ''                Exit Function
    ''            End If
    ''
    ''            '★JDNTRA更新
    ''''''        If setJDNTRA(CStr(varSpdValue(COL_JDNDATNO)), CStr(varSpdValue(COL_JDNLINNO)), intKesikn) = False Then  '2007.03.05
    ''            If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), intKesikn) = False Then
    ''                Exit Function
    ''            End If
    ''        End If
    ''
    ''    End If
    ''
    ''    setNKSTRA = True
    ''    Exit Function
    ''
    ''SETNKSTRA_ERROR:
    ''    Call SSSWIN_LOGWRT("SETNKSTRA_ERROR")
    ''
    ''End Function
    '// V2.00↑ DEL

    '// V2.01↓ DEL
    ''TOKSSAの更新
    'Private Function setTOKSSA(strTokseicd As String, ByVal intKesikn As Currency, ByVal strSSADT As String) As Boolean
    '    Dim Usr_Ody As U_Ody
    '    Dim strSql  As String
    '
    '    Dim intNyukn        As Currency
    '    Dim intKskzankn     As Currency
    '    Dim strMinSsadt     As String
    '
    'On Error GoTo SETTOKSSA_ERROR
    '
    '    setTOKSSA = False
    '
    '    If intKesikn = 0 Then
    '    Else
    '        '消込額の更新
    '        If setTOKSSA2(strTokseicd, intKesikn, 1, strSSADT) = False Then
    '            Exit Function
    '        End If
    '
    '        '消込可能額の更新
    '        '最も古い入金情報を持つｻﾏﾘの日付を取得するSQL作成
    '        strSql = "SELECT MIN(ssadt) ssadt " _
    ''                 & "FROM tokssa " _
    ''                & "WHERE tokcd = '" & strTokseicd & "' " _
    ''                  & "AND (ssanyukn00 + ssanyukn01 + ssanyukn02 + ssanyukn03 + ssanyukn04 + ssanyukn05 + ssanyukn06 + ssanyukn07 + ssanyukn09 > 0 " _
    ''                   & "OR kskzankn > 0 OR ssadt = '" & strSSADT & "') " _
    ''                  & "AND ssadt <= '" & strSSADT & "' " _
    ''                & "ORDER BY ssadt "
    '
    '        'DBアクセス
    '        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '
    '        If CF_Ora_EOF(Usr_Ody) = False Then
    '            strMinSsadt = CF_Ora_GetDyn(Usr_Ody, "ssadt", "")
    '        End If
    '
    '        'SQL作成
    '        strSql = "SELECT tokcd, ssadt, kesdt, ssanyukn00 + ssanyukn01 + ssanyukn02 + ssanyukn03 + ssanyukn04 + ssanyukn05 + ssanyukn06 + ssanyukn07 + ssanyukn09 nyukn, ksknykkn, kskzankn " _
    ''                 & "FROM tokssa " _
    ''                & "WHERE tokcd = '" & strTokseicd & "' " _
    ''                  & "AND (ssanyukn00 + ssanyukn01 + ssanyukn02 + ssanyukn03 + ssanyukn04 + ssanyukn05 + ssanyukn06 + ssanyukn07 + ssanyukn09 > 0 " _
    ''                   & "OR kskzankn > 0 OR ssadt = '" & strSSADT & "') " _
    ''                  & "AND ssadt <= '" & strSSADT & "' " _
    ''                & "ORDER BY ssadt "
    '
    '        If intKesikn < 0 Then
    '            strSql = strSql & "DESC"    '消込額が負のときは締日降順にする
    '        End If
    '
    '        'DBアクセス
    '        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '
    '        Do While (CF_Ora_EOF(Usr_Ody) = False And intKesikn <> 0)
    '            intNyukn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "nyukn", ""))
    '            intKskzankn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "kskzankn", ""))
    '            strSSADT = CF_Ora_GetDyn(Usr_Ody, "ssadt", "")
    '
    '            '消込額の正負により更新手順が異なる
    '            If intKesikn > 0 Then
    '                '消込金額が残額より大きい時、対象ｻﾏﾘが当月度でなければ、残額分をマイナス
    '                If intKesikn > intKskzankn And DB_TOKMTA2.KESISMEDT <> strSSADT Then
    '                    If setTOKSSA2(strTokseicd, (-1) * (intKskzankn), 2, strSSADT) = False Then
    '                        GoTo SETTOKSSA_ERROR
    '                    End If
    '                    intKesikn = intKesikn - intKskzankn
    '                'それ以外は消込額をｻﾏﾘに更新
    '                Else
    '                    If setTOKSSA2(strTokseicd, (-1) * intKesikn, 2, strSSADT) = False Then
    '                        GoTo SETTOKSSA_ERROR
    '                    End If
    '                    intKesikn = 0
    '                End If
    '
    '            '消込額が負の時
    '            Else
    '                If intKesikn < intKskzankn - intNyukn And strMinSsadt <> strSSADT Then
    '                    If setTOKSSA2(strTokseicd, (-1) * (intKskzankn - intNyukn), 2, strSSADT) = False Then
    '                        GoTo SETTOKSSA_ERROR
    '                    End If
    '                    intKesikn = intKesikn - (intKskzankn - intNyukn)
    '                Else
    '                    If setTOKSSA2(strTokseicd, (-1) * intKesikn, 2, strSSADT) = False Then
    '                        GoTo SETTOKSSA_ERROR
    '                    End If
    '                    intKesikn = 0
    '                End If
    '            End If
    '
    '            Usr_Ody.Obj_Ody.MoveNext
    '        Loop
    '
    '        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '    End If
    '
    '    setTOKSSA = True
    '    Exit Function
    '
    'SETTOKSSA_ERROR:
    '    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '
    'End Function
    '// V2.01↑ DEL

    '// V2.01↓ DEL
    ''消込日月度におけるTOKSSAの更新(無ければ新規に作成する)
    ''intKesikn : 更新する金額
    ''intItemKb : 1:消込額に更新 2:消込可能額に更新
    'Private Function setTOKSSA2(strTokseicd As String, intKesikn As Currency, intItemKb As Integer, ByVal strSSADT As String) As Boolean
    '    Dim Usr_Ody As U_Ody
    '    Dim strSql  As String
    '
    '    Dim strKesdt As String
    '
    'On Error GoTo SETTOKSSA2_ERROR
    '
    '    setTOKSSA2 = False
    '
    '    strSql = "SELECT * FROM tokssa " _
    ''            & "WHERE ssadt = '" & strSSADT & "' " _
    ''              & "AND tokcd = '" & strTokseicd & "'"
    '
    '    'DBアクセス
    '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '
    '    'ﾃﾞｰﾀがあるとき
    '    If CF_Ora_EOF(Usr_Ody) = False Then
    '        'UPDATE文を実行する
    '        If intItemKb = 1 Then
    '            strSql = "UPDATE tokssa SET ksknykkn = ksknykkn + " & intKesikn & " "
    '        Else
    '            strSql = "UPDATE tokssa SET kskzankn = kskzankn + " & intKesikn & " "
    '        End If
    '
    '        strSql = strSql _
    ''                & "WHERE ssadt = '" & strSSADT & "' " _
    ''                  & "AND tokcd = '" & strTokseicd & "' "
    '
    '    'ﾃﾞｰﾀが無い時
    '    Else
    '        '回収予定日取得
    '        strKesdt = getKesdt(DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDT, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB, DB_TOKMTA2.TOKKESCC, DB_TOKMTA2.TOKKESDD, DB_TOKMTA2.TOKKDWKB, strSSADT)
    '        'INSERT文を実行する
    '        strSql = "INSERT INTO tokssa ( tokcd, ssadt, kesdt, " _
    ''                & "ssaurikn00, ssaurikn01, ssaurikn02, ssaurikn03, ssaurikn04, ssaurikn05, ssaurikn06, ssaurikn07, ssaurikn08, ssaurikn09, ssauzekn, " _
    ''                & "szakzikn00, szakzikn01, szakzikn02, szakzokn00, szakzokn01, szakzokn02, szbkzikn00, szbkzikn01, szbkzikn02, szbkzokn00, szbkzokn01, szbkzokn02, " _
    ''                & "ssanyukn00, ssanyukn01, ssanyukn02, ssanyukn03, ssanyukn04, ssanyukn05, ssanyukn06, ssanyukn07, ssanyukn08, ssanyukn09, " _
    ''                & "ksknykkn, kskzankn, ssadensu, datno, wrttm, wrtdt ) VALUES (" _
    ''                & "'" & CF_Ora_String(strTokseicd, 10) & "', '" & strSSADT & "', '" & strKesdt & "', " _
    ''                & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " _
    ''                & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " _
    ''                & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
    '
    '        If intItemKb = 1 Then
    '            strSql = strSql & intKesikn & ", 0, 0, '" & Space(10) & "', '" & GV_SysTime & "', '" & GV_SysDate & "')"
    '        Else
    '            strSql = strSql & "0, " & intKesikn & ", 0, '" & Space(10) & "', '" & GV_SysTime & "', '" & GV_SysDate & "')"
    '        End If
    '    End If
    '
    '    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '
    '    'SQL実行
    '    If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
    '        GoTo SETTOKSSA2_ERROR
    '    End If
    '
    '    setTOKSSA2 = True
    '    Exit Function
    '
    'SETTOKSSA2_ERROR:
    '    Call SSSWIN_LOGWRT("SETTOKSSA2_ERROR")
    '
    'End Function
    '// V2.01↑ DEL

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
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'ﾃﾞｰﾀがあるとき
        'If CF_Ora_EOF(Usr_Ody) = False Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/04/23 CHG E N D
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

        '2019.//04/23 CHG START
        '      Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

        ''SQL実行
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo SETTOKSMA_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        setTOKSMA = True
        Exit Function

SETTOKSMA_ERROR:
        Call SSSWIN_LOGWRT("SETTOKSMA_ERROR")

    End Function

    '売上トランの入金額に更新を行う
    '2009/09/18 UPD START RISE)MIYAJIMA
    'Private Function setUDNTRA(strDATNO As String, strLINNO As String, intKesikn As Currency) As Boolean
    Private Function setUDNTRA(ByRef strDATNO As String, ByRef strLINNO As String, ByRef intKesikn As Decimal, ByVal strNYUKB As String) As Boolean
        '2009/09/18 UPD E.N.D RISE)MIYAJIMA
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
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo SETUDNTRA_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        '加算した売上データを取得
        strSql = "SELECT urikn + uzekn - jkesikn zankn, jkesikn FROM udntra WHERE datno = '" & strDATNO & "' " & "AND linno = '" & strLINNO & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	intZankn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "zankn", ""))
        '	'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "jkesikn", ""))
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        Dim dt As DataTable = DB_GetTable(strSql)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            intZankn = SSSVal(DB_NullReplace(dt.Rows(0)("zankn"), ""))
            intJkesikn = SSSVal(DB_NullReplace(dt.Rows(0)("jkesikn"), ""))
        End If
        '2019/04/22 CHG E N D

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
            '2009/09/18 UPD START RISE)MIYAJIMA
            '        '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2
            '        If DB_TOKMTA2.SHAKB = 5 Or DB_TOKMTA2.SHAKB = 6 Then
            '            strSql = strSql & "nyukb = '2', "
            '        Else
            '            strSql = strSql & "nyukb = '1', "
            '        End If
            strSql = strSql & "nyukb = '" & strNYUKB & "', "
            '2009/09/18 UPD E.N.D RISE)MIYAJIMA
        End If

        'UPDATE文を実行する
        strSql = strSql & "uopeid = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "', " & "ucltid = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "', " & "uwrttm = '" & GV_SysTime & "', " & "uwrtdt = '" & GV_SysDate & "', " & "pgid = '" & SSS_PrgId & "' " & "WHERE datno = '" & strDATNO & "' " & "AND linno = '" & strLINNO & "' "
        'SQL実行
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo SETUDNTRA_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        setUDNTRA = True
        Exit Function

SETUDNTRA_ERROR:
        Call SSSWIN_LOGWRT("SETUDNTRA_ERROR")

    End Function

    '受注トランの入金額に更新を行う
    '2009/09/18 UPD START RISE)MIYAJIMA
    'Private Function setJDNTRA(strJDNNO As String, strLINNO As String, intKesikn As Currency) As Boolean
    Private Function setJDNTRA(ByRef strJDNNO As String, ByRef strLINNO As String, ByRef intKesikn As Decimal, ByVal strNYUKB As String) As Boolean
        '2009/09/18 UPD E.N.D RISE)MIYAJIMA
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        Dim intNyukn As Decimal

        On Error GoTo SETJDNTRA_ERROR

        setJDNTRA = False

        'まず金額を加算するUPDATE文を実行する                                   '2007.03.05
        ''''strSql = "UPDATE jdntra SET nyukn = nyukn + " & intKesikn & " " _
        '''''        & "WHERE datno = '" & strDATNO & "' " _
        '''''          & "AND linno = '" & strLinno & "' "
        strSql = "UPDATE jdntra SET nyukn = nyukn + " & intKesikn & " " & "WHERE jdnno = '" & strJDNNO & "' " & "AND linno = '" & strLINNO & "' " & "AND akakrokb = '1'"

        'SQL実行
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo SETJDNTRA_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        strSql = "UPDATE jdntra SET nyukn = nyukn + " & intKesikn * (-1) & " " & "WHERE jdnno = '" & strJDNNO & "' " & "AND linno = '" & strLINNO & "' " & "AND akakrokb = '9'"

        'SQL実行
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo SETJDNTRA_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        '加算した受注データを取得
        strSql = "SELECT nyukn FROM jdntra WHERE jdnno = '" & strJDNNO & "' " & "AND linno = '" & strLINNO & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	intNyukn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "nyukn", ""))
        'End If

        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            intNyukn = SSSVal(DB_NullReplace(dt.Rows(0)("nyukn"), ""))
        End If
        '2019/04/23 CHG E N D

        '更新結果により再度売上UPDATEを実施
        strSql = "UPDATE jdntra SET "

        '消込額が0のとき nyudt = "", nyukb = ""
        If intNyukn = 0 Then
            strSql = strSql & "nyudt = '" & Space(8) & "', " & "nyukb = '" & Space(1) & "', "
        Else
            strSql = strSql & "nyudt = '" & gstrKesidt.Value & "', "
            '2009/09/18 UPD START RISE)MIYAJIMA
            '        '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2
            '        If DB_TOKMTA2.SHAKB = 5 Or DB_TOKMTA2.SHAKB = 6 Then
            '            strSql = strSql & "nyukb = '2', "
            '        Else
            '            strSql = strSql & "nyukb = '1', "
            '        End If
            strSql = strSql & "nyukb = '" & strNYUKB & "', "
            '2009/09/18 UPD E.N.D RISE)MIYAJIMA
        End If

        'UPDATE文を実行する                     '2007.03.05
        ''''strSql = strSql & "uopeid = '" & CF_Ora_String(SSS_OPEID, 8) & "', " _
        '''''                & "ucltid = '" & CF_Ora_String(SSS_CLTID, 5) & "', " _
        '''''                & "uwrttm = '" & GV_SysTime & "', " _
        '''''                & "uwrtdt = '" & GV_SysDate & "', " _
        '''''                & "pgid = '" & SSS_PrgId & "' " _
        '''''          & "WHERE datno = '" & strDATNO & "' " _
        '''''            & "AND linno = '" & strLinno & "' "
        strSql = strSql & "uopeid = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "', " & "ucltid = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "', " & "uwrttm = '" & GV_SysTime & "', " & "uwrtdt = '" & GV_SysDate & "', " & "pgid = '" & SSS_PrgId & "' " & "WHERE jdnno = '" & strJDNNO & "' " & "AND linno = '" & strLINNO & "' "

        'SQL実行
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo SETJDNTRA_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        setJDNTRA = True
        Exit Function

SETJDNTRA_ERROR:
        Call SSSWIN_LOGWRT("setJDNTRA_ERROR")

    End Function

    '// V2.00↓ DEL
    ''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '''   名称：  Function GET_SYSTBC_DENNO
    '''   概要：  伝票番号を取得
    '''   引数：　pin_DKBSB    : 伝票区分
    '''   　　：　pot_strDENNO : 伝票番号
    '''   　　：　pot_strSTTNO : 伝票番号開始
    '''   　　：　pot_strENDNO : 伝票番号終了
    '''   戻値：　0:正常終了 9:異常終了
    '''   備考：
    ''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''Private Function GET_SYSTBC_DENNO(ByVal pin_DKBSB As String, _
    '''                                 ByRef pot_strDENNO As String, _
    '''                                 ByRef pot_strSTTNO As String, _
    '''                                 ByRef pot_strENDNO As String) As Integer
    ''
    ''    Dim Usr_Ody         As U_Ody
    ''    Dim strSql          As String
    ''
    ''    On Error GoTo ERR_GET_SYSTBC_DENNO
    ''
    ''    GET_SYSTBC_DENNO = 9
    ''
    ''    strSql = ""
    ''    strSql = strSql & "Select"
    ''    strSql = strSql & vbCrLf & " DENNO"
    ''    strSql = strSql & vbCrLf & ",STTNO"
    ''    strSql = strSql & vbCrLf & ",ENDNO"
    ''    strSql = strSql & vbCrLf & " From SYSTBC"
    ''    strSql = strSql & vbCrLf & " Where DKBSB    = " & "'" & pin_DKBSB & "'"
    ''    strSql = strSql & vbCrLf & "   And ADDDENCD = " & "'" & String(13, " ") & "'"
    ''
    ''    'DBアクセス
    ''    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''
    ''    If CF_Ora_EOF(Usr_Ody) = False Then
    ''        pot_strDENNO = CF_Ora_GetDyn(Usr_Ody, "DENNO", "")
    ''        pot_strSTTNO = CF_Ora_GetDyn(Usr_Ody, "STTNO", "")
    ''        pot_strENDNO = CF_Ora_GetDyn(Usr_Ody, "ENDNO", "")
    ''        GET_SYSTBC_DENNO = 0
    ''
    ''        GoTo END_GET_SYSTBC_DENNO
    ''    End If
    ''
    ''    GET_SYSTBC_DENNO = 0
    ''
    ''END_GET_SYSTBC_DENNO:
    ''    'クローズ
    ''    Call CF_Ora_CloseDyn(Usr_Ody)
    ''
    ''    Exit Function
    ''
    ''ERR_GET_SYSTBC_DENNO:
    ''    GoTo END_GET_SYSTBC_DENNO
    ''
    ''End Function
    '// V2.00↑ DEL

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
        '// V2.00↓ ADD
        strSql = strSql & " FOR UPDATE "
        '// V2.00↑ ADD

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	pot_DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	pot_RECNO = CF_Ora_GetDyn(Usr_Ody, "RECNO", "")
        '	GET_SYSTBA_NOGET = 0

        '	GoTo END_GET_SYSTBA_NOGET
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            pot_DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
            pot_RECNO = DB_NullReplace(dt.Rows(0)("RECNO"), "")
        End If
        '2019/04/23 CHG E N D

        GET_SYSTBA_NOGET = 0

END_GET_SYSTBA_NOGET:
        'クローズ
        '2019/04/23 CDEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

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
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo F_SYSTBA_Update_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_SYSTBA_Update = 0

F_SYSTBA_Update_END:
        Exit Function

F_SYSTBA_Update_ERROR:
        'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET53_E_034, Main_Inf, "F_SYSTBA_Update")
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
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo F_SYSTBC_Update_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_SYSTBC_Update = 0

F_SYSTBC_Update_END:
        Exit Function

F_SYSTBC_Update_ERROR:
        'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET53_E_034, Main_Inf, "F_SYSTBC_Update")
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
        '// V2.00↓ DEL
        ''    Dim strUDNNO_MIN    As String
        ''    Dim strUDNNO_MAX    As String
        '// V2.00↑ DEL
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
        '// V2.00↓ UPD
        ''    If GET_SYSTBC_DENNO(gc_DKBSB_NKN, strUDNNO, strUDNNO_MIN, strUDNNO_MAX) <> 0 Then
        ''        Exit Function
        ''    End If
        ''    strUDNNO = Format((CCur(strUDNNO) + 1), "00000000")
        If GET_SYSTBC_DENNO2(gc_DKBSB_NKN, strUDNNO) <> 0 Then
            Exit Function
        End If
        '// V2.00↑ UPD

        '// V2.00↓ ADD
        'トランザクションの開始
        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D
        '// V2.00↑ ADD

        '管理ＮＯ取得
        Call GET_SYSTBA_NOGET(strDATNO, strRECNO)
        strDATNO = VB6.Format(CDec(strDATNO) + 1, "0000000000")

        '// V2.00↓ DEL
        ''    'トランザクションの開始
        ''    Call CF_Ora_BeginTrans(gv_Oss_USR1)
        '// V2.00↑ DEL

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
                '2019/04/17 CHG START
                'If F_UDNTRA_Insert_SAGAKU(strDATNO, strRECNO, strUDNNO, VB6.Format(lngI + 1, "000"), strSMADT, CDec(gtypeFR_SUB(lngI).SUB_NYUKN)) = 9 Then GoTo F_UPDATE_SUB_ERROR
                If F_UDNTRA_Insert_SAGAKU(strDATNO, strRECNO, strUDNNO, VB6.Format(lngI + 1, "000"), strSMADT, CDec(Integer.Parse(gtypeFR_SUB(lngI).SUB_NYUKN))) = 9 Then GoTo F_UPDATE_SUB_ERROR
                '2019/04/17 CHG E N D

                '請求サマリ更新（入金額）
                strSSADT = DB_TOKMTA2.KESISMEDT
                'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If F_TOKSSA_Update_SAGAKU(DB_TOKMTA2.TOKSEICD, gtypeFR_SUB(lngI).SUB_UPDID, SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN), strSSADT) = 9 Then GoTo F_UPDATE_SUB_ERROR

                'TOKSMEの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
                Else
                    '売掛サマリ請求更新（邦貨入金額)
                    'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If F_TOKSME_Update_SAGAKU(DB_TOKMTA2.TOKSEICD, gtypeFR_SUB(lngI).SUB_UPDID, SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN), strSMADT) = 9 Then GoTo F_UPDATE_SUB_ERROR
                End If

                '// V2.00↓ ADD
                '入金消込サマリ更新（入金集計金額）
                'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_NYUKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト gtypeFR_SUB().SUB_UPDID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If F_NKSSMA_SSA_Update(DB_TOKMTA2.TOKSEICD, gtypeFR_SUB(lngI).SUB_UPDID, SSSVal(gtypeFR_SUB(lngI).SUB_NYUKN), strSMADT) = 9 Then GoTo F_UPDATE_SUB_ERROR
                '// V2.00↑ ADD

            End If
        Next

        '売上ヘッダ登録（入金レコード）
        If F_UDNTHA_Insert_SAGAKU(strDATNO, strUDNNO, curNYUKN) = 9 Then GoTo F_UPDATE_SUB_ERROR

        '管理ＮＯ更新
        If F_SYSTBA_Update(strDATNO, strRECNO) = 9 Then GoTo F_UPDATE_SUB_ERROR

        '// V2.00↓ DEL
        ''    '伝票番号更新
        ''    If F_SYSTBC_Update(gc_DKBSB_NKN, strUDNNO) = 9 Then GoTo F_UPDATE_SUB_ERROR:
        '// V2.00↑ DEL

        'コミット
        '2019/04/17 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/17 CHG E N D

        '    If gc_CONTROL = "1" Then Debug.Print "SUB  -----------------------------------------"
        F_UPDATE_SUB = 1
        Exit Function

F_UPDATE_SUB_ERROR:
        'ロールバック
        '2019/04/17 CHG START
        'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
        Call DB_Rollback()
        '2019/04/17 CHG E N D
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
        Call GET_TANMTA_KEIBMNCD(DB_TOKMTA2.TANCD, strKEIBUMCD)

        strSql = ""
        strSql = strSql & "Insert Into UDNTHA"
        strSql = strSql & vbCrLf & "(DATNO" ' 1.伝票管理№
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
        strSql = strSql & vbCrLf & ",OKRJONO" '28.送り状№
        strSql = strSql & vbCrLf & ",INVNO" '29.インボイス№
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
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSEICD & "'" '12.TOKCD
        strSql = strSql & vbCrLf & "," & "'" & CF_Ora_String(DB_TOKMTA2.TOKRN, 40) & "'" '13.TOKRN
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
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSEICD & "'" '22.TOKSEICD
        '   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_SEICD & "'"                    '22.TOKSEICD
        strSql = strSql & vbCrLf & "," & "'" & Space(3) & "'" '23.SOUCD
        strSql = strSql & vbCrLf & "," & "'" & Space(20) & "'" '24.SOUNM
        strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '25.NXTKB
        strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '26.NXTNM
        strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '27.EMGODNKB
        strSql = strSql & vbCrLf & "," & "'" & Space(15) & "'" '28.OKRJONO
        strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" '29.INVNO
        strSql = strSql & vbCrLf & "," & "'" & DeCNV_DATE(Get_Acedt(gstrKesidt.Value)) & "'" '30.SMADT
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.KESISMEDT & "'" '31.SSADT
        strSql = strSql & vbCrLf & "," & "'" & getKesdt(DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDT, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB, DB_TOKMTA2.TOKKESCC, DB_TOKMTA2.TOKKESDD, DB_TOKMTA2.TOKKDWKB, DB_TOKMTA2.KESISMEDT) & "'" '32.KESDT
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
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSMEKB & "'" '52.TOKSMEKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSMEDD & "'" '53.TOKSMEDD
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSMECC & "'" '54.TOKSMECC
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSDWKB & "'" '55.TOKSDWKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKKESCC & "'" '56.TOKKESCC
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKKESDD & "'" '57.TOKKESDD
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKKDWKB & "'" '58.TOKKDWKB
        strSql = strSql & vbCrLf & "," & "'" & Space(7) & "'" '59.LSTID
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKJUNKB & "'" '60.TOKJUNKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKMSTKB & "'" '61.TOKMSTKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TKNRPSKB & "'" '62.TKNRPSKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TKNZRNKB & "'" '63.TKNZRNKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKZEIKB & "'" '64.TOKZEIKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKZCLKB & "'" '65.TOKZCLKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKRPSKB & "'" '66.TOKRPSKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKZRNKB & "'" '67.TOKZRNKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKNMMKB & "'" '68.TOKNMMKB
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
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TUKKB & "'" '76.TUKKB
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.FRNKB & "'" '77.FRNKB
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
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo F_UDNTHA_Insert_SAGAKU_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

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

        '    '2006.11.15 入金種別(NYUKB)編集
        '    Select Case FR_SSSSUB.SUB_DFLDKBCD(CLng(pin_LINNO) - 1)
        '        Case "2":   strNYUKB = "2":
        '        Case "3":   strNYUKB = "4":
        '        Case Else:  strNYUKB = "1":
        '    End Select
        If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
            strNYUKB = "2"
        Else
            strNYUKB = "1"
        End If

        '    '明細備考編集
        '    strLINCMA = Replace(AnsiLeftB(FR_SSSSUB.SUB_LINCMA(CLng(pin_LINNO) - 1) & Space(20), 20), "'", "''")

        strSql = ""
        strSql = strSql & "Insert Into UDNTRA "
        strSql = strSql & vbCrLf & "(DATNO" ' 1.伝票管理№
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
        strSql = strSql & vbCrLf & ",RECNO" '12.レコード管理№
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
        strSql = strSql & vbCrLf & ",OKRJONO" '58.送り状№
        strSql = strSql & vbCrLf & ",INVNO" '59.インボイス№
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
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.KESISMEDT & "'" '21.SSADT
        strSql = strSql & vbCrLf & "," & "'" & getKesdt(DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDT, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB, DB_TOKMTA2.TOKKESCC, DB_TOKMTA2.TOKKESDD, DB_TOKMTA2.TOKKDWKB, DB_TOKMTA2.KESISMEDT) & "'" '22.KESDT
        '   strSql = strSql & vbCrLf & "," & "'" & pin_SMADT & "'"                      '21.SSADT
        '   strSql = strSql & vbCrLf & "," & "'" & pin_SMADT & "'"                      '22.KESDT
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSEICD & "'" '23.TOKCD
        '   strSQL = strSQL & vbCrLf & "," & "'" & FR_SSSMAIN.HD_SEICD & "'"            '23.TOKCD
        strSql = strSql & vbCrLf & "," & "'" & Space(6) & "'" '24.TANCD
        strSql = strSql & vbCrLf & "," & "'" & Space(10) & "'" '25.NHSCD
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TOKSEICD & "'" '26.TOKSEICD
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
        '2009/09/18 UPD START RISE)MIYAJIMA
        ''// V2.01↓ UPD
        ''    strSql = strSql & vbCrLf & "," & "'" & gstrKesidt & "'"                      '46.NYUDT   2007.02.27
        '    '更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
        '    If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
        '        strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'"                       '46.NYUDT   2007.02.27
        '    Else
        '        strSql = strSql & vbCrLf & "," & "'" & gstrKesidt & "'"                     '46.NYUDT   2007.02.27
        '    End If
        ''// V2.01↑ UPD
        strSql = strSql & vbCrLf & "," & "'" & gstrKesidt.Value & "'" '46.NYUDT   2007.02.27
        '2009/09/18 UPD E.N.D RISE)MIYAJIMA
        '   strSQL = strSQL & vbCrLf & "," & "'" & DeCNV_DATE(FR_SSSSUB.SUB_HD_KESDT) & "'"     '46.NYUDT   2007.02.27
        strSql = strSql & vbCrLf & "," & "'" & pin_NYUKN & "'" '47.NYUKN
        strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '48.FNYUKN
        strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '49.GNKKN
        strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '50.JKESIKN
        strSql = strSql & vbCrLf & "," & "'" & "0" & "'" '51.FKESIKN
        strSql = strSql & vbCrLf & "," & "'" & Space(1) & "'" '52.KESIKB
        strSql = strSql & vbCrLf & "," & "'" & strNYUKB & "'" '53.NYUKB
        strSql = strSql & vbCrLf & "," & "'" & Space(2) & "'" '54.TNKID
        strSql = strSql & vbCrLf & "," & "'" & DB_TOKMTA2.TUKKB & "'" '55.TUKKB
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
        '2009/09/18 UPD START RISE)MIYAJIMA
        '    strSql = strSql & vbCrLf & "," & "'" & gstrFridt & "'"                      '65.TEGDT   '2007/03/19　ヘッダの振込期日をセット　Saito
        If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
            If Trim(gstrFridt.Value) = "" Then
                '2009/11/02 UPD START RISE)MIYAJIMA
                '            strSql = strSql & vbCrLf & "," & "'" & gstrUnydt & "'"                      '65.TEGDT   '運用日を設定
                strSql = strSql & vbCrLf & "," & "'" & gstrKesidt.Value & "'" '65.TEGDT   '消込日を設定
                '2009/11/02 UPD E.N.D RISE)MIYAJIMA
            Else
                strSql = strSql & vbCrLf & "," & "'" & gstrFridt.Value & "'" '65.TEGDT   '2007/03/19　ヘッダの振込期日をセット　Saito
            End If
        Else
            '現金扱いはここでスペースを転送する
            strSql = strSql & vbCrLf & "," & "'" & Space(8) & "'" '65.TEGDT
        End If
        '2009/09/18 UPD E.N.D RISE)MIYAJIMA
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
        '2019/04/23 CHG START
        'bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
        'If bolRet = False Then
        '	GoTo F_UDNTRA_Insert_SAGAKU_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_UDNTRA_Insert_SAGAKU = 0
        Exit Function

F_UDNTRA_Insert_SAGAKU_ERROR:
        '   Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET53_E_034, Main_Inf, "F_UDNTRA_Insert_SAGAKU")
        Call SSSWIN_LOGWRT("F_UDNTRA_Insert_SAGAKU_ERROR")

    End Function

    '請求サマリの入金額に更新を行う（差額入金用）
    Private Function F_TOKSSA_Update_SAGAKU(ByRef strTokseicd As String, ByRef strUPDID As String, ByRef intKesikn As Decimal, ByVal strSSADT As String) As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        Dim strKesdt As String
        Dim i As Short

        On Error GoTo F_TOKSSA_Update_SAGAKU_ERROR

        F_TOKSSA_Update_SAGAKU = 9

        'サマリ存在チェック
        strSql = "SELECT * FROM tokssa WHERE ssadt = '" & strSSADT & "' " & "AND tokcd = '" & strTokseicd & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''ﾃﾞｰﾀがあるとき
        'If CF_Ora_EOF(Usr_Ody) = False Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/04/23 CHG E N D

            'UPDATE文を実行する
            strSql = "UPDATE tokssa SET ssanyukn" & strUPDID & " = ssanyukn" & strUPDID & " + " & intKesikn & ", " & "kskzankn = kskzankn + " & intKesikn & " " & "WHERE ssadt = '" & strSSADT & "' " & "AND tokcd = '" & strTokseicd & "' "

            'ﾃﾞｰﾀが無い時
        Else
            '回収予定日取得
            strKesdt = getKesdt(DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDT, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB, DB_TOKMTA2.TOKKESCC, DB_TOKMTA2.TOKKESDD, DB_TOKMTA2.TOKKDWKB, strSSADT)
            'INSERT文を実行する
            strSql = "INSERT INTO tokssa ( tokcd, ssadt, kesdt, " & "ssaurikn00, ssaurikn01, ssaurikn02, ssaurikn03, ssaurikn04, ssaurikn05, ssaurikn06, ssaurikn07, ssaurikn08, ssaurikn09, ssauzekn, " & "szakzikn00, szakzikn01, szakzikn02, szakzokn00, szakzokn01, szakzokn02, szbkzikn00, szbkzikn01, szbkzikn02, szbkzokn00, szbkzokn01, szbkzokn02, " & "ssanyukn00, ssanyukn01, ssanyukn02, ssanyukn03, ssanyukn04, ssanyukn05, ssanyukn06, ssanyukn07, ssanyukn08, ssanyukn09, " & "ksknykkn, kskzankn, ssadensu, datno, wrttm, wrtdt ) VALUES (" & "'" & CF_Ora_String(strTokseicd, 10) & "', '" & strSSADT & "', '" & strKesdt & "', " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "

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

        '2019/04/23 CHG START
        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

        ''SQL実行
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_TOKSSA_Update_SAGAKU_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_TOKSSA_Update_SAGAKU = 1
        Exit Function

F_TOKSSA_Update_SAGAKU_ERROR:
        Call SSSWIN_LOGWRT("F_TOKSSA_Update_SAGAKU_ERROR")

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
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''ﾃﾞｰﾀがあるとき
        'If CF_Ora_EOF(Usr_Ody) = False Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/04/23 CHG E N D

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

        '2019/04/23 CHG START
        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

        ''SQL実行
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_TOKSME_Update_SAGAKU_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_TOKSME_Update_SAGAKU = 1
        Exit Function

F_TOKSME_Update_SAGAKU_ERROR:
        Call SSSWIN_LOGWRT("F_TOKSME_Update_SAGAKU_ERROR")

    End Function
    '2007/12/10 FKS)minamoto ADD START

    '// V2.00↓ DEL
    '''======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '''   名称：  Function Execute_PLSQL_PRC_URKET53_01
    '''   概要：  PL/SQL実行処理(入金消込更新日時取得処理)
    '''   引数：　Pin_strUDNDATNO   : 売上伝票管理番号
    '''           Pin_strUDNLINNO   : 売上行番号
    '''   戻値：　0 : 正常  1 : 警告  9 : 異常
    '''   備考：  入金消込更新日時取得処理PL/SQL(PRC_UODFP53_01)を実行する
    '''======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''Public Function Execute_PLSQL_PRC_URKET53_01(ByVal pin_strUDNDATNO As String _
    '''                                               , ByVal pin_strUDNLINNO As String) As Integer
    ''
    ''    Dim strSql       As String            'SQL文
    ''    Dim strPara1     As String            'ﾊﾟﾗﾒｰﾀ1(担当者コード)
    ''    Dim strPara2     As String            'ﾊﾟﾗﾒｰﾀ2(クライアントID)
    ''    Dim strPara3     As String            'ﾊﾟﾗﾒｰﾀ3(売上伝票管理番号)
    ''    Dim strPara4     As String            'ﾊﾟﾗﾒｰﾀ4(売上行番号)
    ''    Dim lngPara5     As Long              '復帰コード
    ''    Dim lngPara6     As Long              'エラーコード
    ''    Dim strPara7     As String            'エラー内容
    ''    Dim lngPara8     As Long              '読取件数
    ''    Dim lngPara9     As Long              '書込件数
    ''    Dim param(9)     As OraParameter      'PL/SQLのバインド変数
    ''    Dim bolRet       As Boolean
    ''
    ''    Execute_PLSQL_PRC_URKET53_01 = 9
    ''
    ''
    ''    '受渡し変数初期設定
    ''    strPara1 = SSS_OPEID
    ''    strPara2 = SSS_CLTID
    ''    strPara3 = pin_strUDNDATNO
    ''    strPara4 = pin_strUDNLINNO
    ''    lngPara5 = 0
    ''    lngPara6 = 0
    ''    strPara7 = ""
    ''    lngPara8 = 0
    ''    lngPara9 = 0
    ''
    ''    'パラメータの初期設定を行う（バインド変数）
    ''    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P5", lngPara5, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P7", strPara7, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P8", lngPara8, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P9", lngPara9, ORAPARM_OUTPUT
    ''
    ''    'データ型をオブジェクトにセット
    ''    Set param(1) = gv_Odb_USR1.Parameters("P1")
    ''    Set param(2) = gv_Odb_USR1.Parameters("P2")
    ''    Set param(3) = gv_Odb_USR1.Parameters("P3")
    ''    Set param(4) = gv_Odb_USR1.Parameters("P4")
    ''    Set param(5) = gv_Odb_USR1.Parameters("P5")
    ''    Set param(6) = gv_Odb_USR1.Parameters("P6")
    ''    Set param(7) = gv_Odb_USR1.Parameters("P7")
    ''    Set param(8) = gv_Odb_USR1.Parameters("P8")
    ''    Set param(9) = gv_Odb_USR1.Parameters("P9")
    ''
    ''    '各オブジェクトのデータ型を設定
    ''    param(1).serverType = ORATYPE_CHAR
    ''    param(2).serverType = ORATYPE_CHAR
    ''    param(3).serverType = ORATYPE_CHAR
    ''    param(4).serverType = ORATYPE_CHAR
    ''    param(5).serverType = ORATYPE_NUMBER
    ''    param(6).serverType = ORATYPE_NUMBER
    ''    param(7).serverType = ORATYPE_VARCHAR2
    ''    param(8).serverType = ORATYPE_NUMBER
    ''    param(9).serverType = ORATYPE_NUMBER
    ''
    ''    'PL/SQL呼び出しSQL
    ''    strSql = "BEGIN PRC_URKET53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9); End;"
    ''
    ''    'DBアクセス
    ''    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
    ''    If bolRet = False Then
    ''        GoTo Execute_PLSQL_PRC_URKET53_01_END
    ''    End If
    ''
    ''    '** 戻り値取得
    ''    lngPara5 = param(5).Value
    ''    lngPara6 = param(6).Value
    ''    If IsNull(param(7).Value) = False Then
    ''        strPara7 = param(7).Value
    ''    End If
    ''    lngPara8 = param(8).Value
    ''    lngPara9 = param(9).Value
    ''
    ''    'エラー情報設定
    ''    gv_Int_OraErr = lngPara6
    ''    gv_Str_OraErrText = Trim(strPara7) & vbCrLf
    ''
    ''    Execute_PLSQL_PRC_URKET53_01 = lngPara5
    ''
    ''Execute_PLSQL_PRC_URKET53_01_END:
    ''    '** パラメタ解消
    ''    gv_Odb_USR1.Parameters.Remove "P1"
    ''    gv_Odb_USR1.Parameters.Remove "P2"
    ''    gv_Odb_USR1.Parameters.Remove "P3"
    ''    gv_Odb_USR1.Parameters.Remove "P4"
    ''    gv_Odb_USR1.Parameters.Remove "P5"
    ''    gv_Odb_USR1.Parameters.Remove "P6"
    ''    gv_Odb_USR1.Parameters.Remove "P7"
    ''    gv_Odb_USR1.Parameters.Remove "P8"
    ''    gv_Odb_USR1.Parameters.Remove "P9"
    ''
    ''End Function
    '// V2.00↑ DEL

    '// V2.00↓ DEL
    '''======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '''   名称：  Function Execute_PLSQL_PRC_URKET53_02
    '''   概要：  PL/SQL実行処理(入金消込更新日時排他処理)
    '''   引数：　なし
    '''   戻値：　0 : 正常  1 : 警告  9 : 異常
    '''   備考：  入金消込更新日時排他処理PL/SQL(PRC_UODFP53_02)を実行する
    '''======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''Public Function Execute_PLSQL_PRC_URKET53_02(p_udndatno As String, p_udnlinno As String, p_nyudt As String) As Integer
    ''
    ''    Dim strSql       As String            'SQL文
    ''    Dim strPara1     As String            'ﾊﾟﾗﾒｰﾀ1(担当者コード)
    ''    Dim strPara2     As String            'ﾊﾟﾗﾒｰﾀ2(クライアントID)
    ''    Dim strPara3     As String            'パラメータ3(売上伝票管理番号)
    ''    Dim strPara4     As String            'パラメータ4(売上行番号)
    ''    Dim strPara5     As String            'パラメータ5(入金日)
    ''    Dim lngPara6     As Long              '復帰コード
    ''    Dim lngPara7     As Long              'エラーコード
    ''    Dim strPara8     As String            'エラー内容
    ''    Dim lngPara9     As Long              '読取件数
    ''    Dim lngPara10    As Long              '書込件数
    ''    Dim param(11)    As OraParameter      'PL/SQLのバインド変数
    ''    Dim bolRet       As Boolean
    ''
    ''    Execute_PLSQL_PRC_URKET53_02 = 9
    ''
    ''
    ''    '受渡し変数初期設定
    ''    strPara1 = SSS_OPEID
    ''    strPara2 = SSS_CLTID
    ''    strPara3 = p_udndatno
    ''    strPara4 = p_udnlinno
    ''    strPara5 = p_nyudt
    ''    lngPara6 = 0
    ''    lngPara7 = 0
    ''    strPara8 = ""
    ''    lngPara9 = 0
    ''    lngPara10 = 0
    ''
    ''    'パラメータの初期設定を行う（バインド変数）
    ''    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P5", strPara5, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P8", strPara8, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P9", lngPara9, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P10", lngPara10, ORAPARM_OUTPUT
    ''
    ''    'データ型をオブジェクトにセット
    ''    Set param(1) = gv_Odb_USR1.Parameters("P1")
    ''    Set param(2) = gv_Odb_USR1.Parameters("P2")
    ''    Set param(3) = gv_Odb_USR1.Parameters("P3")
    ''    Set param(4) = gv_Odb_USR1.Parameters("P4")
    ''    Set param(5) = gv_Odb_USR1.Parameters("P5")
    ''    Set param(6) = gv_Odb_USR1.Parameters("P6")
    ''    Set param(7) = gv_Odb_USR1.Parameters("P7")
    ''    Set param(8) = gv_Odb_USR1.Parameters("P8")
    ''    Set param(9) = gv_Odb_USR1.Parameters("P9")
    ''    Set param(10) = gv_Odb_USR1.Parameters("P10")
    ''
    ''    '各オブジェクトのデータ型を設定
    ''    param(1).serverType = ORATYPE_CHAR
    ''    param(2).serverType = ORATYPE_CHAR
    ''    param(3).serverType = ORATYPE_CHAR
    ''    param(4).serverType = ORATYPE_CHAR
    ''    param(5).serverType = ORATYPE_CHAR
    ''    param(6).serverType = ORATYPE_NUMBER
    ''    param(7).serverType = ORATYPE_NUMBER
    ''    param(8).serverType = ORATYPE_VARCHAR2
    ''    param(9).serverType = ORATYPE_NUMBER
    ''    param(10).serverType = ORATYPE_NUMBER
    ''
    ''    'PL/SQL呼び出しSQL
    ''    strSql = "BEGIN PRC_URKET53_02(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10); End;"
    ''
    ''    'DBアクセス
    ''    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
    ''    If bolRet = False Then
    ''        GoTo Execute_PLSQL_PRC_URKET53_02_END
    ''    End If
    ''
    ''    '** 戻り値取得
    ''    lngPara6 = param(6).Value
    ''    lngPara7 = param(7).Value
    ''    If IsNull(param(8).Value) = False Then
    ''        strPara8 = param(8).Value
    ''    End If
    ''
    ''    'エラー情報設定
    ''    gv_Int_OraErr = lngPara7
    ''    gv_Str_OraErrText = Trim(strPara8) & vbCrLf
    ''
    ''    Execute_PLSQL_PRC_URKET53_02 = lngPara6
    ''
    ''Execute_PLSQL_PRC_URKET53_02_END:
    ''    '** パラメタ解消
    ''    gv_Odb_USR1.Parameters.Remove "P1"
    ''    gv_Odb_USR1.Parameters.Remove "P2"
    ''    gv_Odb_USR1.Parameters.Remove "P3"
    ''    gv_Odb_USR1.Parameters.Remove "P4"
    ''    gv_Odb_USR1.Parameters.Remove "P5"
    ''    gv_Odb_USR1.Parameters.Remove "P6"
    ''    gv_Odb_USR1.Parameters.Remove "P7"
    ''    gv_Odb_USR1.Parameters.Remove "P8"
    ''    gv_Odb_USR1.Parameters.Remove "P9"
    ''    gv_Odb_USR1.Parameters.Remove "P10"
    ''
    ''End Function
    '// V2.00↑ DEL

    '// V2.00↓ DEL
    '''======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '''   名称：  Function Execute_PLSQL_PRC_URKET53_03
    '''   概要：  PL/SQL実行処理(入金消込更新日時削除処理)
    '''   引数：　なし
    '''   戻値：　0 : 正常  1 : 警告  9 : 異常
    '''   備考：  入金消込更新日時削除処理PL/SQL(PRC_UODFP53_03)を実行する
    '''======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''Public Function Execute_PLSQL_PRC_URKET53_03() As Integer
    ''
    ''    Dim strSql       As String            'SQL文
    ''    Dim strPara1     As String            'ﾊﾟﾗﾒｰﾀ1(担当者コード)
    ''    Dim strPara2     As String            'ﾊﾟﾗﾒｰﾀ2(クライアントID)
    ''    Dim lngPara3     As Long              '復帰コード
    ''    Dim lngPara4     As Long              'エラーコード
    ''    Dim strPara5     As String            'エラー内容
    ''    Dim lngPara6     As Long              '読取件数
    ''    Dim lngPara7     As Long              '書込件数
    ''    Dim param(7)     As OraParameter      'PL/SQLのバインド変数
    ''    Dim bolRet       As Boolean
    ''
    ''    Execute_PLSQL_PRC_URKET53_03 = 9
    ''
    ''
    ''    '受渡し変数初期設定
    ''    strPara1 = SSS_OPEID
    ''    strPara2 = SSS_CLTID
    ''    lngPara3 = 0
    ''    lngPara4 = 0
    ''    strPara5 = ""
    ''    lngPara6 = 0
    ''    lngPara7 = 0
    ''
    ''    'パラメータの初期設定を行う（バインド変数）
    ''    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    ''    gv_Odb_USR1.Parameters.Add "P3", lngPara3, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P4", lngPara4, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P5", strPara5, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    ''    gv_Odb_USR1.Parameters.Add "P7", lngPara7, ORAPARM_OUTPUT
    ''
    ''    'データ型をオブジェクトにセット
    ''    Set param(1) = gv_Odb_USR1.Parameters("P1")
    ''    Set param(2) = gv_Odb_USR1.Parameters("P2")
    ''    Set param(3) = gv_Odb_USR1.Parameters("P3")
    ''    Set param(4) = gv_Odb_USR1.Parameters("P4")
    ''    Set param(5) = gv_Odb_USR1.Parameters("P5")
    ''    Set param(6) = gv_Odb_USR1.Parameters("P6")
    ''    Set param(7) = gv_Odb_USR1.Parameters("P7")
    ''
    ''    '各オブジェクトのデータ型を設定
    ''    param(1).serverType = ORATYPE_CHAR
    ''    param(2).serverType = ORATYPE_CHAR
    ''    param(3).serverType = ORATYPE_NUMBER
    ''    param(4).serverType = ORATYPE_NUMBER
    ''    param(5).serverType = ORATYPE_VARCHAR2
    ''    param(6).serverType = ORATYPE_NUMBER
    ''    param(7).serverType = ORATYPE_NUMBER
    ''
    ''    'PL/SQL呼び出しSQL
    ''    strSql = "BEGIN PRC_URKET53_03(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"
    ''
    ''    'DBアクセス
    ''    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSql)
    ''    If bolRet = False Then
    ''        GoTo Execute_PLSQL_PRC_URKET53_03_END
    ''    End If
    ''
    ''    '** 戻り値取得
    ''    lngPara3 = param(3).Value
    ''    lngPara4 = param(4).Value
    ''    If IsNull(param(5).Value) = False Then
    ''        strPara5 = param(5).Value
    ''    End If
    ''
    ''    'エラー情報設定
    ''    gv_Int_OraErr = lngPara4
    ''    gv_Str_OraErrText = Trim(strPara5) & vbCrLf
    ''
    ''    Execute_PLSQL_PRC_URKET53_03 = lngPara3
    ''
    ''Execute_PLSQL_PRC_URKET53_03_END:
    ''    '** パラメタ解消
    ''    gv_Odb_USR1.Parameters.Remove "P1"
    ''    gv_Odb_USR1.Parameters.Remove "P2"
    ''    gv_Odb_USR1.Parameters.Remove "P3"
    ''    gv_Odb_USR1.Parameters.Remove "P4"
    ''    gv_Odb_USR1.Parameters.Remove "P5"
    ''    gv_Odb_USR1.Parameters.Remove "P6"
    ''    gv_Odb_USR1.Parameters.Remove "P7"
    ''
    ''End Function
    '''2007/12/10 FKS)minamoto ADD END
    '// V2.00↑ DEL

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function setNKSTRA
    '   概要：  登録処理
    '   引数：  なし
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Public Function sRegistration(ByRef spd_body As vaSpread) As Short
    Public Function sRegistration(ByRef spd_body As Object) As Short

        Dim i As Short
        Dim j As Short

        On Error GoTo SREGISTRATION_ERROR

        sRegistration = 9

        'トランザクション開始
        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

        '現在時刻、日付をセット
        Call setSysdate(GV_SysTime, GV_SysDate)

        '// V2.00↓ ADD
        If Chk_HAITA_UPD() = False Then
            '2019/04/17 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/04/17 CHG E N D
            Call showMsg("1", "URKET53_901", CStr(0)) '他のプログラムで更新されたため、登録できません。
            sRegistration = 1
            Exit Function
        End If
        '// V2.00↑ ADD

        '// V3.50↓ ADD
        '事前に配列に対して消込戻しを実施する
        Call sPreparationSetNKSTRA(spd_body)
        '// V3.50↑ ADD

        '1行ごとにテーブルに値を更新する
        With spd_body
            'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/25 CHG START
            'For i = 1 To .MaxRows
            For i = 0 To .Rows.Count - 1
                '2019/04/25 CHG E N D

                'スプレッドの値を変数に格納
                '2009/09/15 UPD START RISE)MIYAJIMA
                ''// V2.03↓ UPD
                '            For j = COL_CHK To COL_HENPI
                '''''// V2.00↓ UPD
                ''''''            For j = COL_CHK To COL_JDNDATNO
                ''''            For j = COL_CHK To COL_KESIKN_MAE
                '''''// V2.00↑ UPD
                ''// V2.03↑ UPD
                For j = COL_CHK To COL_SSADT
                    '2009/09/15 UPD E.N.D RISE)MIYAJIMA

                    '2019/04/25 CHG START
                    ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Row = i
                    ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Col = j
                    ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'If .Col = COL_HYFRIDT Then
                    '    '振込期日が空白の時は、space(8)をセット
                    '    'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    If .Text = "" Then
                    '        'UPGRADE_WARNING: オブジェクト varSpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        varSpdValue(j) = Space(8)
                    '    Else
                    '        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        'UPGRADE_WARNING: オブジェクト varSpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        varSpdValue(j) = DeCNV_DATE(.Text)
                    '    End If
                    'Else
                    '    'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    'UPGRADE_WARNING: オブジェクト varSpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    varSpdValue(j) = .Text
                    'End If
                    If j = COL_HYFRIDT Then
                        '振込期日が空白の時は、space(8)をセット
                        If .GetValue(i, j) = "" Then
                            varSpdValue(j) = Space(8)
                        Else
                            varSpdValue(j) = DeCNV_DATE(.GetValue(i, j))
                        End If
                    Else
                        varSpdValue(j) = .GetValue(i, j)
                    End If
                    '2019/04/25 CHG E N D
                Next j

                '// V2.00↓ ADD
                'UPGRADE_WARNING: オブジェクト varSpdValue(COL_NO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/05/07 CHG START
                'If varSpdValue(COL_NO) = "" Then
                If varSpdValue(COL_NO).ToString = "" Then
                    '2019/05/07 CHG E N D
                    Exit For
                End If
                '// V2.00↑ ADD

                'NKSTRAの作成
                If setNKSTRA() = False Then
                    GoTo SREGISTRATION_ERROR
                End If
            Next i
        End With

        'コミット
        '2019/04/17 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/04/17 CHG E N D

        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
        Call SSSWIN_Unlock_EXCTBZ()
        ' === 20130708 === INSERT E -

        sRegistration = 0
        Exit Function

SREGISTRATION_ERROR:
        'ロールバック
        '2019/04/17 CHG START
        'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
        Call DB_Rollback()
        '2019/04/17 CHG E N D
    End Function
    '// V2.00↑ ADD

    '// V3.10↓ DEL
    '''''// V2.00↓ ADD
    ''''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '''''   名称：  Function setNKSTRA
    '''''   概要：  入金消込トランの更新と他テーブル更新
    '''''   引数：  なし
    '''''   戻値：　0 : 正常  1 : 警告  9 : 異常
    '''''   備考：
    ''''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''''Private Function setNKSTRA() As Boolean
    ''''
    ''''    Dim strSql      As String
    ''''    Dim Usr_Ody     As U_Ody
    ''''    Dim Usr_Ody_1   As U_Ody
    ''''
    '''''// V2.01↓ ADD
    ''''    Dim strSMADT_DSP As String      '経理締日付(画面)
    ''''    Dim strSMADT_TBL As String      '経理締日付(入金消込トラン)
    ''''    Dim strNYUDT_DSP As String      '請求締め(画面)
    ''''    Dim strNYUDT_TBL As String      '請求締め(入金消込トラン)
    '''''// V2.01↑ ADD
    ''''
    ''''    Dim lstrKDNNO   As String       '前回消込伝票番号
    '''''// V2.01↓ DEL
    ''''''''    Dim lstrNYUDT   As String       '前回入金日
    '''''// V2.01↑ DEL
    ''''    Dim intJkesikn  As Currency     '前回消込額
    ''''
    ''''    Dim intKesikn   As Currency     '今回消込額
    '''''// V2.01↓ DEL
    ''''''''    Dim strSMADT    As String       '経理締日付
    ''''''''    Dim strSMAUPDDT As String       '経理絞日付（SYSTBAより）
    '''''// V2.01↑ ADD
    ''''
    ''''    Dim strNYUKB    As String       '2007.03.05
    ''''    Dim intRet      As Integer
    ''''
    ''''    Dim cur_KESIKIN As Currency
    ''''    Dim cur_KIN_WK  As Currency
    ''''    Dim int_UPDID   As Integer
    ''''    Dim i           As Integer
    ''''    Dim j           As Integer
    ''''
    '''''// V2.07↓ UPD
    ''''    Dim strUPDID    As String
    '''''// V2.07↑ UPD
    ''''
    ''''    setNKSTRA = False
    ''''
    ''''    '経理締め
    ''''    strSMADT_DSP = DeCNV_DATE(Get_Acedt(gstrKesidt))                            '経理締日付(画面)
    ''''
    ''''    '請求締め
    ''''    strNYUDT_DSP = getSmedt(gstrKesidt, _
    '''''                        DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, _
    '''''                        DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB)                 '請求締め(画面)
    ''''
    '''''// V2.02↓ UPD
    ''''''''    '今回消込額を格納(消込金額－消込金額(締日前))
    ''''''''    intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_BFKESIKN))
    ''''
    ''''    '今回消込額を格納(消込金額－消込金額(締日前))
    ''''    intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))
    '''''// V2.02↑ UPD
    ''''
    '''''-------------------------------------------------------------------------------------------
    ''''
    ''''    '振込期日のみ変更された場合の処理
    ''''    If SSSVal(varSpdValue(COL_KESIKN)) <> 0 And _
    '''''       SSSVal(varSpdValue(COL_KESIKN)) = SSSVal(varSpdValue(COL_KESIKN_MAE)) And _
    '''''       Trim(varSpdValue(COL_HYFRIDT)) <> "" And _
    '''''       Trim(varSpdValue(COL_HYFRIDT)) <> Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT)))) Then
    ''''
    ''''        '削除対象のNKSTRAデータを取得(NKSTRA一明細ごとにサマリの戻しを行う必要があるため)
    ''''        strSql = ""
    ''''        strSql = strSql & "SELECT " & vbCrLf
    ''''        strSql = strSql & "       * " & vbCrLf
    ''''        strSql = strSql & "FROM " & vbCrLf
    ''''        strSql = strSql & "       NKSTRA " & vbCrLf
    ''''        strSql = strSql & "WHERE " & vbCrLf
    ''''        strSql = strSql & "       UDNDATNO = '" & varSpdValue(COL_UDNDATNO) & "' " & vbCrLf
    ''''        strSql = strSql & "AND    UDNLINNO = '" & varSpdValue(COL_UDNLINNO) & "' " & vbCrLf
    ''''        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
    ''''        strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
    ''''
    ''''        'DBアクセス
    ''''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''''
    ''''        Do While CF_Ora_EOF(Usr_Ody) = False
    ''''
    ''''            '取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
    ''''            strSql = ""
    ''''            strSql = strSql & "SELECT " & vbCrLf
    ''''            strSql = strSql & "       * " & vbCrLf
    ''''            strSql = strSql & "FROM " & vbCrLf
    ''''            strSql = strSql & "       NKSTRA " & vbCrLf
    ''''            strSql = strSql & "WHERE " & vbCrLf
    ''''            strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf
    ''''
    ''''            'DBアクセス
    ''''            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
    ''''
    ''''            If CF_Ora_EOF(Usr_Ody_1) Then
    ''''
    '''''// V2.01↓ UPD
    ''''                '消込伝票番号
    ''''                lstrKDNNO = CF_Ora_GetDyn(Usr_Ody, "KDNNO", "")
    ''''
    ''''                '消込金額
    ''''                intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JKESIKN", ""))
    ''''
    ''''                '経理締め
    ''''                strSMADT_TBL = DeCNV_DATE(Get_Acedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", "")))   '経理締日付(入金消込トラン)
    ''''
    ''''                '請求締め
    ''''                strNYUDT_TBL = getSmedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""), _
    '''''                                    DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, _
    '''''                                    DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB)                 '請求締め(入金消込トラン)
    ''''
    ''''                '★NKSTRA更新・追加
    ''''                If strSMADT_DSP = strSMADT_TBL Then
    ''''                    ' 画面消込月度とテーブルの消込月度が同一の場合
    ''''                    If F_NKSTRA_UPDATE1(lstrKDNNO) = 9 Then
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Exit Function
    ''''                    End If
    ''''                Else
    ''''                    ' 画面消込月度とテーブルの消込月度が異なる場合
    ''''                    If F_NKSTRA_INSERT1(Usr_Ody, strSMADT_DSP, lstrKDNNO) = 9 Then
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Exit Function
    ''''                    End If
    ''''                End If
    '''''// V2.01↑ UPD
    ''''
    ''''                '★NKSTRA追加
    ''''                If F_NKSTRA_INSERT3(Usr_Ody) = 9 Then
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Exit Function
    ''''                End If
    ''''
    ''''            End If
    ''''
    ''''            Call CF_Ora_CloseDyn(Usr_Ody_1)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''            Usr_Ody.Obj_Ody.MoveNext
    ''''
    ''''        Loop
    ''''
    ''''        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''
    ''''        setNKSTRA = True
    ''''        Exit Function
    ''''
    ''''    End If
    ''''
    '''''-------------------------------------------------------------------------------------------
    ''''
    '''''// V2.02↓ UPD
    ''''''''    '締日以降消込金額(絶対値)が消込金額(絶対値)より大きい時は元NKSTRAを更新する　→派生してJDNTRA,UDNTRA,TOKSSA,TOKSMAの更新
    ''''''''    If Abs(intKesikn) < Abs(SSSVal(varSpdValue(COL_AFKESIKN))) Then
    ''''
    ''''    '変更前消込金額(絶対値)が消込金額(絶対値)より大きい時は元NKSTRAを更新する　→派生してJDNTRA,UDNTRA,TOKSSA,TOKSMAの更新
    ''''''''    If SSSVal(varSpdValue(COL_KESIKN)) < SSSVal(varSpdValue(COL_KESIKN_MAE)) Then
    ''''    If Abs(SSSVal(varSpdValue(COL_KESIKN))) < Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
    '''''// V2.02↑ UPD
    ''''        '削除対象のNKSTRAデータを取得(NKSTRA一明細ごとにサマリの戻しを行う必要があるため)
    ''''        strSql = ""
    ''''        strSql = strSql & "SELECT " & vbCrLf
    ''''        strSql = strSql & "       * " & vbCrLf
    ''''        strSql = strSql & "FROM " & vbCrLf
    ''''        strSql = strSql & "       NKSTRA " & vbCrLf
    ''''        strSql = strSql & "WHERE " & vbCrLf
    ''''        strSql = strSql & "       UDNDATNO = '" & varSpdValue(COL_UDNDATNO) & "' " & vbCrLf
    ''''        strSql = strSql & "AND    UDNLINNO = '" & varSpdValue(COL_UDNLINNO) & "' " & vbCrLf
    ''''        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
    ''''        strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
    ''''
    ''''        'DBアクセス
    ''''        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    ''''
    ''''        Do While CF_Ora_EOF(Usr_Ody) = False
    ''''
    ''''            '取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
    ''''            strSql = ""
    ''''            strSql = strSql & "SELECT " & vbCrLf
    ''''            strSql = strSql & "       * " & vbCrLf
    ''''            strSql = strSql & "FROM " & vbCrLf
    ''''            strSql = strSql & "       NKSTRA " & vbCrLf
    ''''            strSql = strSql & "WHERE " & vbCrLf
    ''''            strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf
    ''''
    ''''            'DBアクセス
    ''''            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
    ''''
    ''''            If CF_Ora_EOF(Usr_Ody_1) Then
    ''''
    '''''// V2.01↓ UPD
    ''''                '消込伝票番号
    ''''                lstrKDNNO = CF_Ora_GetDyn(Usr_Ody, "KDNNO", "")
    ''''
    ''''                '消込金額
    ''''                intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JKESIKN", ""))
    ''''
    ''''                '経理締め
    ''''                strSMADT_TBL = DeCNV_DATE(Get_Acedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", "")))   '経理締日付(入金消込トラン)
    ''''
    ''''                '請求締め
    ''''                strNYUDT_TBL = getSmedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""), _
    '''''                                    DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, _
    '''''                                    DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB)                 '請求締め(入金消込トラン)
    ''''
    ''''                '★NKSTRA更新・追加
    ''''                If strSMADT_DSP = strSMADT_TBL Then
    ''''                    ' 画面消込月度とテーブルの消込月度が同一の場合
    ''''                    If F_NKSTRA_UPDATE1(lstrKDNNO) = 9 Then
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Exit Function
    ''''                    End If
    ''''                Else
    ''''                    ' 画面消込月度とテーブルの消込月度が異なる場合
    ''''                    If F_NKSTRA_INSERT1(Usr_Ody, strSMADT_DSP, lstrKDNNO) = 9 Then
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Exit Function
    ''''                    End If
    ''''                End If
    ''''
    ''''                '★TOKSSA更新(DATKB=9よりマイナス更新する)
    '''''// V2.02↓ UPD
    ''''''''                If setTOKSSA(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, lstrNYUDT) = False Then
    ''''                If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, strNYUDT_DSP) = 9 Then
    '''''// V2.02↑ UPD
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody_1)                             'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody)                               'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Exit Function
    ''''                End If
    ''''
    ''''                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''''                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''''                Else
    ''''                    '★TOKSMA更新(DATKB=9よりマイナス更新する)
    ''''                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", (-1) * intJkesikn, strSMADT_DSP) = False Then
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                        Exit Function
    ''''                    End If
    ''''                End If
    ''''
    ''''                '★UDNTRA更新(DATKB=9よりマイナス更新する)
    ''''                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn) = False Then
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody_1)                             'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody)                               'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Exit Function
    ''''                End If
    ''''
    ''''                '★JDNTRA更新(DATKB=9よりマイナス更新する)
    ''''                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody_1)                             'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody)                               'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Exit Function
    ''''                End If
    ''''
    '''''// V2.07↓ UPD
    '''''''''// V2.02↓ UPD
    ''''''''''''                '入金消込サマリの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''''''''''''                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''''''''''''                Else
    ''''''''                    '★入金消込サマリ更新（入金消し込み集計金額）
    ''''''''                    If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, CF_Ora_GetDyn(Usr_Ody, "UPDID", ""), (-1) * intJkesikn, strSMADT_DSP, strSMADT_TBL) = 9 Then
    ''''''''                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                        Exit Function
    ''''''''                    End If
    '''''''''// V2.02↑ UPD
    ''''''''
    ''''''''                    '消込金額戻し
    ''''''''                    ARY_NKSSMA_KS(SSSVal(CF_Ora_GetDyn(Usr_Ody, "UPDID", ""))).ZAN_KIN = _
    '''''''''                            ARY_NKSSMA_KS(SSSVal(CF_Ora_GetDyn(Usr_Ody, "UPDID", ""))).ZAN_KIN + intJkesikn
    '''''''''// V2.02↓ UPD
    ''''''''''''                End If
    '''''''''// V2.02↑ UPD
    ''''
    ''''                '★入金消込サマリ更新（入金消し込み集計金額）
    ''''                strUPDID = CF_Ora_GetDyn(Usr_Ody, "UPDID", "")
    ''''                If strSMADT_DSP <> strSMADT_TBL Then
    ''''                    '前月解除の場合、06：手数 と 99：消費 は、01:現金とする
    ''''                    If SSSVal(strUPDID) = 5 Or SSSVal(strUPDID) = 9 Then
    ''''                        strUPDID = "00" '01:現金
    ''''                    End If
    ''''                End If
    ''''                If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD _
    '''''                                     , strUPDID _
    '''''                                     , (-1) * intJkesikn _
    '''''                                     , strSMADT_DSP _
    '''''                                     , strSMADT_TBL) = 9 Then
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Exit Function
    ''''                End If
    ''''                '消込金額戻し
    ''''                ARY_NKSSMA_KS(SSSVal(strUPDID)).ZAN_KIN = _
    '''''                        ARY_NKSSMA_KS(SSSVal(strUPDID)).ZAN_KIN + intJkesikn
    '''''// V2.07↑ UPD
    '''''// V2.01↑ UPD
    ''''            End If
    ''''
    ''''            Call CF_Ora_CloseDyn(Usr_Ody_1)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''            Usr_Ody.Obj_Ody.MoveNext
    ''''
    ''''        Loop
    ''''
    ''''        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''
    ''''        '前回消込金額を0とする
    ''''        varSpdValue(COL_AFKESIKN) = 0
    ''''    End If
    ''''
    '''''-------------------------------------------------------------------------------------------
    ''''
    '''''// V2.02↓ UPD
    ''''''''    '締日以降消込金額(絶対値)が消込金額(絶対値)より小きい時は差額を新規に作成
    ''''''''    If Abs(intKesikn) > Abs(SSSVal(varSpdValue(COL_AFKESIKN))) Then
    ''''
    ''''    '締日以降消込金額(絶対値)が消込金額(絶対値)より小きい時は差額を新規に作成
    ''''''''    If SSSVal(varSpdValue(COL_KESIKN)) > SSSVal(varSpdValue(COL_KESIKN_MAE)) Then
    ''''''''        intKesikn = intKesikn - (SSSVal(varSpdValue(COL_AFKESIKN)) + SSSVal(varSpdValue(COL_BFKESIKN)))
    ''''
    '''''''''// V2.03↓ UPD
    ''''''''    If Abs(SSSVal(varSpdValue(COL_KESIKN))) > Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
    ''''''''        intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))
    '''''''''// V2.02↑ UPD
    ''''''''
    ''''''''''''        strSMADT = DeCNV_DATE(Get_Acedt(gstrKesidt))     '経理締め
    ''''''''        cur_KIN_WK = intKesikn
    ''''''''
    ''''''''        '消込順序で消込む
    ''''''''        For i = 1 To 20
    ''''''''            For j = 0 To 9
    '''''''''''''// V2.02↓ UPD
    ''''''''''''                If ARY_NKSSMA_KS(j).ZAN_KIN <> 0 Then
    ''''''''                If ARY_NKSSMA_KS(j).ZAN_KIN > 0 Then
    '''''''''''''// V2.02↑ UPD
    ''''''''                    If ARY_NKSSMA_KS(j).SEQ = i Then
    ''''''''                        If ARY_NKSSMA_KS(j).ZAN_KIN - cur_KIN_WK >= 0 Then
    ''''''''                            ARY_NKSSMA_KS(j).ZAN_KIN = ARY_NKSSMA_KS(j).ZAN_KIN - cur_KIN_WK
    ''''''''                            cur_KESIKIN = cur_KIN_WK
    ''''''''                            cur_KIN_WK = 0
    ''''''''                            int_UPDID = j
    ''''''''                        Else
    ''''''''                            cur_KESIKIN = ARY_NKSSMA_KS(j).ZAN_KIN
    ''''''''                            cur_KIN_WK = cur_KIN_WK - cur_KESIKIN
    ''''''''                            ARY_NKSSMA_KS(j).ZAN_KIN = 0
    ''''''''                            int_UPDID = j
    ''''''''                        End If
    ''''''''
    ''''''''                        '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2             '2007.03.05
    ''''''''                        If DB_TOKMTA2.SHAKB = 5 Or DB_TOKMTA2.SHAKB = 6 Then
    ''''''''                            strNYUKB = "2"
    ''''''''                        Else
    ''''''''                            strNYUKB = "1"
    ''''''''                        End If
    ''''''''
    '''''''''// V2.01↓ UPD
    ''''''''                        '★NKSTRA追加
    ''''''''                        If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
    ''''''''                            Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                            Exit Function
    ''''''''                        End If
    ''''''''
    ''''''''                        '★TOKSSA更新
    '''''''''// V2.02↓ UPD
    ''''''''''''                        If setTOKSSA(CStr(varSpdValue(COL_TOKSEICD)), intKesikn, DB_TOKMTA2.KESISMEDT) = False Then
    ''''''''                        If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    '''''''''// V2.02↑ UPD
    ''''''''                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                            Exit Function
    ''''''''                        End If
    ''''''''
    ''''''''                        'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''''''''                        If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''''''''                        Else
    ''''''''                            '★TOKSMA更新
    ''''''''                            If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
    ''''''''                                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                                Exit Function
    ''''''''                            End If
    ''''''''                        End If
    ''''''''
    ''''''''                        '★UDNTRA更新
    ''''''''                        If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
    ''''''''                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                            Exit Function
    ''''''''                        End If
    ''''''''
    ''''''''                        '★JDNTRA更新
    ''''''''                        If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
    ''''''''                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                            Exit Function
    ''''''''                        End If
    ''''''''
    '''''''''// V2.02↓ UPD
    ''''''''''''                        '入金消込サマリの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''''''''''''                        If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''''''''''''                        Else
    ''''''''                            '★入金消込サマリ更新（入金消し込み集計金額）
    ''''''''                            If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, ARY_NKSSMA_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    ''''''''                                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''''''                                Exit Function
    ''''''''                            End If
    '''''''''// V2.02↑ UPD
    '''''''''// V2.02↓ UPD
    ''''''''''''                        End If
    '''''''''// V2.02↑ UPD
    '''''''''// V2.01↑ UPD
    ''''''''
    ''''''''                    End If
    ''''''''                End If
    ''''''''                If cur_KIN_WK = 0 Then
    ''''''''                    Exit For
    ''''''''                End If
    ''''''''            Next j
    ''''''''            If cur_KIN_WK = 0 Then
    ''''''''                Exit For
    ''''''''            End If
    ''''''''        Next i
    ''''''''    End If
    ''''
    ''''    If Abs(SSSVal(varSpdValue(COL_KESIKN))) > Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
    ''''        intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))
    ''''
    ''''        '消し込み金額取得
    ''''        cur_KIN_WK = intKesikn
    ''''
    '''''// V2.07↓ UPD
    ''''''''        '支払区分が期日振込、ﾌｧｸﾀﾘﾝｸﾞの時 nyukb = 2             '2007.03.05
    ''''''''        If DB_TOKMTA2.SHAKB = 5 Or DB_TOKMTA2.SHAKB = 6 Then
    ''''''''            strNYUKB = "2"
    ''''''''        Else
    ''''''''            strNYUKB = "1"
    ''''''''        End If
    ''''        '取引区分="03"(手形) or "08"(振込仮) で
    ''''        '期日振込日が入力されているデータを入金区分=2で設定する。
    ''''        'それ以外は１を設定する。
    ''''        strNYUKB = "1"
    ''''        With ARY_NKSSMA_KS(int_UPDID)
    ''''            If .DATKB = "03" Or .DATKB = "08" Then
    ''''                If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    ''''                    strNYUKB = "2"
    ''''                End If
    ''''            End If
    ''''        End With
    '''''// V2.07↑ UPD
    ''''
    ''''        If varSpdValue(COL_HENPI) = "1" And SSSVal(varSpdValue(COL_KESIKN)) = SSSVal(varSpdValue(COL_KOMIKN)) Then
    ''''
    ''''            '返品時消し込み
    ''''
    ''''            cur_KESIKIN = cur_KIN_WK
    ''''
    ''''            'ここで返品時のUPDIDを入手
    ''''            int_UPDID = getUpdid
    ''''
    ''''            '★NKSTRA追加
    ''''            If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
    ''''                Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                Exit Function
    ''''            End If
    ''''
    ''''            '★TOKSSA更新
    ''''            If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    ''''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                Exit Function
    ''''            End If
    ''''
    ''''            'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''''            If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''''            Else
    ''''                '★TOKSMA更新
    ''''                If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
    ''''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                    Exit Function
    ''''                End If
    ''''            End If
    ''''
    ''''            '★UDNTRA更新
    ''''            If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
    ''''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                Exit Function
    ''''            End If
    ''''
    ''''            '★JDNTRA更新
    ''''            If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
    ''''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                Exit Function
    ''''            End If
    ''''
    ''''            '★入金消込サマリ更新（入金消し込み集計金額）
    ''''            If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, ARY_NKSSMA_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    ''''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                Exit Function
    ''''            End If
    ''''
    ''''        Else
    ''''
    ''''            '通常消し込み
    ''''
    ''''            '消込順序で消込む
    ''''            For i = 1 To 20
    ''''                For j = 0 To 9
    ''''                    If ARY_NKSSMA_KS(j).ZAN_KIN <> 0 Then
    ''''                        If ARY_NKSSMA_KS(j).SEQ = i Then
    ''''                            If ARY_NKSSMA_KS(j).ZAN_KIN - cur_KIN_WK >= 0 Then
    ''''                                ARY_NKSSMA_KS(j).ZAN_KIN = ARY_NKSSMA_KS(j).ZAN_KIN - cur_KIN_WK
    ''''                                cur_KESIKIN = cur_KIN_WK
    ''''                                cur_KIN_WK = 0
    ''''                                int_UPDID = j
    ''''                            Else
    ''''                                cur_KESIKIN = ARY_NKSSMA_KS(j).ZAN_KIN
    ''''                                cur_KIN_WK = cur_KIN_WK - cur_KESIKIN
    ''''                                ARY_NKSSMA_KS(j).ZAN_KIN = 0
    ''''                                int_UPDID = j
    ''''                            End If
    ''''
    '''''// V2.07↓ ADD
    ''''                            '取引区分="03"(手形) or "08"(振込仮) で
    ''''                            '期日振込日が入力されているデータを入金区分=2で設定する。
    ''''                            'それ以外は１を設定する。
    ''''                            strNYUKB = "1"
    ''''                            With ARY_NKSSMA_KS(int_UPDID)
    ''''                                If .DATKB = "03" Or .DATKB = "08" Then
    ''''                                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    ''''                                        strNYUKB = "2"
    ''''                                    End If
    ''''                                End If
    ''''                            End With
    '''''// V2.07↑ ADD
    ''''
    ''''                            '★NKSTRA追加
    ''''                            If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
    ''''                                Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                                Exit Function
    ''''                            End If
    ''''
    ''''                            '★TOKSSA更新
    ''''                            If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    ''''                                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                                Exit Function
    ''''                            End If
    ''''
    ''''                            'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''''                            If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''''                            Else
    ''''                                '★TOKSMA更新
    ''''                                If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
    ''''                                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                                    Exit Function
    ''''                                End If
    ''''                            End If
    ''''
    ''''                            '★UDNTRA更新
    ''''                            If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
    ''''                                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                                Exit Function
    ''''                            End If
    ''''
    ''''                            '★JDNTRA更新
    ''''                            If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
    ''''                                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                                Exit Function
    ''''                            End If
    ''''
    ''''                            '★入金消込サマリ更新（入金消し込み集計金額）
    ''''                            If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, ARY_NKSSMA_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    ''''                                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''''                                Exit Function
    ''''                            End If
    ''''                        End If
    ''''                    End If
    ''''                    If cur_KIN_WK = 0 Then
    ''''                        Exit For
    ''''                    End If
    ''''                Next j
    ''''                If cur_KIN_WK = 0 Then
    ''''                    Exit For
    ''''                End If
    ''''            Next i
    ''''        End If
    ''''
    ''''    End If
    '''''// V2.03↑ UPD
    ''''
    ''''    setNKSTRA = True
    ''''    Exit Function
    ''''
    ''''SETNKSTRA_ERROR:
    ''''    Call SSSWIN_LOGWRT("SETNKSTRA_ERROR")
    ''''
    ''''End Function
    '''''// V2.00↑ ADD
    '// V3.10↑ DEL

    '// V2.00↓ ADD
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
        '2019/04/17 ADD START
        Dim dt As DataTable
        '2019/04/17 ADD E N D

        On Error GoTo ERR_GET_SYSTBC_DENNO2

        GET_SYSTBC_DENNO2 = 9
        pot_strDENNO = ""

        'トランザクション開始
        '2019/04/17 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR_SAIBAN)
        'Call DB_BeginTrans(CON)
        '2019/04/17 CHG E N D

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
        '2019/04/17 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR_SAIBAN, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then

        '    '伝票番号の採番
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strDENNO = CF_Ora_GetDyn(Usr_Ody, "DENNO", "")
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strSTTNO = CF_Ora_GetDyn(Usr_Ody, "STTNO", "")
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strENDNO = CF_Ora_GetDyn(Usr_Ody, "ENDNO", "")

        dt = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            '伝票番号の採番
            strDENNO = DB_NullReplace(dt.Rows(0)("DENNO"), "")
            strSTTNO = DB_NullReplace(dt.Rows(0)("STTNO"), "")
            strENDNO = DB_NullReplace(dt.Rows(0)("ENDNO"), "")
            '2019/04/17 CHG E N D

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
            '2019/04/17 CHG START
            'If CF_Ora_Execute(gv_Odb_USR_SAIBAN, strSql) = False Then
            '    Call CF_Ora_RollbackTrans(gv_Odb_USR_SAIBAN)
            '    GET_SYSTBC_DENNO2 = 9
            '    GoTo END_GET_SYSTBC_DENNO2
            'End If
            Call DB_Execute(strSql)
            '2019/04/17 CHG E N D

            ' 戻り値に採番結果を設定
            pot_strDENNO = strDENNO

        Else
            GoTo END_GET_SYSTBC_DENNO2
        End If

        '2019/04/17 CHG START
        'Call CF_Ora_CommitTrans(gv_Odb_USR_SAIBAN)
        'Call DB_Commit()
        '2019/04/17 CHG E N D
        GET_SYSTBC_DENNO2 = 0

END_GET_SYSTBC_DENNO2:
        '2019/04/17 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/17 DEL E N D
        Exit Function

ERR_GET_SYSTBC_DENNO2:

        '2019/04/17 CHG START
        'Call CF_Ora_RollbackTrans(gv_Odb_USR_SAIBAN)
        Call DB_Rollback()
        '2019/04/17 CHG E N D
        GET_SYSTBC_DENNO2 = 9
        GoTo END_GET_SYSTBC_DENNO2

    End Function
    '// V2.00↑ ADD

    '// V2.00↓ ADD
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
        '// V2.03↓ UPD
        ''''    strSql = strSql & "      ,NYUDELDT  = '" & CF_Ora_Sgl(GV_SysDate) & "'" & vbCrLf
        strSql = strSql & "      ,NYUDELDT  = '" & CF_Ora_Sgl(gstrKesidt.Value) & "'" & vbCrLf
        '// V2.03↑ UPD
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
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_NKSTRA_UPDATE1_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_NKSTRA_UPDATE1 = 0
        Exit Function

F_NKSTRA_UPDATE1_ERROR:
        Call SSSWIN_LOGWRT("F_NKSTRA_UPDATE1_ERROR")

    End Function
    '// V2.00↑ ADD

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_NKSTRA_INSERT1
    '   概要：  入金消込トランの追加を行う(取消用レコード）
    '   引数：  pm_strSMADT  : レコードセット
    '           pm_strSMADT  : 経理締日付
    '           pm_lstrKDNNO : 元消込伝票番号
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function F_NKSTRA_INSERT1(ByRef pm_Usr_Ody As U_Ody, ByVal pm_strSMADT As String, ByVal pm_lstrKDNNO As String) As Short
    Private Function F_NKSTRA_INSERT1(ByRef pm_Usr_Ody As DataRow, ByVal pm_strSMADT As String, ByVal pm_lstrKDNNO As String) As Short

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
        '2019/04/23 CHG START
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYURECNO", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNRECNO", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "JKESIKN", "") * -1 & "," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TOKSEICD", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TOKCD", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TANCD", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNNO", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNLINNO", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNDT", "")) & "'," & vbCrLf
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "URIKN", "") & "," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TEGDT", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNDT", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TUKKB", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "INVNO", "")) & "'," & vbCrLf
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "FURIKN", "") & "," & vbCrLf
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "FKESIKN", "") & "," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FRNKB", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYUKB", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNDATNO", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNLINNO", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "MAEUKKB", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(pm_strSMADT) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "REGDT", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "DKBID", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UPDID", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNDATNO", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(pm_lstrKDNNO) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FOPEID", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FCLTID", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "WRTFSTTM", "")) & "'," & vbCrLf
        'strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "WRTFSTDT", "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("NYURECNO"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("UDNRECNO"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
        strSql = strSql & "  " & DB_NullReplace(pm_Usr_Ody(0)("JKESIKN"), "") * -1 & "," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("TOKSEICD"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("TOKCD"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("TANCD"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("JDNNO"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("JDNLINNO"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("UDNDT"), "")) & "'," & vbCrLf
        strSql = strSql & "  " & DB_NullReplace(pm_Usr_Ody(0)("URIKN"), "") & "," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("TEGDT"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("JDNDT"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("TUKKB"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("INVNO"), "")) & "'," & vbCrLf
        strSql = strSql & "  " & DB_NullReplace(pm_Usr_Ody(0)("FURIKN"), "") & "," & vbCrLf
        strSql = strSql & "  " & DB_NullReplace(pm_Usr_Ody(0)("FKESIKN"), "") & "," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("FRNKB"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("NYUKB"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("UDNDATNO"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("UDNLINNO"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("MAEUKKB"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(pm_strSMADT) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("REGDT"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("DKBID"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("UPDID"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("JDNDATNO"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(pm_lstrKDNNO) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("FOPEID"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("FCLTID"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("WRTFSTTM"), "")) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(DB_NullReplace(pm_Usr_Ody(0)("WRTFSTDT"), "")) & "'," & vbCrLf
        '2019/04/23 CHG E N D
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
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '    GoTo F_NKSTRA_INSERT1_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_NKSTRA_INSERT1 = 0
        Exit Function

F_NKSTRA_INSERT1_ERROR:
        Call SSSWIN_LOGWRT("F_NKSTRA_INSERT1_ERROR")

    End Function
    '// V2.00↑ ADD

    '// V2.00↓ ADD
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
    '2009/11/02 UPD START RISE)MIYAJIMA
    Private Function F_NKSTRA_INSERT2(ByVal pm_cur_KESIKIN As Decimal, ByVal pm_strSMADT As String, ByVal pm_strNYUKB As String, ByVal pm_int_UPDID As Short, ByRef pm_str_TEGDT As String) As Short
        'Private Function F_NKSTRA_INSERT2( _
        ''                                    ByVal pm_cur_KESIKIN As Currency, _
        ''                                    ByVal pm_strSMADT As String, _
        ''                                    ByVal pm_strNYUKB As String, _
        ''                                    ByVal pm_int_UPDID As Integer) As Integer
        '2009/11/02 UPD E.N.D RISE)MIYAJIMA

        Dim strSql As String

        On Error GoTo F_NKSTRA_INSERT2_ERROR

        F_NKSTRA_INSERT2 = 9

        '消込伝票番号の採番処理
        If GET_SYSTBC_DENNO2(gc_DKBSB_KES, strKDNNO) Then
            GoTo F_NKSTRA_INSERT2_ERROR
        End If

        '2009/10/22 ADD START RISE)MIYAJIMA
        If pm_cur_KESIKIN = 0 Then
            intProcErrFlg = 1
            GoTo F_NKSTRA_INSERT2_ERROR
        End If
        '2009/10/22 ADD E.N.D RISE)MIYAJIMA

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
        '2009/11/02 UPD START RISE)MIYAJIMA
        pm_str_TEGDT = Space(8)
        If CDbl(pm_strNYUKB) = 2 Then
            If Trim(CF_Ora_Sgl(varSpdValue(COL_HYFRIDT))) = "" Then
                strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
                pm_str_TEGDT = gstrKesidt.Value
            Else
                '20091227↓UPD
                'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT)))) <> CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) Then
                    strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
                    'UPGRADE_WARNING: オブジェクト varSpdValue(COL_HYFRIDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    pm_str_TEGDT = varSpdValue(COL_HYFRIDT)
                Else
                    'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT)))) <> "" Then
                        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If gstrKesidt.Value <= Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT)))) Then
                            'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            strSql = strSql & " '" & CF_Ora_Sgl(Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT))))) & "'," & vbCrLf
                            'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            pm_str_TEGDT = Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT))))
                        Else
                            strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
                            pm_str_TEGDT = gstrKesidt.Value
                        End If
                    Else
                        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
                        'UPGRADE_WARNING: オブジェクト varSpdValue(COL_HYFRIDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        pm_str_TEGDT = varSpdValue(COL_HYFRIDT)
                    End If
                End If
                ''2009/12/11 UPD START RISE)MIYAJIMA
                ''            If Trim(CF_Ora_Sgl(varSpdValue(COL_BFHYFRIDT))) <> "" Then
                ''                If gstrKesidt <= varSpdValue(COL_BFHYFRIDT) Then
                ''                    strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_BFHYFRIDT)) & "'," & vbCrLf
                ''                    pm_str_TEGDT = varSpdValue(COL_BFHYFRIDT)
                '            If Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT)))) <> "" Then
                '                If gstrKesidt <= Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT)))) Then
                '                    strSql = strSql & " '" & CF_Ora_Sgl(Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT))))) & "'," & vbCrLf
                '                    pm_str_TEGDT = Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT))))
                ''2009/12/11 UPD END RISE)MIYAJIMA
                '                Else
                '                    strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt) & "'," & vbCrLf
                '                    pm_str_TEGDT = gstrKesidt
                '                End If
                '            Else
                '                strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
                '                pm_str_TEGDT = varSpdValue(COL_HYFRIDT)
                '            End If
                '20091227↑UPD
            End If
        Else
            If ARY_NKSSMA_KS(pm_int_UPDID).DATKB = "03" Then
                If Trim(CF_Ora_Sgl(varSpdValue(COL_HYFRIDT))) = "" Then
                    strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
                    pm_str_TEGDT = gstrKesidt.Value
                Else
                    '20091227↓UPD
                    'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT)))) <> CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) Then
                        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
                        'UPGRADE_WARNING: オブジェクト varSpdValue(COL_HYFRIDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        pm_str_TEGDT = varSpdValue(COL_HYFRIDT)
                    Else
                        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT)))) <> "" Then
                            'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If gstrKesidt.Value <= Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT)))) Then
                                'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                strSql = strSql & " '" & CF_Ora_Sgl(Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT))))) & "'," & vbCrLf
                                'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                pm_str_TEGDT = Trim(DeCNV_DATE(CObj(varSpdValue(COL_BFHYFRIDT))))
                            Else
                                strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
                                pm_str_TEGDT = gstrKesidt.Value
                            End If
                        Else
                            strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
                            'UPGRADE_WARNING: オブジェクト varSpdValue(COL_HYFRIDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            pm_str_TEGDT = varSpdValue(COL_HYFRIDT)
                        End If
                    End If
                End If
            Else
                strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
                pm_str_TEGDT = Space(8)
            End If
            ''2009/12/11 UPD START RISE)MIYAJIMA
            ''                If Trim(CF_Ora_Sgl(varSpdValue(COL_BFHYFRIDT))) <> "" Then
            ''                    If gstrKesidt <= varSpdValue(COL_BFHYFRIDT) Then
            ''                        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_BFHYFRIDT)) & "'," & vbCrLf
            ''                        pm_str_TEGDT = varSpdValue(COL_BFHYFRIDT)
            '                If Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT)))) <> "" Then
            '                    If gstrKesidt <= Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT)))) Then
            '                        strSql = strSql & " '" & CF_Ora_Sgl(Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT))))) & "'," & vbCrLf
            '                        pm_str_TEGDT = Trim(DeCNV_DATE(CVar(varSpdValue(COL_BFHYFRIDT))))
            ''2009/12/11 UPD END RISE)MIYAJIMA
            '                    Else
            '                        strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt) & "'," & vbCrLf
            '                        pm_str_TEGDT = gstrKesidt
            '                    End If
            '                Else
            '                    strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
            '                    pm_str_TEGDT = varSpdValue(COL_HYFRIDT)
            '                End If
            '            End If
            '        Else
            '            strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
            '            pm_str_TEGDT = Space(8)
            '        End If
            '20091227↑UPD
        End If
        ''2009/09/23 UPD START RISE)MIYAJIMA
        '    If pm_strNYUKB = 2 Then
        '        If Trim(CF_Ora_Sgl(varSpdValue(COL_HYFRIDT))) = "" Then
        '            strSql = strSql & " '" & CF_Ora_Sgl(gstrUnydt) & "'," & vbCrLf
        '        Else
        '            strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
        '        End If
        '    Else
        '        If ARY_NKSSMA_KS(pm_int_UPDID).DATKB = "03" Then
        '            If Trim(CF_Ora_Sgl(varSpdValue(COL_HYFRIDT))) = "" Then
        '                strSql = strSql & " '" & CF_Ora_Sgl(gstrUnydt) & "'," & vbCrLf
        '            Else
        '                strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
        '            End If
        '        Else
        '            strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
        '        End If
        '    End If
        '2009/11/02 UPD E.N.D RISE)MIYAJIMA
        ''2009/09/18 UPD START RISE)MIYAJIMA
        '    If pm_strNYUKB = 2 Then
        '        If Trim(CF_Ora_Sgl(varSpdValue(COL_HYFRIDT))) = "" Then
        '            strSql = strSql & " '" & CF_Ora_Sgl(gstrUnydt) & "'," & vbCrLf
        '        Else
        '            strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
        '        End If
        '    Else
        '        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
        '    End If
        '''// V3.10↓ UPD
        ''    If ARY_NKSSMA_KS(pm_int_UPDID).DATKB = "03" Or ARY_NKSSMA_KS(pm_int_UPDID).DATKB = "08" Then
        ''        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
        ''    Else
        ''        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
        ''    End If
        ''''// V2.07↓ UPD
        ''''    If ARY_NKSSMA_KS(pm_int_UPDID).DATKB = "03" Or ARY_NKSSMA_KS(pm_int_UPDID).DATKB = "08" Then
        ''''        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
        ''''    Else
        ''''        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
        ''''    End If
        '''
        '''    strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
        ''''// V2.07↑ UPD
        '''// V3.10↑ UPD
        ''2009/09/18 UPD E.N.D RISE)MIYAJIMA
        '2009/09/23 UPD E.N.D RISE)MIYAJIMA
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_JDNDT)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_TUKKB)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_INVNO)) & "'," & vbCrLf
        strSql = strSql & "  " & 0 & "," & vbCrLf
        strSql = strSql & "  " & 0 & "," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_FRNKB)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(pm_strNYUKB) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_UDNDATNO)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_UDNLINNO)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_MAEUKKB)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(pm_strSMADT) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(ARY_NKSSMA_KS(pm_int_UPDID).DATKB) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(ARY_NKSSMA_KS(pm_int_UPDID).UPDID) & "'," & vbCrLf
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
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_NKSTRA_INSERT2_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_NKSTRA_INSERT2 = 0
        Exit Function

F_NKSTRA_INSERT2_ERROR:
        Call SSSWIN_LOGWRT("F_NKSTRA_INSERT2_ERROR")

    End Function
    '// V2.00↑ ADD

    '2009/09/18 DEL START RISE)MIYAJIMA （未使用のため）
    ''// V2.00↓ ADD
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function F_NKSTRA_INSERT3
    ''   概要：  入金消込トランの追加を行う(取消用レコード）
    ''   引数：  pm_Usr_Ody   : レコードセット
    ''   戻値：　0 : 正常  1 : 警告  9 : 異常
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function F_NKSTRA_INSERT3( _
    ''                                    ByRef pm_Usr_Ody As U_Ody) As Integer
    '
    '    Dim strSql  As String
    '
    'On Error GoTo F_NKSTRA_INSERT3_ERROR
    '
    '    F_NKSTRA_INSERT3 = 9
    '
    '    '消込伝票番号の採番処理
    '    If GET_SYSTBC_DENNO2(gc_DKBSB_KES, strKDNNO) Then
    '        GoTo F_NKSTRA_INSERT3_ERROR
    '    End If
    '
    '    '翌月消込取消
    '    strSql = ""
    '    strSql = strSql & "INSERT INTO NKSTRA ( " & vbCrLf
    '    strSql = strSql & "  KDNNO" & vbCrLf
    '    strSql = strSql & " ,DATKB" & vbCrLf
    '    strSql = strSql & " ,AKAKROKB" & vbCrLf
    '    strSql = strSql & " ,NYURECNO" & vbCrLf
    '    strSql = strSql & " ,UDNRECNO" & vbCrLf
    '    strSql = strSql & " ,NYUDT" & vbCrLf
    '    strSql = strSql & " ,JKESIKN" & vbCrLf
    '    strSql = strSql & " ,TOKSEICD" & vbCrLf
    '    strSql = strSql & " ,TOKCD" & vbCrLf
    '    strSql = strSql & " ,TANCD" & vbCrLf
    '    strSql = strSql & " ,JDNNO" & vbCrLf
    '    strSql = strSql & " ,JDNLINNO" & vbCrLf
    '    strSql = strSql & " ,UDNDT" & vbCrLf
    '    strSql = strSql & " ,URIKN" & vbCrLf
    '    strSql = strSql & " ,TEGDT" & vbCrLf
    '    strSql = strSql & " ,JDNDT" & vbCrLf
    '    strSql = strSql & " ,TUKKB" & vbCrLf
    '    strSql = strSql & " ,INVNO" & vbCrLf
    '    strSql = strSql & " ,FURIKN" & vbCrLf
    '    strSql = strSql & " ,FKESIKN" & vbCrLf
    '    strSql = strSql & " ,FRNKB" & vbCrLf
    '    strSql = strSql & " ,NYUKB" & vbCrLf
    '    strSql = strSql & " ,UDNDATNO" & vbCrLf
    '    strSql = strSql & " ,UDNLINNO" & vbCrLf
    '    strSql = strSql & " ,MAEUKKB" & vbCrLf
    '    strSql = strSql & " ,SMADT" & vbCrLf
    '    strSql = strSql & " ,REGDT" & vbCrLf
    '    strSql = strSql & " ,NYUDELDT" & vbCrLf
    '    strSql = strSql & " ,DKBID" & vbCrLf
    '    strSql = strSql & " ,UPDID" & vbCrLf
    '    strSql = strSql & " ,JDNDATNO" & vbCrLf
    '    strSql = strSql & " ,MOTKDNNO" & vbCrLf
    '    strSql = strSql & " ,FOPEID" & vbCrLf
    '    strSql = strSql & " ,FCLTID" & vbCrLf
    '    strSql = strSql & " ,WRTFSTTM" & vbCrLf
    '    strSql = strSql & " ,WRTFSTDT" & vbCrLf
    '    strSql = strSql & " ,OPEID" & vbCrLf
    '    strSql = strSql & " ,CLTID" & vbCrLf
    '    strSql = strSql & " ,WRTTM" & vbCrLf
    '    strSql = strSql & " ,WRTDT" & vbCrLf
    '    strSql = strSql & " ,UOPEID" & vbCrLf
    '    strSql = strSql & " ,UCLTID" & vbCrLf
    '    strSql = strSql & " ,UWRTTM" & vbCrLf
    '    strSql = strSql & " ,UWRTDT" & vbCrLf
    '    strSql = strSql & " ,PGID" & vbCrLf
    '    strSql = strSql & " ,DLFLG" & vbCrLf
    '    strSql = strSql & ") VALUES ( " & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(strKDNNO) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl("1") & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl("1") & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYURECNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNRECNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYUDT", "")) & "'," & vbCrLf
    '    strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "JKESIKN", "") & "," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TOKSEICD", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TOKCD", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TANCD", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNLINNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNDT", "")) & "'," & vbCrLf
    '    strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "URIKN", "") & "," & vbCrLf
    ''// V3.10↓ UPD
    '    If CF_Ora_GetDyn(pm_Usr_Ody, "DKBID", "") = "03" Or CF_Ora_GetDyn(pm_Usr_Ody, "DKBID", "") = "08" Then
    '        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
    '    Else
    '        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
    '    End If
    '''// V2.07↓ UPD
    '''    If CF_Ora_GetDyn(pm_Usr_Ody, "DKBID", "") = "03" Or CF_Ora_GetDyn(pm_Usr_Ody, "DKBID", "") = "08" Then
    '''        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
    '''    Else
    '''        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
    '''    End If
    ''
    ''    strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_HYFRIDT)) & "'," & vbCrLf
    '''// V2.07↑ UPD
    ''// V3.10↑ UPD
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNDT", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "TUKKB", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "INVNO", "")) & "'," & vbCrLf
    '    strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "FURIKN", "") & "," & vbCrLf
    '    strSql = strSql & "  " & CF_Ora_GetDyn(pm_Usr_Ody, "FKESIKN", "") & "," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FRNKB", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYUKB", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNDATNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UDNLINNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "MAEUKKB", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "SMADT", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "REGDT", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "NYUDELDT", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "DKBID", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "UPDID", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "JDNDATNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "MOTKDNNO", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FOPEID", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "FCLTID", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "WRTFSTTM", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(CF_Ora_GetDyn(pm_Usr_Ody, "WRTFSTDT", "")) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(SSS_OPEID) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(SSS_CLTID) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(GV_SysTime) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(GV_SysDate) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(SSS_OPEID) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(SSS_CLTID) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(GV_SysTime) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(GV_SysDate) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl(SSS_PrgId) & "'," & vbCrLf
    '    strSql = strSql & " '" & CF_Ora_Sgl("2") & "'" & vbCrLf
    '    strSql = strSql & ")"
    '
    '    '★INSERT実行
    '    If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
    '        GoTo F_NKSTRA_INSERT3_ERROR
    '    End If
    '
    '    F_NKSTRA_INSERT3 = 0
    '    Exit Function
    '
    'F_NKSTRA_INSERT3_ERROR:
    '    Call SSSWIN_LOGWRT("F_NKSTRA_INSERT3_ERROR")
    '
    'End Function
    ''// V2.00↑ ADD
    '2009/09/18 DEL E.N.D RISE)MIYAJIMA

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_NKSSMA_KSK_Update
    '   概要：  入金消込サマリの入金集計消込金額に対して更新を行う
    '   引数：  pm_strTokcd      : 得意先コード
    '           pm_strUpdid      : 更新項目ID情報
    '           pm_curKesikn     : 消込金額
    '           pm_strSMADT_DSP  : 経理締日付
    '           pm_strSMADT_TBL  : 経理締日付
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_NKSSMA_KSK_Update(ByVal pm_strTokcd As String, ByVal pm_strUpdid As String, ByVal pm_curKesikn As Decimal, ByVal pm_strSMADT_DSP As String, ByVal pm_strSMADT_TBL As String) As Short

        Dim i As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo F_NKSSMA_KSK_Update_ERROR

        F_NKSSMA_KSK_Update = 9

        'サマリ存在チェック
        strSql = ""
        strSql = strSql & "SELECT "
        strSql = strSql & "       TOKCD "
        strSql = strSql & "FROM "
        strSql = strSql & "       NKSSMA "
        strSql = strSql & "WHERE "
        strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
        strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT_DSP) & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''ﾃﾞｰﾀがあるとき
        'If CF_Ora_EOF(Usr_Ody) = False Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            '2019/04/23 CHG E N D

            'UPDATE文を実行する
            strSql = ""
            strSql = strSql & "UPDATE "
            strSql = strSql & "       NKSSMA "
            strSql = strSql & "SET "
            '2009/09/15 UPD START RISE)MIYAJIMA
            ''// V2.01↓ UPD
            '        If pm_strSMADT_DSP <> pm_strSMADT_TBL Then
            '            strSql = strSql & "       SSANYUKN" & pm_strUpdid & " = " & "SSANYUKN" & pm_strUpdid & " + " & (-1) * pm_curKesikn & " "
            '        Else
            '            strSql = strSql & "       KSKNYKKN" & pm_strUpdid & " = " & "KSKNYKKN" & pm_strUpdid & " + " & pm_curKesikn & " "
            '        End If
            ''// V2.01↑ UPD
            strSql = strSql & "       KSKNYKKN" & pm_strUpdid & " = " & "KSKNYKKN" & pm_strUpdid & " + " & pm_curKesikn & " "
            '2009/09/15 UPD E.N.D RISE)MIYAJIMA
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
            strSql = strSql & "INSERT INTO NKSSMA ( "
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
            '2009/09/15 UPD START RISE)MIYAJIMA
            ''// V2.01↓ UPD
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
            ''// V2.01↑ UPD
            strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
            For i = 0 To 9
                'UPGRADE_WARNING: オブジェクト SSSVal(pm_strUpdid) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If i = SSSVal(pm_strUpdid) Then
                    strSql = strSql & pm_curKesikn & ", "
                Else
                    strSql = strSql & "0, "
                End If
            Next i
            '2009/09/15 UPD E.N.D RISE)MIYAJIMA
            strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
            strSql = strSql & "'" & CF_Ora_Sgl(SSS_OPEID.Value) & "',"
            strSql = strSql & "'" & CF_Ora_Sgl(SSS_CLTID.Value) & "',"
            strSql = strSql & "'" & CF_Ora_Sgl(GV_SysTime) & "',"
            strSql = strSql & "'" & CF_Ora_Sgl(GV_SysDate) & "')"
        End If

        '2019/04/23 CHG START
        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

        ''SQL実行
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_NKSSMA_KSK_Update_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_NKSSMA_KSK_Update = 1
        Exit Function

F_NKSSMA_KSK_Update_ERROR:
        Call SSSWIN_LOGWRT("F_NKSSMA_KSK_Update_ERROR")

    End Function
    '// V2.00↑ ADD

    '2009/09/15 DEL START RISE)MIYAJIMA
    ''// V3.20↓ ADD
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function F_NKSSMA_KSK_Update2
    ''   概要：  入金消込サマリの入金集計消込金額に対して更新を行う
    ''   引数：  pm_strTokcd      : 得意先コード
    ''           pm_strUpdid      : 更新項目ID情報
    ''           pm_curKesikn     : 消込金額
    ''           pm_strSMADT_DSP  : 経理締日付
    ''           pm_strSMADT_TBL  : 経理締日付
    ''   戻値：　0 : 正常  1 : 警告  9 : 異常
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function F_NKSSMA_KSK_Update2( _
    ''                                    ByVal pm_strTokcd As String, _
    ''                                    ByVal pm_strUpdid As String, _
    ''                                    ByVal pm_curKesikn As Currency, _
    ''                                    ByVal pm_strSMADT_DSP As String, _
    ''                                    ByVal pm_strSMADT_TBL As String) As Integer
    '
    '    Dim i       As Integer
    '    Dim Usr_Ody As U_Ody
    '    Dim strSql  As String
    '
    'On Error GoTo F_NKSSMA_KSK_Update2_ERROR
    '
    '    F_NKSSMA_KSK_Update2 = 9
    '
    '    'サマリ存在チェック
    '    strSql = ""
    '    strSql = strSql & "SELECT "
    '    strSql = strSql & "       TOKCD "
    '    strSql = strSql & "FROM "
    '    strSql = strSql & "       NKSSMA "
    '    strSql = strSql & "WHERE "
    '    strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
    '    strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT_DSP) & "'"
    '
    '    'DBアクセス
    '    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '
    '    'ﾃﾞｰﾀがあるとき
    '    If CF_Ora_EOF(Usr_Ody) = False Then
    '        'UPDATE文を実行する
    '        strSql = ""
    '        strSql = strSql & "UPDATE "
    '        strSql = strSql & "       NKSSMA "
    '        strSql = strSql & "SET "
    '        strSql = strSql & "       KSKNYKKN" & pm_strUpdid & " = " & "KSKNYKKN" & pm_strUpdid & " - " & pm_curKesikn & " "
    '        strSql = strSql & "      ,OPEID = '" & CF_Ora_Sgl(SSS_OPEID) & "'"
    '        strSql = strSql & "      ,CLTID = '" & CF_Ora_Sgl(SSS_CLTID) & "'"
    '        strSql = strSql & "      ,WRTTM = '" & CF_Ora_Sgl(GV_SysTime) & "'"
    '        strSql = strSql & "      ,WRTDT = '" & CF_Ora_Sgl(GV_SysDate) & "'"
    '        strSql = strSql & "WHERE "
    '        strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
    '        strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT_DSP) & "'"
    '
    '    'ﾃﾞｰﾀが無い時
    '    Else
    '        'INSERT文を実行する
    '        strSql = ""
    '        strSql = strSql & "INSERT INTO NKSSMA ( "
    '        strSql = strSql & " TOKCD "
    '        strSql = strSql & ",SMADT "
    '        strSql = strSql & ",SSANYUKN00 "
    '        strSql = strSql & ",SSANYUKN01 "
    '        strSql = strSql & ",SSANYUKN02 "
    '        strSql = strSql & ",SSANYUKN03 "
    '        strSql = strSql & ",SSANYUKN04 "
    '        strSql = strSql & ",SSANYUKN05 "
    '        strSql = strSql & ",SSANYUKN06 "
    '        strSql = strSql & ",SSANYUKN07 "
    '        strSql = strSql & ",SSANYUKN08 "
    '        strSql = strSql & ",SSANYUKN09 "
    '        strSql = strSql & ",KSKNYKKN00 "
    '        strSql = strSql & ",KSKNYKKN01 "
    '        strSql = strSql & ",KSKNYKKN02 "
    '        strSql = strSql & ",KSKNYKKN03 "
    '        strSql = strSql & ",KSKNYKKN04 "
    '        strSql = strSql & ",KSKNYKKN05 "
    '        strSql = strSql & ",KSKNYKKN06 "
    '        strSql = strSql & ",KSKNYKKN07 "
    '        strSql = strSql & ",KSKNYKKN08 "
    '        strSql = strSql & ",KSKNYKKN09 "
    '        strSql = strSql & ",KSKZANKN00 "
    '        strSql = strSql & ",KSKZANKN01 "
    '        strSql = strSql & ",KSKZANKN02 "
    '        strSql = strSql & ",KSKZANKN03 "
    '        strSql = strSql & ",KSKZANKN04 "
    '        strSql = strSql & ",KSKZANKN05 "
    '        strSql = strSql & ",KSKZANKN06 "
    '        strSql = strSql & ",KSKZANKN07 "
    '        strSql = strSql & ",KSKZANKN08 "
    '        strSql = strSql & ",KSKZANKN09 "
    '        strSql = strSql & ",OPEID "
    '        strSql = strSql & ",CLTID "
    '        strSql = strSql & ",WRTTM "
    '        strSql = strSql & ",WRTDT "
    '        strSql = strSql & ") VALUES ( "
    '        strSql = strSql & "'" & CF_Ora_Sgl(pm_strTokcd) & "', "
    '        strSql = strSql & "'" & CF_Ora_Sgl(pm_strSMADT_DSP) & "',"
    '        strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
    '        For i = 0 To 9
    '            If i = SSSVal(pm_strUpdid) Then
    '                strSql = strSql & (-1) * pm_curKesikn & ", "
    '            Else
    '                strSql = strSql & "0, "
    '            End If
    '        Next i
    '        strSql = strSql & "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "
    '        strSql = strSql & "'" & CF_Ora_Sgl(SSS_OPEID) & "',"
    '        strSql = strSql & "'" & CF_Ora_Sgl(SSS_CLTID) & "',"
    '        strSql = strSql & "'" & CF_Ora_Sgl(GV_SysTime) & "',"
    '        strSql = strSql & "'" & CF_Ora_Sgl(GV_SysDate) & "')"
    '    End If
    '    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '
    '    'SQL実行
    '    If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
    '        GoTo F_NKSSMA_KSK_Update2_ERROR
    '    End If
    '
    '    F_NKSSMA_KSK_Update2 = 1
    '    Exit Function
    '
    'F_NKSSMA_KSK_Update2_ERROR:
    '    Call SSSWIN_LOGWRT("F_NKSSMA_KSK_Update2_ERROR")
    '
    'End Function
    ''// V3.20↑ ADD
    '2009/09/15 DEL E.N.D RISE)MIYAJIMA

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_NKSSMA_SSA_Update
    '   概要：  入金消込サマリの入金集計消込金額に対して更新を行う
    '   引数：  pm_strTokcd  : 得意先コード
    '           pm_strUpdid  : 更新項目ID情報
    '           pm_curKesikn : 消込金額
    '           pm_strSMADT  : 経理締日付
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_NKSSMA_SSA_Update(ByVal pm_strTokcd As String, ByVal pm_strUpdid As String, ByVal pm_curKesikn As Decimal, ByVal pm_strSMADT As String) As Short

        Dim i As Short
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String

        On Error GoTo F_NKSSMA_SSA_Update_ERROR

        F_NKSSMA_SSA_Update = 9

        'サマリ存在チェック
        strSql = ""
        strSql = strSql & "SELECT "
        strSql = strSql & "       TOKCD "
        strSql = strSql & "FROM "
        strSql = strSql & "       NKSSMA "
        strSql = strSql & "WHERE "
        strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokcd) & "'"
        strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(pm_strSMADT) & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''ﾃﾞｰﾀがあるとき
        'If CF_Ora_EOF(Usr_Ody) = False Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt IsNot Nothing OrElse dt.Rows.Count > 0 Then
            '2019/04/23 CHG E N D

            'UPDATE文を実行する
            strSql = ""
            strSql = strSql & "UPDATE "
            strSql = strSql & "       NKSSMA "
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
            strSql = strSql & "INSERT INTO NKSSMA ( "
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

        '2019/04/23 CHG START
        '      Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

        ''SQL実行
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_NKSSMA_SSA_Update_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_NKSSMA_SSA_Update = 0
        Exit Function

F_NKSSMA_SSA_Update_ERROR:
        Call SSSWIN_LOGWRT("F_NKSSMA_SSA_Update_ERROR")

    End Function
    '// V2.00↑ ADD

    '// V2.00↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_NKSSMA_SSA_Update
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
            '2019/04/23 CHG START
            ''UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

            ''ﾃﾞｰﾀがあるとき
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '	' 更新前データと異なるデータが存在した場合はエラーとする。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	If ARY_UDNTRA_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_UDNTRA_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_UDNTRA_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_UDNTRA_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or ARY_UDNTRA_HAITA(i).UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or ARY_UDNTRA_HAITA(i).UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or ARY_UDNTRA_HAITA(i).UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or ARY_UDNTRA_HAITA(i).UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
            '		GoTo Chk_HAITA_UPD_ERROR
            '	End If
            'End If

            'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            Dim dt As DataTable = DB_GetTable(strSql)
            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                ' 更新前データと異なるデータが存在した場合はエラーとする。
                If ARY_UDNTRA_HAITA(i).OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or ARY_UDNTRA_HAITA(i).CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or ARY_UDNTRA_HAITA(i).WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or ARY_UDNTRA_HAITA(i).WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or ARY_UDNTRA_HAITA(i).UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or ARY_UDNTRA_HAITA(i).UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or ARY_UDNTRA_HAITA(i).UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or ARY_UDNTRA_HAITA(i).UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    GoTo Chk_HAITA_UPD_ERROR
                End If
            End If
            '2019/04/23 CHG E N D

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
            '2019/04/23 CHG START
            ''UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

            ''ﾃﾞｰﾀがあるとき
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '	' 更新前データと異なるデータが存在した場合はエラーとする。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	If ARY_JDNTRA_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_JDNTRA_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_JDNTRA_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_JDNTRA_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or ARY_JDNTRA_HAITA(i).UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or ARY_JDNTRA_HAITA(i).UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or ARY_JDNTRA_HAITA(i).UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or ARY_JDNTRA_HAITA(i).UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
            '		GoTo Chk_HAITA_UPD_ERROR
            '	End If
            'End If

            'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

            Dim dt As DataTable = DB_GetTable(strSql)

            If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                If ARY_JDNTRA_HAITA(i).OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or ARY_JDNTRA_HAITA(i).CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or ARY_JDNTRA_HAITA(i).WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or ARY_JDNTRA_HAITA(i).WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or ARY_JDNTRA_HAITA(i).UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or ARY_JDNTRA_HAITA(i).UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or ARY_JDNTRA_HAITA(i).UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or ARY_JDNTRA_HAITA(i).UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    GoTo Chk_HAITA_UPD_ERROR
                End If
            End If
            '2019/04/23 CHG E N D
        Next i

        '入金消込サマリー排他チェック
        For i = 1 To UBound(ARY_NKSSMA_HAITA)
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
            strSql = strSql & "       NKSSMA " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "WHERE " & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(ARY_NKSSMA_HAITA(i).TOKCD) & "'" & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "AND    SMADT = '" & CF_Ora_Sgl(ARY_NKSSMA_HAITA(i).SMADT) & "'" & vbCrLf
            'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            strSql = strSql & "FOR UPDATE " & vbCrLf

            'DBアクセス
            '2019/04/23 CHG START
            ''UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

            ''ﾃﾞｰﾀがあるとき
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '	' 更新前データと異なるデータが存在した場合はエラーとする。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	If ARY_NKSSMA_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_NKSSMA_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_NKSSMA_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_NKSSMA_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Then
            '		GoTo Chk_HAITA_UPD_ERROR
            '	End If
            'End If

            'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            Dim dt As DataTable = DB_GetTable(strSql)

            If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                If ARY_NKSSMA_HAITA(i).OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or ARY_NKSSMA_HAITA(i).CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or ARY_NKSSMA_HAITA(i).WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or ARY_NKSSMA_HAITA(i).WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Then
                    GoTo Chk_HAITA_UPD_ERROR
                End If

            End If
            '2019/04/23 CHG E N D

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
            '2019/04/23 CHG START
            ''UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

            ''ﾃﾞｰﾀがあるとき
            'If CF_Ora_EOF(Usr_Ody) = False Then
            '	' 更新前データと異なるデータが存在した場合はエラーとする。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	If ARY_NKSTRA_HAITA(i).OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or ARY_NKSTRA_HAITA(i).CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or ARY_NKSTRA_HAITA(i).WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or ARY_NKSTRA_HAITA(i).WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or ARY_NKSTRA_HAITA(i).UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or ARY_NKSTRA_HAITA(i).UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or ARY_NKSTRA_HAITA(i).UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or ARY_NKSTRA_HAITA(i).UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
            '		GoTo Chk_HAITA_UPD_ERROR
            '	End If
            'End If

            'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            Dim dt As DataTable = DB_GetTable(strSql)

            If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                If ARY_NKSTRA_HAITA(i).OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or ARY_NKSTRA_HAITA(i).CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or ARY_NKSTRA_HAITA(i).WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or ARY_NKSTRA_HAITA(i).WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or ARY_NKSTRA_HAITA(i).UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or ARY_NKSTRA_HAITA(i).UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or ARY_NKSTRA_HAITA(i).UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or ARY_NKSTRA_HAITA(i).UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    GoTo Chk_HAITA_UPD_ERROR
                End If

            End If
            '2019/04/23 CHG E N D
        Next i

        Chk_HAITA_UPD = True

        Exit Function

Chk_HAITA_UPD_ERROR:

    End Function
    '// V2.00↑ ADD

    '// V2.01↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_TOKSSA_Update
    '   概要：  TOKSSAの更新(無ければ新規に作成する)
    '   引数：  pm_strTokseicd  : 得意先コード
    '           pm_intKesikn : 消込金額
    '           pm_strSSADT  : 締日付
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_TOKSSA_Update(ByRef pm_strTokseicd As String, ByRef pm_intKesikn As Decimal, ByVal pm_strSSADT As String) As Boolean

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String
        Dim strKesdt As String
        Dim strMOT_KSKNYKKN As Decimal
        Dim strMOT_KSKZANKN As Decimal
        Dim strKSKNYKKN As Decimal
        Dim strKSKZANKN As Decimal
        Dim strJKESIKN As Decimal

        On Error GoTo F_TOKSSA_Update_ERROR

        F_TOKSSA_Update = 9

        'サマリ存在チェック
        strSql = ""
        strSql = strSql & "SELECT "
        strSql = strSql & "       KSKNYKKN , KSKZANKN "
        strSql = strSql & "FROM "
        strSql = strSql & "       TOKSSA "
        strSql = strSql & "WHERE "
        strSql = strSql & "       TOKCD = '" & CF_Ora_Sgl(pm_strTokseicd) & "'"
        strSql = strSql & "AND    SSADT = '" & CF_Ora_Sgl(pm_strSSADT) & "'"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        ''ﾃﾞｰﾀがない時
        'If CF_Ora_EOF(Usr_Ody) = True Then
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '2019/04/23 CHG E N D

            '回収予定日取得
            strKesdt = getKesdt(DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDT, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB, DB_TOKMTA2.TOKKESCC, DB_TOKMTA2.TOKKESDD, DB_TOKMTA2.TOKKDWKB, pm_strSSADT)

            '該当データが無い場合はInsert処理
            strSql = ""
            strSql = strSql & " INSERT INTO TOKSSA("
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
            strSql = strSql & "   '" & Space(10) & "'," '伝票管理№
            strSql = strSql & "   '" & Trim(GV_SysTime) & "'," 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            strSql = strSql & "   '" & Trim(GV_SysDate) & "')" 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)

            'SQL実行
            '2019/04/23 CHG START
            'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
            '    GoTo F_TOKSSA_Update_ERROR
            'End If
            DB_Execute(strSql)
            '2019/04/23 CHG E N D

            strMOT_KSKNYKKN = 0 '消込入金額
            strMOT_KSKZANKN = 0 '消込入金額残

        Else
            '2019/04/23 CHG START
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'strMOT_KSKNYKKN = CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN", "") '消込入金額
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'strMOT_KSKZANKN = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN", "") '消込入金額残
            strMOT_KSKNYKKN = DB_NullReplace(dt.Rows(0)("KSKNYKKN"), "") '消込入金額
            strMOT_KSKZANKN = DB_NullReplace(dt.Rows(0)("KSKZANKN"), "") '消込入金額残
        End If

        strJKESIKN = pm_intKesikn

        '請求サマリの消込入金額と消込入金残額の計算を行う
        strKSKNYKKN = strMOT_KSKNYKKN + strJKESIKN
        strKSKZANKN = strMOT_KSKZANKN - strJKESIKN

        '請求サマリの更新
        strSql = ""
        strSql = strSql & "  UPDATE TOKSSA"
        strSql = strSql & "  SET KSKNYKKN =  '" & Trim(CStr(strKSKNYKKN)) & "'"
        strSql = strSql & "  ,   KSKZANKN =  '" & Trim(CStr(strKSKZANKN)) & "'"
        strSql = strSql & ",     WRTTM = '" & Trim(GV_SysTime) & "'"
        strSql = strSql & ",     WRTDT = '" & Trim(GV_SysDate) & "'"

        strSql = strSql & "  WHERE TOKCD   = '" & Trim(pm_strTokseicd) & "'"
        strSql = strSql & "  AND   SSADT   = '" & Trim(pm_strSSADT) & "'"

        'SQL実行
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_TOKSSA_Update_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_TOKSSA_Update = 0
        Exit Function

F_TOKSSA_Update_ERROR:
        Call SSSWIN_LOGWRT("F_TOKSSA_Update_ERROR")

    End Function
    '// V2.00↑ ADD

    '// V2.03↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function getUpdid
    '   概要： 支払区分より入金種別のUPDIDを取得
    '   引数： strSHAKB   : 支払区分
    '   戻値： UPDID
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function getUpdid() As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String
        Dim strDKBID As String

        Dim strRECNO1 As String
        Dim strLINNO1 As String
        Dim strDATNO2 As String
        Dim strLINNO2 As String
        '2019/04/23 ADD START
        Dim dt As DataTable
        '2019/04/23 ADD E N D

        On Error GoTo ERR_GET_UPDID

        getUpdid = ""

        '元黒のデータを入手

        '// V3.40↓ UPD
        '売上トラン
        '    strSql = ""
        '    strSql = strSql & "SELECT "
        '    strSql = strSql & "       RECNO , LINNO "
        '    strSql = strSql & "FROM "
        '    strSql = strSql & "       UDNTRA "
        '    strSql = strSql & "WHERE "
        '    strSql = strSql & "       DKBID = '02' "
        '    strSql = strSql & "AND    DATNO = '" & varSpdValue(COL_UDNDATNO) & "' "
        '    strSql = strSql & "AND    LINNO = '" & varSpdValue(COL_UDNLINNO) & "' "
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
        '// V3.40↑ UPD

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	'ﾃﾞｰﾀがない時
        '	GoTo GET_DEF_DKBID
        'Else
        '	'ﾃﾞｰﾀがある時
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strRECNO1 = CF_Ora_GetDyn(Usr_Ody, "RECNO", "")
        '	'// V3.40↓ UPD
        '	'        strLINNO1 = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strLINNO1 = CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")
        '	'// V3.40↑ UPD
        'End If
        dt = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'ﾃﾞｰﾀがない時
            GoTo GET_DEF_DKBID
        Else
            'ﾃﾞｰﾀがある時
            strRECNO1 = DB_NullReplace(dt.Rows(0)("RECNO"), "")

            strLINNO1 = DB_NullReplace(dt.Rows(0)("JDNLINNO"), "")
        End If
        '2019/04/23 CHG E N D

        '売上トラン
        strSql = ""
        strSql = strSql & "SELECT "
        strSql = strSql & "       DATNO , LINNO "
        strSql = strSql & "FROM "
        strSql = strSql & "       UDNTRA "
        strSql = strSql & "WHERE "
        strSql = strSql & "       DKBID = '01' "
        strSql = strSql & "AND    RECNO = '" & strRECNO1 & "' "
        '// V3.40↓ UPD
        '    strSql = strSql & "AND    LINNO = '" & strLINNO1 & "' "
        strSql = strSql & "AND    JDNLINNO = '" & strLINNO1 & "' "
        '// V3.40↑ UPD

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	'ﾃﾞｰﾀがない時
        '	GoTo GET_DEF_DKBID
        'Else
        '	'ﾃﾞｰﾀがある時
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strDATNO2 = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strLINNO2 = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
        'End If
        dt = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'ﾃﾞｰﾀがない時
            GoTo GET_DEF_DKBID
        Else
            'ﾃﾞｰﾀがある時
            strDATNO2 = DB_NullReplace(dt.Rows(0)("DATNO"), "")

            strLINNO2 = DB_NullReplace(dt.Rows(0)("LINNO"), "")
        End If
        '2019/04/23 CHG E N D

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
        '// V3.60↓ ADD
        '入金消込レコードは消込順序にしたがって作成されるのでKDNNOの降順で取得すれば優先順位の逆の金種が取得できる
        strSql = strSql & "ORDER BY KDNNO DESC "
        '// V3.60↑ ADD

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	'ﾃﾞｰﾀがない時
        '	GoTo GET_DEF_DKBID
        'Else
        '	'ﾃﾞｰﾀがある時
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strDKBID = CF_Ora_GetDyn(Usr_Ody, "DKBID", "")
        'End If
        dt = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'ﾃﾞｰﾀがない時
            GoTo GET_DEF_DKBID
        Else
            'ﾃﾞｰﾀがある時
            strDKBID = DB_NullReplace(dt.Rows(0)("DKBID"), "")

        End If
        '2019/04/23 CHG E N D

        GoTo GET_SYSTBD_UPDID

GET_DEF_DKBID:

        Select Case DB_TOKMTA2.SHAKB
            Case "3"
                strDKBID = "02"
            Case "4"
                strDKBID = "02"
                '2009/09/15 DEL START RISE)MIYAJIMA (重複しているので削除)
                '        Case "5"
                '            strDKBID = "08"
                '2009/09/15 DEL E.N.D RISE)MIYAJIMA
            Case "5"
                strDKBID = "08"
            Case "6"
                strDKBID = "08"
            Case Else
                strDKBID = "02"
        End Select

GET_SYSTBD_UPDID:

        strSql = "SELECT * FROM SYSTBD " & "WHERE DKBSB = '050' " & "AND DKBID = '" & strDKBID & "' "

        'DBアクセス
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	getUpdid = CF_Ora_GetDyn(Usr_Ody, "updid", "")
        'End If
        dt = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then

            getUpdid = DB_NullReplace(dt.Rows(0)("updid"), "")

        End If
        '2019/04/23 CHG E N D

END_GET_UPDID:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function

ERR_GET_UPDID:
        GoTo END_GET_UPDID

    End Function
    '// V2.03↑ ADD

    '2009/09/18 DEL START RISE)MIYAJIMA
    ''// V3.10↓ ADD
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    ''   名称：  Function setNKSTRA
    ''   概要：  入金消込トランの更新と他テーブル更新
    ''   引数：  なし
    ''   戻値：　0 : 正常  1 : 警告  9 : 異常
    ''   備考：
    '' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    'Private Function setNKSTRA() As Boolean
    '
    '    Dim strSql      As String
    '    Dim Usr_Ody     As U_Ody
    '    Dim Usr_Ody_1   As U_Ody
    '
    '    Dim strSMADT_DSP As String      '経理締日付(画面)
    '    Dim strSMADT_TBL As String      '経理締日付(入金消込トラン)
    '    Dim strNYUDT_DSP As String      '請求締め(画面)
    '    Dim strNYUDT_TBL As String      '請求締め(入金消込トラン)
    '
    '    Dim lstrKDNNO   As String       '前回消込伝票番号
    '    Dim intJkesikn  As Currency     '前回消込額
    '    Dim intKesikn   As Currency     '今回消込額
    '
    '    Dim strNYUKB    As String       '2007.03.05
    '    Dim intRet      As Integer
    '
    '    Dim cur_KESIZAN As Currency
    '    Dim cur_KESIKIN As Currency
    '    Dim cur_KIN_WK  As Currency
    '    Dim int_UPDID   As Integer
    '    Dim strUPDID    As String
    '
    '    Dim i           As Integer
    '    Dim j           As Integer
    '
    ''2009/09/15 ADD START RISE)MIYAJIMA
    '    Dim Usr_Ody_Henpin  As U_Ody
    '    Dim cur_HEN_JKESIKN As Currency
    '    Dim str_HEN_TEGDT As String
    '    Dim str_HEN_UPDID As String
    '    Dim str_HEN_DKBID As String
    '    Dim cur_HENKIN As Currency
    '    Dim cur_HEN_KESIKIN As Currency
    ''2009/09/15 ADD E.N.D RISE)MIYAJIMA
    '
    '    setNKSTRA = False
    '
    '    '経理締め
    '    strSMADT_DSP = DeCNV_DATE(Get_Acedt(gstrKesidt))                            '経理締日付(画面)
    '
    '    '請求締め
    '    strNYUDT_DSP = getSmedt(gstrKesidt, _
    ''                        DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, _
    ''                        DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB)                 '請求締め(画面)
    '
    '    '今回消込額を格納(消込金額－消込金額(締日前))
    '    intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))
    '
    ''-------------------------------------------------------------------------------------------
    '
    '    '変更前消込金額(絶対値)が消込金額(絶対値)より大きい時は元NKSTRAを更新する　→派生してJDNTRA,UDNTRA,TOKSSA,TOKSMAの更新
    '    If Abs(SSSVal(varSpdValue(COL_KESIKN))) < Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
    '
    '        '削除対象のNKSTRAデータを取得(NKSTRA一明細ごとにサマリの戻しを行う必要があるため)
    '        strSql = ""
    '        strSql = strSql & "SELECT " & vbCrLf
    '        strSql = strSql & "       * " & vbCrLf
    '        strSql = strSql & "FROM " & vbCrLf
    '        strSql = strSql & "       NKSTRA " & vbCrLf
    '        strSql = strSql & "WHERE " & vbCrLf
    '        strSql = strSql & "       UDNDATNO = '" & varSpdValue(COL_UDNDATNO) & "' " & vbCrLf
    '        strSql = strSql & "AND    UDNLINNO = '" & varSpdValue(COL_UDNLINNO) & "' " & vbCrLf
    '        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
    '        strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
    '
    '        'DBアクセス
    '        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    '
    '        Do While CF_Ora_EOF(Usr_Ody) = False
    '
    '            '取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
    '            strSql = ""
    '            strSql = strSql & "SELECT " & vbCrLf
    '            strSql = strSql & "       * " & vbCrLf
    '            strSql = strSql & "FROM " & vbCrLf
    '            strSql = strSql & "       NKSTRA " & vbCrLf
    '            strSql = strSql & "WHERE " & vbCrLf
    '            strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf
    '
    '            'DBアクセス
    '            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
    '
    '            If CF_Ora_EOF(Usr_Ody_1) Then
    '
    '                '消込伝票番号
    '                lstrKDNNO = CF_Ora_GetDyn(Usr_Ody, "KDNNO", "")
    '
    '                '消込金額
    '                intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JKESIKN", ""))
    '
    '                '経理締め
    '                strSMADT_TBL = DeCNV_DATE(Get_Acedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", "")))   '経理締日付(入金消込トラン)
    '
    '                '請求締め
    '                strNYUDT_TBL = getSmedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""), _
    ''                                    DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, _
    ''                                    DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB)                 '請求締め(入金消込トラン)
    '
    '                '★NKSTRA更新・追加
    '                If strSMADT_DSP = strSMADT_TBL Then
    '                    ' 画面消込月度とテーブルの消込月度が同一の場合
    '                    If F_NKSTRA_UPDATE1(lstrKDNNO) = 9 Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '                Else
    '                    ' 画面消込月度とテーブルの消込月度が異なる場合
    '                    If F_NKSTRA_INSERT1(Usr_Ody, strSMADT_DSP, lstrKDNNO) = 9 Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '                End If
    '
    '                '★TOKSSA更新(DATKB=9よりマイナス更新する)
    '                If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, strNYUDT_DSP) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody_1)                             'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Call CF_Ora_CloseDyn(Usr_Ody)                               'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    '                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    '                Else
    '                    '★TOKSMA更新(DATKB=9よりマイナス更新する)
    '                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", (-1) * intJkesikn, strSMADT_DSP) = False Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '                End If
    '
    '                '★UDNTRA更新(DATKB=9よりマイナス更新する)
    '                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn) = False Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody_1)                             'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Call CF_Ora_CloseDyn(Usr_Ody)                               'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★JDNTRA更新(DATKB=9よりマイナス更新する)
    '                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn) = False Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody_1)                             'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Call CF_Ora_CloseDyn(Usr_Ody)                               'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★入金消込サマリ更新（入金消し込み集計金額）
    '                strUPDID = CF_Ora_GetDyn(Usr_Ody, "UPDID", "")
    '                If strSMADT_DSP <> strSMADT_TBL Then
    '                    '前月解除の場合、06：手数 と 99：消費 は、01:現金とする
    '                    If SSSVal(strUPDID) = 5 Or SSSVal(strUPDID) = 9 Then
    '                        strUPDID = "00" '01:現金
    '                    End If
    '                End If
    '
    ''// V3.20↓ ADD
    '                '★期日到来している消し込みを解除した場合は現金化する。(08：振込仮）
    '                If SSSVal(strUPDID) = 7 Then
    '                    If Trim(varSpdValue(COL_BFHYFRIDT)) <> "" Then
    '                        If CNV_DATE(gstrUnydt) > varSpdValue(COL_BFHYFRIDT) Then
    '                            strUPDID = "00" '01:現金
    '                        End If
    '                    End If
    '                End If
    ''2009/09/15 DEL START RISE)MIYAJIMA
    ''                '★本入金消し込みを解除した場合は消し込み金額を減算する。
    ''                If F_NKSSMA_KSK_Update2(DB_TOKMTA2.TOKSEICD _
    '''                                     , "08" _
    '''                                     , intJkesikn _
    '''                                     , strSMADT_DSP _
    '''                                     , strSMADT_TBL) = 9 Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''2009/09/15 DEL E.N.D RISE)MIYAJIMA
    ''// V3.20↑ ADD
    '
    '                If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD _
    ''                                     , strUPDID _
    ''                                     , (-1) * intJkesikn _
    ''                                     , strSMADT_DSP _
    ''                                     , strSMADT_TBL) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody_1)                         'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    ''// V3.50↓ DEL
    ''                '消込金額戻し
    ''                ARY_NKSSMA_KS(SSSVal(strUPDID)).ZAN_KIN = _
    '''                        ARY_NKSSMA_KS(SSSVal(strUPDID)).ZAN_KIN + intJkesikn
    ''// V3.50↑ DEL
    '            End If
    '
    '            Call CF_Ora_CloseDyn(Usr_Ody_1)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '            Usr_Ody.Obj_Ody.MoveNext
    '
    '        Loop
    '
    '        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '
    '        '前回消込金額を0とする
    '        varSpdValue(COL_AFKESIKN) = 0
    '    End If
    '
    ''-------------------------------------------------------------------------------------------
    '
    '    '締日以降消込金額(絶対値)が消込金額(絶対値)より小きい時は差額を新規に作成
    '    If Abs(SSSVal(varSpdValue(COL_KESIKN))) > Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
    '        intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))
    '
    ''2009/09/15 ADD START RISE)MIYAJIMA
    '        Dim curHenpiKin As Currency
    '        curHenpiKin = GET_HENPINKIN(varSpdValue(COL_NO), varSpdValue(COL_HYJDNNO))
    '
    '        '消し込み金額取得
    '        cur_KIN_WK = intKesikn + curHenpiKin
    '
    '        If cur_KIN_WK > 0 Then
    '
    '            '●●●●●通常消し込み●●●●●
    '
    '            Do
    '                '消込可能金額取得
    '                If Get_KESIKIN(cur_KIN_WK, cur_KESIKIN, cur_KESIZAN, int_UPDID) = False Then
    '                    Exit Do
    '                End If
    '                '消込残金額
    '                cur_KIN_WK = cur_KESIZAN
    '
    '                strNYUKB = GET_NYUKB(ARY_NKSSMA_KS(int_UPDID).DATKB)
    '                '取引区分="03"(手形) or "08"(振込仮) で
    '                '期日振込日が入力されているデータを入金区分=2で設定する。
    '                'それ以外は１を設定する。
    '                With ARY_NKSSMA_KS(int_UPDID)
    '                    If .DATKB = "03" Or .DATKB = "08" Then
    '                        If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    '                            strNYUKB = "2"
    '                        End If
    '                    End If
    '                End With
    '
    '                '★NKSTRA追加
    '                If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★TOKSSA更新
    '                If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    '                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    '                Else
    '                    '★TOKSMA更新
    '                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '                End If
    '
    '                '★UDNTRA更新
    '                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★JDNTRA更新
    '                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★入金消込サマリ更新（入金消し込み集計金額）
    '                If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, ARY_NKSSMA_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                If cur_KIN_WK = 0 Then
    '                    Exit Do
    '                End If
    '            Loop
    '
    '            '★★（返品用黒作成）★★
    '
    '            If curHenpiKin <> 0 Then
    '
    '                cur_KESIKIN = curHenpiKin * -1
    '
    '                'ここで返品時のUPDIDを入手
    '                int_UPDID = getUpdid
    '
    '                strNYUKB = GET_NYUKB(ARY_NKSSMA_KS(int_UPDID).DATKB)
    '                '取引区分="03"(手形) or "08"(振込仮) で
    '                '期日振込日が入力されているデータを入金区分=2で設定する。
    '                'それ以外は１を設定する。
    '                With ARY_NKSSMA_KS(int_UPDID)
    '                    If .DATKB = "03" Or .DATKB = "08" Then
    '                        If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    '                            strNYUKB = "2"
    '                        End If
    '                    End If
    '                End With
    '
    '                '★NKSTRA追加
    '                If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★TOKSSA更新
    '                If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    '                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    '                Else
    '                    '★TOKSMA更新
    '                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '                End If
    '
    '                '★UDNTRA更新
    '                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★JDNTRA更新
    '                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '                '★入金消込サマリ更新（入金消し込み集計金額）
    '                If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, ARY_NKSSMA_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    '                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                    Exit Function
    '                End If
    '
    '            End If
    '
    '        End If
    '
    '        '●●●●●返品時消し込み●●●●●
    '
    '        If varSpdValue(COL_HENPI) = "1" And SSSVal(varSpdValue(COL_KESIKN)) < 0 Then
    '
    '            cur_KESIKIN = intKesikn
    '            cur_HENKIN = cur_KESIKIN
    '
    '            If GetMotoKesikomiData(Usr_Ody_Henpin) Then
    '
    '                Do Until CF_Ora_EOF(Usr_Ody_Henpin)
    '                    cur_HEN_JKESIKN = CF_Ora_GetDyn(Usr_Ody_Henpin, "JKESIKN", "")
    '                    str_HEN_TEGDT = CF_Ora_GetDyn(Usr_Ody_Henpin, "TEGDT", "")
    '                    str_HEN_UPDID = CF_Ora_GetDyn(Usr_Ody_Henpin, "UPDID", "")
    '                    str_HEN_DKBID = CF_Ora_GetDyn(Usr_Ody_Henpin, "DKBID", "")
    '
    '                    If cur_HENKIN + cur_HEN_JKESIKN >= 0 Then
    '                        cur_HEN_KESIKIN = cur_HENKIN
    '                        cur_HENKIN = 0
    '                    Else
    '                        cur_HEN_KESIKIN = cur_HEN_JKESIKN * -1
    '                        cur_HENKIN = cur_HENKIN + cur_HEN_JKESIKN
    '                    End If
    '
    '                    strNYUKB = GET_NYUKB(str_HEN_DKBID)
    '                    strUPDID = str_HEN_UPDID
    '
    '                    '★期日到来している消し込みを解除した場合は現金化する。(08：振込仮）
    '                    If SSSVal(str_HEN_UPDID) = 7 Then
    '                        If Trim(str_HEN_TEGDT) <> "" Then
    '                            If CNV_DATE(gstrUnydt) > CNV_DATE(str_HEN_TEGDT) Then
    '                                strNYUKB = "1"
    '                                strUPDID = "00" '01:現金
    '                            End If
    '                        End If
    '                    End If
    '
    '                    '★NKSTRA追加
    '                    If F_NKSTRA_INSERT4(cur_HEN_KESIKIN, strSMADT_DSP, strNYUKB, SSSVal(str_HEN_UPDID), str_HEN_TEGDT) = 9 Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '
    '                    '★TOKSSA更新
    '                    If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_HEN_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '
    '                    'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    '                    If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    '                    Else
    '                        '★TOKSMA更新
    '                        If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_HEN_KESIKIN, strSMADT_DSP) = False Then
    '                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                            Exit Function
    '                        End If
    '                    End If
    '
    '                    '★UDNTRA更新
    '                    If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_HEN_KESIKIN) = False Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '
    '                    '★JDNTRA更新
    '                    If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_HEN_KESIKIN) = False Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '
    '                    '★入金消込サマリ更新（入金消し込み集計金額）
    '                    If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, strUPDID, cur_HEN_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    '                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '                        Exit Function
    '                    End If
    '
    '                    If cur_HENKIN >= 0 Then
    '                        Exit Do
    '                    End If
    '
    '                    Usr_Ody_Henpin.Obj_Ody.MoveNext
    '
    '                Loop
    '            End If
    '        End If
    ''2009/09/15 ADD E.N.D RISE)MIYAJIMA
    ''2009/09/15 DEL START RISE)MIYAJIMA
    ''        '消し込み金額取得
    ''        cur_KIN_WK = intKesikn
    ''
    '''// V3.20↓ DEL
    '''        '取引区分="03"(手形) or "08"(振込仮) で
    '''        '期日振込日が入力されているデータを入金区分=2で設定する。
    '''        'それ以外は１を設定する。
    '''        strNYUKB = "1"
    '''        With ARY_NKSSMA_KS(int_UPDID)
    '''            If .DATKB = "03" Or .DATKB = "08" Then
    '''                If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    '''                    strNYUKB = "2"
    '''                End If
    '''            End If
    '''        End With
    '''// V3.20↑ DEL
    ''
    ''
    '''2009/09/15 UPD START RISE)MIYAJIMA
    ''''// V3.60↓ UPD
    ''''''// V3.50↓ UPD
    ''''''        If varSpdValue(COL_HENPI) = "1" And _
    '''''''            SSSVal(varSpdValue(COL_KESIKN)) = SSSVal(varSpdValue(COL_KOMIKN)) Then
    '''''        If varSpdValue(COL_HENPI) = "1" And _
    ''''''            SSSVal(varSpdValue(COL_KESIKN)) <= SSSVal(varSpdValue(COL_KOMIKN)) Then
    ''''2009/09/08 UPD START RISE)MIYAJIMA
    ''''        If varSpdValue(COL_HENPI) = "1" And _
    '''''            SSSVal(varSpdValue(COL_KESIKN)) <= SSSVal(varSpdValue(COL_KOMIKN)) And _
    '''''                SSSVal(varSpdValue(COL_KESIKN)) < 0 Then
    '''        If varSpdValue(COL_HENPI) = "1" Then
    ''''2009/09/08 UPD E.N.D RISE)MIYAJIMA
    ''''// V3.50↑ UPD
    ''''// V3.60↑ UPD
    ''        If varSpdValue(COL_HENPI) = "1" And SSSVal(varSpdValue(COL_KESIKN)) <= SSSVal(varSpdValue(COL_KOMIKN)) _
    '''        Or varSpdValue(COL_HENPI) = "1" And SSSVal(varSpdValue(COL_KESIKN)) < 0 Then
    '''2009/09/15 UPD E.N.D RISE)MIYAJIMA
    ''
    ''            '●●●●●返品時消し込み●●●●●
    ''
    ''            cur_KESIKIN = cur_KIN_WK
    ''
    ''            'ここで返品時のUPDIDを入手
    ''            int_UPDID = getUpdid
    ''
    '''2009/09/15 UPD START RISE)MIYAJIMA
    ''''// V3.20↓ ADD
    '''            '取引区分="03"(手形) or "08"(振込仮) で
    '''            '期日振込日が入力されているデータを入金区分=2で設定する。
    '''            'それ以外は１を設定する。
    '''            strNYUKB = "1"
    '''            With ARY_NKSSMA_KS(int_UPDID)
    '''                If .DATKB = "03" Or .DATKB = "08" Then
    '''                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    '''                        strNYUKB = "2"
    '''                    End If
    '''                End If
    '''            End With
    ''''// V3.20↑ ADD
    ''            strNYUKB = GET_NYUKB(ARY_NKSSMA_KS(int_UPDID).DATKB)
    ''            '取引区分="03"(手形) or "08"(振込仮) で
    ''            '期日振込日が入力されているデータを入金区分=2で設定する。
    ''            'それ以外は１を設定する。
    ''            With ARY_NKSSMA_KS(int_UPDID)
    ''                If .DATKB = "03" Or .DATKB = "08" Then
    ''                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    ''                        strNYUKB = "2"
    ''                    End If
    ''                End If
    ''            End With
    '''2009/09/15 UPD E.N.D RISE)MIYAJIMA
    ''
    ''            '★NKSTRA追加
    ''            If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
    ''                Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                Exit Function
    ''            End If
    ''
    ''            '★TOKSSA更新
    ''            If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    ''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                Exit Function
    ''            End If
    ''
    ''            'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''            If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''            Else
    ''                '★TOKSMA更新
    ''                If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''            End If
    ''
    ''            '★UDNTRA更新
    ''            If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
    ''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                Exit Function
    ''            End If
    ''
    ''            '★JDNTRA更新
    ''            If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
    ''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                Exit Function
    ''            End If
    ''
    '''2009/09/15 DEL START RISE)MIYAJIMA
    '''            '★入金消込サマリ更新（入金消し込み集計金額）
    '''            If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, ARY_NKSSMA_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    '''                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    '''                Exit Function
    '''            End If
    '''2009/09/15 DEL E.N.D RISE)MIYAJIMA
    ''
    ''        Else
    ''
    ''            '●●●●●通常消し込み●●●●●
    ''
    ''            Do
    ''                '消込可能金額取得
    ''                If Get_KESIKIN(cur_KIN_WK, cur_KESIKIN, cur_KESIZAN, int_UPDID) = False Then
    ''                    Exit Do
    ''                End If
    ''                '消込残金額
    ''                cur_KIN_WK = cur_KESIZAN
    ''
    '''2009/09/15 UPD START RISE)MIYAJIMA
    '''                '取引区分="03"(手形) or "08"(振込仮) で
    '''                '期日振込日が入力されているデータを入金区分=2で設定する。
    '''                'それ以外は１を設定する。
    '''                strNYUKB = "1"
    '''                With ARY_NKSSMA_KS(int_UPDID)
    '''                    If .DATKB = "03" Or .DATKB = "08" Then
    '''                        If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    '''                            strNYUKB = "2"
    '''                        End If
    '''                    End If
    '''                End With
    ''                strNYUKB = GET_NYUKB(ARY_NKSSMA_KS(int_UPDID).DATKB)
    ''                '取引区分="03"(手形) or "08"(振込仮) で
    ''                '期日振込日が入力されているデータを入金区分=2で設定する。
    ''                'それ以外は１を設定する。
    ''                With ARY_NKSSMA_KS(int_UPDID)
    ''                    If .DATKB = "03" Or .DATKB = "08" Then
    ''                        If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
    ''                            strNYUKB = "2"
    ''                        End If
    ''                    End If
    ''                End With
    '''2009/09/15 UPD E.N.D RISE)MIYAJIMA
    ''
    ''                '★NKSTRA追加
    ''                If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)                           'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                '★TOKSSA更新
    ''                If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外のときのみ
    ''                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
    ''                Else
    ''                    '★TOKSMA更新
    ''                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
    ''                        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                        Exit Function
    ''                    End If
    ''                End If
    ''
    ''                '★UDNTRA更新
    ''                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                '★JDNTRA更新
    ''                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN) = False Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                '★入金消込サマリ更新（入金消し込み集計金額）
    ''                If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, ARY_NKSSMA_KS(int_UPDID).UPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
    ''                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    ''                    Exit Function
    ''                End If
    ''
    ''                If cur_KIN_WK = 0 Then
    ''                    Exit Do
    ''                End If
    ''            Loop
    ''
    ''        End If
    ''2009/09/15 DEL E.N.D RISE)MIYAJIMA
    '    End If
    '
    '    setNKSTRA = True
    '    Exit Function
    '
    'SETNKSTRA_ERROR:
    '    Call SSSWIN_LOGWRT("SETNKSTRA_ERROR")
    '
    'End Function
    ''// V3.10↑ ADD
    '2009/09/18 DEL E.N.D RISE)MIYAJIMA

    '// V3.10↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function setNKSTRA
    '   概要：  消込可能金額取得
    '   引数：  pcur_KESIKIN      : 消込金額
    '           pcur_KESIKOMIKIN  : 消込した金額
    '           pcur_KESIKOMIZAN  : 消込したができなかった残金額
    '           pint_KESIKOMIID   : 更新項目ID情報
    '   戻値：　true : 正常  false : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Function Get_KESIKIN(ByVal pcur_KESIKIN As Decimal, ByRef pcur_KESIKOMIKIN As Decimal, ByRef pcur_KESIKOMIZAN As Decimal, ByRef pint_KESIKOMIID As Short) As Boolean

        Get_KESIKIN = False

        Dim i As Short
        Dim j As Short

        Dim BlnEndLoop As Boolean

        Dim intKESI_SEQ As Short
        Dim cur_KESIKIN As Decimal
        Dim cur_KESIZAN As Decimal
        Dim int_KESIID As Short


        BlnEndLoop = False

        '消込順序で消込む
        For i = 1 To 20
            '対象消込順の設定
            intKESI_SEQ = i

            '消込金種のループ
            For j = 0 To 9
                '対象消込順であるか確認する
                If ARY_NKSSMA_KS(j).SEQ = intKESI_SEQ Then
                    'その金種で消込可能かの判断を行う
                    If ARY_NKSSMA_KS(j).ZAN_KIN > 0 Then

                        '消込処理
                        If ARY_NKSSMA_KS(j).ZAN_KIN - pcur_KESIKIN >= 0 Then
                            '消込んだ金額を設定
                            cur_KESIKIN = pcur_KESIKIN
                            '消込できなかった金額を設定
                            cur_KESIZAN = 0
                            '消込んだ金額を考慮にいれて残額を反映する
                            ARY_NKSSMA_KS(j).ZAN_KIN = ARY_NKSSMA_KS(j).ZAN_KIN - pcur_KESIKIN
                            '更新IDを設定
                            int_KESIID = j
                            'ループ終了
                            BlnEndLoop = True
                        Else
                            '消込んだ金額を設定
                            cur_KESIKIN = ARY_NKSSMA_KS(j).ZAN_KIN
                            '消込できなかった金額を設定
                            cur_KESIZAN = pcur_KESIKIN - ARY_NKSSMA_KS(j).ZAN_KIN
                            '消込んだ金額を考慮にいれて残額を反映する
                            ARY_NKSSMA_KS(j).ZAN_KIN = 0
                            '更新IDを設定
                            int_KESIID = j
                            'ループ終了
                            BlnEndLoop = True
                        End If

                    End If
                End If
                '終了フラグがTRUEの場合は終わる
                If BlnEndLoop = True Then
                    Exit For
                End If
            Next j
            '終了フラグがTRUEの場合は終わる
            If BlnEndLoop = True Then
                Exit For
            End If
        Next i

        '計算結果の反映
        pcur_KESIKOMIKIN = cur_KESIKIN
        pcur_KESIKOMIZAN = cur_KESIZAN
        pint_KESIKOMIID = int_KESIID

        Get_KESIKIN = True

    End Function
    '// V3.10↑ ADD

    '// V3.50↓ ADD
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function sPreparationSetNKSTRA
    '   概要：  入金消込更新の準備処理（消込金額配列戻し）
    '   引数：  なし
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/19 CHG START
    'Public Function sPreparationSetNKSTRA(ByRef spd_body As vaSpread) As Short
    Public Function sPreparationSetNKSTRA(ByRef spd_body As Object) As Short
        '2019/04/19 CHG E N D
        Dim strSql As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        'UPGRADE_WARNING: 構造体 Usr_Ody_1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody_1 As U_Ody

        Dim i As Integer
        Dim j As Integer

        Dim intJkesikn As Decimal '前回消込額
        Dim strUPDID As String
        Dim strSMADT_DSP As String '経理締日付(画面)
        Dim strSMADT_TBL As String '経理締日付(入金消込トラン)
        Dim strNYUDT_DSP As String '請求締め(画面)
        Dim strNYUDT_TBL As String '請求締め(入金消込トラン)
        '2009/09/15 UPD START RISE)MIYAJIMA
        '    Dim vntWK_SpdValue(COL_HENPI)   As Variant
        Dim vntWK_SpdValue(COL_SSADT) As Object
        '2009/09/15 UPD E.N.D RISE)MIYAJIMA
        '2009/09/18 ADD START RISE)MIYAJIMA
        Dim strTEGDT As String
        '2009/09/18 ADD E.N.D RISE)MIYAJIMA

        '2009/11/25 ADD START RISE)MIYAJIMA
        Dim strDKBID As String
        Dim strNYUKB As String
        '2009/11/25 ADD E.N.D RISE)MIYAJIMA

        '2019/04/17 ADD START
        Dim dt As DataTable
        '2019/04/17 ADD EN D

        sPreparationSetNKSTRA = -1

        '経理締め
        strSMADT_DSP = DeCNV_DATE(Get_Acedt(gstrKesidt.Value)) '経理締日付(画面)

        '請求締め
        strNYUDT_DSP = getSmedt(gstrKesidt.Value, DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB) '請求締め(画面)

        '入金消込用配列に消込解除分の金額を加算する
        With spd_body
            'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/25 CHG START
            'For i = 1 To .MaxRows
            For i = 0 To .Rows.Count - 1
                '2019/04/25 CHG E N D
                '2009/09/15 UPD START RISE)MIYAJIMA
                'スプレッドの値を変数に格納
                '            For j = COL_CHK To COL_HENPI
                For j = COL_CHK To COL_SSADT
                    '2009/09/15 UPD E.N.D RISE)MIYAJIMA

                    '2019/04/25 CHG START
                    ''UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Row = i
                    ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Col = j
                    ''UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'If .Col = COL_HYFRIDT Then
                    '    '振込期日が空白の時は、space(8)をセット
                    '    'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    If .Text = "" Then
                    '        'UPGRADE_WARNING: オブジェクト vntWK_SpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        vntWK_SpdValue(j) = Space(8)
                    '    Else
                    '        'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        'UPGRADE_WARNING: オブジェクト vntWK_SpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '        vntWK_SpdValue(j) = DeCNV_DATE(.Text)
                    '    End If
                    'Else
                    '    'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    'UPGRADE_WARNING: オブジェクト vntWK_SpdValue(j) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '    vntWK_SpdValue(j) = .Text
                    'End If
                    If j = COL_HYFRIDT Then
                        '振込期日が空白の時は、space(8)をセット
                        If .GetValue(i, j) = "" Then
                            varSpdValue(j) = Space(8)
                        Else
                            varSpdValue(j) = DeCNV_DATE(.GetValue(i, j))
                        End If
                    Else
                        varSpdValue(j) = .GetValue(i, j)
                    End If
                    '2019/04/25 CHG E N D
                Next j

                'UPGRADE_WARNING: オブジェクト vntWK_SpdValue(COL_NO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If vntWK_SpdValue(COL_NO) = "" Then
                    Exit For
                End If

                '消込解除されているか判断する
                'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If System.Math.Abs(SSSVal(vntWK_SpdValue(COL_KESIKN))) < System.Math.Abs(SSSVal(vntWK_SpdValue(COL_KESIKN_MAE))) Then

                    'DBアクセス
                    strSql = ""
                    strSql = strSql & "SELECT " & vbCrLf
                    strSql = strSql & "       * " & vbCrLf
                    strSql = strSql & "FROM " & vbCrLf
                    strSql = strSql & "       NKSTRA " & vbCrLf
                    strSql = strSql & "WHERE " & vbCrLf
                    'UPGRADE_WARNING: オブジェクト vntWK_SpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strSql = strSql & "       UDNDATNO = '" & vntWK_SpdValue(COL_UDNDATNO) & "' " & vbCrLf
                    'UPGRADE_WARNING: オブジェクト vntWK_SpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strSql = strSql & "AND    UDNLINNO = '" & vntWK_SpdValue(COL_UDNLINNO) & "' " & vbCrLf
                    strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
                    strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf

                    '2019/04/17 CHG START
                    'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

                    'Do While CF_Ora_EOF(Usr_Ody) = False

                    dt = DB_GetTable(strSql)
                    For cnt As Integer = 0 To dt.Rows.Count - 1
                        '2019/04/17 CHG E N D

                        '取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
                        strSql = ""
                        strSql = strSql & "SELECT " & vbCrLf
                        strSql = strSql & "       * " & vbCrLf
                        strSql = strSql & "FROM " & vbCrLf
                        strSql = strSql & "       NKSTRA " & vbCrLf
                        strSql = strSql & "WHERE " & vbCrLf
                        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/17 CHG START
                        'strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf
                        strSql = strSql & "       MOTKDNNO = '" & DB_NullReplace(dt.Rows(cnt)("kdnno"), "") & "' " & vbCrLf
                        '2019/04/17 CHG E N D

                        'DBアクセス
                        '2019/04/17 CHG START
                        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)

                        'If CF_Ora_EOF(Usr_Ody_1) Then

                        '    '消込金額
                        '    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '    intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JKESIKN", ""))
                        '    '経理締め
                        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '    strSMADT_TBL = DeCNV_DATE(Get_Acedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""))) '経理締日付(入金消込トラン)
                        '    '請求締め
                        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '    strNYUDT_TBL = getSmedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""), DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB) '請求締め(入金消込トラン)

                        '    '2009/11/25 UPD START RISE)MIYAJIMA
                        '    '更新IDと入金種別を取得
                        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '    strUPDID = CF_Ora_GetDyn(Usr_Ody, "UPDID", "")
                        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '    strNYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
                        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '    strDKBID = CF_Ora_GetDyn(Usr_Ody, "DKBID", "")
                        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '    strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")

                        dt = DB_GetTable(strSql)

                        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then

                            '消込金額
                            intJkesikn = SSSVal(DB_NullReplace(dt.Rows(cnt)("JKESIKN"), ""))
                            '経理締め
                            strSMADT_TBL = DeCNV_DATE(Get_Acedt(DB_NullReplace(dt.Rows(cnt)("NYUDT"), ""))) '経理締日付(入金消込トラン)
                            '請求締め
                            strNYUDT_TBL = getSmedt(DB_NullReplace(dt.Rows(cnt)("NYUDT"), ""), DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB) '請求締め(入金消込トラン)

                            '更新IDと入金種別を取得
                            strUPDID = DB_NullReplace(dt.Rows(cnt)("UPDID"), "")
                            strNYUKB = DB_NullReplace(dt.Rows(cnt)("NYUKB"), "")
                            strDKBID = DB_NullReplace(dt.Rows(cnt)("DKBID"), "")
                            strTEGDT = DB_NullReplace(dt.Rows(cnt)("TEGDT"), "")
                            '2019/04/17 CHG E N D

                            '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、
                            If strNYUKB = "2" Or strNYUKB = "3" Then
                                If Trim(strTEGDT) <> "" Then
                                    '2010/03/17 CHG START RISE)MIYAJIMA
                                    '                                If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt) Then
                                    '                                    strUPDID = "00" '01:現金
                                    '                                End If
                                    If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
                                        '''' UPD 2010/03/19  FKS) T.Yamamoto    Start
                                        '                                    If Mid(strSMADT_DSP, 1, 6) > Mid(strTEGDT, 1, 6) Then
                                        If strSMADT_DSP <> strSMADT_TBL Then
                                            '''' UPD 2010/03/19  FKS) T.Yamamoto    End
                                            strUPDID = "00" '01:現金
                                        End If
                                    End If
                                    '2010/03/17 CHG E.N.D RISE)MIYAJIMA
                                End If
                            End If

                            '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
                            If strDKBID = "03" Then
                                If Trim(strTEGDT) <> "" Then
                                    '2010/03/17 CHG START RISE)MIYAJIMA
                                    '                                If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt) Then
                                    '                                    strUPDID = "00" '01:現金
                                    '                                End If
                                    If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
                                        '''' UPD 2010/03/19  FKS) T.Yamamoto    Start
                                        '                                    If Mid(strSMADT_DSP, 1, 6) > Mid(strTEGDT, 1, 6) Then
                                        If strSMADT_DSP <> strSMADT_TBL Then
                                            '''' UPD 2010/03/19  FKS) T.Yamamoto    End
                                            strUPDID = "00" '01:現金
                                        End If
                                    End If
                                    '2010/03/17 CHG E.N.D RISE)MIYAJIMA
                                End If
                            End If

                            ''2009/09/18 UPD START RISE)MIYAJIMA
                            '                        '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、
                            '                        If Trim(strTEGDT) <> "" Then
                            '                            If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt) Then
                            '                                strUPDID = "00" '01:現金
                            '                            End If
                            '                        End If
                            ''                        'どこに戻すか判定する
                            ''                        strUPDID = CF_Ora_GetDyn(Usr_Ody, "UPDID", "")
                            ''                        If strSMADT_DSP <> strSMADT_TBL Then
                            ''                            '前月解除の場合、06：手数 と 99：消費 は、01:現金とする
                            ''                            If SSSVal(strUPDID) = 5 Or SSSVal(strUPDID) = 9 Then
                            ''                                strUPDID = "00" '01:現金
                            ''                            End If
                            ''                        End If
                            ''2009/09/18 UPD E.N.D RISE)MIYAJIMA
                            '2009/11/25 UPD E.N.D RISE)MIYAJIMA


                            '消込金額戻し
                            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            ARY_NKSSMA_KS(SSSVal(strUPDID)).ZAN_KIN = ARY_NKSSMA_KS(SSSVal(strUPDID)).ZAN_KIN + intJkesikn

                        End If

                        '2019/04/17 CHG START
                        'Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        ''UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'Usr_Ody.Obj_Ody.MoveNext()

                        ''Loop
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                    Next
                    '2019/04/17 CHG E N D
                End If
            Next i
        End With

        sPreparationSetNKSTRA = 0

    End Function
    '// V3.50↑ ADD

    '2009/09/15 ADD START RISE)MIYAJIMA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function GET_DKBIDtoNYUKB
    '   概要：  入金種別取得
    '   引数：  なし
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function GET_DKBIDtoNYUKB(ByRef strDKBID As String) As String

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String
        Dim strNYUKB As String
        Dim strDFLDKBCD As String

        On Error GoTo ERR_GET_DKBIDtoNYUKB

        strNYUKB = ""
        strDFLDKBCD = ""

        strSql = "SELECT DFLDKBCD FROM systbd " & "WHERE dkbsb = '050' " & "AND dkbid = '" & strDKBID & "' "

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strDFLDKBCD = CF_Ora_GetDyn(Usr_Ody, "DFLDKBCD", "")
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strDFLDKBCD = DB_NullReplace(dt.Rows(0)("DFLDKBCD"), "")
        End If
        '2019/04/23 CHG E N D

END_GET_DKBIDtoNYUKB:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        '入金種別
        Select Case Trim(strDFLDKBCD)
            Case "3" : strNYUKB = "4"
            Case "2" : strNYUKB = "2"
            Case Else : strNYUKB = "1"
        End Select

        GET_DKBIDtoNYUKB = strNYUKB

        Exit Function

ERR_GET_DKBIDtoNYUKB:
        GoTo END_GET_DKBIDtoNYUKB

    End Function
    '2009/09/15 ADD E.N.D RISE)MIYAJIMA

    '2009/09/15 ADD START RISE)MIYAJIMA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function GET_HENPINKIN
    '   概要：  まだ消込に使用していない返品金額を返す（チェックされている場合のみ）
    '   引数：  なし
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function GET_HENPINKIN(ByRef vntNo As Object, ByRef vntJDNNO As Object) As Decimal

        Dim tmp As Object
        Dim idxRow As Integer
        Dim intKesikn As Decimal '消込額

        On Error GoTo ERR_GET_HENPINKIN

        intKesikn = 0

        '返品を検索
        With FR_SSSMAIN.spd_body

            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/19 CHG START
            'For idxRow = 1 To .MaxRows
            For idxRow = 0 To .RowCount - 1
                '2019/04/19 CHG E N D

                '''' DEL 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
                '            '返品を対象にする
                '            .GetText COL_HENPI, idxRow, tmp
                '            If tmp = "1" Then
                '''' DEL 2010/09/01  FKS) T.Yamamoto    End

                'チェックが入っているかを取得
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/19 CHG START
                '.GetText(COL_CHK, idxRow, tmp)
                tmp = IIf(.GetValue(idxRow, COL_CHK) = True, 1, 0)
                '2019/04/19 CHG E N D
                'UPGRADE_WARNING: オブジェクト SSSVal(tmp) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If SSSVal(tmp) = 1 Then


                    '受注番号取得
                    'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/19 CHG START
                    'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_HYJDNNO)
                    '2019/04/19 CHG E N D

                    '受注番号比較
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト vntJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If vntJDNNO = tmp Then

                        '入金済額を取得
                        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/19 CHG START
                        'Call .GetText(COL_KESIKN, idxRow, tmp)
                        tmp = .GetValue(idxRow, COL_KESIKN)
                        '2019/04/19 CHG E N D

                        '''' UPD 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
                        '                        If SSSVal(tmp) < 0 Then
                        '
                        '                            intKesikn = intKesikn + SSSVal(tmp)
                        '
                        '                        End If
                        '返品金額と、すでに消込に使用した返品金額を集計する
                        'UPGRADE_WARNING: オブジェクト vntNo の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト SSSVal(tmp) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If SSSVal(tmp) < 0 Or idxRow < vntNo Then
                            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            intKesikn = intKesikn + SSSVal(tmp)

                            '消込前金額を取得
                            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/19 CHG START
                            'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                            tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                            '2019/04/19 CHG E N D
                            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            intKesikn = intKesikn - SSSVal(tmp)
                        End If
                        '''' UPD 2010/09/01  FKS) T.Yamamoto    End


                    End If

                End If

                '''' DEL 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
                '            End If
                '''' DEL 2010/09/01  FKS) T.Yamamoto    End

            Next idxRow

        End With

        '''' UPD 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
        '返品金額を使い切った場合、０とする
        '    GET_HENPINKIN = intKesikn
        If intKesikn > 0 Then
            GET_HENPINKIN = 0
        Else
            GET_HENPINKIN = intKesikn
        End If
        '''' UPD 2010/09/01  FKS) T.Yamamoto    End

END_GET_HENPINKIN:

        Exit Function

ERR_GET_HENPINKIN:
        GoTo END_GET_HENPINKIN

    End Function
    '2009/09/15 ADD E.N.D RISE)MIYAJIMA

    '2009/09/15 ADD START RISE)MIYAJIMA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称： Function GetMotoKesikomiData
    '   概要： 返品可能金額を入手
    '   引数：
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '2019/04/23 CHG START
    'Public Function GetMotoKesikomiData(ByRef Usr_Ody_Henpin As U_Ody) As Boolean
    Public Function GetMotoKesikomiData(ByRef Usr_Ody_Henpin As DataTable) As Boolean
        '2019/04/23 CHG E N D

        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody
        Dim strSql As String
        Dim strDKBID As String

        Dim strRECNO1 As String
        Dim strLINNO1 As String
        Dim strMOTONO As String
        Dim strDATNO2 As String
        Dim strLINNO2 As String

        On Error GoTo ERR_GetMotoKesikomiData

        GetMotoKesikomiData = False

        '元黒のデータを入手

        '売上トラン（画面表示上の返品を検索）
        strSql = ""
        strSql = strSql & "SELECT "
        strSql = strSql & "       RECNO , JDNLINNO , MOTDATNO "
        strSql = strSql & "FROM "
        strSql = strSql & "       UDNTRA "
        strSql = strSql & "WHERE "
        strSql = strSql & "       DKBID IN ('02','06') "
        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "AND    DATNO = '" & varSpdValue(COL_UDNDATNO) & "' "
        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        strSql = strSql & "AND    LINNO = '" & varSpdValue(COL_UDNLINNO) & "' "
        strSql = strSql & "AND    AKAKROKB = '9' " & vbCrLf

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '    'ﾃﾞｰﾀがない時
        '    GoTo END_GetMotoKesikomiData
        'Else
        '    'ﾃﾞｰﾀがある時
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strRECNO1 = CF_Ora_GetDyn(Usr_Ody, "RECNO", "")
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strLINNO1 = CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strMOTONO = CF_Ora_GetDyn(Usr_Ody, "MOTDATNO", "")
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            GoTo END_GetMotoKesikomiData
        Else
            strRECNO1 = DB_NullReplace(dt.Rows(0)("RECNO"), "")
            strLINNO1 = DB_NullReplace(dt.Rows(0)("JDNLINNO"), "")
            strMOTONO = DB_NullReplace(dt.Rows(0)("MOTDATNO"), "")
        End If
        '2019/04/23 CHG E N D

        '売上トラン（元黒に関連しているデータを検索）
        strSql = ""
        strSql = strSql & " SELECT DATNO , LINNO "
        strSql = strSql & " FROM (SELECT * "
        strSql = strSql & "     FROM UDNTRA "
        strSql = strSql & "     WHERE  RECNO    = '" & strRECNO1 & "' "
        strSql = strSql & "     AND    JDNLINNO = '" & strLINNO1 & "' "
        strSql = strSql & "     AND    DATNO    = '" & strMOTONO & "' "
        strSql = strSql & "     UNION "
        strSql = strSql & "     SELECT * "
        strSql = strSql & "     FROM UDNTRA "
        strSql = strSql & "     WHERE  RECNO    = '" & strRECNO1 & "' "
        strSql = strSql & "     AND    JDNLINNO = '" & strLINNO1 & "' "
        strSql = strSql & "     AND    MOTDATNO = '" & strMOTONO & "' "
        strSql = strSql & "     AND    DKBID IN ('02', '06')) "
        strSql = strSql & " GROUP BY DATNO , LINNO "

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '    'ﾃﾞｰﾀがない時
        '    GoTo END_GetMotoKesikomiData
        'Else
        '    'ﾃﾞｰﾀがある時
        '    Do Until CF_Ora_EOF(Usr_Ody)
        '        If strDATNO2 = "" Then
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            strDATNO2 = "'" & CF_Ora_GetDyn(Usr_Ody, "DATNO", "") & "'"
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            strLINNO2 = "'" & CF_Ora_GetDyn(Usr_Ody, "LINNO", "") & "'"
        '        Else
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            strDATNO2 = strDATNO2 & "," & "'" & CF_Ora_GetDyn(Usr_Ody, "DATNO", "") & "'"
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            strLINNO2 = strLINNO2 & "," & "'" & CF_Ora_GetDyn(Usr_Ody, "LINNO", "") & "'"
        '        End If
        '        'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        Usr_Ody.Obj_Ody.MoveNext()
        '    Loop
        'End If
        Dim dt2 As DataTable = DB_GetTable(strSql)

        If dt2 Is Nothing OrElse dt2.Rows.Count <= 0 Then
            'ﾃﾞｰﾀがない時
            GoTo END_GetMotoKesikomiData
        Else
            'ﾃﾞｰﾀがある時
            For i As Integer = 0 To dt.Rows.Count - 1
                If strDATNO2 = "" Then
                    strDATNO2 = "'" & DB_NullReplace(dt.Rows(0)("DATNO"), "") & "'"
                    strLINNO2 = "'" & DB_NullReplace(dt.Rows(0)("LINNO"), "") & "'"
                Else
                    strDATNO2 = strDATNO2 & "," & "'" & DB_NullReplace(dt.Rows(0)("DATNO"), "") & "'"
                    strLINNO2 = strLINNO2 & "," & "'" & DB_NullReplace(dt.Rows(0)("LINNO"), "") & "'"
                End If

            Next
        End If
        '2019/04/23 CHG E N D

        '入金消込トラン
        strSql = ""
        strSql = strSql & " SELECT"
        strSql = strSql & "     SUM(JKESIKN) JKESIKN,DKBID,UPDID,TEGDT"
        strSql = strSql & " FROM"
        strSql = strSql & "    (SELECT"
        strSql = strSql & "       CASE  WHEN   UPDID = '00' THEN  4 "
        strSql = strSql & "             WHEN   UPDID = '01' THEN  5 "
        strSql = strSql & "             WHEN   UPDID = '02' THEN  6 "
        strSql = strSql & "             WHEN   UPDID = '03' THEN  1 "
        strSql = strSql & "             WHEN   UPDID = '04' THEN  8 "
        strSql = strSql & "             WHEN   UPDID = '05' THEN  3 "
        strSql = strSql & "             WHEN   UPDID = '06' THEN  9 "
        strSql = strSql & "             WHEN   UPDID = '07' THEN  7 "
        strSql = strSql & "             WHEN   UPDID = '08' THEN  0 "
        strSql = strSql & "             WHEN   UPDID = '09' THEN  2 "
        strSql = strSql & "       END AS SEQNO "
        strSql = strSql & "      ,JKESIKN "
        strSql = strSql & "      ,DKBID "
        strSql = strSql & "      ,UPDID "
        strSql = strSql & "      ,TEGDT "
        strSql = strSql & "     FROM "
        strSql = strSql & "       NKSTRA "
        strSql = strSql & "     WHERE "
        strSql = strSql & "            DATKB    = '1' "
        strSql = strSql & "     AND    AKAKROKB = '1' "
        strSql = strSql & "     AND    UDNDATNO IN (" & strDATNO2 & ") "
        strSql = strSql & "     AND    UDNLINNO IN (" & strLINNO2 & ") "
        strSql = strSql & "     AND    KDNNO NOT IN "
        strSql = strSql & "            (SELECT MOTKDNNO FROM NKSTRA WHERE TRIM(MOTKDNNO) IS NOT NULL) "
        strSql = strSql & "    )"
        strSql = strSql & " GROUP BY DKBID,UPDID,TEGDT,SEQNO"
        strSql = strSql & " ORDER BY SEQNO DESC"

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_Henpin, strSql)

        'If CF_Ora_EOF(Usr_Ody_Henpin) = True Then
        '    'ﾃﾞｰﾀがない時
        '    GoTo END_GetMotoKesikomiData
        'End If
        Usr_Ody_Henpin = DB_GetTable(strSql)

        If Usr_Ody_Henpin Is Nothing OrElse Usr_Ody_Henpin.Rows.Count <= 0 Then
            'ﾃﾞｰﾀがない時
            GoTo END_GetMotoKesikomiData
        End If
        '2019/04/23 CHG E N D

        GetMotoKesikomiData = True

END_GetMotoKesikomiData:
        'クローズ
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody)
        '2019/04/23 DEL E N D

        Exit Function

ERR_GetMotoKesikomiData:
        GoTo END_GetMotoKesikomiData

    End Function
    '2009/09/15 ADD E.N.D RISE)MIYAJIMA

    '2009/09/15 ADD START RISE)MIYAJIMA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_NKSTRA_INSERT4
    '   概要：  入金消込トランの追加を行う(追加用レコード）
    '   引数：  pm_cur_KESIKIN  : レコードセット
    '           pm_strSMADT     : 経理締日付
    '           pm_strNYUKB     : 入金種別
    '           pm_int_UPDID    : UODID
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function F_NKSTRA_INSERT4(ByVal pm_cur_KESIKIN As Decimal, ByVal pm_strSMADT As String, ByVal pm_strNYUKB As String, ByVal pm_int_UPDID As Short, ByVal pm_strTEGDT As String) As Short

        Dim strSql As String

        On Error GoTo F_NKSTRA_INSERT4_ERROR

        F_NKSTRA_INSERT4 = 9

        '消込伝票番号の採番処理
        If GET_SYSTBC_DENNO2(gc_DKBSB_KES, strKDNNO) Then
            GoTo F_NKSTRA_INSERT4_ERROR
        End If

        '2009/10/22 ADD START RISE)MIYAJIMA
        If pm_cur_KESIKIN = 0 Then
            intProcErrFlg = 1
            GoTo F_NKSTRA_INSERT4_ERROR
        End If
        '2009/10/22 ADD E.N.D RISE)MIYAJIMA

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
        strSql = strSql & " '" & pm_strTEGDT & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_JDNDT)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_TUKKB)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_INVNO)) & "'," & vbCrLf
        strSql = strSql & "  " & 0 & "," & vbCrLf
        strSql = strSql & "  " & 0 & "," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_FRNKB)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(pm_strNYUKB) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_UDNDATNO)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_UDNLINNO)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(varSpdValue(COL_MAEUKKB)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(pm_strSMADT) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(gstrKesidt.Value) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(Space(8)) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(ARY_NKSSMA_KS(pm_int_UPDID).DATKB) & "'," & vbCrLf
        strSql = strSql & " '" & CF_Ora_Sgl(ARY_NKSSMA_KS(pm_int_UPDID).UPDID) & "'," & vbCrLf
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
        '2019/04/23 CHG START
        'If CF_Ora_Execute(gv_Odb_USR1, strSql) = False Then
        '	GoTo F_NKSTRA_INSERT4_ERROR
        'End If
        DB_Execute(strSql)
        '2019/04/23 CHG E N D

        F_NKSTRA_INSERT4 = 0
        Exit Function

F_NKSTRA_INSERT4_ERROR:
        Call SSSWIN_LOGWRT("F_NKSTRA_INSERT4_ERROR")

    End Function
    '2009/09/15 ADD E.N.D RISE)MIYAJIMA

    '2009/09/18 ADD START RISE)MIYAJIMA
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function GET_DKBIDtoUPDID
    '   概要：  入金更新ID取得
    '   引数：  なし
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function GET_DKBIDtoUPDID(ByRef strDKBID As String) As String

        Dim i As Short
        Dim strUPDID As String

        On Error GoTo ERR_GET_DKBIDtoUPDID

        For i = 0 To UBound(ARY_NKSSMA_KS)
            If ARY_NKSSMA_KS(i).DATKB = strDKBID Then
                strUPDID = ARY_NKSSMA_KS(i).UPDID
                Exit For
            End If
        Next i

END_GET_DKBIDtoUPDID:

        GET_DKBIDtoUPDID = strUPDID
        Exit Function

ERR_GET_DKBIDtoUPDID:
        GoTo END_GET_DKBIDtoUPDID

    End Function
    '2009/09/18 ADD E.N.D RISE)MIYAJIMA

    '2009/09/18 ADD START RISE)MIYAJIMA
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
        Dim strTEGDT As String
        Dim strNYUKB As String
        Dim strUPDID As String
        Dim int_UPDID As Short

        'UPGRADE_WARNING: 構造体 Usr_Ody_Henpin の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        '2019/04/23 CHG START
        'Dim Usr_Ody_Henpin As U_Ody
        Dim Usr_Ody_Henpin As DataTable
        '2019/04/23 CHG E N D
        Dim cur_HEN_JKESIKN As Decimal
        Dim str_HEN_TEGDT As String
        Dim str_HEN_UPDID As String
        Dim str_HEN_DKBID As String
        Dim cur_HENKIN As Decimal
        Dim cur_HEN_KESIKIN As Decimal
        Dim curHenpiKin As Decimal

        Dim i As Short
        Dim j As Short

        setNKSTRA = False

        '経理締め
        strSMADT_DSP = DeCNV_DATE(Get_Acedt(gstrKesidt.Value)) '経理締日付(画面)

        '請求締め
        strNYUDT_DSP = getSmedt(gstrKesidt.Value, DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB) '請求締め(画面)

        '今回消込額を格納(消込金額－消込金額(締日前))
        'UPGRADE_WARNING: オブジェクト SSSVal(varSpdValue(COL_KESIKN_MAE)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))

        '-------------------------------------------------------------------------------------------

        '変更前消込金額(絶対値)が消込金額(絶対値)より大きい時は元NKSTRAを更新する　→派生してJDNTRA,UDNTRA,TOKSSA,TOKSMAの更新
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
            'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

            'Do While CF_Ora_EOF(Usr_Ody) = False

            '	'取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
            '	strSql = ""
            '	strSql = strSql & "SELECT " & vbCrLf
            '	strSql = strSql & "       * " & vbCrLf
            '	strSql = strSql & "FROM " & vbCrLf
            '	strSql = strSql & "       NKSTRA " & vbCrLf
            '	strSql = strSql & "WHERE " & vbCrLf
            '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "kdnno", "") & "' " & vbCrLf

            '	'DBアクセス
            '	Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)

            '	If CF_Ora_EOF(Usr_Ody_1) Then

            '		'消込伝票番号
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		lstrKDNNO = CF_Ora_GetDyn(Usr_Ody, "KDNNO", "")

            '		'消込金額
            '		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		intJkesikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JKESIKN", ""))

            '		'経理締め
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		strSMADT_TBL = DeCNV_DATE(Get_Acedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""))) '経理締日付(入金消込トラン)

            '		'請求締め
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		strNYUDT_TBL = getSmedt(CF_Ora_GetDyn(Usr_Ody, "NYUDT", ""), DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB) '請求締め(入金消込トラン)

            '		'更新IDと入金種別を取得
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		strUPDID = CF_Ora_GetDyn(Usr_Ody, "UPDID", "")
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		strNYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		strDKBID = CF_Ora_GetDyn(Usr_Ody, "DKBID", "")
            '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")

            '		'★NKSTRA更新・追加
            '		If strSMADT_DSP = strSMADT_TBL Then
            '			' 画面消込月度とテーブルの消込月度が同一の場合
            '			If F_NKSTRA_UPDATE1(lstrKDNNO) = 9 Then
            '				Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '				Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '				Exit Function
            '			End If
            '		Else
            '			' 画面消込月度とテーブルの消込月度が異なる場合
            '			If F_NKSTRA_INSERT1(Usr_Ody, strSMADT_DSP, lstrKDNNO) = 9 Then
            '				Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '				Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '				Exit Function
            '			End If
            '		End If

            '		'★TOKSSA更新(DATKB=9よりマイナス更新する)
            '		'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, strNYUDT_DSP) = 9 Then
            '			Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Exit Function
            '		End If

            '		'★TOKSMA更新(DATKB=9よりマイナス更新する)
            '		If strNYUKB = "1" Or strNYUKB = "3" Then
            '			'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '			If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", (-1) * intJkesikn, strSMADT_DSP) = False Then
            '				Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '				Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '				Exit Function
            '			End If
            '		End If

            '		'★UDNTRA更新(DATKB=9よりマイナス更新する)
            '		'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn, strNYUKB) = False Then
            '			Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Exit Function
            '		End If

            '		'★JDNTRA更新(DATKB=9よりマイナス更新する)
            '		'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '		If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn, strNYUKB) = False Then
            '			Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Exit Function
            '		End If

            '		'★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、
            '		If strNYUKB = "2" Or strNYUKB = "3" Then
            '			If Trim(strTEGDT) <> "" Then
            '				'2010/03/17 CHG START RISE)MIYAJIMA
            '				'                        If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt) Then
            '				'                            strUPDID = "00" '01:現金
            '				'                        End If
            '				If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
            '					'''' UPD 2010/03/19  FKS) T.Yamamoto    Start
            '					'                            If Mid(strSMADT_DSP, 1, 6) > Mid(strTEGDT, 1, 6) Then
            '					If strSMADT_DSP <> strSMADT_TBL Then
            '						'''' UPD 2010/03/19  FKS) T.Yamamoto    End
            '						strUPDID = "00" '01:現金
            '					End If
            '				End If
            '				'2010/03/17 CHG E.N.D RISE)MIYAJIMA
            '			End If
            '		End If

            '		'2009/10/01 ADD START RISE)MIYAJIMA
            '		'★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
            '		If strDKBID = "03" Then
            '			If Trim(strTEGDT) <> "" Then
            '				'2010/03/17 CHG START RISE)MIYAJIMA
            '				'                        If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt) Then
            '				'                            strUPDID = "00" '01:現金
            '				'                        End If
            '				If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
            '					'''' UPD 2010/03/19  FKS) T.Yamamoto    Start
            '					'                            If Mid(strSMADT_DSP, 1, 6) > Mid(strTEGDT, 1, 6) Then
            '					If strSMADT_DSP <> strSMADT_TBL Then
            '						'''' UPD 2010/03/19  FKS) T.Yamamoto    End
            '						strUPDID = "00" '01:現金
            '					End If
            '				End If
            '				'2010/03/17 CHG E.N.D RISE)MIYAJIMA
            '			End If
            '		End If
            '		'2009/10/01 ADD E.N.D RISE)MIYAJIMA

            '		'★入金消込サマリ更新（入金消し込み集計金額）
            '		If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, strUPDID, (-1) * intJkesikn, strSMADT_DSP, strSMADT_TBL) = 9 Then
            '			Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '			Exit Function
            '		End If

            '	End If

            '	Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            '	'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	Usr_Ody.Obj_Ody.MoveNext()

            'Loop

            '         Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            Dim dt As DataTable = DB_GetTable(strSql)
            If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                For cnt As Integer = 0 To dt.Rows.Count - 1

                    '取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
                    strSql = ""
                    strSql = strSql & "SELECT " & vbCrLf
                    strSql = strSql & "       * " & vbCrLf
                    strSql = strSql & "FROM " & vbCrLf
                    strSql = strSql & "       NKSTRA " & vbCrLf
                    strSql = strSql & "WHERE " & vbCrLf
                    strSql = strSql & "       MOTKDNNO = '" & DB_NullReplace(dt.Rows(cnt)("kdnno"), "") & "' " & vbCrLf

                    Dim dt2 As DataTable = DB_GetTable(strSql)

                    If dt2 Is Nothing OrElse dt2.Rows.Count <= 0 Then
                        '消込伝票番号
                        lstrKDNNO = DB_NullReplace(dt.Rows(cnt)("KDNNO"), "")

                        '消込金額
                        intJkesikn = SSSVal(DB_NullReplace(dt.Rows(cnt)("JKESIKN"), ""))

                        '経理締め
                        strSMADT_TBL = DeCNV_DATE(Get_Acedt(DB_NullReplace(dt.Rows(cnt)("NYUDT"), ""))) '経理締日付(入金消込トラン)

                        '請求締め
                        strNYUDT_TBL = getSmedt(DB_NullReplace(dt.Rows(cnt)("NYUDT"), ""), DB_TOKMTA2.TOKSMEKB, DB_TOKMTA2.TOKSMEDD, DB_TOKMTA2.TOKSMECC, DB_TOKMTA2.TOKSDWKB) '請求締め(入金消込トラン)

                        '更新IDと入金種別を取得
                        strUPDID = DB_NullReplace(dt.Rows(cnt)("UPDID"), "")
                        strNYUKB = DB_NullReplace(dt.Rows(cnt)("NYUKB"), "")
                        strDKBID = DB_NullReplace(dt.Rows(cnt)("DKBID"), "")
                        strTEGDT = DB_NullReplace(dt.Rows(cnt)("TEGDT"), "")

                        '★NKSTRA更新・追加
                        If strSMADT_DSP = strSMADT_TBL Then
                            ' 画面消込月度とテーブルの消込月度が同一の場合
                            If F_NKSTRA_UPDATE1(lstrKDNNO) = 9 Then
                                Exit Function
                            End If
                        Else
                            ' 画面消込月度とテーブルの消込月度が異なる場合
                            If F_NKSTRA_INSERT1(dt.Rows(cnt), strSMADT_DSP, lstrKDNNO) = 9 Then
                                Exit Function
                            End If
                        End If

                        '★TOKSSA更新(DATKB=9よりマイナス更新する)
                        If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), (-1) * intJkesikn, strNYUDT_DSP) = 9 Then
                            Exit Function
                        End If

                        '★TOKSMA更新(DATKB=9よりマイナス更新する)
                        If strNYUKB = "1" Or strNYUKB = "3" Then
                            If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", (-1) * intJkesikn, strSMADT_DSP) = False Then
                                Exit Function
                            End If
                        End If

                        '★UDNTRA更新(DATKB=9よりマイナス更新する)
                        If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), (-1) * intJkesikn, strNYUKB) = False Then
                            Exit Function
                        End If

                        '★JDNTRA更新(DATKB=9よりマイナス更新する)
                        If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), (-1) * intJkesikn, strNYUKB) = False Then
                            Exit Function
                        End If

                        '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、
                        If strNYUKB = "2" Or strNYUKB = "3" Then
                            If Trim(strTEGDT) <> "" Then

                                If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
                                    If strSMADT_DSP <> strSMADT_TBL Then
                                        strUPDID = "00" '01:現金
                                    End If
                                End If

                            End If
                        End If

                        '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
                        If strDKBID = "03" Then
                            If Trim(strTEGDT) <> "" Then
                                If CNV_DATE(strTEGDT) <= CNV_DATE(gstrUnydt.Value) Then
                                    If strSMADT_DSP <> strSMADT_TBL Then
                                        strUPDID = "00" '01:現金
                                    End If
                                End If
                            End If
                        End If

                        '★入金消込サマリ更新（入金消し込み集計金額）
                        If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, strUPDID, (-1) * intJkesikn, strSMADT_DSP, strSMADT_TBL) = 9 Then
                            Exit Function
                        End If

                    End If
                Next

            End If
            '2019/04/23 CHG E N D

            '前回消込金額を0とする
            '2009/10/06 UPD START RISE)MIYAJIMA
            '        varSpdValue(COL_AFKESIKN) = 0
            'UPGRADE_WARNING: オブジェクト varSpdValue(COL_KESIKN_MAE) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            varSpdValue(COL_KESIKN_MAE) = 0
            '2009/10/06 UPD E.N.D RISE)MIYAJIMA
        End If

        '-------------------------------------------------------------------------------------------

        '締日以降消込金額(絶対値)が消込金額(絶対値)より小きい時は差額を新規に作成
        'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If System.Math.Abs(SSSVal(varSpdValue(COL_KESIKN))) > System.Math.Abs(SSSVal(varSpdValue(COL_KESIKN_MAE))) Then
            'UPGRADE_WARNING: オブジェクト SSSVal(varSpdValue(COL_KESIKN_MAE)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            intKesikn = SSSVal(varSpdValue(COL_KESIKN)) - SSSVal(varSpdValue(COL_KESIKN_MAE))

            '返品金額を画面上より取得
            curHenpiKin = GET_HENPINKIN(varSpdValue(COL_NO), varSpdValue(COL_HYJDNNO))

            '消し込み金額取得
            cur_KIN_WK = intKesikn + curHenpiKin

            If cur_KIN_WK > 0 Then

                '●●●●●通常消し込み●●●●●

                Do
                    '消込可能金額取得
                    If Get_KESIKIN(cur_KIN_WK, cur_KESIKIN, cur_KESIZAN, int_UPDID) = False Then
                        Exit Do
                    End If

                    '消込残金額
                    cur_KIN_WK = cur_KESIZAN

                    '更新IDと入金種別を取得
                    strUPDID = ARY_NKSSMA_KS(int_UPDID).UPDID
                    strDKBID = ARY_NKSSMA_KS(int_UPDID).DATKB
                    strNYUKB = GET_DKBIDtoNYUKB(strDKBID)

                    If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
                        'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込のとき
                        Select Case strDKBID
                            '取引区分=01、02、03は入金種別は1に設定する
                            '''' UPD 2011/11/15  FKS) T.Yamamoto    Start    連絡票№FC11110201
                            '他を追加
                            '                        Case "01", "02", "03"
                            Case "01", "02", "03", "07"
                                '''' UPD 2011/11/15  FKS) T.Yamamoto    End
                                strNYUKB = "1"
                                '上記以外は入金種別は2に設定する
                            Case Else
                                strNYUKB = "2"
                        End Select
                    Else
                        'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外
                        '取引区分に応じた入金種別を設定する
                        '更新IDと入金種別を取得値で良い
                    End If

                    '★NKSTRA追加
                    '2009/11/02 UPD START RISE)MIYAJIMA
                    '                If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
                    If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID, strTEGDT) = 9 Then
                        '2009/11/02 UPD E.N.D RISE)MIYAJIMA
                        '2019/04/23 DEL START
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        '2019/04/23 DEL E N D
                        Exit Function
                    End If

                    '★TOKSSA更新
                    'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
                        '2019/04/23 DEL START
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        '2019/04/23 DEL E N D
                        Exit Function
                    End If

                    '★TOKSMA更新
                    If strNYUKB = "1" Or strNYUKB = "3" Then
                        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
                            '2019/04/23 DEL START
                            'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                            '2019/04/23 DEL E N D
                            Exit Function
                        End If
                    End If

                    '★UDNTRA更新
                    'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
                        '2019/04/23 DEL START
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        '2019/04/23 DEL E N D
                        Exit Function
                    End If

                    '★JDNTRA更新
                    'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
                        '2019/04/23 DEL START
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        '2019/04/23 DEL E N D
                        Exit Function
                    End If

                    '2010/03/17 DEL START RISE)MIYAJIMA
                    '                 '画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、
                    '                If strNYUKB = "2" Or strNYUKB = "3" Then
                    ''2009/11/02 UPD START RISE)MIYAJIMA
                    ''                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
                    ''                        If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt) Then
                    ''                            strUPDID = "00" '01:現金
                    ''                        End If
                    ''                    End If
                    '                    If Trim(strTEGDT) <> "" Then
                    '                        If CNV_DATE(Trim(strTEGDT)) <= CNV_DATE(gstrUnydt) Then
                    '                            strUPDID = "00" '01:現金
                    '                        End If
                    '                    End If
                    ''2009/11/02 UPD E.N.D RISE)MIYAJIMA
                    '                End If
                    '2010/03/17 DEL E.N.D RISE)MIYAJIMA

                    '2010/03/17 DEL START RISE)MIYAJIMA
                    ''2009/10/01 ADD START RISE)MIYAJIMA
                    '                '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
                    '                If strDKBID = "03" Then
                    ''2009/11/02 UPD START RISE)MIYAJIMA
                    ''                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
                    ''                        If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt) Then
                    ''                            strUPDID = "00" '01:現金
                    ''                        End If
                    ''                    End If
                    '                    If Trim(strTEGDT) <> "" Then
                    '                        If CNV_DATE(Trim(strTEGDT)) <= CNV_DATE(gstrUnydt) Then
                    '                            strUPDID = "00" '01:現金
                    '                        End If
                    '                    End If
                    ''2009/11/02 UPD E.N.D RISE)MIYAJIMA
                    '                End If
                    ''2009/10/01 ADD E.N.D RISE)MIYAJIMA
                    '2010/03/17 DEL E.N.D RISE)MIYAJIMA

                    '★入金消込サマリ更新（入金消し込み集計金額）
                    If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, strUPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
                        '2019/04/23 DEL START
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        '2019/04/23 DEL E N D
                        Exit Function
                    End If

                    If cur_KIN_WK = 0 Then
                        Exit Do
                    End If
                Loop
                '2009/11/02 ADD START RISE)MIYAJIMA
            End If
            '2009/11/02 ADD E.N.D RISE)MIYAJIMA
            '★★（返品用黒作成）★★
            '2009/11/02 UPD START RISE)MIYAJIMA
            '            If curHenpiKin <> 0 Then
            If curHenpiKin <> 0 And intKesikn > 0 Then
                '2009/11/02 ADD E.N.D RISE)MIYAJIMA

                '''' UPD 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
                '                cur_KESIKIN = curHenpiKin * -1
                '返品金額の方が多かった場合、今回消込金額の分だけ消し込む
                If intKesikn < System.Math.Abs(curHenpiKin) Then
                    cur_KESIKIN = intKesikn
                Else
                    cur_KESIKIN = System.Math.Abs(curHenpiKin)
                End If
                '''' UPD 2010/09/01  FKS) T.Yamamoto    End

                'ここで返品時のUPDIDを入手
                int_UPDID = CShort(getUpdid)

                '更新IDと入金種別を取得
                strUPDID = ARY_NKSSMA_KS(int_UPDID).UPDID
                strDKBID = ARY_NKSSMA_KS(int_UPDID).DATKB
                strNYUKB = GET_DKBIDtoNYUKB(strDKBID)

                If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
                    'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込のとき
                    Select Case strDKBID
                        '取引区分=01、02、03は入金種別は1に設定する
                        '''' UPD 2011/11/15  FKS) T.Yamamoto    Start    連絡票№FC11110201
                        '他を追加
                        '                        Case "01", "02", "03"
                        Case "01", "02", "03", "07"
                            '''' UPD 2011/11/15  FKS) T.Yamamoto    End
                            strNYUKB = "1"
                            '上記以外は入金種別は2に設定する
                        Case Else
                            strNYUKB = "2"
                    End Select
                Else
                    'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外
                    '取引区分に応じた入金種別を設定する
                    '更新IDと入金種別を取得値で良い
                End If

                '★NKSTRA追加
                '2009/11/02 UPD START RISE)MIYAJIMA
                '                If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID) = 9 Then
                If F_NKSTRA_INSERT2(cur_KESIKIN, strSMADT_DSP, strNYUKB, int_UPDID, strTEGDT) = 9 Then
                    '2009/11/02 UPD E.N.D RISE)MIYAJIMA
                    '2019/04/23 DEL START
                    'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                    '2019/04/23 DEL E N D
                    Exit Function
                End If

                '★TOKSSA更新
                'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
                    '2019/04/23 DEL START
                    'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                    '2019/04/23 DEL E N D
                    Exit Function
                End If

                '★TOKSMA更新
                If strNYUKB = "1" Or strNYUKB = "3" Then
                    'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_KESIKIN, strSMADT_DSP) = False Then
                        '2019/04/23 DEL START
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        '2019/04/23 DEL E N D
                        Exit Function
                    End If
                End If

                '★UDNTRA更新
                'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
                    '2019/04/23 DEL START
                    'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                    '2019/04/23 DEL E N D
                    Exit Function
                End If

                '★JDNTRA更新
                'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_KESIKIN, strNYUKB) = False Then
                    '2019/04/23 DEL START
                    'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                    '2019/04/23 DEL E N D
                    Exit Function
                End If

                '2010/03/17 DEL START RISE)MIYAJIMA
                '                 '画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、
                '                If strNYUKB = "2" Or strNYUKB = "3" Then
                ''2009/11/02 UPD START RISE)MIYAJIMA
                ''                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
                ''                        If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt) Then
                ''                            strUPDID = "00" '01:現金
                ''                        End If
                ''                    End If
                '                    If Trim(strTEGDT) <> "" Then
                '                        If CNV_DATE(Trim(strTEGDT)) <= CNV_DATE(gstrUnydt) Then
                '                            strUPDID = "00" '01:現金
                '                        End If
                '                    End If
                ''2009/11/02 UPD E.N.D RISE)MIYAJIMA
                '                End If
                '2010/03/17 DEL E.N.D RISE)MIYAJIMA

                '2010/03/17 DEL START RISE)MIYAJIMA
                ''2009/10/01 ADD START RISE)MIYAJIMA
                '                '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
                '                If strDKBID = "03" Then
                ''2009/11/02 UPD START RISE)MIYAJIMA
                ''                    If Trim(varSpdValue(COL_HYFRIDT)) <> "" Then
                ''                        If CNV_DATE(Trim(varSpdValue(COL_HYFRIDT))) <= CNV_DATE(gstrUnydt) Then
                ''                            strUPDID = "00" '01:現金
                ''                        End If
                ''                    End If
                '                    If Trim(strTEGDT) <> "" Then
                '                        If CNV_DATE(Trim(strTEGDT)) <= CNV_DATE(gstrUnydt) Then
                '                            strUPDID = "00" '01:現金
                '                        End If
                '                    End If
                ''2009/11/02 UPD E.N.D RISE)MIYAJIMA
                '                End If
                ''2009/10/01 ADD E.N.D RISE)MIYAJIMA
                '2010/03/17 DEL E.N.D RISE)MIYAJIMA

                '★入金消込サマリ更新（入金消し込み集計金額）
                If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, strUPDID, cur_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
                    '2019/04/23 DEL START
                    'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                    '2019/04/23 DEL E N D
                    Exit Function
                End If

                '2009/11/02 DEL START RISE)MIYAJIMA
                '            End If
                '2009/10/02 DEL E.N.D RISE)MIYAJIMA

            End If

            '●●●●●返品時消し込み●●●●●

            'UPGRADE_WARNING: オブジェクト SSSVal(varSpdValue(COL_KESIKN)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト varSpdValue(COL_HENPI) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If varSpdValue(COL_HENPI) = "1" And SSSVal(varSpdValue(COL_KESIKN)) < 0 Then

                cur_KESIKIN = intKesikn

                '''' UPD 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
                '            cur_HENKIN = cur_KESIKIN
                '返品可能金額を求めて消し込む必要がある金額を取得
                cur_HENKIN = GET_HENPIN_MotoKesi(varSpdValue(COL_NO), varSpdValue(COL_HYJDNNO))
                cur_KESIKIN = cur_KESIKIN - cur_HENKIN

                If cur_HENKIN < 0 Then
                    '''' UPD 2010/09/01  FKS) T.Yamamoto    End
                    If GetMotoKesikomiData(Usr_Ody_Henpin) Then

                        '2019/04/23 CHG START
                        'Do Until CF_Ora_EOF(Usr_Ody_Henpin)
                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'cur_HEN_JKESIKN = CF_Ora_GetDyn(Usr_Ody_Henpin, "JKESIKN", "")
                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'str_HEN_TEGDT = CF_Ora_GetDyn(Usr_Ody_Henpin, "TEGDT", "")
                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'str_HEN_UPDID = CF_Ora_GetDyn(Usr_Ody_Henpin, "UPDID", "")
                        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'str_HEN_DKBID = CF_Ora_GetDyn(Usr_Ody_Henpin, "DKBID", "")

                        For cnt As Integer = 0 To Usr_Ody_Henpin.Rows.Count - 1
                            cur_HEN_JKESIKN = DB_NullReplace(Usr_Ody_Henpin.Rows(cnt)("JKESIKN"), "")
                            str_HEN_TEGDT = DB_NullReplace(Usr_Ody_Henpin.Rows(cnt)("TEGDT"), "")
                            str_HEN_UPDID = DB_NullReplace(Usr_Ody_Henpin.Rows(cnt)("UPDID"), "")
                            str_HEN_DKBID = DB_NullReplace(Usr_Ody_Henpin.Rows(cnt)("DKBID"), "")
                            '2019/04/23 CHG E N D

                            If cur_HENKIN + cur_HEN_JKESIKN >= 0 Then
                                cur_HEN_KESIKIN = cur_HENKIN
                                cur_HENKIN = 0
                            Else
                                cur_HEN_KESIKIN = cur_HEN_JKESIKN * -1
                                cur_HENKIN = cur_HENKIN + cur_HEN_JKESIKN
                            End If

                            '更新IDと入金種別を取得
                            strNYUKB = GET_DKBIDtoNYUKB(str_HEN_DKBID)

                            If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
                                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込のとき
                                Select Case str_HEN_DKBID
                                    '取引区分=01、02、03は入金種別は1に設定する
                                    '''' UPD 2011/11/15  FKS) T.Yamamoto    Start    連絡票№FC11110201
                                    '他を追加
                                    '                            Case "01", "02", "03"
                                    Case "01", "02", "03", "07"
                                        '''' UPD 2011/11/15  FKS) T.Yamamoto    End
                                        strNYUKB = "1"
                                        '上記以外は入金種別は2に設定する
                                    Case Else
                                        strNYUKB = "2"
                                End Select
                            Else
                                'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外
                                '取引区分に応じた入金種別を設定する
                                '更新IDと入金種別を取得値で良い
                            End If

                            '★NKSTRA追加
                            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If F_NKSTRA_INSERT4(cur_HEN_KESIKIN, strSMADT_DSP, strNYUKB, SSSVal(str_HEN_UPDID), str_HEN_TEGDT) = 9 Then
                                '2019/04/23 DEL START
                                'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                                '2019/04/23 DEL E N D
                                Exit Function
                            End If

                            '★TOKSSA更新
                            'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), cur_HEN_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
                                '2019/04/23 DEL START
                                'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                                '2019/04/23 DEL E N D 
                                Exit Function
                            End If

                            '★TOKSMA更新
                            If strNYUKB = "1" Or strNYUKB = "3" Then
                                'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", cur_HEN_KESIKIN, strSMADT_DSP) = False Then
                                    '2019/04/23 DEL START
                                    'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                                    '2019/04/23 DEL E N D
                                    Exit Function
                                End If
                            End If

                            '★UDNTRA更新
                            'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), cur_HEN_KESIKIN, strNYUKB) = False Then
                                '2019/04/23 DEL START
                                'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                                '2019/04/23 DEL E N D
                                Exit Function
                            End If

                            '★JDNTRA更新
                            'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), cur_HEN_KESIKIN, strNYUKB) = False Then
                                '2019/04/23 DEL START
                                'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                                '2019/04/23 DEL E N D
                                Exit Function
                            End If

                            '2010/03/17 DEL START RISE)MIYAJIMA
                            '                     '画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、
                            '                    If strNYUKB = "2" Or strNYUKB = "3" Then
                            '                        If Trim(str_HEN_TEGDT) <> "" Then
                            '                            If CNV_DATE(str_HEN_TEGDT) <= CNV_DATE(gstrUnydt) Then
                            '                                str_HEN_UPDID = "00" '01:現金
                            '                            End If
                            '                        End If
                            '                    End If
                            '2010/03/17 DEL E.N.D RISE)MIYAJIMA

                            '2010/03/17 DEL START RISE)MIYAJIMA
                            ''2009/10/01 ADD START RISE)MIYAJIMA
                            '                    '★画面で振込期日が入力された場合でかつ振込期日＞運用日の場合、入金種別が03手形の時
                            '                    If str_HEN_DKBID = "03" Then
                            '                        If Trim(str_HEN_TEGDT) <> "" Then
                            '                            If CNV_DATE(str_HEN_TEGDT) <= CNV_DATE(gstrUnydt) Then
                            '                                str_HEN_UPDID = "00" '01:現金
                            '                            End If
                            '                        End If
                            '                    End If
                            ''2009/10/01 ADD E.N.D RISE)MIYAJIMA
                            '2010/03/17 DEL E.N.D RISE)MIYAJIMA

                            '★入金消込サマリ更新（入金消し込み集計金額）
                            If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, str_HEN_UPDID, cur_HEN_KESIKIN, strSMADT_DSP, strSMADT_DSP) = 9 Then
                                '2019/04/23 DEL START
                                'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                                '2019/04/23 DEL E N D
                                Exit Function
                            End If

                            '金額が0になったらループを抜ける
                            If cur_HENKIN >= 0 Then
                                '2019/04/23 CHG START
                                'Exit Do
                                Exit For
                                '2019/04/23 CHG E N D
                            End If

                            'UPGRADE_WARNING: オブジェクト Usr_Ody_Henpin.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/23 CHG START
                            'Usr_Ody_Henpin.Obj_Ody.MoveNext()

                            'Loop 
                        Next
                        '2019/04/23 CHG E N D
                    End If
                    '''' ADD 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
                End If

                If cur_KESIKIN < 0 Then
                    If setNKSTRA_HENPIN_UPDID(cur_KESIKIN, strSMADT_DSP) = 9 Then
                        '2019/04/23 DEL START
                        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        '2019/04/23 DEL E N D
                        Exit Function
                    End If
                End If
                '''' ADD 2010/09/01  FKS) T.Yamamoto    End
            End If
        End If

        setNKSTRA = True
        Exit Function

SETNKSTRA_ERROR:
        Call SSSWIN_LOGWRT("SETNKSTRA_ERROR")

    End Function
    '2009/09/18 ADD E.N.D RISE)MIYAJIMA

    '''' ADD 2010/09/01  FKS) T.Yamamoto    Start    連絡票№822
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function setNKSTRA_HENPIN_UPDID
    '   概要：  返品時のUPDIDで入金消込トランの更新と他テーブル更新
    '   引数：  pm_cur_KESIKIN  : 消込金額
    '           pm_strSMADT     : 経理締日付
    '   戻値：　0 : 正常  1 : 警告  9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Function setNKSTRA_HENPIN_UPDID(ByVal pm_cur_KESIKIN As Decimal, ByVal pm_strSMADT As String) As Short
        Dim strSql As String
        'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        Dim Usr_Ody As U_Ody

        Dim strDKBID As String
        Dim strTEGDT As String
        Dim strNYUKB As String
        Dim strUPDID As String
        Dim int_UPDID As Short

        On Error GoTo setNKSTRA_HENPIN_UPDID_ERROR

        setNKSTRA_HENPIN_UPDID = 9

        '返品時のUPDIDを取得
        strUPDID = ""
        Select Case DB_TOKMTA2.SHAKB
            Case "3"
                strDKBID = "02"
            Case "4"
                strDKBID = "02"
            Case "5"
                strDKBID = "08"
            Case "6"
                strDKBID = "08"
            Case Else
                strDKBID = "02"
        End Select

        strSql = "SELECT * FROM SYSTBD " & "WHERE DKBSB = '050' " & "AND DKBID = '" & strDKBID & "' "

        'DBアクセス
        '2019/04/23 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	strUPDID = CF_Ora_GetDyn(Usr_Ody, "updid", "")
        'End If
        Dim dt As DataTable = DB_GetTable(strSql)

        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            strUPDID = DB_NullReplace(dt.Rows(0)("updid"), "")
        End If
        '2019/04/23 CHG E N D

        int_UPDID = CShort(strUPDID)

        '更新IDと入金種別を取得
        strUPDID = ARY_NKSSMA_KS(int_UPDID).UPDID
        strDKBID = ARY_NKSSMA_KS(int_UPDID).DATKB
        strNYUKB = GET_DKBIDtoNYUKB(strDKBID)

        If DB_TOKMTA2.SHAKB = "5" Or DB_TOKMTA2.SHAKB = "6" Then
            'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込のとき
            Select Case strDKBID
                '取引区分=01、02、03は入金種別は1に設定する
                '''' UPD 2011/11/15  FKS) T.Yamamoto    Start    連絡票№FC11110201
                '他を追加
                '            Case "01", "02", "03"
                Case "01", "02", "03", "07"
                    '''' UPD 2011/11/15  FKS) T.Yamamoto    End
                    strNYUKB = "1"
                    '上記以外は入金種別は2に設定する
                Case Else
                    strNYUKB = "2"
            End Select
        Else
            'TOKSMAの更新は支払条件が、ﾌｧｸﾀﾘﾝｸﾞ、期日振込以外
            '取引区分に応じた入金種別を設定する
            '更新IDと入金種別を取得値で良い
        End If

        '★NKSTRA追加
        If F_NKSTRA_INSERT2(pm_cur_KESIKIN, pm_strSMADT, strNYUKB, int_UPDID, strTEGDT) = 9 Then
            GoTo setNKSTRA_HENPIN_UPDID_ERROR
        End If

        '★TOKSSA更新
        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If F_TOKSSA_Update(CStr(varSpdValue(COL_TOKSEICD)), pm_cur_KESIKIN, DB_TOKMTA2.KESISMEDT) = 9 Then
            GoTo setNKSTRA_HENPIN_UPDID_ERROR
        End If

        '★TOKSMA更新
        If strNYUKB = "1" Or strNYUKB = "3" Then
            'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If setTOKSMA(CStr(varSpdValue(COL_TOKCD)), "00", pm_cur_KESIKIN, pm_strSMADT) = False Then
                GoTo setNKSTRA_HENPIN_UPDID_ERROR
            End If
        End If

        '★UDNTRA更新
        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If setUDNTRA(CStr(varSpdValue(COL_UDNDATNO)), CStr(varSpdValue(COL_UDNLINNO)), pm_cur_KESIKIN, strNYUKB) = False Then
            GoTo setNKSTRA_HENPIN_UPDID_ERROR
        End If

        '★JDNTRA更新
        'UPGRADE_WARNING: オブジェクト varSpdValue() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If setJDNTRA(CStr(varSpdValue(COL_JDNNO)), CStr(varSpdValue(COL_JDNLINNO)), pm_cur_KESIKIN, strNYUKB) = False Then
            GoTo setNKSTRA_HENPIN_UPDID_ERROR
        End If

        '★入金消込サマリ更新（入金消し込み集計金額）
        If F_NKSSMA_KSK_Update(DB_TOKMTA2.TOKSEICD, strUPDID, pm_cur_KESIKIN, pm_strSMADT, pm_strSMADT) = 9 Then
            GoTo setNKSTRA_HENPIN_UPDID_ERROR
        End If

        setNKSTRA_HENPIN_UPDID = 0
		Exit Function

setNKSTRA_HENPIN_UPDID_ERROR:
        '2019/04/23 DEL START
        'Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
        '2019/04/23 DEL E N D
        Call SSSWIN_LOGWRT("setNKSTRA_HENPIN_UPDID_ERROR")
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function GET_HENPIN_MotoKesi
	'   概要：  返品可能金額を求めて消し込む必要がある金額を返す
	'   引数：  行№、受注番号
	'   戻値：　返品金額
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function GET_HENPIN_MotoKesi(ByRef vntNo As Object, ByRef vntJDNNO As Object) As Decimal
		
		Dim tmp As Object
		Dim idxRow As Integer
		
		On Error GoTo ERR_GET_HENPIN_MotoKesi
		
		GET_HENPIN_MotoKesi = 0
		
		With FR_SSSMAIN.spd_body

            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/19 CHG START
            'For idxRow = 1 To .MaxRows
            For idxRow = 0 To .RowCount - 1
                '2019/04/19 CHG E N D

                'チェックが入っているかを取得
                'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/04/19 CHG START
                '.GetText(COL_CHK, idxRow, tmp)
                tmp = IIf(.GetValue(idxRow, COL_CHK) = True, 1, 0)
                '2019/04/19 CHG E N D

                'UPGRADE_WARNING: オブジェクト SSSVal(tmp) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If SSSVal(tmp) = 1 Then

                    '受注番号取得
                    'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/04/19 CHG START
                    'Call .GetText(COL_HYJDNNO, idxRow, tmp)
                    tmp = .GetValue(idxRow, COL_HYJDNNO)
                    '2019/04/19 CHG E N D

                    '受注番号比較
                    'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト vntJDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If vntJDNNO = tmp Then

                        '入金済額を取得
                        'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/04/19 CHG START
                        'Call .GetText(COL_KESIKN, idxRow, tmp)
                        tmp = .GetValue(idxRow, COL_KESIKN)
                        '2019/04/19 CHG E N D

                        '引数の行より後の返品金額を除く
                        'UPGRADE_WARNING: オブジェクト vntNo の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト SSSVal(tmp) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If SSSVal(tmp) < 0 And idxRow > vntNo Then
                        Else
                            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            GET_HENPIN_MotoKesi = GET_HENPIN_MotoKesi + SSSVal(tmp)

                            '消込前金額を取得
                            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/04/19 CHG START
                            'Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                            tmp = .GetValue(idxRow, COL_KESIKN_MAE)
                            '2019/04/19 CHG E N D

                            'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            GET_HENPIN_MotoKesi = GET_HENPIN_MotoKesi - SSSVal(tmp)
                        End If

                    End If

                End If

            Next idxRow

        End With
		
		If GET_HENPIN_MotoKesi > 0 Then
			GET_HENPIN_MotoKesi = 0
		End If
		
END_GET_HENPIN_MotoKesi: 
		
		Exit Function
		
ERR_GET_HENPIN_MotoKesi: 
		GoTo END_GET_HENPIN_MotoKesi
		
	End Function
	'''' ADD 2010/09/01  FKS) T.Yamamoto    End
End Module