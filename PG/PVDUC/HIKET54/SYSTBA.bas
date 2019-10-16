Attribute VB_Name = "SYSTBA_DBM"
        Option Explicit
'==========================================================================
'   SYSTBA.DBM   ﾕｰｻﾞｰ情報管理ﾃｰﾌﾞﾙ               UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBA
    USRID          As String * 8     'ユーザーID            !@@@@@@@@
    USRNMA         As String * 30    'ユーザー名1(漢字)
    USRNMB         As String * 30    'ユーザー名2(漢字)
    USRRN          As String * 20    'ユーザー略称
    USRNK          As String * 10    'ユーザー名称(カナ)
    USRZP          As String * 8     'ユーザー郵便番号
    USRADA         As String * 30    'ユーザー住所1
    USRADB         As String * 30    'ユーザー住所2
    USRADC         As String * 30    'ユーザー住所3
    USRTL          As String * 12    'ユーザー電話番号
    USRFX          As String * 12    'ユーザーFAX番号
    USRBOSNM       As String * 30    'ユーザー代表者名称
    USRTANNM       As String * 30    'ユーザー担当者名
    SMAMM          As String * 2     '決算月                MM
    SMADD          As String * 2     '決算日                DD
    SMAMONDD       As String * 2     '月次決算日            DD
    SMEDD          As String * 2     '締め日                DD
    KESCC          As String * 2     '回収支払月            MM
    KESDD          As String * 2     '回収支払日            DD
    DATNO          As String * 10    '伝票管理NO.           0000000000
    RECNO          As String * 10    'レコード管理NO.       0000000000
    STTDATNO       As String * 10    '開始伝票管理NO.
    ENDDATNO       As String * 10    '終了伝票管理NO.
    STTRECNO       As String * 10    '開始レコード管理NO.
    ENDRECNO       As String * 10    '終了レコード管理NO.
    GYMSTTDT       As String * 8     '業務開始日付          YYYY/MM/DD
    TOKSSAKB       As String * 1     '得意先請求締処理区分  0
    TOKSMAKB       As String * 1     '得意先経理締処理区分  0
    SIRSSAKB       As String * 1     '仕入先支払締処理区分  0
    SIRSMAKB       As String * 1     '仕入先経理締処理区分  0
    SMAUPDDT       As String * 8     '前回経理締実行日      YYYY/MM/DD
    UKSMEDT        As String * 8     '月次仮締日（売り）
    SKSMEDT        As String * 8     '月次仮締日（仕入）
    MINSPCCP       As String * 8     '最低空き容量(Ｍ)      9(8)
    MONUPDSC       As String * 2     'トラン保存期間(月)    99
    YERUPDSC       As String * 2     'サマリ保存期間(月)    99
    MONUPDDT       As String * 8     '前回月次更新実行日    YYYY/MM/DD
    YERUPDDT       As String * 8     '前回年次更新実行日    YYYY/MM/DD
    NEGKB(1)       As String * 1     '和暦採用区分          0
    NEGDT(4)       As String * 8     '元年(西暦)            YYYY/MM/DD
    NEGYY(4)       As String * 4     '元号(年)              YYYY
    NEGNM(4)       As String * 4     '元号
    VERNO          As String * 3     'VERNO                 !@@@
    LEVNO          As String * 2     'LEBEL NO              00
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    ZAIHYKKB       As String * 1     '在庫評価方法          0
    GNKHYKKB       As String * 1     '原価評価方法-粗利用   0
    HYKSTTDT       As String * 8     '評価計算開始日付      YYYY/MM/DD
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    WRTFSTTM       As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
    WRTFSTDT       As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(登録日付)
