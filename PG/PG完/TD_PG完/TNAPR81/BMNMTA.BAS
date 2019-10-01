Attribute VB_Name = "BMNMTA_DBM"
        Option Explicit
'==========================================================================
'   BMNMTA.DBM   部門マスタ　                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_BMNMTA
    DATKB           As String * 1       '伝票削除区分
    BMNCD           As String * 6       '部門コード
    STTTKDT         As String * 8       '適用開始日
    ENDTKDT         As String * 8       '適用終了日
    BMNNM           As String * 40      '部門名称
    BMNZP           As String * 20      '郵便番号
    BMNADA          As String * 60      '住所１
    BMNADB          As String * 60      '住所２
    BMNADC          As String * 60      '住所３
    BMNTL           As String * 20      '電話番号
    BMNFX           As String * 20      'FAX番号
    BMNURL          As String * 50      'URL
    BMNCDUP         As String * 6       '上位部門コード
    BMNLV           As Currency         '階層
    ZMJGYCD         As String * 1       '会計事業所コード
    ZMCD            As String * 1       '会計区分コード
    ZMBMNCD         As String * 3       '会計部門コード
    EIGYOCD         As String * 1       '営業所コード
    TIKKB           As String * 1       '地区区分
    HTANCD          As String * 3       '発注担当コード
    STANCD          As String * 3       '生産担当コード
    BMNPRNM         As String * 40      '印字用名称
    RELFL           As String * 1       '連携フラグ
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type
Global DB_BMNMTA As TYPE_DB_BMNMTA
Global DBN_BMNMTA As Integer

' === 20060828 === INSERT S - ACE)Nagasawa 適用日対応
'基準日検索条件
Public WLSBMN_KJNDT         As String           '基準日
' === 20060828 === INSERT E -

' === 20061204 === INSERT S - ACE)Nagasawa 見積/受注では営業部門のみ入力
Public WLSBMN_EIGYO         As String           '営業部門検索（空白:全件表示 "1":営業部門のみ)
' === 20061204 === INSERT E -

'部門マスタ検索戻り値
Public WLSBMN_RTNCODE       As String           '部門コード

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_BMNMTA_Clear
    '   概要：  部門マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_BMNMTA_Clear(ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA)

        Dim Clr_DB_BMNMTA As TYPE_DB_BMNMTA
    
        pot_DB_BMNMTA = Clr_DB_BMNMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPBMNCD_SEARCH
    '   概要：  部門コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20060828 === UPDATE S - ACE)Sejima
'D    Public Function DSPBMNCD_SEARCH(ByVal pin_strBMNCD As String, _
'D                                    ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA) As Integer
' === 20060828 === UPDATE ↓
    Public Function DSPBMNCD_SEARCH(ByVal pin_strBMNCD As String, _
                                    ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA, _
                           Optional ByVal pin_strDate As String = "") As Integer
' === 20060828 === UPDATE E

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPBMNCD_SEARCH
    
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
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPBMNCD_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_BMNMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "")                    '部門コード
                .STTTKDT = CF_Ora_GetDyn(Usr_Ody, "STTTKDT", "")                '適用開始日
                .ENDTKDT = CF_Ora_GetDyn(Usr_Ody, "ENDTKDT", "")                '適用終了日
                .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "")                    '部門名称
                .BMNZP = CF_Ora_GetDyn(Usr_Ody, "BMNZP", "")                    '郵便番号
                .BMNADA = CF_Ora_GetDyn(Usr_Ody, "BMNADA", "")                  '住所１
                .BMNADB = CF_Ora_GetDyn(Usr_Ody, "BMNADB", "")                  '住所２
                .BMNADC = CF_Ora_GetDyn(Usr_Ody, "BMNADC", "")                  '住所３
                .BMNTL = CF_Ora_GetDyn(Usr_Ody, "BMNTL", "")                    '電話番号
                .BMNFX = CF_Ora_GetDyn(Usr_Ody, "BMNFX", "")                    'FAX番号
                .BMNURL = CF_Ora_GetDyn(Usr_Ody, "BMNURL", "")                  'URL
                .BMNCDUP = CF_Ora_GetDyn(Usr_Ody, "BMNCDUP", "")                '上位部門コード
                .BMNLV = CF_Ora_GetDyn(Usr_Ody, "BMNLV", 0)                     '階層
                .ZMJGYCD = CF_Ora_GetDyn(Usr_Ody, "ZMJGYCD", "")                '会計事業所コード
                .ZMCD = CF_Ora_GetDyn(Usr_Ody, "ZMCD", "")                      '会計区分コード
                .ZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "")                '会計部門コード
                .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "")                '営業所コード
                .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "")                    '地区区分
                .HTANCD = CF_Ora_GetDyn(Usr_Ody, "HTANCD", "")                  '発注担当コード
                .STANCD = CF_Ora_GetDyn(Usr_Ody, "STANCD", "")                  '生産担当コード
                .BMNPRNM = CF_Ora_GetDyn(Usr_Ody, "BMNPRNM", "")                '印字用名称
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        

        DSPBMNCD_SEARCH = 0
        
        Exit Function
    
