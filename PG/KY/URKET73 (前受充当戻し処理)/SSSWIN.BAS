Attribute VB_Name = "SSSWIN"
Option Explicit


'******************************************************************'
'* PG名:URKET73 入金消込
'* 更新日   : 2008/07/25
'* 更新者   : FKS)中田
'* 処理内容 : 明細が2行以上ある受注に対し、返品登録を行った後
'*            受注訂正を行うと本来出力対象にあらないデータが
'*            画面上に出てきてしまうのを修正
'******************************************************************'


'--------------------
'■関数部
'--------------------


Public Function AnsiStrConv(varArg As Variant, _
                            varCnv As Variant)
'概要：文字列のｺｰﾄﾞ変換
'引数：varArg,Input,Variant,変換元文字列
'　　：varCnv,Input,Variant,conversion定数(StrConv 関数参照)
'説明：Ａｎｓｉ ⇔ ＵｎｉＣｏｄｅに変換した文字列を返す

#If Win32 Then
    AnsiStrConv = StrConv(varArg, varCnv)
  #Else
    AnsiStrConv = varArg
#End If

End Function

Public Function AnsiLenB(ByVal strArg As String) As Long
'概要：文字数カウント
'引数：strArg,Input,String,対象文字列
'説明：Ａｎｓｉコードのバイトオーダで文字列のﾊﾞｲﾄ数を返す

#If Win32 Then
    AnsiLenB = LenB(AnsiStrConv(strArg, vbFromUnicode))
  #Else
    AnsiLenB = LenB(strArg)
#End If

End Function

Public Function LenWid(ByVal pm_Characters As Variant) As Variant
    If IsNull(pm_Characters) Then
'        Call AE_SystemError("LenWid のパラメタに", 190)
        LenWid = Null
        Exit Function '--------------------
    End If
    LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
End Function

Public Function LeftWid$(ByVal pm_Characters$, ByVal pm_Wid As Long)
    LeftWid$ = StrConv(LeftB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid), vbUnicode)
End Function

Public Function MidWid$(ByVal pm_Characters$, ByVal pm_Wid As Long, Optional ByVal pm_LnWid)
    If IsMissing(pm_LnWid) Then
        MidWid$ = StrConv(MidB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid), vbUnicode)
    Else
        MidWid$ = StrConv(MidB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid, pm_LnWid), vbUnicode)
    End If
End Function

Public Function RightWid$(ByVal pm_Characters$, ByVal pm_Wid As Long)
    RightWid$ = StrConv(RightB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid), vbUnicode)
End Function

Function Get_DBHEAD() As String
'現在の環境のDBHEAD を返す、環境未設定の場合は、""を返す。
Dim ret%, wkStr As String * 128

    Get_DBHEAD = ""
    ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr, 128, ByVal "SSSWIN.INI")
    If ret > 0 Then Get_DBHEAD = Left$(wkStr, ret)
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Init
'   概要：  プログラム起動時初期処理
'   引数：  なし
'   戻値：  なし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Sub CF_Init()

    'Dim datDT           As Date
    'Dim strYMD          As String
    'Dim strUNYDT        As String
    Dim intLenCommand   As String
    'Dim intRet          As Integer
    
    '二重起動ﾁｪｯｸ
    If App.PrevInstance Then
        MsgBox "【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", vbExclamation Or vbOKOnly, SSS_PrgNm
        End
    End If
    

    ' "しばらくお待ちください" ウィンドウ表示
    Load ICN_ICON

    
    '---------------------
    ' 起動パラメータ設定
    '---------------------
    intLenCommand = LenWid(Trim$(Command$))
    If intLenCommand < 15 Then
        MsgBox "メニューから実行してください。", vbOKOnly, SSS_PrgNm
        End
        'Call Error_Exit("メニューから実行してください。")
    End If
    
    SSS_CLTID = MidWid$(Command$, 2, 5)
    SSS_OPEID = MidWid$(Command$, 7, 6)
    
    '---------------------
    ' SSSWIN.INI テーブル設定
    '---------------------
    strINIDATNM(0) = "USR_PATH"
    strINIDATNM(1) = "DAT_PATH"
    strINIDATNM(2) = "PRG_PATH"
    strINIDATNM(3) = "WRK_PATH"
    strINIDATNM(4) = "IMG_PATH"
    SSS_INICnt = 4
    'Iniファイル読込み
    Call CF_INIT_GETINI
    

    ' "しばらくお待ちください" ウィンドウ消去
    Unload ICN_ICON


End Sub

Function SSSVal(INP_Value As Variant) As Variant
    If IsNumeric(INP_Value) = True Then
        SSSVal = CCur(INP_Value)
    Else
        SSSVal = 0
    End If
End Function

Function CNV_DATE(pdate As String) As String

    If LenWid(pdate) = 8 Then
        CNV_DATE = LeftWid$(pdate, 4) & "/" & MidWid$(pdate, 5, 2) & "/" & RightWid$(pdate, 2)
    ElseIf LenWid(pdate) = 6 Then
        CNV_DATE = LeftWid$(pdate, 2) & "/" & MidWid$(pdate, 3, 2) & "/" & RightWid$(pdate, 2)
    Else
        CNV_DATE = ""
    End If
End Function

Function DeCNV_DATE(pdate As String) As String
    '
    If LenWid(pdate) = 10 Then
        DeCNV_DATE = LeftWid$(pdate, 4) & MidWid$(pdate, 6, 2) & RightWid$(pdate, 2)
    ElseIf LenWid(pdate) = 8 Then
        DeCNV_DATE = LeftWid$(pdate, 2) & MidWid$(pdate, 4, 2) & RightWid$(pdate, 2)
    Else
        DeCNV_DATE = ""
    End If
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_INIT_GETINI
    '   概要：  INIファイル読込み（共通）
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Sub CF_INIT_GETINI()
    Dim WL_WinDir As String, i As Integer, LENGTH As Integer
    Dim rtnPara As String * MAX_PATH
    '---------------------
    ' SSSWIN.INI 読込み
    '---------------------
    For i = 0 To SSS_INICnt
        rtnPara = ""
        LENGTH = GetPrivateProfileString("SSSWIN", ByVal strINIDATNM(i), "", rtnPara, Len(rtnPara), ByVal "SSSWIN.INI")
        If LENGTH = 0 Then
            MsgBox "SSSWIN.INI を確認してください。" & Chr(13) & "[" & strINIDATNM(i) & "]"
