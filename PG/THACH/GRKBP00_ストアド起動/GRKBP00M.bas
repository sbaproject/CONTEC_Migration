Attribute VB_Name = "GRKBP00M"
Option Explicit
'//*****************************************************************************************
'//*
'//*＜名称＞
'//*    GRKBP00M.BAS
'//*
'//*＜バージョン＞
'//*    1.00
'//*＜作成者＞
'//*    Rise
'//*＜説明＞
'//*    ストアド起動 モジュール
'//*****************************************************************************************
'//* CHANGE HISTORY
'//* Version  |YYYYMMDD|Programmer     |Description
'//* ---------|--------|---------------|---------------------------------------------------*
'//* 1.00     |20060710|Rise)          |新規
'//* ---------|--------|---------------|---------------------------------------------------*
'//* 1.01     |20071026|Rise)          |排他競合時処理中止し異常終了
'//* ---------|--------|---------------|---------------------------------------------------*
'//* 1.10     |20080514|Rise)          |読込んだファイル名を並び替える(ファイル名順)
'//*          |20080515|Rise)          |送信ファイルが既に存在している場合はファイル名の
'//*          |        |               |時間時刻に＋１しファイルを作成する
'//* 1.11     |20090128|Rise)          |1.10対応のRETRY回数をINIﾌｧｲﾙより取得する様に変更
'//* 1.20     |20091015|Rise)          |テキスト出力＆ＲＤＢ更新のプログラムのリカバリー対策
'//*****************************************************************************************
'//----------------------------------------------
'//スリープ
'//----------------------------------------------
Private Declare Function Sleep Lib "kernel32.dll" (ByVal mstime As Long) As Long

' -- ADD -- 2008/05/15 START (1.10)
'//ファイルをコピーします。
Private Declare Function CopyFile Lib "kernel32" _
    Alias "CopyFileA" _
    (ByVal lpExistingFileName As String, _
     ByVal lpNewFileName As String, _
     ByVal bFailIfExists As Long) _
    As Long
' -- ADD -- 2008/05/15 END   (1.10)

'//*****************************************************************************************
'// プログラム情報
'//*****************************************************************************************
'//ジョブＩＤ・ジョブ名称
Public Const gvcstJOB_ID                    As String = "GRKBP00"
Public Const gvcstJOB_Titl                  As String = "GRKBP00SQL"

'//メッセージボックス表示フラグ
Public Const gvcstDspMsg                    As Boolean = False

'//*****************************************************************************************
'// インスタンス定義
'//*****************************************************************************************
Public D0                                   As ClsComn                  '//System 関数
Public ClsMessage                           As ClsMessage               '//Message
Public clsOra                               As ClsOraDB

'//*****************************************************************************************
'// 変数定義
'//*****************************************************************************************
Public gvINIInformation                     As gvtypIniFile             '//ＩＮＩファイル構造体

'//*****************************************************************************************
'// 構造体定義
'//*****************************************************************************************
Public Type typFileInfo
    strFilePath                             As String
    strFileName1                            As String
    strFileExtn1                            As String
    strFileName2                            As String
    strFileExtn2                            As String
    strFileTimeStampAddFlg                  As String
End Type

Public Type typFileName
    strFileName()                           As Variant
End Type

'//*****************************************************************************************
'// ＰＧ個別変数定義
'//*****************************************************************************************
Public gvstrJOBID                           As String                   '//パラメータより取得したジョブID
Public gvstrPLSQLPACKAGE                    As String                   '//起動PLSQLパッケージ
Public gvstrPLSQLFUNCTION                   As String                   '//起動PLSQLファンクション

Public gvaryPARAMETER()                     As String                   '//追加PARAMETER
Public gvintInFileCount                     As Integer                  '//IN ファイル数
Public gvaryInFileInfo()                    As typFileInfo              '//IN ファイル情報
Public gvintOtFileCount                     As Integer                  '//OUTファイル数
Public gvaryOtFileInfo()                    As typFileInfo              '//OUTファイル情報
Public gvaryInGetFile()                     As typFileName              '//フォルダ内ファイル一覧
Public gvaryOtGetFile()                     As typFileName              '//フォルダ内ファイル一覧

' -- ADD -- 2007/02/08 START
Public Const pc_strIni_LOGPATH              As String = "LOG_PATH"
Public Const pc_strIni_LOGNAME              As String = "LOG_NAME"
Public Const pc_strIni_RETRY_INTERVAL       As String = "RETRY_INTERVAL"
Public Const pc_strIni_RETRY_TIMES          As String = "RETRY_TIMES"
Public pv_curRETRY_INTERVAL                 As Currency                 'リトライ間隔
Public pv_curRETRY_TIMES                    As Currency                 'リトライ回数
Public pv_strLOG_PATH                       As String                   'エラーログファイルパス
Public pv_strLOG_NAME                       As String                   'エラーログファイル名
Public gv_Int_OraErr                        As Integer                  '//ORACLEエラー番号
Public gv_Str_OraErrText                    As String                   '//ORACLEエラーテキスト
' -- ADD -- 2007/02/08 END

' -- ADD -- 2008/05/15 START (1.10)
Public gvstrPLSqlWkFileName                 As String                   '//ストアドへ渡すワークファイルの名前（JOBID + "WK")
' -- ADD -- 2008/05/15 END   (1.10)

' -- ADD -- 2009/01/28 START (1.11)
Public Const pc_strIni_RETRY_TIMESTAMP      As String = "RETRY_TIMESTAMP"
Public gvintRETRY_TIMESTAMP                 As Integer                  '//タイムスタンプ名前変更RETRY回数
' -- ADD -- 2009/01/28 END   (1.11)

'//*****************************************************************************************
'//*
'//* <名  称>
'//*    Main
'//*
'//* <戻り値>
'//*
'//* <引  数>     項目名                  I/O           内容
'//*
'//* <説  明>
'//*    システム起動時の実行プロシジャー
'//*****************************************************************************************
Sub Main()
    
    On Error GoTo ONERR_STEP
    
    '//共通オブジェクトのインスタンス作成
    If Not Ctr_Object(True) Then
