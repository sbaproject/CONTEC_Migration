Attribute VB_Name = "AE_CMN"
Option Explicit
'********************************************************************************
'*  システム名　　　：  新総合情報システム
'*  サブシステム名　：　販売システム
'*  機能　　　　　　：　共通
'*  モジュール名　　：　業務共通処理
'*  作成者　　　　　：　ACE)長澤
'*  作成日　　　　　：  2006.05.24
'*-------------------------------------------------------------------------------
'*<01> YYYY.MM.DD　：　修正情報
'*     修正者
'********************************************************************************
'************************************************************************************
'   API
'************************************************************************************
'//----------------------------------------------
'//親プロセスへの終了コード復帰
'//----------------------------------------------
Public Declare Sub ExitProcess Lib "kernel32" (ByVal uExitCode As Long)
'//----------------------------------------------
'//スリープ
'//----------------------------------------------
Public Declare Function Sleep Lib "kernel32.dll" (ByVal mstime As Long) As Long

'************************************************************************************
'   Public定数
'************************************************************************************
    Public Type Cmn_Inp_Inf
        InpTanCd        As String       '入力担当者ＩＤ
        InpTanNm        As String       '入力担当者名
        InpTKCHGKB      As String       '単価変更権限
        InpCLIID        As String       'クライアントＩＤ
    End Type
'************************************************************************************
'   Public定数
'************************************************************************************
    '端数計算桁数
    Public Const gc_strRPSKB_D1     As String = "1"         '小数第一位
    Public Const gc_strRPSKB_D2     As String = "2"         '小数第二位
    Public Const gc_strRPSKB_D3     As String = "3"         '小数第三位
    Public Const gc_strRPSKB_D4     As String = "4"         '小数第四位
    Public Const gc_strRPSKB_D5     As String = "5"         '小数第五位
    Public Const gc_strRPSKB_I1     As String = "10"         '１
    Public Const gc_strRPSKB_I2     As String = "11"         '１０
    Public Const gc_strRPSKB_I3     As String = "12"         '１００
    
Global Const MAX_PATH = 260

'************************************************************************************
'   Public変数
'************************************************************************************
    Public Inp_Inf                  As Cmn_Inp_Inf          '入力者情報
    Public GV_SysDate               As String               'ＤＢサーバー日付
    Public GV_SysTime               As String               'ＤＢサーバー時刻
    Public GV_UNYDate               As String               '運用日付

'************************************************************************************
'   Private変数
'************************************************************************************
    Dim strINIDATNM(4)  As String           'ＩＮＩのシンボル
    Dim SSS_INIDAT(4)   As String
    Dim SSS_INICnt      As Integer
    
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Init_BAT
'   概要：  プログラム起動時初期処理(バッチ用)
'   引数：  pot_strErrMsg : エラーメッセージ
'           pin_strPGID   : 空白は通常処理　ﾌﾟﾛｸﾞﾗﾑIDが入っている場合はそれぞれの固有の処理を実行
'   戻値：  なし
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Init_BAT(ByRef pot_strErrMsg As String, _
                            Optional pin_strPGID As String = "") As Integer

    Dim datDT           As Date
    Dim DB_TANMTA       As TYPE_DB_TANMTA
    Dim DB_UNYMTA       As TYPE_DB_UNYMTA
    Dim strYMD          As String
    Dim intLenCommand   As String
    Dim intRet          As Integer

    CF_Init_BAT = 9
    
    pot_strErrMsg = ""
    
    '二重起動ﾁｪｯｸ
    If App.PrevInstance Then
        pot_strErrMsg = "【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。"
        Exit Function
    End If
    