'            Call Error_Exit("SSSUSR.INI を確認してください。[" & strINIDATNM(I) & "]")
        Else
            SSS_INIDAT(i) = LeftWid$(rtnPara, LENGTH)
        End If
        If Right$(SSS_INIDAT(i), 1) <> "\" And Right$(SSS_INIDAT(i), 1) <> ":" Then SSS_INIDAT(i) = SSS_INIDAT(i) & "\"
    Next i
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   引数：  Pin_strDate     : 計算対象日付(８桁の数値Or日付）
'           Pin_strTOKSMEKB : 締区分
'           Pin_strTOKSMEDD : 締初期日付（売上）
'           Pin_strTOKSMECC : 締サイクル（売上）
'           Pin_strTOKSDWKB : 締め曜日
'   備考：改造(Saito 2007/02/24)
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function getSmedt(ByVal pin_strDate As String, _
                     ByVal Pin_strTOKSMEKB As String, _
                     ByVal Pin_strTOKSMEDD As String, _
                     ByVal Pin_strTOKSMECC As String, _
                     ByVal Pin_strTOKSDWKB As String) As String
                     
    Dim strDate     As String
    Dim yy          As Integer
    Dim mm          As Integer
    Dim dd          As Integer
    Dim Cnt         As Integer
    Dim i           As Integer
    Dim setidx      As Integer
    Dim idx         As Integer
    Dim addMM       As Integer
    Dim smeday(15)  As Integer
    Dim intToksmeCc As Integer
    Dim intToksmeDD As Integer
    Dim intTOKSDWKB As Integer
    Dim strSmedt    As String
    
    getSmedt = ""
    
    '日付チェック
    If IsDate(pin_strDate) = True Then
        strDate = Format(pin_strDate, "yyyy/mm/dd")
    Else
        If IsDate(Format(pin_strDate, "@@@@/@@/@@")) = True Then
            strDate = Format(pin_strDate, "@@@@/@@/@@")
        Else
            Exit Function
        End If
    End If
    
    yy = Year(strDate)
    mm = Month(strDate)
    dd = Day(strDate)
   
    '締区分＝"日"の場合
    If Pin_strTOKSMEKB = 1 Then
        '締初期日付取得
        If IsNumeric(Pin_strTOKSMEDD) = True Then
            intToksmeDD = CInt(Pin_strTOKSMEDD)
        Else
            Exit Function
        End If
    
        '締サイクル取得
        If IsNumeric(Pin_strTOKSMECC) = True Then
            intToksmeCc = CInt(Pin_strTOKSMECC)
        Else
            Exit Function
        End If
        
        If intToksmeCc = 1 Then         '毎日締め
            getSmedt = DeCNV_DATE(CStr(DateSerial(yy, mm, dd)))
            Exit Function
        End If
        '
        If intToksmeCc <= 0 Or intToksmeCc > 15 Then intToksmeCc = 30
        Cnt = Int(30 / intToksmeCc) '締回数／月
        setidx = False
        For i = 0 To Cnt - 1
            smeday(i) = intToksmeDD + intToksmeCc * i
            If smeday(i) > 27 Then smeday(i) = 99
            If dd <= smeday(i) And setidx = False Then
                'idx = I + Pin_intCHTNKB '該当日付の締日配列添字
                setidx = True
            End If
        Next i
        If setidx = False Then idx = Cnt '+ Pin_intCHTNKB
        addMM = Int(idx / Cnt)
        idx = idx Mod Cnt
        If idx < 0 Then idx = idx + Cnt
        '
        If smeday(idx) = 99 Then
            strSmedt = CStr(DateSerial(yy, mm + addMM + 1, 0))
        Else
            strSmedt = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
        End If
        
    Else
        '締曜日取得
        If IsNumeric(Pin_strTOKSDWKB) = True Then
            intTOKSDWKB = CInt(Pin_strTOKSDWKB)
        Else
            Exit Function
        End If
        
        '締日区分＝"曜日"の場合
        If Weekday(strDate) > intTOKSDWKB Then
            strSmedt = CStr(DateSerial(Year(strDate), Month(strDate), Day(strDate) + (7 - Weekday(strDate) + intTOKSDWKB)))
        Else
            strSmedt = CStr(DateSerial(Year(strDate), Month(strDate), Day(strDate) + (intTOKSDWKB - Weekday(strDate))))
        End If
    End If
    
    getSmedt = DeCNV_DATE(strSmedt)
    
    
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Function GET_MEIMTA_KANKOZ
'   概要： 名称マスタ存在チェック
'   引数： pin_MEICDA   : 名称キー
'   戻値： 0:正常終了 9:異常終了 8:削除済みレコード
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function GET_MEIMTA_KANKOZ(ByVal pin_MEICDA As String) As Integer

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    Dim strMEICDA       As String
    
    On Error GoTo ERR_GET_MEIMTA_KANKOZ

    GET_MEIMTA_KANKOZ = 9
    
    strMEICDA = Trim(pin_MEICDA) & Space(10)
    
    strSql = ""
    strSql = strSql & vbCrLf & "Select * From MEIMTA"
    strSql = strSql & vbCrLf & " Where KEYCD    = '062'"
    strSql = strSql & vbCrLf & "   And MEICDA   = " & "'" & Mid(Trim(strMEICDA) & Space(20), 2, 9) & "'"
    strSql = strSql & vbCrLf & "   And MEICDB   = " & "'" & Left(Trim(strMEICDA) & Space(5), 1) & "'"

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    If CF_Ora_EOF(Usr_Ody) = False Then
        
        Select Case CF_Ora_GetDyn(Usr_Ody, "DATKB", "")
            Case "1"
                GET_MEIMTA_KANKOZ = 0
            Case "9"
                GET_MEIMTA_KANKOZ = 8
        End Select

        
        GoTo END_GET_MEIMTA_KANKOZ
    End If
    
END_GET_MEIMTA_KANKOZ:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_GET_MEIMTA_KANKOZ:
    GoTo END_GET_MEIMTA_KANKOZ
    
End Function

'**************************************************************************************************
'プロシジャ名   ：Get_Authority
'処理概要       ：プログラムの実行権限を取得する
'                 CrystalReportのプレビュー画面の印刷ボタンをユーザ権限によって制御する
'引数   １：ec_DATE(担当者の適用日を判断する日付)
'       ２：ec_CRW(CrystalReportコントロール名) オプション
'戻値   1：権限マスタにデータ有り
'       9：権限マスタにデータなし
'**************************************************************************************************
Public Function Get_Authority(ec_DATE As String, Optional ec_CRW As Control) As String

'変数宣言
    Dim strSql      As String
    Dim Usr_Ody     As U_Ody

    '初期値は全権限なし
    gs_UPDAUTH = "9"        '更新権限
    gs_PRTAUTH = "9"        '印刷権限
    gs_FILEAUTH = "9"       'ファイル出力権限
    gs_SALTAUTH = "9"       '販売単価変更権限
    gs_HDNTAUTH = "9"       '発注単価変更権限
    gs_SAPMAUTH = "9"       '販売計画年初計画修正権限

    'ユーザIDから印刷権限を取得する
    strSql = "Select"
    strSql = strSql & " K.UPDAUTH"
    strSql = strSql & ",K.PRTAUTH"
    strSql = strSql & ",K.FILEAUTH"
    strSql = strSql & ",K.SALTAUTH"
    strSql = strSql & ",K.HDNTAUTH"
    strSql = strSql & ",K.SAPMAUTH"
    strSql = strSql & " From KNGMTB K"
    strSql = strSql & "     ,TANMTA T"
    strSql = strSql & " Where K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END)"
    strSql = strSql & "   And T.TANCD   = " & "'" & Trim(SSS_OPEID) & "'"
    strSql = strSql & "   And K.PGID    = " & "'" & SSS_PrgId & "'"
    strSql = strSql & "   And K.DATKB   = '1'"
    strSql = strSql & "   And T.DATKB   = '1'"

    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    If CF_Ora_EOF(Usr_Ody) = True Then
        '取得データなしの場合は権限なしとみなす。
        Get_Authority = 9
    Else
        Do While CF_Ora_EOF(Usr_Ody) = False

            gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "")      '更新権限
            gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "")      '印刷権限
            gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "")    'ファイル出力権限
            gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "")    '販売単価変更権限
            gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "")    '発注単価変更権限
            gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "")    '販売計画年初計画修正権限
             
            '次レコード
            Usr_Ody.Obj_Ody.MoveNext
        Loop
        Get_Authority = 1
    End If

    If ec_CRW Is Nothing Then
    Else
        If gs_PRTAUTH = "1" Then
            '印刷権限がある場合
            ec_CRW.WindowShowPrintBtn = True    '印刷ボタン
        Else
            '印刷権限が無い場合
            ec_CRW.WindowShowPrintBtn = False   '印刷ボタン
        End If
        If gs_FILEAUTH = "1" Then
            'エクスポート権限がある場合
            ec_CRW.WindowShowExportBtn = True   'エクスポートボタン
        Else
            'エクスポート権限が無い場合
            ec_CRW.WindowShowExportBtn = False  'エクスポートボタン
        End If
    End If