End Type
Global DB_SYSTBA As TYPE_DB_SYSTBA
Global DBN_SYSTBA As Integer
' Index1( USRID )

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_SYSTBA_Clear
    '   概要：  ユーザー情報管理テーブル構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SYSTBA_Clear(ByRef pot_DB_SYSTBA As TYPE_DB_SYSTBA)

        Dim Clr_DB_SYSTBA As TYPE_DB_SYSTBA
    
        pot_DB_SYSTBA = Clr_DB_SYSTBA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SYSTBA_SEARCH
    '   概要：  ユーザー情報管理テーブル検索
    '   引数：  pot_DB_SYSTBA   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function SYSTBA_SEARCH(ByRef pot_DB_SYSTBA As TYPE_DB_SYSTBA) As Integer

        Dim strSQL          As String
        Dim Usr_Ody_LC      As U_Ody
        Dim intCnt          As Integer

    On Error GoTo ERR_SYSTBA_SEARCH
    
        SYSTBA_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SYSTBA "
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
 
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '取得データなし
            SYSTBA_SEARCH = 1
            GoTo END_SYSTBA_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody_LC) = False Then
            With pot_DB_SYSTBA
                .USRID = CF_Ora_GetDyn(Usr_Ody_LC, "USRID", "")                    'ユーザーID
                .USRNMA = CF_Ora_GetDyn(Usr_Ody_LC, "USRNMA", "")                  'ユーザー名1(漢字)
                .USRNMB = CF_Ora_GetDyn(Usr_Ody_LC, "USRNMB", "")                  'ユーザー名2(漢字)
                .USRRN = CF_Ora_GetDyn(Usr_Ody_LC, "USRRN", "")                    'ユーザー略称
                .USRNK = CF_Ora_GetDyn(Usr_Ody_LC, "USRNK", "")                    'ユーザー名称(カナ)
                .USRZP = CF_Ora_GetDyn(Usr_Ody_LC, "USRZP", "")                    'ユーザー郵便番号
                .USRADA = CF_Ora_GetDyn(Usr_Ody_LC, "USRADA", "")                  'ユーザー住所1
                .USRADB = CF_Ora_GetDyn(Usr_Ody_LC, "USRADB", "")                  'ユーザー住所2
                .USRADC = CF_Ora_GetDyn(Usr_Ody_LC, "USRADC", "")                  'ユーザー住所3
                .USRTL = CF_Ora_GetDyn(Usr_Ody_LC, "USRTL", "")                    'ユーザー電話番号
                .USRFX = CF_Ora_GetDyn(Usr_Ody_LC, "USRFX", "")                    'ユーザーFAX番号
                .USRBOSNM = CF_Ora_GetDyn(Usr_Ody_LC, "USRBOSNM", "")              'ユーザー代表者名称
                .USRTANNM = CF_Ora_GetDyn(Usr_Ody_LC, "USRTANNM", "")              'ユーザー担当者名
                .SMAMM = CF_Ora_GetDyn(Usr_Ody_LC, "SMAMM", "")                    '決算月
                .SMADD = CF_Ora_GetDyn(Usr_Ody_LC, "SMADD", "")                    '決算日
                .SMAMONDD = CF_Ora_GetDyn(Usr_Ody_LC, "SMAMONDD", "")              '月次決算日
                .SMEDD = CF_Ora_GetDyn(Usr_Ody_LC, "SMEDD", "")                    '締め日
                .KESCC = CF_Ora_GetDyn(Usr_Ody_LC, "KESCC", "")                    '回収支払月
                .KESDD = CF_Ora_GetDyn(Usr_Ody_LC, "KESDD", "")                    '回収支払日
                .DATNO = CF_Ora_GetDyn(Usr_Ody_LC, "DATNO", "")                    '伝票管理NO.
                .RECNO = CF_Ora_GetDyn(Usr_Ody_LC, "RECNO", "")                    'レコード管理NO.
                .STTDATNO = CF_Ora_GetDyn(Usr_Ody_LC, "STTDATNO", "")              '開始伝票管理NO.
                .ENDDATNO = CF_Ora_GetDyn(Usr_Ody_LC, "ENDDATNO", "")              '終了伝票管理NO.
                .STTRECNO = CF_Ora_GetDyn(Usr_Ody_LC, "STTRECNO", "")              '開始レコード管理NO.
                .ENDRECNO = CF_Ora_GetDyn(Usr_Ody_LC, "ENDRECNO", "")              '終了レコード管理NO.
                .GYMSTTDT = CF_Ora_GetDyn(Usr_Ody_LC, "GYMSTTDT", "")              '業務開始日付
                .TOKSSAKB = CF_Ora_GetDyn(Usr_Ody_LC, "TOKSSAKB", "")              '得意先請求締処理区分
                .TOKSMAKB = CF_Ora_GetDyn(Usr_Ody_LC, "TOKSMAKB", "")              '得意先経理締処理区分
                .SIRSSAKB = CF_Ora_GetDyn(Usr_Ody_LC, "SIRSSAKB", "")              '仕入先支払締処理区分
                .SIRSMAKB = CF_Ora_GetDyn(Usr_Ody_LC, "SIRSMAKB", "")              '仕入先経理締処理区分
                .SMAUPDDT = CF_Ora_GetDyn(Usr_Ody_LC, "SMAUPDDT", "")              '前回経理締実行日
                .UKSMEDT = CF_Ora_GetDyn(Usr_Ody_LC, "UKSMEDT", "")                '月次仮締日（売り）
                .SKSMEDT = CF_Ora_GetDyn(Usr_Ody_LC, "SKSMEDT", "")                '月次仮締日（仕入）
                .MINSPCCP = CF_Ora_GetDyn(Usr_Ody_LC, "MINSPCCP", "")              '最低空き容量(Ｍ)
                .MONUPDSC = CF_Ora_GetDyn(Usr_Ody_LC, "MONUPDSC", "")              'トラン保存期間(月)
                .YERUPDSC = CF_Ora_GetDyn(Usr_Ody_LC, "YERUPDSC", "")              'サマリ保存期間(月)
                .MONUPDDT = CF_Ora_GetDyn(Usr_Ody_LC, "MONUPDDT", "")              '前回月次更新実行日
                .YERUPDDT = CF_Ora_GetDyn(Usr_Ody_LC, "YERUPDDT", "")              '前回年次更新実行日
                '和暦採用区分
                For intCnt = 0 To 1
                    .NEGKB(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGKB" & Format(intCnt, "00"), "")
                Next
                '元年(西暦)
                For intCnt = 0 To 4
                    .NEGDT(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGDT" & Format(intCnt, "00"), "")
                Next
                '元号(年)
                For intCnt = 0 To 4
                    .NEGYY(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGYY" & Format(intCnt, "00"), "")
                Next
                '元号
                For intCnt = 0 To 4
                    .NEGNM(intCnt) = CF_Ora_GetDyn(Usr_Ody_LC, "NEGNM" & Format(intCnt, "00"), "")
                Next
                .VERNO = CF_Ora_GetDyn(Usr_Ody_LC, "VERNO", "")                    'VERNO
                .LEVNO = CF_Ora_GetDyn(Usr_Ody_LC, "LEVNO", "")                    'LEBEL NO
                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")                    'クライアントＩＤ
                .ZAIHYKKB = CF_Ora_GetDyn(Usr_Ody_LC, "ZAIHYKKB", "")              '在庫評価方法
                .GNKHYKKB = CF_Ora_GetDyn(Usr_Ody_LC, "GNKHYKKB", "")              '原価評価方法-粗利用
                .HYKSTTDT = CF_Ora_GetDyn(Usr_Ody_LC, "HYKSTTDT", "")              '評価計算開始日付
                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")                    'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")                    'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")              'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")              'ﾀｲﾑｽﾀﾝﾌﾟ(登録日付)
            End With
        End If

        SYSTBA_SEARCH = 0
        
END_SYSTBA_SEARCH:
        
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
        Exit Function
    
ERR_SYSTBA_SEARCH:
        GoTo END_SYSTBA_SEARCH
        
    End Function