'   日付形式チェック
    datDT = Date
    strYMD = Format(Year(datDT), "0000") & "/" & Format(Month(datDT), "00") & "/" & Format(Day(datDT), "00")
    
    If CStr(datDT) <> strYMD Then
        pot_strErrMsg = "日付の形式 '" & CStr(datDT) & "' が違います。" & " " _
             & "コントロールパネルの地域（地球の絵）の日付" & " " _
             & "の短い形式を yyyy/MM/dd に変更して下さい。"
        Exit Function
    End If
    
    '---------------------
    ' 起動パラメータ設定
    '---------------------
    Select Case UCase(Trim(pin_strPGID))
        '出荷予定データ作成処理
        Case "SYKFP70"
        
        '通常
        Case Else
            intLenCommand = LenB(Trim$(Command$))
            If intLenCommand < 15 Then
                intRet = CF_Get_BATUSER
                If intRet <> 0 Then
                    pot_strErrMsg = "バッチを実行する担当者ＩＤ、端末ＩＤがありません。設定を確認して下さい。"
                    Exit Function
                End If
            Else
                SSS_CLTID = CF_Ctr_AnsiMidB(Command$, 2, 5)     'クライアントID
                SSS_OPEID = CF_Ctr_AnsiMidB(Command$, 7, 8)     '入力担当者ID
            End If
            
            '入力担当者名取得
            Inp_Inf.InpTanCd = SSS_OPEID
            Inp_Inf.InpCLIID = SSS_CLTID
            
            Call DB_TANMTA_Clear(DB_TANMTA)
            intRet = DSPTANCD_SEARCH(Inp_Inf.InpTanCd, DB_TANMTA)
            If intRet = 0 Then
                Inp_Inf.InpTanNm = DB_TANMTA.TANNM              '入力担当者名
            End If
    End Select
    
    
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
    
    '運用日付取得
    Call CF_Get_UnyDt
    
    CF_Init_BAT = 0
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_INIT_GETINI
    '   概要：  INIファイル読込み（共通）
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function CF_INIT_GETINI() As String
    Dim WL_WinDir As String, I As Integer, LENGTH As Integer
    Dim rtnPara As String * MAX_PATH
    
    CF_INIT_GETINI = ""
    
    '---------------------
    ' SSSWIN.INI 読込み
    '---------------------
    For I = 0 To SSS_INICnt
        rtnPara = ""
        LENGTH = GetPrivateProfileString("SSSWIN", ByVal strINIDATNM(I), "", rtnPara, Len(rtnPara), ByVal "SSSWIN.INI")
        If LENGTH = 0 Then
            CF_INIT_GETINI = "SSSWIN.INI を確認してください。" & Chr(13) & "[" & strINIDATNM(I) & "]"
            Exit For
        Else
            SSS_INIDAT(I) = CF_Ctr_AnsiLeftB(rtnPara, LENGTH)
        End If
        If Right$(SSS_INIDAT(I), 1) <> "\" And Right$(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
    Next I
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Get_TANNM
    '   概要：  担当者名称取得
    '   引数：　pm_Def_LineNo
    '           pm_HIKET51_DSP_DATA    :画面業務情報構造体
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_TANNM(pm_TANCD As String) As String

    Dim Ret_Value        As String
    Dim DB_TANMTA        As TYPE_DB_TANMTA
    Dim intRet           As Integer
    
    Ret_Value = ""
    
    '担当者マスタ検索
    Call DB_TANMTA_Clear(DB_TANMTA)
    intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
    If intRet = 0 Then
        Ret_Value = DB_TANMTA.TANNM
    End If
    
    CF_Get_TANNM = Ret_Value
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Get_BATUSER
    '   概要：  バッチ用担当者取得
    '   引数：　なし
    '   戻値：　0 : 正常　9 : 異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_BATUSER() As Integer

    Dim Mst_Inf          As TYPE_DB_FIXMTA
    Dim intRet           As Integer
    
    CF_Get_BATUSER = 9
    
    '固定値マスタ検索
    'バッチ用担当者ＩＤ取得
    Call DB_FIXMTA_Clear(Mst_Inf)
    
    intRet = DSPCTLCD_SEARCH(gc_strCTLCD_TANCD_BAT, Mst_Inf)
    If intRet = 0 Then
        SSS_OPEID = Mst_Inf.FIXVAL
    Else
        Exit Function
    End If
    
    'バッチ用端末ＩＤ取得
    Call DB_FIXMTA_Clear(Mst_Inf)
    
    intRet = DSPCTLCD_SEARCH(gc_strCTLCD_CLTID_BAT, Mst_Inf)
    If intRet = 0 Then
        SSS_CLTID = Mst_Inf.FIXVAL
    Else
        Exit Function
    End If
    
    CF_Get_BATUSER = 0
    