End Function

Function Get_Acedt(ByVal wdate As String) As String
' 該当経理締日付
    
    wdate = CNV_DATE(wdate)
'    If Not CHECK_DATE(wdate) Then
'        Call Error_Exit("日付エラー(Get_Acedt): " & wdate)
'    End If
    If DB_SYSTBA.SMADD > "27" Then
        Get_Acedt = CStr(DateSerial(Year(wdate), Month(wdate) + 1, 0))
    ElseIf Right$(wdate, 2) <= DB_SYSTBA.SMADD Then
        Get_Acedt = Left$(wdate, 8) & DB_SYSTBA.SMADD
    Else
        Get_Acedt = CStr(DateSerial(Year(wdate), Month(wdate) + 1, SSSVal(DB_SYSTBA.SMADD)))
    End If
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function GET_TANMTA_KEIBMNCD
'   概要：  経理部門コードを取得
'   引数：　pot_TANCD       : 担当者コード
'       ：　pot_KEIBMNCD    : 経理部門コード
'   戻値：　0:正常終了 9:異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function GET_TANMTA_KEIBMNCD(ByRef pot_TANCD As String, _
                                    ByRef pot_KEIBMNCD As String) As Integer

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    
'2009/06/15 連絡票№664対応 START
    Dim strKEIBMNCD     As String       '所属部門コード
    Dim strOLDBMNCD     As String       '旧所属部門コード
    Dim strTANTKDT      As String       '適用日
    Dim strZMBMNCD      As String       '会計部門コード
'2009/06/15 連絡票№664対応 E.N.D
    
    On Error GoTo ERR_GET_TANMTA_KEIBMNCD
    
    GET_TANMTA_KEIBMNCD = 9
    
'2009/06/15 連絡票№664対応 START
'    strSql = ""
'    strSql = strSql & "Select KEIBMNCD From TANMTA"
'    strSql = strSql & " Where TANCD  = " & "'" & pot_TANCD & "'"
'
'    'DBアクセス
'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'    If CF_Ora_EOF(Usr_Ody) = False Then
'        pot_KEIBMNCD = CF_Ora_GetDyn(Usr_Ody, "KEIBMNCD", "")
'        GET_TANMTA_KEIBMNCD = 0
'
'        GoTo END_GET_TANMTA_KEIBMNCD
'    End If

    '担当者Ｍ
    strSql = ""
    strSql = strSql & "Select TANBMNCD,OLDBMNCD,TANTKDT From TANMTA"
    strSql = strSql & " Where TANCD  = " & "'" & pot_TANCD & "'"

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    If CF_Ora_EOF(Usr_Ody) = False Then
        strKEIBMNCD = CF_Ora_GetDyn(Usr_Ody, "TANBMNCD", "")
        strOLDBMNCD = CF_Ora_GetDyn(Usr_Ody, "OLDBMNCD", "")
        strTANTKDT = CF_Ora_GetDyn(Usr_Ody, "TANTKDT", "")
    Else
        GoTo END_GET_TANMTA_KEIBMNCD:
    End If

'2009/06/15 連絡票№664対応 E.N.D

    '部門Ｍ
    strSql = ""
    strSql = strSql & "Select ZMBMNCD From BMNMTA"
    If SSSVal(gstrKesidt) >= SSSVal(strTANTKDT) Then
        strSql = strSql & " Where BMNCD = " & "'" & strKEIBMNCD & "'"
    Else
        strSql = strSql & " Where BMNCD = " & "'" & strOLDBMNCD & "'"
    End If
    strSql = strSql & "   and " & "'" & gstrKesidt & "'" & " BETWEEN STTTKDT AND ENDTKDT "

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    If CF_Ora_EOF(Usr_Ody) = False Then
        strZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "")
    Else
        GoTo END_GET_TANMTA_KEIBMNCD:
    End If

    '経理部門コードを引数へ設定する
    pot_KEIBMNCD = strZMBMNCD


        
    GET_TANMTA_KEIBMNCD = 0
    
END_GET_TANMTA_KEIBMNCD:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_GET_TANMTA_KEIBMNCD:
    GoTo END_GET_TANMTA_KEIBMNCD
    
End Function


Function SSS_WEEKNM(ByVal idx As Integer) As String
' 曜日名を返す。
    Select Case idx
        Case 1
            SSS_WEEKNM = "日曜日"
        Case 2
            SSS_WEEKNM = "月曜日"
        Case 3
            SSS_WEEKNM = "火曜日"
        Case 4
            SSS_WEEKNM = "水曜日"
        Case 5
            SSS_WEEKNM = "木曜日"
        Case 6
            SSS_WEEKNM = "金曜日"
        Case 7
            SSS_WEEKNM = "土曜日"
        Case Else
            SSS_WEEKNM = ""
    End Select
End Function