'        GoTo EXIT_STEP     2007.10.26
        GoTo EXIT_STEP2
    End If

    '//プログラム２重起動チェック
    If Not D0.ChkDuplicateInstance(gvcstJOB_Titl) Then
        If gvcstDspMsg Then
            MsgBox "【" & Trim(gvcstJOB_Titl) & "】は既に起動中です。重複して起動する事はできません。", _
                                                            vbExclamation Or vbOKOnly, gvcstJOB_Titl
        End If
        AppActivate gvcstJOB_Titl
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If
    
    '//パラメータの取得
    If Not Get_CommandLine() Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If
    
    '//固有パラメータの取得
    If Not Get_CommandLineByPosition(2, gvstrJOBID) Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If
        
    '//起動ストアド名の生成
    gvstrPLSQLPACKAGE = Mid(gvstrJOBID, 1, 7)
    gvstrPLSQLFUNCTION = Mid(gvstrJOBID, 1, 7) & "B"
    
    '//ステータスファイルに異常終了を書込み
    Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_Status.TXT", "NG", True)
    
    '//ＩＮＩファイルの取得(共通)
    If Not GetIniFile(gvINIInformation) Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If

    '//ＩＮＩファイルの取得(個別)
    If Not GetIndividualIniFile() Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If

    '//データベース接続(ORACLEｻｰﾊﾞｰ)
    If Not clsOra.OraConnect(gvINIInformation.strSQLDATABASE, _
                                    gvINIInformation.strSQLUID, gvINIInformation.strSQLPWD, gvcstDspMsg) Then
'        GoTo EXIT_STEP    2007.10.26
        GoTo EXIT_STEP2
    End If

    '//メッセージクラスへOraDatabaseプロパティをセットする
    ClsMessage.OraDatabase = clsOra.OraDatabase
    
' -- UPD -- 2007/10/26 START --------------------------
' -- ADD -- 2007/02/08 START
    '//排他制御ＯＮ
'   Call Ctr_HaitaOn
    If Not Ctr_HaitaOn() Then
        GoTo EXIT_STEP2
    End If
' -- ADD -- 2007/02/08 END
' -- UPD -- 2007/10/26 END ----------------------------
    
    '//ストアド起動処理
    If Not Ctr_StoredProcedure Then
        GoTo EXIT_STEP
    End If

    '//ステータスファイルに正常終了を書込み
    Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_Status.TXT", "OK", True)
    
'----------------------------------------------------------------------------------------
EXIT_STEP:
''''    '//共通オブジェクトの解放
''''    Call Ctr_Object(False)
    
' -- ADD -- 2007/02/08 START
    '//排他制御ＯＦＦ
    Call Ctr_HaitaOff
' -- ADD -- 2007/02/08 END

' -- ADD -- 2007/10/26 START
EXIT_STEP2:
' -- ADD -- 2007/10/26 END
    '//終了処理
    Call Ctr_END
    
    On Error GoTo 0
    
    End
    
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        MsgBox "<Sub_Main> " & vbCrLf & "実行時エラーです。処理を中止します。" _
                            & vbCrLf & Err.Description, _
                            vbOKOnly + vbCritical, App.Title
    End If
    Resume EXIT_STEP

End Sub

'//*****************************************************************************************
'//*
'//* <名  称>
'//*    Ctr_END
'//*
'//* <戻り値>     型          説明
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*
'//* <説  明>
'//*    プログラムの終了処理
'//*****************************************************************************************
Public Sub Ctr_END()

    '//データベース接続解除(ORACLEｻｰﾊﾞｰ)
    Call clsOra.OraDisConnect
    '//共通オブジェクトの解放
    Call Ctr_Object(False)
    '//プログラム終了
    End

End Sub

'//*****************************************************************************************
'//*
'//* <名  称>
'//*    Ctr_Object
'//*
'//* <戻り値>     型          説明
'//*              Boolean     True    :設定できた
'//*                          False   :設定できなかった
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*              pmf_Set          Boolean          I             True:作成 False:解放
'//* <説  明>
'//*    オブジェクトインスタンスの作成／解放
'//*****************************************************************************************
Function Ctr_Object(ByRef pmf_Set As Boolean) As Boolean

    Const PROCEDURE         As String = "Ctr_Object"
    
    On Error GoTo ONERR_STEP
    
    Ctr_Object = False
    
    If pmf_Set Then
        '//共通オブジェクトのインスタンス作成
        Set D0 = New ClsComn                                '//共通ｸﾗｽ
        Set clsOra = New ClsOraDB                           '//Oracle
        Set ClsMessage = New ClsMessage                     '//Message
    Else
        '//共通オブジェクトのインスタンス解放
        If Not (ClsMessage Is Nothing) Then                 '//Message
            Set ClsMessage = Nothing
        End If
        If Not (clsOra Is Nothing) Then                     '//Oracle
            Set clsOra = Nothing
        End If
        If Not (D0 Is Nothing) Then                         '//共通ｸﾗｽ
            Set D0 = Nothing
        End If
    End If
    
    Ctr_Object = True
    
'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP
    
End Function

'//*****************************************************************************************
'//*
'//* <名  称>
'//*    GetIndividualIniFile
'//*
'//* <戻り値>
'//*              True    :読込みＯＫ
'//*              False   :読込みＥＲＲ
'//*
'//* <引  数>     項目名             I/O      内容
'//*
'//* <説  明>
'//*    システム共通初期設定ファイル(INIﾌｧｲﾙ)の読込み処理
'//*****************************************************************************************
Public Function GetIndividualIniFile() As Boolean
    
    Const PROCEDURE         As String = "GetIndividualIniFile"
    
    '//INIﾌｧｲﾙ取得ｷｰ
    Const cstInFileCountKey As String = "INFILECOUNT"
    Const cstOtFileCountKey As String = "OTFILECOUNT"
    Const cstInFilePathKey  As String = "INFILEPATH"
    Const cstOtFilePathKey  As String = "OTFILEPATH"
    Const cstInFileNAMEKey  As String = "INFILENAME"
    Const cstOtFileNAMEKey  As String = "OTFILENAME"
    Const cstInFileCopyKey  As String = "INFILECPNM"
    Const cstOtFileTimeKey  As String = "OTFILETMSP"
    Const cstPARAMETERKey   As String = "PARAMETER"
    
    Dim wk_String                       As String
    Dim str_Key                         As String
    Dim str_Path                        As String
    Dim int_Idx                         As Integer
    Dim i                               As Integer
    
' -- ADD -- 2007/02/08 START
    Dim intRet      As Integer
    Dim strWK       As String