End Function

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Get_SysDt
'//*
'//* <戻り値>     型          説明
'//*              Boolean     True:正常 / False:異常
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*
'//* <説  明>
'//*    DBサーバーの日付(西暦)を取得する。
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20041016|ACE)Moriga     |新規作成
'//**************************************************************************************
Public Function CF_Get_SysDt() As Boolean
    
    On Error GoTo ERR_HANDLE
    
    Dim Str_Sql         As String
    Dim Usr_Ody         As U_Ody
    Dim Str_Val         As String
    Dim Lng_Cnt         As Long
    Dim Lng_Idx         As Long
    Dim Str_SysDt       As String
    
    CF_Get_SysDt = False
    
    '// 初期化
    GV_SysDate = ""
    GV_SysTime = ""
    Str_SysDt = ""
    
    Str_Sql = ""
    Str_Sql = Str_Sql & "SELECT"
    Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
    Str_Sql = Str_Sql & "FROM"
    Str_Sql = Str_Sql & "       Dual "
    
    If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
        GoTo ERR_HANDLE
    End If
    
    Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))
    
    GV_SysDate = Mid(Str_SysDt, 1, 8)
    GV_SysTime = Mid(Str_SysDt, 9, 6)
    
    CF_Get_SysDt = True

EXIT_HANDLE:
    Call CF_Ora_CloseDyn(Usr_Ody)
    Exit Function
    
ERR_HANDLE:
    GoTo EXIT_HANDLE
    
End Function

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Get_UnyDt
'//*
'//* <戻り値>     型          説明
'//*              Boolean     True:正常 / False:異常
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*
'//* <説  明>
'//*    運用日付(西暦)を取得する。
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20060706|ACE)Nagasawa   |新規作成
'//**************************************************************************************
Public Function CF_Get_UnyDt() As Boolean
    
    Dim intRet      As Integer
    Dim Mst_Inf     As TYPE_DB_UNYMTA
    
    CF_Get_UnyDt = False
    
    '初期化
    GV_UNYDate = ""
    
    'サーバーのシステム日付取得
    Call CF_Get_SysDt
    
    '運用日付を取得
    intRet = DSPUNYDT_SEARCH(Mst_Inf)
    If intRet = 0 Then
        GV_UNYDate = Mst_Inf.UNYDT
    Else
        GV_UNYDate = GV_SysDate
    End If
    
    CF_Get_UnyDt = True
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Edit_ErrLog
'   概要：  エラーログ出力処理
'   引数：  pin_strLOG_PATH    : 出力ログファイルパス
'           pin_strLOG_NAME    : 出力ログファイル名
'           pin_strPrgId       : 出力プログラム名
'           pin_intErrCd       : エラーコード
'           pin_strErrMsg      : エラーメッセージ
'           pin_strErrLocation : 発生箇所（ファンクション名）
'           pin_strTime        : 発生時刻
'           pin_strDate        : 発生日付
'   戻値：  0 : 正常 9 : 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Edit_ErrLog(ByVal pin_strLOG_PATH As String _
                             , ByVal pin_strLOG_NAME As String _
                             , ByVal pin_strPrgId As String _
                             , ByVal pin_intErrCd As Integer _
                             , ByVal pin_strErrMsg As String _
                             , ByVal pin_strErrLocation As String _
                             , ByVal pin_strTime As String _
                             , ByVal pin_strDate As String) As Integer

    Dim intFNo          As Integer
    Dim strCSV          As String
    Dim bolOpen         As Boolean
    
On Error GoTo CF_Edit_ErrLog_End

    CF_Edit_ErrLog = 9
    bolOpen = False
    
    intFNo = FreeFile

    If Right$(Trim(pin_strLOG_PATH), 1) <> "\" Then
        pin_strLOG_PATH = Trim(pin_strLOG_PATH) & "\"
    End If
    
    'ファイルオープン
    Open Trim(pin_strLOG_PATH) & Trim(pin_strLOG_NAME) For Append As intFNo
    bolOpen = True
    
    strCSV = ""
    'プログラムID
    strCSV = strCSV & pin_strPrgId & ","
    'エラー番号
    strCSV = strCSV & Trim(CStr(pin_intErrCd)) & ","
    'エラー内容
    strCSV = strCSV & pin_strErrMsg & ","
    '発生場所（ファンクション名等）
    strCSV = strCSV & pin_strErrLocation & ","
    '発生日
    strCSV = strCSV & pin_strDate & ","
    '発生時刻
    strCSV = strCSV & pin_strTime
    
    Print #intFNo, strCSV
    
    CF_Edit_ErrLog = 0