'ログファイルの書き出し
'若干改造
Sub SSSWIN_LOGWRT(ByVal LogMsg As String)
Dim Fno As Integer, errcnt As Integer, rtn As Integer
Dim wbuf As String
'    '
'    Call ResetDBSTAT(DBN_SYSTBE)
'    '
    LSet DB_SYSTBE = DB_CLRREC
    DB_SYSTBE.PRGID = SSS_PrgId
    DB_SYSTBE.LOGNM = LogMsg
    DB_SYSTBE.OPEID = SSS_OPEID
    DB_SYSTBE.CLTID = SSS_CLTID
    DB_SYSTBE.WRTTM = Format$(Now, "hhnnss")
    DB_SYSTBE.WRTDT = Format$(Now, "YYYYMMDD")
    
    errcnt = 0
    Fno = FreeFile
    On Error Resume Next
    'ディレクトリ存在チェック
    wbuf = Dir$(SSS_INIDAT(1), 16)
    If wbuf = "" Then
        Call MsgBox("SSSWIN.INI の DAT_PATH の設定されているディレクトリが存在しません。" & Chr(13) & "SSSWIN.INIを修正して下さい。", 48)
        'Call WRT_ERRLOG(0, "              USR_PATH=" & USR_PATH)
        '''Call SSS_CLOSE
        rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
        End
    End If
    Err = 0
    On Error GoTo ErrorLogFile
    Open SSS_INIDAT(1) & SSS_PrgId & ".DTA" For Append Access Write Lock Write As Fno
'    Open SSS_INIDAT(1) & "SYSTBE.DTA" For Append Access Write Lock Write As Fno
    On Error GoTo 0
'    Print #Fno, SSS_PrgId & LogMsg & SSS_OPEID & SSS_CLTID & Format$(Now, "hhnnss") & Format$(Now, "YYYYMMDD")
    Print #Fno, DB_SYSTBE.PRGID & DB_SYSTBE.LOGNM & DB_SYSTBE.OPEID & DB_SYSTBE.CLTID & DB_SYSTBE.WRTTM & DB_SYSTBE.WRTDT
    Close #Fno
    Exit Sub
ErrorLogFile:
    errcnt = errcnt + 1
    If errcnt > SSS_ReTryCnt Then
        If MsgBox("履歴ファイルロックエラー !" & Chr$(13) & "中止しても宜しいですか？", 20) = 6 Then
            '''Call SSS_CLOSE
            rtn = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
            End
        Else
            errcnt = 0
        End If
    End If
    DoEvents
    Resume
End Sub

'Sub ResetBuf(ByVal Fno As Integer)  'Generated.
'End Sub
'

'=======================================================Saito作成分=======================================================


'ｸﾞﾛｰﾊﾞﾙ変数の初期化
Public Sub initVal()
    gstrKesidt = Space(8)
    gstrKaidt_Fr = Space(8)
    gstrKaidt_To = Space(8)
    gstrTokseicd = Space(5)
    gstrFridt = Space(8)
    
    With DB_TOKMTA
        .TOKSEICD = Space(5)
        .TOKNMA = Space(60)
        .TOKSMEDT = Space(8)
        .SHAKB = Space(1)
        .SHAKBNM = Space(10)
        .TOKSMEKB = Space(1)
        .TOKSMEDD = Space(2)
        .TOKSMECC = Space(2)
        .TOKSDWKB = Space(1)
        .TOKKESDD = Space(2)
        .TOKKESCC = Space(2)
        .HYTOKKESDD = Space(2)
        .TOKKDWKB = Space(1)
        .KESISMEDT = Space(8)
        .FRNKB = Space(1)
        .TUKKB = Space(3)
        .TOKJUNKB = Space(1)
        .TOKMSTKB = Space(1)
        .TKNRPSKB = Space(1)
        .TKNZRNKB = Space(1)
        .TOKZEIKB = Space(1)
        .TOKZCLKB = Space(1)
        .TOKRPSKB = Space(1)
        .TOKZRNKB = Space(1)
        .TOKNMMKB = Space(1)
    End With
End Sub

'運用日日付を取得する
Public Function getUnydt() As String
    Dim Usr_Ody As U_Ody
    Dim strSql As String
    
    strSql = "SELECT unydt FROM unymta"
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    getUnydt = CF_Ora_GetDyn(Usr_Ody, "unydt", "")
    GV_UNYDate = getUnydt       '2007.03.05
    
    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
End Function

'SYSTBA情報を取得する
Public Sub getSYSTBA()
    Dim Usr_Ody     As U_Ody
    Dim strSql      As String
    
    strSql = "SELECT * FROM systba"
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        DB_SYSTBA.SMAUPDDT = CF_Ora_GetDyn(Usr_Ody, "smaupddt", "")
        DB_SYSTBA.MONUPDDT = CF_Ora_GetDyn(Usr_Ody, "monupddt", "")
        DB_SYSTBA.SMADD = CF_Ora_GetDyn(Usr_Ody, "smadd", "")
    End If
     
    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
End Sub

'担当者名を取得する
Public Function getTannm(strTancd As String) As String
    Dim Usr_Ody As U_Ody
    Dim strSql As String
    
    strSql = "SELECT tannm FROM tanmta" _
          & " WHERE tancd = '" & strTancd & "'"
          
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    getTannm = CF_Ora_GetDyn(Usr_Ody, "tannm", "")
 
    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
End Function

'現在日付、時刻をセットする
Public Sub setSysdate(ByRef strWRTTM As String, ByRef strWRTDT As String)
    Dim Usr_Ody As U_Ody
    Dim strSql As String
    
    strSql = "SELECT TO_CHAR(SYSDATE, 'HH24MISS') wrttm, " _
                  & "TO_CHAR(SYSDATE, 'YYYYMMDD') wrtdt " _
             & "FROM dual"
          
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        strWRTTM = CF_Ora_GetDyn(Usr_Ody, "wrttm", "")
        strWRTDT = CF_Ora_GetDyn(Usr_Ody, "wrtdt", "")
    End If
    
    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
End Sub