' -- ADD -- 2007/02/08 END
    
    On Error GoTo ONERR_STEP
    
    GetIndividualIniFile = False
    
    '実PATH取得
    str_Path = GetFullPath(gvcst_IniFilePath)
    
    '//-------------------------------------------------------------
    '//追加パラメータ取得
    '//-------------------------------------------------------------
    ReDim gvaryPARAMETER(0)
    i = 0
    Do
        i = i + 1
        wk_String = D0.GetIniString(gvstrJOBID, cstPARAMETERKey & CStr(i), str_Path)
        If Trim(wk_String) = "" Then
            Exit Do
        End If
        ReDim Preserve gvaryPARAMETER(i)
        gvaryPARAMETER(i) = Trim(wk_String)
    Loop
    
    '//-------------------------------------------------------------
    '//IN ﾌｧｲﾙ情報取得
    '//-------------------------------------------------------------
    wk_String = D0.GetIniString(gvstrJOBID, cstInFileCountKey, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    gvintInFileCount = Val(wk_String)
    
    ReDim gvaryInFileInfo(gvintInFileCount)
    For i = 1 To gvintInFileCount
    
        '//--ファイルパス 取得--
        str_Key = cstInFilePathKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        gvaryInFileInfo(i).strFilePath = wk_String
    
        '//--ファイル名   取得--
        str_Key = cstInFileNAMEKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        
        int_Idx = InStr(1, wk_String, ".")
        gvaryInFileInfo(i).strFileName1 = Mid(wk_String, 1, int_Idx - 1)
        gvaryInFileInfo(i).strFileExtn1 = Mid(wk_String, int_Idx)
    
        '//--前回ファイル名   取得--
        str_Key = cstInFileCopyKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            gvaryInFileInfo(i).strFileName2 = ""
            gvaryInFileInfo(i).strFileExtn2 = ""
        Else
            int_Idx = InStr(1, wk_String, ".")
            gvaryInFileInfo(i).strFileName2 = Mid(wk_String, 1, int_Idx - 1)
            gvaryInFileInfo(i).strFileExtn2 = Mid(wk_String, int_Idx)
        End If
    
    Next i
    
    '//-------------------------------------------------------------
    '//OUTﾌｧｲﾙ情報取得
    '//-------------------------------------------------------------
    wk_String = D0.GetIniString(gvstrJOBID, cstOtFileCountKey, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    gvintOtFileCount = Val(wk_String)
    
    ReDim gvaryOtFileInfo(gvintOtFileCount)
    For i = 1 To gvintOtFileCount
    
        '//--ファイルパス 取得--
        str_Key = cstOtFilePathKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        gvaryOtFileInfo(i).strFilePath = wk_String
    
        '//--ファイル名   取得--
        str_Key = cstOtFileNAMEKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
    
        int_Idx = InStr(1, wk_String, ".")
        gvaryOtFileInfo(i).strFileName1 = Mid(wk_String, 1, int_Idx - 1)
        gvaryOtFileInfo(i).strFileExtn1 = Mid(wk_String, int_Idx)
    
        '//--タイムスタンプ付加フラグ 取得 (0:付加しない 1:付加する) --
        str_Key = cstOtFileTimeKey & CStr(i)
        wk_String = D0.GetIniString(gvstrJOBID, str_Key, str_Path)
        If Trim(wk_String) = "" Then
            GoTo ERROR_STEP
        End If
        
        gvaryOtFileInfo(i).strFileTimeStampAddFlg = wk_String
    
    Next i
    
' -- ADD -- 2007/02/08 START
    '//-------------------------------------------------------------
    '//各プログラムに対応したリトライ情報を取得する
    '//-------------------------------------------------------------
    'リトライ間隔
    pv_curRETRY_INTERVAL = 1000
    wk_String = D0.GetIniString(gvstrJOBID, pc_strIni_RETRY_INTERVAL, str_Path)
    strWK = wk_String
    If IsNumeric(strWK) = True Then
        pv_curRETRY_INTERVAL = CCur(strWK)
    End If
    
    'リトライ回数
    pv_curRETRY_TIMES = 5
    wk_String = D0.GetIniString(gvstrJOBID, pc_strIni_RETRY_TIMES, str_Path)
    strWK = wk_String
    If IsNumeric(strWK) = True Then
        pv_curRETRY_TIMES = CCur(strWK)
    End If
    '//-------------------------------------------------------------
    '//排他制御用のINI取得
    '//-------------------------------------------------------------
    'ログファイルパス
    wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_LOGPATH, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    pv_strLOG_PATH = wk_String
    
    'ログファイル名
    wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_LOGNAME, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    pv_strLOG_NAME = wk_String

' -- ADD -- 2007/02/08 END
    
' -- ADD -- 2009/01/28 START (1.11)
    '//-------------------------------------------------------------
    '//タイムスタンプの名前変更処理のRETRY回数の取得
    '//-------------------------------------------------------------
    'RETRY回数
    wk_String = D0.GetIniString(gvcstJOB_ID, pc_strIni_RETRY_TIMESTAMP, str_Path)
    If Trim(wk_String) = "" Then
        GoTo ERROR_STEP
    End If
    If IsNumeric(wk_String) = True Then
        gvintRETRY_TIMESTAMP = CInt(wk_String)
    End If
' -- ADD -- 2009/01/28 END   (1.11)
    
    GetIndividualIniFile = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ERROR_STEP:
    If gvcstDspMsg Then
        MsgBox "【" & Trim(gvcstJOB_Titl) & "】はＩＮＩファイルの取得に失敗しました。処理を中止します。", _
                                                        vbExclamation Or vbOKOnly, App.Title
    End If
    GoTo EXIT_STEP
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP
End Function

'//*****************************************************************************************
'//*
'//* <名  称>
'//*    Ctr_StoredProcedure
'//*
'//* <戻り値>   型                  説明
'//*            Boolean             True:OK , False:Error
'//*
'//* <引  数>   項目名              型              I/O     内容
'//*
'//* <説  明>
'//*    ストアド処理の起動
'//*****************************************************************************************
Public Function Ctr_StoredProcedure() As Boolean

    Const PROCEDURE         As String = "Ctr_StoredProcedure"
    
    Dim i                   As Integer
    Dim vntArray            As Variant
    Dim strNewTimeStamp     As String
    Dim strOldTimeStamp     As String
    Dim strNewFileName      As String
    Dim strOldFileName      As String
    Dim strFrFileName       As String
    Dim strToFileName       As String
    Dim strZnFileName       As String
    Dim int_LoopCnt         As Integer
    Dim int_LoopMax         As Integer
    
    On Error Resume Next
    Kill GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_DelLst.TXT"
    On Error GoTo 0
    
    On Error GoTo ONERR_STEP
    
    Ctr_StoredProcedure = False

    int_LoopMax = 1
    int_LoopCnt = 1
    
' -- ADD -- 2008/05/15 START (1.10)
    gvstrPLSqlWkFileName = gvstrJOBID & "_WK"
' -- ADD -- 2008/05/15 END   (1.10)
    
    '// IN ﾌｧｲﾙ一覧を取得
    ReDim gvaryInGetFile(0)
    For i = 1 To gvintInFileCount
        ReDim Preserve gvaryInGetFile(i)
        Call Get_FileList(gvaryInFileInfo(i).strFilePath, _
                          gvaryInFileInfo(i).strFileName1 & "*" & gvaryInFileInfo(i).strFileExtn1, _
                          vntArray, int_LoopMax)
        gvaryInGetFile(i).strFileName = vntArray
    Next i

    '// IN ﾌｧｲﾙ一覧の配列の次元をあわせる
    For i = 1 To gvintInFileCount
        ReDim Preserve gvaryInGetFile(i).strFileName(int_LoopMax)
    Next i

    '//ストアド起動
    Do Until int_LoopCnt > int_LoopMax
        
        '// タイムスタンプ取得
        Do
            strNewTimeStamp = clsOra.OraGetNowDt(1) & clsOra.OraGetNowTm
            If strOldTimeStamp <> strNewTimeStamp Then
                Exit Do
            End If
            D0.Ctr_WaitTime (1)
        Loop
        strOldTimeStamp = strNewTimeStamp
        
        '// OUTﾌｧｲﾙ一覧を生成
        ReDim gvaryOtGetFile(0)
        For i = 1 To gvintOtFileCount
            ReDim Preserve gvaryOtGetFile(i)
            ReDim Preserve gvaryOtGetFile(i).strFileName(1)
            '// ﾀｲﾑｽﾀﾝﾌﾟ付加判定
            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
                gvaryOtGetFile(i).strFileName(1) = gvaryOtFileInfo(i).strFileName1 & _
                                    strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
            Else
                gvaryOtGetFile(i).strFileName(1) = gvaryOtFileInfo(i).strFileName1 & _
                                                      gvaryOtFileInfo(i).strFileExtn1
            End If
        Next i
        
' -- ADD -- 2007/01/14 START
        '// 送信ファイルのバックアップと送信ファイルの名前を変更
        On Error Resume Next
        For i = 1 To gvintOtFileCount
            '//名前変更
            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) <> 1 Then
' -- UPD -- 2008/05/15 START (1.10)
'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                             "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
                             gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
' -- UPD -- 2008/05/15 END   (1.10)
                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
                                    gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
                If Dir(strOldFileName) <> "" Then
                    Kill strOldFileName
                End If
                If Dir(strNewFileName) <> "" Then
' -- UPD -- 2009/10/15 START (1.20)
'                    Name strNewFileName As strOldFileName
                    '//コピー処理
                    Call CopyFile(strNewFileName, strOldFileName, 0)
' -- UPD -- 2009/10/15 END   (1.20)
                End If
            End If
        Next i
        On Error GoTo 0
        On Error GoTo ONERR_STEP
' -- ADD -- 2007/01/14 END
        
        '// ストアド処理の実行処理
        If Not RunStoredProcedure(int_LoopCnt) Then
            GoTo EXIT_STEP
        End If
        
' -- UPD -- 2009/01/28 START (1.11)
' -- UPD -- 2006/12/15 START
        '// 送信ファイルのバックアップと送信ファイルの名前を変更
        If Not Snd_FileCopy(strNewTimeStamp) Then
            GoTo EXIT_STEP
        End If

'        '// 送信ファイルのバックアップと送信ファイルの名前を変更
'        On Error Resume Next
'        For i = 1 To gvintOtFileCount
'
'            '//バックアップ
'            If UCase(Right(gvaryOtFileInfo(i).strFilePath, 3)) <> "TMP" Then
'                '// ﾀｲﾑｽﾀﾝﾌﾟ付加判定
'                If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
'                    strFrFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                 "WK" & gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                    strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & _
'                                        gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                Else
'                    strFrFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                 "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
'                    strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\SND\" & _
'                                        gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                End If
'                FileCopy strFrFileName, strToFileName
'            End If
'
'            '//名前変更
'            '// ﾀｲﾑｽﾀﾝﾌﾟ付加判定
'            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                             "WK" & gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                    gvaryOtFileInfo(i).strFileName1 & strNewTimeStamp & gvaryOtFileInfo(i).strFileExtn1
'            Else
'                strOldFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                             "WK" & gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
'                strNewFileName = gvaryOtFileInfo(i).strFilePath & "\" & _
'                                    gvaryOtFileInfo(i).strFileName1 & gvaryOtFileInfo(i).strFileExtn1
'            End If
'            If Dir(strNewFileName) <> "" Then
'                Kill strNewFileName
'            End If
'            Name strOldFileName As strNewFileName
'
'        Next i
'        On Error GoTo 0
' -- UPD -- 2006/12/15 END
' -- UPD -- 2009/01/28 END   (1.11)
        
        '// 受信ファイルのバックアップと削除リストを作成
        On Error GoTo ONERR_STEP
        For i = 1 To gvintInFileCount
            
            If Not IsEmpty(gvaryInGetFile(i).strFileName(int_LoopCnt)) Then
                '//バックアップ
                strFrFileName = gvaryInFileInfo(i).strFilePath & "\" & gvaryInGetFile(i).strFileName(int_LoopCnt)
' -- UPD -- 2006/12/15 START
'                strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\RCV\" & gvaryInGetFile(i).strFileName(int_LoopCnt)
                strToFileName = GetFullPath(gvcst_BakFilePath) & "\DAT\RCV\" & _
                                    AddTimeStampFileName(gvaryInGetFile(i).strFileName(int_LoopCnt))
' -- UPD -- 2006/12/15 END
                If UCase(Right(gvaryInFileInfo(i).strFilePath, 3)) <> "TMP" Then
                    FileCopy strFrFileName, strToFileName
                End If
    
                If gvaryInFileInfo(i).strFileName2 = "" Then
                    If UCase(Right(gvaryInFileInfo(i).strFileName1, 3)) <> "ZEN" Then
                        '//ファイル削除
                        Kill strFrFileName
                    End If
                Else
                    '//前回分へ保存
                    strZnFileName = Replace(UCase(strFrFileName), UCase(gvaryInFileInfo(i).strFileName1), UCase(gvaryInFileInfo(i).strFileName2))
                    strZnFileName = Replace(UCase(strZnFileName), UCase(gvaryInFileInfo(i).strFileExtn1), UCase(gvaryInFileInfo(i).strFileExtn2))
                    If Dir(strZnFileName) <> "" Then
                        Kill strZnFileName
                    End If
                    Name strFrFileName As strZnFileName
                End If
                
                '//削除リスト作成
                If UCase(Right(gvaryInFileInfo(i).strFilePath, 3)) <> "TMP" Then
                    Call Put_TextFile(GetFullPath(gvcst_TmpFilePath) & "\" & gvstrJOBID & "_DelLst.TXT", gvaryInGetFile(i).strFileName(int_LoopCnt), False)
                End If
            End If
        
        Next i
    
        int_LoopCnt = int_LoopCnt + 1
    
    Loop
    
    Ctr_StoredProcedure = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP

End Function

' -- ADD -- 2008/05/15 START (1.10)
'//****************************************************************************************
'//*
'//* <名  称>
'//*    Snd_FileCopy
'//*
'//* <戻り値>     型          説明
'//*
'//* <引  数>     項目名             型              I/O           内容
'//*
'//* <説  明>
'//*    送信ファイルのバックアップと名前の変更を行う
'//****************************************************************************************
Function Snd_FileCopy(ByRef pstrNewTimeStamp As String) As Boolean

    Const PROCEDURE             As String = "Snd_FileCopy"
    
    Dim str_FromFileName        As String
    Dim str_BackToFileName      As String
    Dim str_SendToFileName      As String
    Dim dtaNewTimeStamp         As Date
    Dim i                       As Integer
    Dim intLoopCnt              As Integer

    On Error GoTo ONERR_STEP
            
    Snd_FileCopy = False
    
    For i = 1 To gvintOtFileCount
        '//バッチで作成されているファイル名を生成
        If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
            str_FromFileName _
                            = gvaryOtFileInfo(i).strFilePath _
                            & "\" _
                            & gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 _
                            & pstrNewTimeStamp _
                            & gvaryOtFileInfo(i).strFileExtn1
        Else
            str_FromFileName _
                            = gvaryOtFileInfo(i).strFilePath _
                            & "\" _
                            & gvstrPLSqlWkFileName & gvaryOtFileInfo(i).strFileName1 _
                            & gvaryOtFileInfo(i).strFileExtn1
        End If
    
        '//-------------- 送信        フォルダのファイル処理 ---------------
        
        dtaNewTimeStamp = Format(pstrNewTimeStamp, "0000/00/00 00:00:00")
    
        '// コピー処理
        intLoopCnt = 0
        Do
            '//処理対象のファイルが存在しない場合はループを抜ける
            If Dir(str_FromFileName) = "" Then
                Exit Do
            End If
            
            '//ループ異常終了(99回ループしても駄目だったら終了する)
' -- UPD -- 2009/01/28 START (1.11)
'            intLoopCnt = intLoopCnt + 1
'            If intLoopCnt > 99 Then
'                Call F_Edit_ErrLog(0, "９９回リトライしましたが、ファイルコピーができませんでした。", "Snd_FileCopy")
'                GoTo EXIT_STEP
'            End If
            If intLoopCnt > gvintRETRY_TIMESTAMP Then
                Call F_Edit_ErrLog(0, CStr(gvintRETRY_TIMESTAMP) & " 回リトライしましたが、ファイルコピーができませんでした。【送信フォルダ処理】" & str_FromFileName, "Snd_FileCopy")
                GoTo EXIT_STEP
            End If
            intLoopCnt = intLoopCnt + 1
' -- UPD -- 2009/01/28 END   (1.11)
            
            '//送信ファイルコピー
            If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
                
                '//フォルダへ置くファイル名の生成
                str_SendToFileName _
                                = gvaryOtFileInfo(i).strFilePath _
                                & "\" _
                                & gvaryOtFileInfo(i).strFileName1 _
                                & Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") _
                                & gvaryOtFileInfo(i).strFileExtn1
                
                '//コピー処理
                If CopyFile(str_FromFileName, str_SendToFileName, 1) <> 0 Then
                    '//コピーが正常に行われた（コピー先のファイルが存在していないモード）
                    Exit Do
                End If
            
            Else
                
                '//フォルダへ置くファイル名の生成
                str_SendToFileName _
                                = gvaryOtFileInfo(i).strFilePath _
                                & "\" _
                                & gvaryOtFileInfo(i).strFileName1 _
                                & gvaryOtFileInfo(i).strFileExtn1
                
' -- UPD -- 2009/10/15 START (1.20)
'                '//コピー処理
'                If CopyFile(str_FromFileName, str_SendToFileName, 1) <> 0 Then
'                    '//コピーが正常に行われた（コピー先のファイルが存在していないモード）
'                    Exit Do
'                End If
'                '//コピーが正常に行われなかった。
'                Call F_Edit_ErrLog(0, "既にファイルが存在するため、ファイルコピーができませんでした。", "Snd_FileCopy")
'                GoTo EXIT_STEP
                '//コピー処理
                If CopyFile(str_FromFileName, str_SendToFileName, 0) <> 0 Then
                    '//コピーが正常に行われた（同一ファイルがあるとき上書きするモード）
                    Exit Do
                End If
                '//コピーが正常に行われなかった。
                Call F_Edit_ErrLog(0, "ファイルコピーができませんでした。", "Snd_FileCopy")
                GoTo EXIT_STEP
' -- UPD -- 2009/10/15 END   (1.20)
            
            End If
        
            '// コピーが正常にできないためタイムスタンプに１加算
            dtaNewTimeStamp = DateAdd("s", 1, dtaNewTimeStamp)
        Loop
    
        '//-------------- バックアップフォルダのファイル処理 ---------------
        
        '// ※バックアップフォルダにファイルをコピーする場合は、
        '//   タイムスタンプ付加区分の有無に関わらずタイムスタンプをつける。
        
        '//バックアップ
        If UCase(Right(gvaryOtFileInfo(i).strFilePath, 3)) <> "TMP" Then
        
            dtaNewTimeStamp = Format(pstrNewTimeStamp, "0000/00/00 00:00:00")
        
            '// コピー処理
            intLoopCnt = 0
            Do
                '//処理対象のファイルが存在しない場合はループを抜ける
                If Dir(str_FromFileName) = "" Then
                    Exit Do
                End If
                
                '//ループ異常終了(99回ループしても駄目だったら終了する)
' -- UPD -- 2009/01/28 START (1.11)
'                intLoopCnt = intLoopCnt + 1
'                If intLoopCnt > 99 Then
'                    Call F_Edit_ErrLog(0, "９９回リトライしましたが、ファイルコピーができませんでした。", "Snd_FileCopy")
'                    GoTo EXIT_STEP
'                End If
                If intLoopCnt > gvintRETRY_TIMESTAMP Then
                    Call F_Edit_ErrLog(0, CStr(gvintRETRY_TIMESTAMP) & " 回リトライしましたが、ファイルコピーができませんでした。【送信フォルダ（バックアップ）処理】" & str_FromFileName, "Snd_FileCopy")
                    GoTo EXIT_STEP
                End If
                intLoopCnt = intLoopCnt + 1
' -- UPD -- 2009/01/28 END   (1.11)
                
                '//送信ファイルコピー
                If Val(gvaryOtFileInfo(i).strFileTimeStampAddFlg) = 1 Then
                    
                    '//フォルダへ置くファイル名の生成
                    str_BackToFileName _
                                    = GetFullPath(gvcst_BakFilePath) _
                                    & "\DAT\SND\" _
                                    & gvaryOtFileInfo(i).strFileName1 _
                                    & Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") _
                                    & gvaryOtFileInfo(i).strFileExtn1
                Else
                    
                    '//フォルダへ置くファイル名の生成
                    str_BackToFileName _
                                    = GetFullPath(gvcst_BakFilePath) _
                                    & "\DAT\SND\" _
                                    & gvaryOtFileInfo(i).strFileName1 _
                                    & Format(dtaNewTimeStamp, "YYYYMMDDHHMMSS") _
                                    & gvaryOtFileInfo(i).strFileExtn1
                
                End If
            
                '//バックアップフォルダのファイル処理
                If CopyFile(str_FromFileName, str_BackToFileName, 1) <> 0 Then
                    '//コピーが正常に行われた（コピー先のファイルが存在していないモード）
                    Exit Do
                End If
    
                '// コピーが正常にできないためタイムスタンプに１加算
                dtaNewTimeStamp = DateAdd("s", 1, dtaNewTimeStamp)
            Loop
    
        End If
        
        '//バッチで作成されているファイルを削除
        If Dir(str_FromFileName) <> "" Then
            Kill str_FromFileName
        End If
    
    Next i
    
    Snd_FileCopy = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP

End Function
' -- ADD -- 2008/05/15 END   (1.10)

'//*****************************************************************************************
'//*
'//* <名  称>
'//*    Get_FileList
'//*
'//* <戻り値>   型                  説明
'//*            Boolean             True:OK , False:Error
'//*
'//* <引  数>   項目名              型              I/O     内容
'//*
'//* <説  明>
'//*    指定されたフォルダーのファイル一覧を返す（指定された条件で）
'//*****************************************************************************************
Public Function Get_FileList(ByVal pmsGetFilePath As String, ByVal pmsGetFileName As String, _
                             ByRef pmvArray As Variant, ByRef pmiLoopMax As Integer) As Boolean

    Const PROCEDURE         As String = "Get_FileList"
    
    Dim i                   As Integer
    Dim strFileNmae         As String
    
    On Error GoTo ONERR_STEP
    
    Get_FileList = False

    i = 0
    ReDim pmvArray(i)

    strFileNmae = Dir(pmsGetFilePath & "\" & pmsGetFileName, vbNormal)      ' 最初のフォルダ名を返します。
    Do While strFileNmae <> ""                                              ' ループを開始します。

        i = i + 1
        ReDim Preserve pmvArray(i)

        pmvArray(i) = strFileNmae                                           ' ファイル名の格納

        strFileNmae = Dir                                                   ' 次のファイル名を返します。
    Loop
    
    If pmiLoopMax <= i Then
        pmiLoopMax = i
    End If
        
' -- ADD -- 2008/05/14 START (1.10)
    Dim int_i       As Integer
    Dim int_j       As Integer
    Dim vnt_Work    As Variant

    For int_i = 1 To UBound(pmvArray)
        For int_j = int_i + 1 To UBound(pmvArray)
            If pmvArray(int_i) >= pmvArray(int_j) Then
                vnt_Work = pmvArray(int_i)
                pmvArray(int_i) = pmvArray(int_j)
                pmvArray(int_j) = vnt_Work
            End If
        Next int_j
    Next int_i
' -- ADD -- 2008/05/14 END   (1.10)

    Get_FileList = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP

End Function

'//*****************************************************************************************
'//*
'//* <名  称>
'//*    RunStoredProcedure
'//*
'//* <戻り値>   型                  説明
'//*            Boolean             True:OK , False:Error
'//*
'//* <引  数>   項目名              型              I/O     内容
'//*
'//* <説  明>
'//*    ストアド処理の実行処理
'//*****************************************************************************************
Public Function RunStoredProcedure(ByVal pmiIndex As Integer) As Boolean

    Const PROCEDURE         As String = "RunStoredProcedure"

    Dim i            As Integer
    Dim intRtnCd     As Integer     '戻り値
    Dim strEXECUTE   As String

    RunStoredProcedure = False

    On Error GoTo ONERR_STEP

'// ﾄﾗﾝｻﾞｸｼｮﾝ制御は、オラクル側で実施するのでコメントにする
''''    '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
''''    clsOra.OraBeginTrans

    '//PL/SQLを呼ぶ（前処理）
    
    '// -- ﾊﾟﾗﾒｰﾀのｸﾘｱ --
    clsOra.OraDatabase.Parameters.Remove "RTNCD"
    clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
    clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
    For i = 1 To UBound(gvaryPARAMETER)
        clsOra.OraDatabase.Parameters.Remove "PARA_ADDPARA" & CStr(i)
    Next i
    For i = 1 To gvintInFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
    Next i
    For i = 1 To gvintOtFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
    Next i

    '// -- ﾊﾟﾗﾒｰﾀの設定 --
    
    '//ログインユーザーＩＤ
    clsOra.OraDatabase.Parameters.Add "PARA_OPEID", gvstrOPEID, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters("PARA_OPEID").serverType = ORATYPE_CHAR

    '//端末番号
    clsOra.OraDatabase.Parameters.Add "PARA_CLTID", gvstrCLTID, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters("PARA_CLTID").serverType = ORATYPE_CHAR
        
    '//追加パラメータ
    For i = 1 To UBound(gvaryPARAMETER)
        clsOra.OraDatabase.Parameters.Add "PARA_ADDPARA" & CStr(i), gvaryPARAMETER(i), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_ADDPARA" & CStr(i)).serverType = ORATYPE_CHAR
    Next i
    
    '//IN ファイルパス・ファイル名
    For i = 1 To gvintInFileCount
        clsOra.OraDatabase.Parameters.Add "PARA_INPATH" & CStr(i), D0.Chk_Null(gvaryInFileInfo(i).strFilePath), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_INPATH" & CStr(i)).serverType = ORATYPE_VARCHAR2
        clsOra.OraDatabase.Parameters.Add "PARA_INFILE" & CStr(i), D0.Chk_Null(gvaryInGetFile(i).strFileName(pmiIndex)), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_INFILE" & CStr(i)).serverType = ORATYPE_VARCHAR2
    Next i
    
    '//OUTファイルパス・ファイル名
    For i = 1 To gvintOtFileCount
        clsOra.OraDatabase.Parameters.Add "PARA_OTPATH" & CStr(i), D0.Chk_Null(gvaryOtFileInfo(i).strFilePath), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters("PARA_OTPATH" & CStr(i)).serverType = ORATYPE_VARCHAR2
' -- UPD -- 2008/05/15 START (1.10)
'        clsOra.OraDatabase.Parameters.Add "PARA_OTFILE" & CStr(i), "WK" & D0.Chk_Null(gvaryOtGetFile(i).strFileName(1)), ORAPARM_INPUT
        clsOra.OraDatabase.Parameters.Add "PARA_OTFILE" & CStr(i), gvstrPLSqlWkFileName & D0.Chk_Null(gvaryOtGetFile(i).strFileName(1)), ORAPARM_INPUT
' -- UPD -- 2008/05/15 END   (1.10)
        clsOra.OraDatabase.Parameters("PARA_OTFILE" & CStr(i)).serverType = ORATYPE_VARCHAR2
    Next i
    
    '//戻り値
    intRtnCd = 0
    clsOra.OraDatabase.Parameters.Add "RTNCD", intRtnCd, ORAPARM_OUTPUT
    clsOra.OraDatabase.Parameters("RTNCD").serverType = ORATYPE_NUMBER

    '//PL/SQLを呼ぶ（MAIN）
    strEXECUTE = ""
    strEXECUTE = strEXECUTE & "BEGIN"
    strEXECUTE = strEXECUTE & ":RTNCD := " & gvstrPLSQLPACKAGE & "." & gvstrPLSQLFUNCTION & "("
    strEXECUTE = strEXECUTE & " :PARA_OPEID"
    strEXECUTE = strEXECUTE & ",:PARA_CLTID"
    For i = 1 To UBound(gvaryPARAMETER)
        strEXECUTE = strEXECUTE & ",:PARA_ADDPARA" & CStr(i)
    Next i
    For i = 1 To gvintInFileCount
        strEXECUTE = strEXECUTE & ",:PARA_INPATH" & CStr(i)
        strEXECUTE = strEXECUTE & ",:PARA_INFILE" & CStr(i)
    Next i
    For i = 1 To gvintOtFileCount
        strEXECUTE = strEXECUTE & ",:PARA_OTPATH" & CStr(i)
        strEXECUTE = strEXECUTE & ",:PARA_OTFILE" & CStr(i)
    Next i
    strEXECUTE = strEXECUTE & ");"
    strEXECUTE = strEXECUTE & "END;"
        
    If Not clsOra.OraExecute(strEXECUTE, , PROCEDURE, gvcstDspMsg) Then
        '//ﾊﾟﾗﾒｰﾀのｸﾘｱ
        clsOra.OraDatabase.Parameters.Remove "RTNCD"
        clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
        clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
        For i = 1 To gvintInFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
        Next i
        For i = 1 To gvintOtFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
        Next i
        GoTo EXIT_STEP
    End If
    
    '//戻り値確認
    If clsOra.OraDatabase.Parameters("RTNCD").Value <> 0 Then
        '//(異常)
        '//ﾊﾟﾗﾒｰﾀのｸﾘｱ
        clsOra.OraDatabase.Parameters.Remove "RTNCD"
        clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
        clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
        For i = 1 To UBound(gvaryPARAMETER)
            clsOra.OraDatabase.Parameters.Remove "PARA_ADDPARA" & CStr(i)
        Next i
        For i = 1 To gvintInFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
        Next i
        For i = 1 To gvintOtFileCount
            clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
            clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
        Next i
'// ﾄﾗﾝｻﾞｸｼｮﾝ制御は、オラクル側で実施するのでコメントにする
''''        '//ﾄﾗﾝｻﾞｸｼｮﾝ(ﾛｰﾙﾊﾞｯｸ)
''''        clsOra.OraRollback
        GoTo EXIT_STEP
    End If
    
    '//PL/SQLを呼ぶ（後処理）
    '//ﾊﾟﾗﾒｰﾀのｸﾘｱ
    clsOra.OraDatabase.Parameters.Remove "RTNCD"
    clsOra.OraDatabase.Parameters.Remove "PARA_OPEID"
    clsOra.OraDatabase.Parameters.Remove "PARA_CLTID"
    For i = 1 To UBound(gvaryPARAMETER)
        clsOra.OraDatabase.Parameters.Remove "PARA_ADDPARA" & CStr(i)
    Next i
    For i = 1 To gvintInFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_INPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_INFILE" & CStr(i)
    Next i
    For i = 1 To gvintOtFileCount
        clsOra.OraDatabase.Parameters.Remove "PARA_OTPATH" & CStr(i)
        clsOra.OraDatabase.Parameters.Remove "PARA_OTFILE" & CStr(i)
    Next i

'// ﾄﾗﾝｻﾞｸｼｮﾝ制御は、オラクル側で実施するのでコメントにする
''''    '//ﾄﾗﾝｻﾞｸｼｮﾝ(ｺﾐｯﾄ)
''''    clsOra.OraCommitTrans

    RunStoredProcedure = True

'----------------------------------------------------------------------------------------
EXIT_STEP:
    On Error GoTo 0
    Exit Function
'----------------------------------------------------------------------------------------
ONERR_STEP:
    If gvcstDspMsg Then
        ClsMessage.RuntimeErrorMsg Err.Description, PROCEDURE
    End If
    Resume EXIT_STEP
    
End Function

' -- ADD -- 2006/12/15 START
'//*****************************************************************************************
'//*
'//* <名  称>
'//*    AddTimeStampFileName
'//*
'//* <戻り値>   型                  説明
'//*            String              タイムスタンプ付加されたファイル名
'//*
'//* <引  数>   項目名              型              I/O     内容
'//*            strFilePathName     String          I       ファイル名
'//*
'//* <説  明>
'//*    ファイル名にタイムスタンプを付加したファイル名を返す
'//*****************************************************************************************
Function AddTimeStampFileName(ByVal strFilePathName As String) As String

    Dim int_Idx                         As Integer
    Dim strFileName                     As String
    Dim strFileExtn                     As String
    
    'ファイル名にタイムスタンプを付加する為の判断文字数
    Const intLength As Integer = 19
    
    If Len(strFilePathName) <= intLength Then
        'ファイル名が設定文字以下なのでタイムスタンプを付加する
        int_Idx = InStr(1, strFilePathName, ".")
        strFileName = Mid(strFilePathName, 1, int_Idx - 1) & clsOra.OraGetNowDt(1) & clsOra.OraGetNowTm
        strFileExtn = Mid(strFilePathName, int_Idx)
    
        'ファイル名生成
        AddTimeStampFileName = strFileName & strFileExtn
    Else
        'ファイル名が設定文字より大きいのでタイムスタンプを付加する
        
        'ファイル名生成
        AddTimeStampFileName = strFilePathName
    End If

End Function
' -- ADD -- 2006/12/15 END

' -- ADD -- 2007/02/08 START
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function ctr_HaitaOn
'   概要：　排他制御処理
'   引数：　無し
'   戻値：　True : 正常 False : 異常
'   備考：  排他制御ＯＮ
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function Ctr_HaitaOn() As Boolean

    Dim strMsg          As String
    Dim IntCnt          As Integer
    
    Ctr_HaitaOn = False
    
    IntCnt = 0
    Do Until IntCnt > pv_curRETRY_TIMES
    
        IntCnt = IntCnt + 1
        
        '排他チェックを行う
        Select Case CF_Chk_Lock_EXCTBZ(strMsg)
            '正常
            Case 0
                Exit Do
                
            '排他処理中
            Case 1
                If IntCnt > pv_curRETRY_TIMES Then
                    'エラーログ出力
                    Call F_Edit_ErrLog(0, Trim(strMsg) & "が実行中のため処理を中止しました。", "Ctr_HaitaOn")
                    Exit Function
                Else
                    Sleep (pv_curRETRY_INTERVAL)
                End If
                
            '異常終了
            Case 9
                'エラーログ出力
                Call F_Edit_ErrLog(0, "業務排他処理にてＤＢエラーが発生しました。", "Ctr_HaitaOn")
                Exit Function
                
        End Select
    Loop

    Ctr_HaitaOn = True
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function Ctr_HaitaOff
'   概要：　排他制御処理
'   引数：　無し
'   戻値：　True : 正常 False : 異常
'   備考：  排他制御ＯＦＦ
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function Ctr_HaitaOff() As Boolean

    Dim strMsg          As String
    
    '排他処理解除
    Call CF_Unlock_EXCTBZ(strMsg)

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
    
    '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
    clsOra.OraBeginTrans
    bolTrn = True
    
    '排他制御
    intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
    If intRet <> 0 Then
        '排他エラー
        Pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    '//ﾄﾗﾝｻﾞｸｼｮﾝ(ｺﾐｯﾄ)
    clsOra.OraCommitTrans
    bolTrn = False
    
    CF_Chk_Lock_EXCTBZ = 0
    
    Exit Function
    
CF_Chk_Lock_EXCTBZ_Err:

    'ロールバック
    If bolTrn = True Then
        '//ﾄﾗﾝｻﾞｸｼｮﾝ(ﾛｰﾙﾊﾞｯｸ)
        clsOra.OraRollback
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
    
    '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
    clsOra.OraBeginTrans
    bolTrn = True
    
    '排他制御解除
    intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
    If intRet <> 0 Then
        '排他エラー
        Pot_strMsg = strMsg
        CF_Unlock_EXCTBZ = intRet
        GoTo CF_Unlock_EXCTBZ_Err
    End If
    
    '//ﾄﾗﾝｻﾞｸｼｮﾝ(ｺﾐｯﾄ)
    clsOra.OraCommitTrans
    bolTrn = False
    
    CF_Unlock_EXCTBZ = 0
    
    Exit Function
    
CF_Unlock_EXCTBZ_Err:

    'ロールバック
    If bolTrn = True Then
        '//ﾄﾗﾝｻﾞｸｼｮﾝ(ﾛｰﾙﾊﾞｯｸ)
        clsOra.OraRollback
    End If
    
End Function
' === 20061105 === INSERT E -

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
'    strPara1 = Inp_Inf.InpTanCd
'    strPara2 = SSS_CLTID
'    strPara3 = Pin_strPRCCASE
'    strPara4 = SSS_PrgId
'    lngPara5 = 0
'    lngPara6 = 0
'    strPara7 = ""
    strPara1 = gvstrOPEID
    strPara2 = gvstrCLTID
    strPara3 = Pin_strPRCCASE
    strPara4 = gvstrJOBID
    lngPara5 = 0
    lngPara6 = 0
    strPara7 = ""
    
    Pot_strMsg = ""

    'パラメータの初期設定を行う（バインド変数）
    clsOra.OraDatabase.Parameters.Add "P1", strPara1, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P2", strPara2, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P3", strPara3, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P4", strPara4, ORAPARM_INPUT
    clsOra.OraDatabase.Parameters.Add "P5", lngPara5, ORAPARM_OUTPUT
    clsOra.OraDatabase.Parameters.Add "P6", lngPara6, ORAPARM_OUTPUT
    clsOra.OraDatabase.Parameters.Add "P7", strPara7, ORAPARM_OUTPUT

    'データ型をオブジェクトにセット
    Set param(1) = clsOra.OraDatabase.Parameters("P1")
    Set param(2) = clsOra.OraDatabase.Parameters("P2")
    Set param(3) = clsOra.OraDatabase.Parameters("P3")
    Set param(4) = clsOra.OraDatabase.Parameters("P4")
    Set param(5) = clsOra.OraDatabase.Parameters("P5")
    Set param(6) = clsOra.OraDatabase.Parameters("P6")
    Set param(7) = clsOra.OraDatabase.Parameters("P7")

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
    If Not clsOra.OraExecute(strSQL, , "AE_Execute_PLSQL_EXCTBZ", gvcstDspMsg) Then
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
    clsOra.OraDatabase.Parameters.Remove "P1"
    clsOra.OraDatabase.Parameters.Remove "P2"
    clsOra.OraDatabase.Parameters.Remove "P3"
    clsOra.OraDatabase.Parameters.Remove "P4"
    clsOra.OraDatabase.Parameters.Remove "P5"
    clsOra.OraDatabase.Parameters.Remove "P6"
    clsOra.OraDatabase.Parameters.Remove "P7"
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function F_Edit_ErrLog
'   概要：  エラーログ出力処理
'   引数：  pin_intErrCd       : エラーコード（オラクルエラー時以外はゼロ）
'           pin_strErrMsg      : エラーメッセージ
'           pin_strErrLocation : 発生箇所（ファンクション名）
'   戻値：  0 : 正常 9 : 異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_Edit_ErrLog(ByVal pin_intErrCd As Integer, _
                               ByVal pin_strErrMsg As String, _
                               ByVal pin_strErrLocation As String) As Integer

    Dim intRet          As Integer
    Dim strTime         As String
    Dim strDate         As String
    
    F_Edit_ErrLog = 9
    
    strTime = ""
    strDate = ""
    
    'システム日付取得
    strDate = clsOra.OraGetNowDt(1)
    strTime = clsOra.OraGetNowTm()
    
    'エラーログ書き込み
    Call CF_Edit_ErrLog(pv_strLOG_PATH _
                      , pv_strLOG_NAME _
                      , gvstrJOBID _
                      , pin_intErrCd _
                      , pin_strErrMsg _
                      , pin_strErrLocation _
                      , strTime _
                      , strDate)
    
    F_Edit_ErrLog = 0

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

' -- ADD -- 2007/02/08 END