CF_Edit_ErrLog_End:

    If bolOpen = True Then
        'クローズ
        Close intFNo
    End If

End Function

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Ctr_AnsiLeftB
'//*
'//* <戻り値>     型          説明
'//*              String      変換後の文字列
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*              pm_Value           String           I            対象文字列
'//*              pm_Len             Long             I            文字列の長さ
'//* <説  明>
'//*    半角文字を1バイト、全角文字を2バイトとして左から指定の長さの文字列を取得します。
'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20020715|FKS)           |新規作成
'//**************************************************************************************
Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, _
                           ByVal pm_Len As Long) As String

    CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)

    Exit Function

End Function

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Ctr_AnsiRightB
'//*
'//* <戻り値>     型          説明
'//*              String      変換後の文字列
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*              pm_Value           String           I            対象文字列
'//*              pm_Len             Long             I            文字列の長さ
'//* <説  明>
'//*    半角文字を1バイト、全角文字を2バイトとして右から指定の長さの文字列を取得します。
'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20020715|FKS)           |新規作成
'//**************************************************************************************
Public Function CF_Ctr_AnsiRightB(ByVal pm_Value As String, _
                            ByVal pm_Len As Long) As Variant
    
    CF_Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
    
    Exit Function

End Function

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Ctr_AnsiMidB
'//*
'//* <戻り値>     型          説明
'//*              String      変換後の文字列
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*              pm_Value           String           I            対象文字列
'//*              pm_Start           Long             I            切り取り開始バイト数
'//*              pm_Len             Long             I            文字列の長さ
'//* <説  明>
'//*    半角文字を1バイト、全角文字を2バイトとして指定した位置から指定の長さの文字列を取得します。
'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20020715|FKS)           |新規作成
'//**************************************************************************************
Public Function CF_Ctr_AnsiMidB(ByVal pm_Value As String, _
                          ByVal pm_Start As Long, _
                 Optional ByVal pm_Len As Long) As String

    Dim Str_Value       As String

    If pm_Len < 1 Then
        Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
    Else
        Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)
        
        '//全角文字が途中で途切れる場合１文字多めにカットする。
        If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
            Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
        End If
    End If
    
    CF_Ctr_AnsiMidB = Str_Value

    Exit Function

End Function

'//***************************************************************************************
'//*
'//* <名  称>
'//*    CF_Ctr_AnsiLenB
'//*
'//* <戻り値>     型          説明
'//*              Long        長さバイト数
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*              pm_Value           String           I            対象文字列
'//* <説  明>
'//*    半角文字を1バイト、全角文字を2バイトとして対象文字列の長さバイト数を取得します。
'//*
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
'//* ---------|--------|---------------|------------------------------------------------*
'//* 1.00     |20020715|FKS)           |新規作成
'//**************************************************************************************
Public Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Long

    CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))

    Exit Function

End Function

Function Get_DBHEAD() As String
'現在の環境のDBHEAD を返す、環境未設定の場合は、""を返す。
Dim ret%, wkStr As String * 128

    Get_DBHEAD = ""
    ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr, 128, ByVal "SSSWIN.INI")
    If ret > 0 Then Get_DBHEAD = Left$(wkStr, ret)
End Function

Sub Error_Exit(ByVal ErrorMsg As String)
Dim rtn, I As Integer
    End