'請求先名を取得する(同時に支払条件、請求締日、消込日における締日を取得)
'0:国内取引先
'1:海外取引先
'8:請求先ではない得意先
'9:該当データなし
Public Function getTokseinm(strKesidt As String, ByVal strTokseicd As String) As Integer
    Dim Usr_Ody As U_Ody
    Dim strSql  As String
    '支払条件の名称宣言
    Dim SHAKB_NAME() As Variant
   
    getTokseinm = 9
    
    SHAKB_NAME = Array("", "振込", "手形", "振込または手形", "振込手形併用", "期日振込", "ﾌｧｸﾀﾘﾝｸﾞ")
  
    strSql = "SELECT * FROM tokmta " _
            & "WHERE tokcd = '" & strTokseicd & "' " _
              & "AND tokcd = tokseicd"
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        With DB_TOKMTA
            .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
            .TOKNMA = CF_Ora_GetDyn(Usr_Ody, "toknma", "")
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "tokrn", "")
            .TOKSMEDT = CF_Ora_GetDyn(Usr_Ody, "toksmedt", "")
            .SHAKB = CF_Ora_GetDyn(Usr_Ody, "shakb", "")
            .SHAKBNM = SHAKB_NAME(SSSVal(CF_Ora_GetDyn(Usr_Ody, "shakb", "")))
            
            .TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "toksmekb", "")
            .TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "toksmedd", "")
            .TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "toksmecc", "")
            .TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "toksdwkb", "")
            .TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "tokkescc", "")
            .TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "tokkesdd", "")
            .TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "tokkdwkb", "")
            .FRNKB = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")
            .TUKKB = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")
            .TOKJUNKB = CF_Ora_GetDyn(Usr_Ody, "tokjunkb", "")
            .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "tokmstkb", "")
            .TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "tknrpskb", "")
            .TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "tknzrnkb", "")
            .TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "tokzeikb", "")
            .TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "tokzclkb", "")
            .TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "tokrpskb", "")
            .TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "tokzrnkb", "")
            .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "toknmmkb", "")
            .TANCD = CF_Ora_GetDyn(Usr_Ody, "tancd", "")
            
            If .TOKSMEKB = "1" Then
                '日締め
                If SSSVal(.TOKSMEDD) > 27 Then
                    .HYTOKKESDD = "末日"
                Else
                    .HYTOKKESDD = .TOKSMEDD & "日"
                End If
            Else
                '週締め
                .HYTOKKESDD = "週締"
            End If
            
            '消込日における締日を取得
            .KESISMEDT = getSmedt(strKesidt, .TOKSMEKB, .TOKSMEDD, .TOKSMECC, .TOKSDWKB)
            
            getTokseinm = SSSVal(.FRNKB)
        End With
    Else
        '請求先ではない得意先として存在すれば8を返す 2007/02/28 Add
        strSql = "SELECT * FROM tokmta WHERE tokcd = '" & strTokseicd & "'"
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
        If CF_Ora_EOF(Usr_Ody) = True Then
            getTokseinm = 9
        Else
            getTokseinm = 8
        End If
    End If
    
    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
End Function

'引数に含まれる全角項目を削除し、その値を返す
Public Function delZenkaku(strText As String) As String
    Dim tmp1    As String
    Dim tmp2    As String
    Dim i       As Long
    
    If strText = "" Then Exit Function

    tmp2 = ""
    
    For i = 1 To Len(strText)
        tmp1 = Mid(strText, i, 1)

        '半角以外の文字は無効にする
        If Len(tmp1) = AnsiLenB(tmp1) Then
        Else
            tmp1 = Space(1)
        End If

        tmp2 = tmp2 & tmp1
    Next
    
    delZenkaku = tmp2
End Function

'メッセージボックスの表示
Public Function showMsg(strMsgkb As String, strMsgnm As String, strMsgsq As String) As VbMsgBoxResult
    Dim Usr_Ody     As U_Ody
    Dim strSql      As String
    Dim strMsgcm    As String
    Dim intMsgkb    As Integer
    
    strSql = "SELECT * FROM systbh"
    strSql = strSql & " WHERE msgkb = '" & Trim$(strMsgkb) & "'"
    strSql = strSql & "   AND msgnm = '" & Trim$(strMsgnm) & "'"
    strSql = strSql & "   AND msgsq = '" & Trim$(strMsgsq) & "'"
    
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    strMsgcm = CF_Ora_GetDyn(Usr_Ody, "msgcm", "")
    intMsgkb = Int(CF_Ora_GetDyn(Usr_Ody, "btnkb", ""))
    intMsgkb = intMsgkb + Int(CF_Ora_GetDyn(Usr_Ody, "btnon", ""))
    intMsgkb = intMsgkb + Int(CF_Ora_GetDyn(Usr_Ody, "icnkb", ""))
    
    showMsg = MsgBox(Trim$(strMsgcm), intMsgkb, Trim$(SSS_PrgNm))
End Function



'回収予定日を取得する
'スラッシュなしで返す
Public Function getKesdt(strToksmekb As String, strToksmedt As String, strToksmecc As String, strToksdwkb As String _
    , strTokkescc As String, strTokkesdd As String, strTokkdwkb As String, ByVal strDate As String) As String
    
Dim tmp As Integer
    
    'スラッシュつきに変換
    strDate = CNV_DATE(strDate)
    '日締め
    If strToksmekb = "1" Then
        If SSSVal(strToksmecc) = 1 Then
            getKesdt = DeCNV_DATE(strDate)
            Exit Function
        End If
        
        tmp = SSSVal(strTokkesdd)
        If tmp = 99 Then tmp = 30
        If tmp > 27 Then
            getKesdt = DeCNV_DATE(CStr(DateSerial(Year(strDate), Month(strDate) + SSSVal(strTokkescc) + 1, 0)))
        Else
            getKesdt = DeCNV_DATE(CStr(DateSerial(Year(strDate), Month(strDate) + SSSVal(strTokkescc), tmp)))
        End If
    '週締め
    Else
        getKesdt = DeCNV_DATE(CStr(DateSerial(Year(strDate), Month(strDate), Day(strDate) _
           + SSSVal(strTokkescc) * 7 + SSSVal(strTokkdwkb) - SSSVal(strToksdwkb))))
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Function getDkbnm
'   概要： 入金種別名称を取得
'   引数： pin_MEICDA   : 名称キー  intRow  :行番号
'   戻値： 区分名称
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function getDkbnm(strDKBID As String, intRow As Integer) As String
    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    
    On Error GoTo ERR_GET_DKBNM

    getDkbnm = ""
    
    'dkbflbが1のものが差額入金で選択できる区分となる
    strSql = "SELECT * FROM systbd " _
            & "WHERE dkbsb = '050' " _
              & "AND dkbid = '" & strDKBID & "' " _
              & "AND dkbflb = '1'"
        
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    If CF_Ora_EOF(Usr_Ody) = False Then
        With gtypeFR_SUB(intRow)
            .SUB_DKBNM = CF_Ora_GetDyn(Usr_Ody, "dkbnm", "")
            .SUB_UPDID = CF_Ora_GetDyn(Usr_Ody, "updid", "")
            .SUB_DFLDKBCD = CF_Ora_GetDyn(Usr_Ody, "dfldkbcd", "")
            .SUB_DKBZAIFL = CF_Ora_GetDyn(Usr_Ody, "dkbzaifl", "")
            .SUB_DKBTEGFL = CF_Ora_GetDyn(Usr_Ody, "dkbtegfl", "")
            .SUB_DKBFLA = CF_Ora_GetDyn(Usr_Ody, "dkbfla", "")
            .SUB_DKBFLB = CF_Ora_GetDyn(Usr_Ody, "dkbflb", "")
            .SUB_DKBFLC = CF_Ora_GetDyn(Usr_Ody, "dkbflc", "")
            getDkbnm = .SUB_DKBNM
        End With
    End If
    