ERR_DSPBMNCD_SEARCH:
        
        
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
    Public Function DSPEIGYOCD_SEARCH(ByVal pin_strEIGYOCD As String, _
                                      ByRef pot_DB_BMNMTA As TYPE_DB_BMNMTA, _
                                      Optional ByVal pin_strDate As String = "") As Integer

        Dim strSQL          As String
        Dim strDate         As String
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPEIGYOCD_SEARCH
    
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
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPEIGYOCD_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_BMNMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .BMNCD = CF_Ora_GetDyn(Usr_Ody, "BMNCD", "")                    '部門コード
                .STTTKDT = CF_Ora_GetDyn(Usr_Ody, "STTTKDT", "")                '適用開始日
                .ENDTKDT = CF_Ora_GetDyn(Usr_Ody, "ENDTKDT", "")                '適用終了日
                .BMNNM = CF_Ora_GetDyn(Usr_Ody, "BMNNM", "")                    '部門名称
                .BMNZP = CF_Ora_GetDyn(Usr_Ody, "BMNZP", "")                    '郵便番号
                .BMNADA = CF_Ora_GetDyn(Usr_Ody, "BMNADA", "")                  '住所１
                .BMNADB = CF_Ora_GetDyn(Usr_Ody, "BMNADB", "")                  '住所２
                .BMNADC = CF_Ora_GetDyn(Usr_Ody, "BMNADC", "")                  '住所３
                .BMNTL = CF_Ora_GetDyn(Usr_Ody, "BMNTL", "")                    '電話番号
                .BMNFX = CF_Ora_GetDyn(Usr_Ody, "BMNFX", "")                    'FAX番号
                .BMNURL = CF_Ora_GetDyn(Usr_Ody, "BMNURL", "")                  'URL
                .BMNCDUP = CF_Ora_GetDyn(Usr_Ody, "BMNCDUP", "")                '上位部門コード
                .BMNLV = CF_Ora_GetDyn(Usr_Ody, "BMNLV", 0)                     '階層
                .ZMJGYCD = CF_Ora_GetDyn(Usr_Ody, "ZMJGYCD", "")                '会計事業所コード
                .ZMCD = CF_Ora_GetDyn(Usr_Ody, "ZMCD", "")                      '会計区分コード
                .ZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "")                '会計部門コード
                .EIGYOCD = CF_Ora_GetDyn(Usr_Ody, "EIGYOCD", "")                '営業所コード
                .TIKKB = CF_Ora_GetDyn(Usr_Ody, "TIKKB", "")                    '地区区分
                .HTANCD = CF_Ora_GetDyn(Usr_Ody, "HTANCD", "")                  '発注担当コード
                .STANCD = CF_Ora_GetDyn(Usr_Ody, "STANCD", "")                  '生産担当コード
                .BMNPRNM = CF_Ora_GetDyn(Usr_Ody, "BMNPRNM", "")                '印字用名称
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        

        DSPEIGYOCD_SEARCH = 0
        
        Exit Function
    
ERR_DSPEIGYOCD_SEARCH:
        
        
    End Function
' === 20061215 === INSERT E -