End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function AE_CmnMsgLibrary_Bat
'   概要：  標準メッセージ表示処理(バッチ用)
'   引数：  Pin_strPgNm     : プログラム名
'           Pin_strMsgCode  : メッセージコード（DB検索用）
'           pin_strMsg      : 追加メッセージ
'   戻値：
'   備考：  アプリの実行時に出力される標準メッセージ。
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_CmnMsgLibrary_Bat(ByVal Pin_strPgNm As String, _
                                 ByVal Pin_strMsgCode As String, _
                                 Optional ByVal pin_strMsg As String = "") As Integer

    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim strMsg_add      As String
    
    On Error Resume Next

    AE_CmnMsgLibrary_Bat = False

    strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1)         'メッセージ種別
    strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2)           'メッセージアイテム
    
    Beep

    'メッセージマスタ検索
    intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
    If intRet <> 0 Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, Pin_strPgNm)
            Exit Function
        End If
    End If

    '追加メッセージの編集
    strMsg_add = ""
    If Mst_Inf.MSGSQ = "9" Then
        'ＤＢアクセス系エラーとする
        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "発生箇所   : " & pin_strMsg
    Else
        If Trim(pin_strMsg) <> "" Then
            strMsg_add = vbCrLf & pin_strMsg
        End If
    End If

    'メッセージ表示
    Select Case Mst_Inf.BTNKB
        'OK
        Case gc_strBTNKB_OKOnly
            AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
            
        'OK/キャンセル
        Case gc_strBTNKB_OKCancel
            AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            
        '中止/再試行/無視
        Case gc_strBTNKB_AbortRetryIgnore
            AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbAbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            
        'はい/いいえ/キャンセル
        Case gc_strBTNKB_YesNoCancel
            AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
        
        'はい/いいえ
        Case gc_strBTNKB_YesNo
            AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
            
        '再試行/キャンセル
        Case gc_strBTNKB_RetryCancel
            AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbRetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
        
        Case Else
        
    End Select
        
End Function

' === 20061102 === INSERT S - ACE)Nagasawa INIファイル格納場所変更
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Get_IniInf
'   概要：  Iniファイル読込み処理（プログラム固有）
'   引数：  pin_strSection :
'   戻値：  0 : 正常 9 : 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Get_IniInf(pin_strSection As String, _
                              pin_strKey As String, _
                              pot_strValue As String) As Integer

    Dim Wk          As String * 256
    Dim lngRet      As Long
    
    CF_Get_IniInf = 9
    
    pot_strValue = ""
    
    'Iniファイル読込み
    lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk, Len(Wk), App.Path & "\" & SSS_PrgId & ".ini")
    If lngRet > 0 Then
        pot_strValue = CF_Ctr_AnsiLeftB(Wk, lngRet)
        pot_strValue = Trim$(pot_strValue)
    Else
        Exit Function
    End If
    
    CF_Get_IniInf = 0
    
End Function
' === 20061102 === INSERT E -

' === 20061105 === INSERT S - ACE)Nagasawa 排他制御の追加
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_Execute_PLSQL_EXCTBZ
    '   概要：  PL/SQL実行処理(排他制御処理)
    '   引数：　Pin_strPRCCASE   : 処理ケース(C:チェック W:書込処理 D:削除処理)
    '           Pot_strMsg       : エラー内容
    '   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
    '   備考：  排他制御用PL/SQL(PRC_EXCTBZ)を実行する
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, _
                                        ByRef Pot_strMsg As String) As Integer

    Dim strSQL      As String           'SQL文
    Dim strPara1    As String           'ﾊﾟﾗﾒｰﾀ1(担当者コード)
    Dim strPara2    As String           'ﾊﾟﾗﾒｰﾀ2(クライアントID)
    Dim strPara3    As String           'ﾊﾟﾗﾒｰﾀ3(処理ケース)
    Dim strPara4    As String           'ﾊﾟﾗﾒｰﾀ4(業務コード(PGID))
    Dim lngPara5    As Long             'ﾊﾟﾗﾒｰﾀ5(復帰ｺｰﾄﾞ)
    Dim lngPara6    As Long             'ﾊﾟﾗﾒｰﾀ6(ｴﾗｰｺｰﾄﾞ)
    Dim strPara7    As String           'ﾊﾟﾗﾒｰﾀ7(ｴﾗｰ内容)
    Dim param(7)    As OraParameter     'PL/SQLのバインド変数
    Dim bolRet      As Boolean
    
    AE_Execute_PLSQL_EXCTBZ = 9
    
    '受渡し変数初期設定
    strPara1 = Inp_Inf.InpTanCd
    strPara2 = SSS_CLTID
    strPara3 = Pin_strPRCCASE
    strPara4 = SSS_PrgId
    lngPara5 = 0
    lngPara6 = 0
    strPara7 = ""
    
    Pot_strMsg = ""

    'パラメータの初期設定を行う（バインド変数）
    gv_Odb_USR1.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    gv_Odb_USR1.Parameters.Add "P5", lngPara5, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    gv_Odb_USR1.Parameters.Add "P7", strPara7, ORAPARM_OUTPUT

    'データ型をオブジェクトにセット
    Set param(1) = gv_Odb_USR1.Parameters("P1")
    Set param(2) = gv_Odb_USR1.Parameters("P2")
    Set param(3) = gv_Odb_USR1.Parameters("P3")
    Set param(4) = gv_Odb_USR1.Parameters("P4")
    Set param(5) = gv_Odb_USR1.Parameters("P5")
    Set param(6) = gv_Odb_USR1.Parameters("P6")
    Set param(7) = gv_Odb_USR1.Parameters("P7")

    '各オブジェクトのデータ型を設定
    param(1).serverType = ORATYPE_CHAR
    param(2).serverType = ORATYPE_CHAR
    param(3).serverType = ORATYPE_CHAR
    param(4).serverType = ORATYPE_CHAR
    param(5).serverType = ORATYPE_NUMBER
    param(6).serverType = ORATYPE_NUMBER
    param(7).serverType = ORATYPE_VARCHAR2

    'PL/SQL呼び出しSQL
    strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"

    'DBアクセス
    bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
    If bolRet = False Then
        GoTo AE_Execute_PLSQL_EXCTBZ_END
    End If

    '** 戻り値取得
    lngPara5 = param(5).Value
    lngPara6 = param(6).Value
    If IsNull(param(7).Value) = False Then
        strPara7 = param(7).Value
        Pot_strMsg = strPara7
    End If

    'エラー情報設定
    gv_Int_OraErr = lngPara6
    gv_Str_OraErrText = strPara7
    
    AE_Execute_PLSQL_EXCTBZ = lngPara5
    