END_GET_DKBNM:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_GET_DKBNM:
    GoTo END_GET_DKBNM
    
End Function

'差額入金で使う構造体のクリア
Public Sub initSubFormType(intRow As Integer)
    With gtypeFR_SUB(intRow)
        .SUB_DKBID = Space(2)       '2byte space
        .SUB_DKBNM = Space(6)       '6byte space
        .SUB_UPDID = Space(2)       '2byte space
        .SUB_DFLDKBCD = Space(13)   '13byte space
        .SUB_DKBZAIFL = Space(1)    '1byte space
        .SUB_DKBTEGFL = Space(1)    '1byte space
        .SUB_DKBFLA = Space(1)      '1byte space
        .SUB_DKBFLB = Space(1)      '1byte space
        .SUB_DKBFLC = Space(1)      '1byte space
        .SUB_KOUZA = Space(10)      '10byte space
        .SUB_NYUKN = Space(9)       '9byte  space
        .SUB_LINCMA = Space(20)     '20byte space
    End With
End Sub

'差額入金で使う構造体の移動
Public Sub moveSubFormType(intRow As Integer)
    With gtypeFR_SUB(intRow)
        .SUB_DKBID = gtypeFR_SUB(intRow + 1).SUB_DKBID
        .SUB_DKBNM = gtypeFR_SUB(intRow + 1).SUB_DKBNM
        .SUB_UPDID = gtypeFR_SUB(intRow + 1).SUB_UPDID
        .SUB_DFLDKBCD = gtypeFR_SUB(intRow + 1).SUB_DFLDKBCD
        .SUB_DKBZAIFL = gtypeFR_SUB(intRow + 1).SUB_DKBZAIFL
        .SUB_DKBTEGFL = gtypeFR_SUB(intRow + 1).SUB_DKBTEGFL
        .SUB_DKBFLA = gtypeFR_SUB(intRow + 1).SUB_DKBFLA
        .SUB_DKBFLB = gtypeFR_SUB(intRow + 1).SUB_DKBFLB
        .SUB_DKBFLC = gtypeFR_SUB(intRow + 1).SUB_DKBFLC
        .SUB_KOUZA = gtypeFR_SUB(intRow + 1).SUB_KOUZA
        .SUB_NYUKN = gtypeFR_SUB(intRow + 1).SUB_NYUKN
        .SUB_LINCMA = gtypeFR_SUB(intRow + 1).SUB_LINCMA
    End With
    initSubFormType (intRow + 1)
End Sub


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Function getSQLforBody
'   概要： 明細部表示データ取得SQLを作成する
'   引数： pm_strSmaupddt   : 消込日
'       ： pm_strTokseicd   : 請求先コード
'       ： pm_strKaidt_Fr   : 売上日(開始)
'       ： pm_strKaidt_To   : 売上日(終了)
'       ： pm_strKesikb     : 消込表示区分
'       ： pm_intSortkb     : ソート順
'   戻値： 生成したSQL文
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function getSQLforBody(pm_strSmaupddt As String, _
                              pm_strTokseicd As String, _
                              pm_strKaidt_Fr As String, _
                              pm_strKaidt_to As String, _
                              pm_strKesikb As String, _
                     Optional pm_intSortkb As Integer = 0) As String
                     
    Dim strSql  As String
    
    strSql = " "
    strSql = strSql & "SELECT " & vbCrLf
    strSql = strSql & "  UH.NXTKB " & vbCrLf
    strSql = strSql & " ,TO_DATE(UR.UDNDT, 'YYYY/MM/DD') HY_UDNDT  " & vbCrLf
    strSql = strSql & " ,TRIM(UR.JDNNO) || SUBSTR(UR.JDNLINNO, 2, 2) HY_JDNNO  " & vbCrLf
    strSql = strSql & " ,TO_DATE(UR.KESDT, 'YYYY/MM/DD') HY_KAIDT " & vbCrLf
    strSql = strSql & " ,UR.TOKJDNNO " & vbCrLf
    strSql = strSql & " ,UH.TANNM  " & vbCrLf
    strSql = strSql & " ,UR.URIKN " & vbCrLf
    strSql = strSql & " ,UR.UZEKN " & vbCrLf
    strSql = strSql & " ,UR.URIKN + UR.UZEKN KOMIKN  " & vbCrLf
    strSql = strSql & " ,NVL(NR1.JKESIKN, 0) + NVL(NR2.JKESIKN, 0) KESIKN  " & vbCrLf
    strSql = strSql & " ,NVL(NR1.JKESIKN, 0) BFKESIKN " & vbCrLf
    strSql = strSql & " ,NVL(NR2.JKESIKN, 0) AFKESIKN  " & vbCrLf
    strSql = strSql & " ,UR.JDNNO " & vbCrLf
    strSql = strSql & " ,UR.JDNLINNO " & vbCrLf
    strSql = strSql & " ,UR.UDNDT " & vbCrLf
    strSql = strSql & " ,UR.KESDT  " & vbCrLf
    strSql = strSql & " ,UR.RECNO " & vbCrLf
    strSql = strSql & " ,UR.AKAKROKB " & vbCrLf
    strSql = strSql & " ,UR.KESIKB " & vbCrLf
    strSql = strSql & " ,UR.HENRSNCD " & vbCrLf
    strSql = strSql & " ,UR.HENSTTCD  " & vbCrLf
    strSql = strSql & " ,UR.TOKCD " & vbCrLf
    strSql = strSql & " ,UR.TOKSEICD " & vbCrLf
    strSql = strSql & " ,UH.TANCD " & vbCrLf
    strSql = strSql & " ,JR.JDNDT " & vbCrLf
    strSql = strSql & " ,UH.TUKKB  " & vbCrLf
    strSql = strSql & " ,UR.INVNO " & vbCrLf
    strSql = strSql & " ,UR.FURIKN " & vbCrLf
    strSql = strSql & " ,UH.FRNKB " & vbCrLf
    strSql = strSql & " ,UR.DATNO " & vbCrLf
    strSql = strSql & " ,UR.LINNO " & vbCrLf
    strSql = strSql & " ,UH.MAEUKKB    " & vbCrLf
    strSql = strSql & " ,UR.UDNNO  " & vbCrLf
    strSql = strSql & " ,JR.DATNO JDNDATNO  " & vbCrLf
    strSql = strSql & " ,UR.URITK  " & vbCrLf
    strSql = strSql & " ,UR.WRTFSTDT  UDNWRTFSTDT  " & vbCrLf
    strSql = strSql & " ,UR.WRTFSTTM  UDNWRTFSTTM  " & vbCrLf
    '排他処理用
    strSql = strSql & " ,UR.OPEID  UDNOPEID  " & vbCrLf
    strSql = strSql & " ,UR.CLTID  UDNCLTID  " & vbCrLf
    strSql = strSql & " ,UR.WRTDT  UDNWRTDT  " & vbCrLf
    strSql = strSql & " ,UR.WRTTM  UDNWRTTM  " & vbCrLf
    strSql = strSql & " ,UR.UOPEID UDNUOPEID " & vbCrLf
    strSql = strSql & " ,UR.UCLTID UDNUCLTID " & vbCrLf
    strSql = strSql & " ,UR.UWRTDT UDNUWRTDT " & vbCrLf
    strSql = strSql & " ,UR.UWRTTM UDNUWRTTM " & vbCrLf
    strSql = strSql & " ,JR.OPEID  JDNOPEID  " & vbCrLf
    strSql = strSql & " ,JR.CLTID  JDNCLTID  " & vbCrLf
    strSql = strSql & " ,JR.WRTDT  JDNWRTDT  " & vbCrLf
    strSql = strSql & " ,JR.WRTTM  JDNWRTTM  " & vbCrLf
    strSql = strSql & " ,JR.UOPEID JDNUOPEID " & vbCrLf
    strSql = strSql & " ,JR.UCLTID JDNUCLTID " & vbCrLf
    strSql = strSql & " ,JR.UWRTDT JDNUWRTDT " & vbCrLf
    strSql = strSql & " ,JR.UWRTTM JDNUWRTTM " & vbCrLf

    strSql = strSql & "FROM " & vbCrLf
    strSql = strSql & "  (SELECT " & vbCrLf
    strSql = strSql & "          * " & vbCrLf
    strSql = strSql & "   FROM   UDNTRA" & vbCrLf
    strSql = strSql & "   WHERE  DATKB    =  '1' " & vbCrLf
    strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
    strSql = strSql & "   AND    DENKB    =  '1' " & vbCrLf
    strSql = strSql & "   AND    IRISU    <> 9 " & vbCrLf
    If Trim(pm_strKaidt_Fr) <> "" Then
        strSql = strSql & "   AND    UDNDT    >= '" & pm_strKaidt_Fr & "' " & vbCrLf
    End If
    strSql = strSql & "   AND    UDNDT    <= '" & pm_strKaidt_to & "' " & vbCrLf
'未請求月を見出力にする場合は、下記のコメントアウトを外してください
'    strSql = strSql & "   AND    SSADT    <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
    strSql = strSql & "  ) UR " & vbCrLf

    strSql = strSql & " ,UDNTHA UH " & vbCrLf

    strSql = strSql & " ,(SELECT UDNNO " & vbCrLf
    strSql = strSql & "         ,LINNO " & vbCrLf
    strSql = strSql & "         ,MAX(WRTFSTDT || WRTFSTTM) AS DT " & vbCrLf
    strSql = strSql & "   FROM   UDNTRA " & vbCrLf
    strSql = strSql & "   WHERE  DENKB = '1' " & vbCrLf
    strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
    strSql = strSql & "   GROUP BY UDNNO,LINNO " & vbCrLf
    strSql = strSql & "  ) B " & vbCrLf

    strSql = strSql & " ,(SELECT " & vbCrLf
    strSql = strSql & "          UDNDATNO " & vbCrLf
    strSql = strSql & "         ,UDNLINNO " & vbCrLf
    strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
    strSql = strSql & "   FROM   NKSTRA " & vbCrLf
    strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
    strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
    strSql = strSql & "   AND   (NYUDT <=" & "'" & pm_strSmaupddt & "' OR NYUKB = '3') " & vbCrLf
    strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
    strSql = strSql & "  ) NR1 " & vbCrLf

    strSql = strSql & " ,(SELECT " & vbCrLf
    strSql = strSql & "          UDNDATNO " & vbCrLf
    strSql = strSql & "         ,UDNLINNO " & vbCrLf
    strSql = strSql & "         ,SUM(JKESIKN) JKESIKN " & vbCrLf
    strSql = strSql & "   FROM   NKSTRA " & vbCrLf
    strSql = strSql & "   WHERE  DATKB = '1' " & vbCrLf
    strSql = strSql & "   AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
    strSql = strSql & "   AND   (NYUDT > '" & pm_strSmaupddt & "' AND NYUKB <> '3') " & vbCrLf
    strSql = strSql & "   GROUP BY UDNDATNO, UDNLINNO " & vbCrLf
    strSql = strSql & "  ) NR2 " & vbCrLf

    strSql = strSql & " ,(SELECT " & vbCrLf
    strSql = strSql & "          * " & vbCrLf
    strSql = strSql & "   FROM   JDNTRA " & vbCrLf
    strSql = strSql & "   WHERE  DATNO IN ( " & vbCrLf
    strSql = strSql & "                     SELECT MAX(DATNO) " & vbCrLf
    strSql = strSql & "                     FROM JDNTRA " & vbCrLf
    strSql = strSql & "                     WHERE TOKSEICD = '" & pm_strTokseicd & "' " & vbCrLf
    strSql = strSql & "                     GROUP BY JDNNO " & vbCrLf
    strSql = strSql & "                   ) " & vbCrLf
    strSql = strSql & "  ) JR  " & vbCrLf
    
    strSql = strSql & "WHERE " & vbCrLf
    strSql = strSql & "  NOT EXISTS " & vbCrLf
    strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
    strSql = strSql & "   WHERE " & vbCrLf
    strSql = strSql & "        DATKB    = '1'" & vbCrLf
    strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
    strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
    strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
    strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
    strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
    strSql = strSql & "   AND  UR.AKAKROKB = '9' " & vbCrLf
    strSql = strSql & "   AND (DKBID    = '01' AND AKAKROKB = '1')" & vbCrLf
    strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
    strSql = strSql & " AND UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
    strSql = strSql & " ) " & vbCrLf