AE_Execute_PLSQL_EXCTBZ_END:
    '** パラメタ解消
    gv_Odb_USR1.Parameters.Remove "P1"
    gv_Odb_USR1.Parameters.Remove "P2"
    gv_Odb_USR1.Parameters.Remove "P3"
    gv_Odb_USR1.Parameters.Remove "P4"
    gv_Odb_USR1.Parameters.Remove "P5"
    gv_Odb_USR1.Parameters.Remove "P6"
    gv_Odb_USR1.Parameters.Remove "P7"
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_Lock_EXCTBZ
'   概要：　排他制御処理
'   引数：　Pot_strMsg       : エラー内容
'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
'   備考：  排他制御（排他チェック＆排他テーブルへの書き込み）を行う
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_Lock_EXCTBZ(ByRef Pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
On Error GoTo CF_Chk_Lock_EXCTBZ_Err

    CF_Chk_Lock_EXCTBZ = 9
    Pot_strMsg = ""
    bolTrn = False
    
    '排他チェック
    intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)
    If intRet <> 0 Then
        '排他エラー
        Pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    'トランザクションの開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTrn = True
    
    '排他制御
    intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
    If intRet <> 0 Then
        '排他エラー
        Pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTrn = False
    
    CF_Chk_Lock_EXCTBZ = 0
    
    Exit Function
    
CF_Chk_Lock_EXCTBZ_Err:

    'ロールバック
    If bolTrn = True Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Unlock_EXCTBZ
'   概要：　排他制御解除処理
'   引数：　Pot_strMsg       : エラー内容
'   戻値：　0 : 正常  9 : 異常
'   備考：  排他制御（排他テーブルからの削除）を行う
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Unlock_EXCTBZ(ByRef Pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
On Error GoTo CF_Unlock_EXCTBZ_Err

    CF_Unlock_EXCTBZ = 9
    Pot_strMsg = ""
    bolTrn = False
    
    'トランザクションの開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTrn = True
    
    '排他制御解除
    intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
    If intRet <> 0 Then
        '排他エラー
        Pot_strMsg = strMsg
        CF_Unlock_EXCTBZ = intRet
        GoTo CF_Unlock_EXCTBZ_Err
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTrn = False
    
    CF_Unlock_EXCTBZ = 0
    
    Exit Function
    
CF_Unlock_EXCTBZ_Err:

    'ロールバック
    If bolTrn = True Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    
End Function
' === 20061105 === INSERT E -