'    strSql = strSql & " (UR.AKAKROKB = '9' AND " & vbCrLf
'    strSql = strSql & "  NOT EXISTS " & vbCrLf
'    strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
'    strSql = strSql & "   WHERE " & vbCrLf
'    strSql = strSql & "        DATKB    = '1'" & vbCrLf
'    strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
'    strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
'    strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
'    strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
'    strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
'    strSql = strSql & "   AND (DKBID    = '01' AND AKAKROKB = '1')" & vbCrLf
'    strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
'    strSql = strSql & " AND UDNDT < '" & pm_strKaidt_Fr & "'" & vbCrLf
'    strSql = strSql & " ) OR " & vbCrLf
'    strSql = strSql & " (UR.AKAKROKB = '1' AND " & vbCrLf
'    strSql = strSql & "  NOT EXISTS " & vbCrLf
'    strSql = strSql & "  (SELECT * FROM UDNTRA " & vbCrLf
'    strSql = strSql & "   WHERE " & vbCrLf
'    strSql = strSql & "        DATKB    = '1'" & vbCrLf
'    strSql = strSql & "   AND  TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
'    strSql = strSql & "   AND  JDNNO    = UR.JDNNO " & vbCrLf
'    strSql = strSql & "   AND  JDNLINNO = UR.JDNLINNO " & vbCrLf
'    strSql = strSql & "   AND  RECNO    = UR.RECNO " & vbCrLf
'    strSql = strSql & "   AND  IRISU    <> 9 " & vbCrLf
'    strSql = strSql & "   AND (DKBID  <> '01' AND AKAKROKB = '9')" & vbCrLf
'    strSql = strSql & "   AND  DENKB    = '1'" & vbCrLf
'    strSql = strSql & "   AND  UDNDT > '" & pm_strKaidt_to & "'" & vbCrLf
'    strSql = strSql & " )))" & vbCrLf
    
    strSql = strSql & "AND   UR.TOKSEICD = '" & CF_Ora_Sgl(pm_strTokseicd) & "' " & vbCrLf
    strSql = strSql & "AND   UR.UDNDT   <= '" & pm_strKaidt_to & "' " & vbCrLf
    strSql = strSql & "AND ((UR.DKBID  = '01' AND UR.AKAKROKB = '1') " & vbCrLf
    strSql = strSql & "      OR  " & vbCrLf
    strSql = strSql & "     (UR.DKBID <> '01' AND UR.AKAKROKB = '9')) " & vbCrLf
    strSql = strSql & "AND UR.WRTFSTDT || UR.WRTFSTTM = B.DT " & vbCrLf
    strSql = strSql & "AND UR.UDNNO   = B.UDNNO " & vbCrLf
    strSql = strSql & "AND UR.LINNO   = B.LINNO " & vbCrLf
    strSql = strSql & "AND UR.DATNO   = UH.DATNO " & vbCrLf
    strSql = strSql & "AND UH.MAEUKKB = '2' " & vbCrLf

    If pm_strKesikb = 1 Then
        strSql = strSql & "AND (" & vbCrLf
        strSql = strSql & "     (UR.URIKN + UR.UZEKN <> UR.JKESIKN) " & vbCrLf
        strSql = strSql & "      OR" & vbCrLf
        strSql = strSql & "     ((UR.URIKN + UR.UZEKN =  UR.JKESIKN) " & vbCrLf
        strSql = strSql & "       AND EXISTS " & vbCrLf
        strSql = strSql & "       (SELECT * FROM UDNTRA " & vbCrLf
        strSql = strSql & "        WHERE  JDNNO    =  UR.JDNNO" & vbCrLf
        strSql = strSql & "        AND    JDNLINNO =  UR.JDNLINNO" & vbCrLf
        strSql = strSql & "        AND    DATKB    =  '1'" & vbCrLf
        strSql = strSql & "        AND    TOKSEICD =  '" & pm_strTokseicd & "' " & vbCrLf
        strSql = strSql & "        AND    AKAKROKB =  '9'" & vbCrLf
        strSql = strSql & "        AND    IRISU    <> 9 " & vbCrLf
        strSql = strSql & "        AND    DKBID    IN  ('02','06')" & vbCrLf
        strSql = strSql & "        AND    URIKN + UZEKN   <> JKESIKN " & vbCrLf
        If Trim(pm_strKaidt_Fr) <> "" Then
            strSql = strSql & "        AND    UDNDT    >= '" & pm_strKaidt_Fr & "'" & vbCrLf
        End If
        strSql = strSql & "        AND    UDNDT    <= '" & pm_strKaidt_to & "'" & vbCrLf
        strSql = strSql & "       )" & vbCrLf
        strSql = strSql & "      ) " & vbCrLf
        strSql = strSql & "    ) " & vbCrLf
    End If

'未請求月を見出力にする場合は、下記のコメントアウトを外してください
'    strSql = strSql & "AND UR.SSADT  <= '" & DB_TOKMTA.TOKSMEDT & "'" & vbCrLf
    
    strSql = strSql & "AND TRIM(JR.JDNDELDT) IS NULL " & vbCrLf
    strSql = strSql & "AND UR.JDNNO    = JR.JDNNO " & vbCrLf
    strSql = strSql & "AND UR.JDNLINNO = JR.LINNO " & vbCrLf
    strSql = strSql & "AND UR.DATNO    = NR1.UDNDATNO(+) " & vbCrLf
    strSql = strSql & "AND UR.LINNO    = NR1.UDNLINNO(+) " & vbCrLf
    strSql = strSql & "AND UR.DATNO    = NR2.UDNDATNO(+) " & vbCrLf
    strSql = strSql & "AND UR.LINNO    = NR2.UDNLINNO(+) " & vbCrLf
    
    'ｿｰﾄ順の変更
    Select Case pm_intSortkb
        Case 0
            strSql = strSql & "ORDER BY UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
        Case 1
            strSql = strSql & "ORDER BY JDNNO, JDNLINNO, UDNDT, KESDT, DATNO"
        Case 2
            strSql = strSql & "ORDER BY TOKJDNNO, UDNDT, KESDT, JDNNO, JDNLINNO, DATNO"
    End Select



    getSQLforBody = strSql
    
    Debug.Print strSql

End Function
'V1.04 ADD ↓
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Function getJDNTRKB
'   概要： 明細部表示データ取得SQLを作成する
'   引数： pm_StrJdnno   　 : 受注番号
'       ： pm_StrJdnlinno   : 受注行番号
'   戻値： 送り状№
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function getOKRJONO(pm_StrJdnno As String, pm_StrJdnlinno As String) As String

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    Dim strJdntrkb      As String

    On Error GoTo ERR_getOKRJONO


        ''受注番号より受注取引区分を取得する。
        strSql = " "
        strSql = strSql & " SELECT  JDNTRKB"
        strSql = strSql & "  FROM   JDNTHA"
        strSql = strSql & " WHERE   DATNO IN"
        strSql = strSql & " ("
        strSql = strSql & "  SELECT  MAX(DATNO)"
        strSql = strSql & "   FROM   JDNTHA"
        strSql = strSql & "  WHERE   DATKB = '1'"
        strSql = strSql & "    AND   JDNNO = '" & pm_StrJdnno & "'"
        strSql = strSql & " )"
        strSql = strSql & "    AND DATKB = '1'"


        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
        If CF_Ora_EOF(Usr_Ody) = False Then
            strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '受注取引区分
        End If
        
        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ


        '受注番号＋行番号を送り状№へ変換
        'システム・セットアップ受注の場合は行番号を「001」とする
        If strJdntrkb = "11" Or strJdntrkb = "21" Then
            getOKRJONO = Trim$(pm_StrJdnno) & "001"
        Else
            getOKRJONO = Trim$(pm_StrJdnno) & Trim$(pm_StrJdnlinno)
        End If


END_getOKRJONO:

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
    Exit Function

ERR_getOKRJONO:
    GoTo END_getOKRJONO


End Function
'V1.04 ADD ↑
